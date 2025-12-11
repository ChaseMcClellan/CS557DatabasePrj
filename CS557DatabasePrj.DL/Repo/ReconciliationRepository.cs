using CS557DatabasePrj.BL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.DL.Repo
{
    public class ReconciliationRepository : BaseRepository
    {
        public async Task<ReconciliationResults> GetReportAsync(int year, int month, int branchId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("p_year", year, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_month", month, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_branch_id", branchId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_discrepancies_found", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using var conn = Open();

            using var multi = await conn.QueryMultipleAsync(
                "sp_monthly_account_reconciliation",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60);

            // Read the branch info (first result set)
            var branchInfo = await multi.ReadFirstOrDefaultAsync<BranchInfo>();
            if (branchInfo == null)
                return null;

            // Read the reconciliation records (second result set)
            var reconciliationRecords = (await multi.ReadAsync<ReconciliationRecord>()).ToList();

            // Read the summary (third result set)
            var summary = await multi.ReadFirstOrDefaultAsync<SummaryReport>();

            // Get the output parameter value
            var discrepanciesFound = parameters.Get<int>("p_discrepancies_found");

            return new ReconciliationResults
            {
                BranchInfo = branchInfo,
                ReconciliationReport = reconciliationRecords,
                Summary = summary ?? new SummaryReport(),
                DiscrepanciesFound = discrepanciesFound // Add this property in your ReconciliationResults class
            };
        }

    }
}