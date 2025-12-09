-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema bank_db
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema bank_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `bank_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `bank_db` ;

-- -----------------------------------------------------
-- Table `bank_db`.`branches`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`branches` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `AddressLine1` VARCHAR(45) NOT NULL,
  `AddressLine2` VARCHAR(45) NULL DEFAULT NULL,
  `City` VARCHAR(45) NOT NULL,
  `State` VARCHAR(45) NOT NULL,
  `PostalCode` VARCHAR(45) NOT NULL,
  `Phone` VARCHAR(45) NULL DEFAULT NULL,
  `UpdatedUtc` DATETIME NULL,
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `IsActive` TINYINT NULL,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`roles` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Description` VARCHAR(255) NULL DEFAULT NULL,
  `IsAdmin` TINYINT NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`users` (
  `Id` INT NOT NULL,
  `UserName` VARCHAR(100) NULL DEFAULT NULL,
  `FirstName` VARCHAR(45) NULL DEFAULT NULL,
  `LastName` VARCHAR(45) NULL DEFAULT NULL,
  `PassWordHash` VARCHAR(255) NOT NULL,
  `Email` VARCHAR(100) NULL DEFAULT NULL,
  `Phone` VARCHAR(45) NULL DEFAULT NULL,
  `SsnHash` VARCHAR(255) NULL DEFAULT NULL,
  `RoleId` INT NOT NULL,
  `HomeBranchId` INT NULL DEFAULT NULL,
`UpdatedUtc` DATETIME NULL,
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `IsActive` TINYINT NULL,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `UserBranch_idx` (`HomeBranchId` ASC) VISIBLE,
  INDEX `UserRole_idx` (`RoleId` ASC) VISIBLE,
  CONSTRAINT `UserBranch`
    FOREIGN KEY (`HomeBranchId`)
    REFERENCES `bank_db`.`branches` (`Id`),
  CONSTRAINT `UserRole`
    FOREIGN KEY (`RoleId`)
    REFERENCES `bank_db`.`roles` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`accounttypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`accounttypes` (
  `Id` INT NOT NULL,
  `Type` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`accounts` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `AccountNumber` VARCHAR(45) NOT NULL,
  `OwnerUserId` INT NOT NULL,
  `BranchId` INT NOT NULL,
  `CurrentBalance` DECIMAL(15,2) NOT NULL DEFAULT 0,
  `AccountType` INT NOT NULL,
  `Createdutc` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedUtc` DATETIME NULL,
  `CurrencyCode` VARCHAR(3) NOT NULL DEFAULT 'USD',
  `IsActive` TINYINT NULL,
  `UpdatedByUserId` INT NULL,
  `CreatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `AccountOwner_idx` (`OwnerUserId` ASC) VISIBLE,
  INDEX `AccountBranch_idx` (`BranchId` ASC) VISIBLE,
  INDEX `AccountType_idx` (`AccountType` ASC) VISIBLE,
  CONSTRAINT `AccountBranch`
    FOREIGN KEY (`BranchId`)
    REFERENCES `bank_db`.`branches` (`Id`),
  CONSTRAINT `AccountOwner`
    FOREIGN KEY (`OwnerUserId`)
    REFERENCES `bank_db`.`users` (`Id`),
  CONSTRAINT `AccountType`
    FOREIGN KEY (`AccountType`)
    REFERENCES `bank_db`.`accounttypes` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`cardtypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`cardtypes` (
  `Id` INT NOT NULL,
  `Type` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`cards`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`cards` (
  `Id` INT NOT NULL,
  `CardNumberMasked` VARCHAR(255) NOT NULL,
  `ExpiratationUtc`DATETIME NOT NULL,
  `CardHolderName` VARCHAR(91) NOT NULL,
  `AccountId` INT NOT NULL,
  `OwnerUserId` INT NOT NULL,
  `CardType` INT NOT NULL,
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `IsActive` TINYINT NULL,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `CardOwner_idx` (`OwnerUserId` ASC) VISIBLE,
  INDEX `CardAccount_idx` (`AccountId` ASC) VISIBLE,
  INDEX `CardCardType_idx` (`CardType` ASC) VISIBLE,
  CONSTRAINT `CardAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`),
  CONSTRAINT `CardCardType`
    FOREIGN KEY (`CardType`)
    REFERENCES `bank_db`.`cardtypes` (`Id`),
  CONSTRAINT `CardOwner`
    FOREIGN KEY (`OwnerUserId`)
    REFERENCES `bank_db`.`users` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`deposits`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`deposits` (
  `Id` INT NOT NULL,
  `AccountId` INT NOT NULL,
  `Source` VARCHAR(45) NOT NULL,
  `ReceivedUtc` DATETIME NULL DEFAULT NULL,
  `Amount` DECIMAL(14,2) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`),
  INDEX `DepositAccount_idx` (`AccountId` ASC) VISIBLE,
  CONSTRAINT `DepositAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`employees`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`employees` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `EmployeeNumber` VARCHAR(45) NULL DEFAULT NULL,
  `BranchId` INT NOT NULL,
  `FirstName` VARCHAR(45) NOT NULL,
  `LastName` VARCHAR(45) NOT NULL,
  `UserId` INT NULL DEFAULT NULL,
  `UpdatedUtc` DATETIME NULL,
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `IsActive` TINYINT NULL,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `EmployeeNumber_UNIQUE` (`EmployeeNumber` ASC) VISIBLE,
  INDEX `EmployeeBranch_idx` (`BranchId` ASC) VISIBLE,
  INDEX `EmployeeUser_idx` (`UserId` ASC) VISIBLE,
  CONSTRAINT `EmployeeBranch`
    FOREIGN KEY (`BranchId`)
    REFERENCES `bank_db`.`branches` (`Id`),
  CONSTRAINT `EmployeeUser`
    FOREIGN KEY (`UserId`)
    REFERENCES `bank_db`.`users` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`loanstatus`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`loanstatus` (
  `Id` INT NOT NULL,
  `Type` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`loans`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`loans` (
  `Id` INT NOT NULL,
  `BranchId` INT NOT NULL,
  `AccountId` INT NOT NULL,
  `Principal` DECIMAL(10,0) NOT NULL,
  `AnualInterest` DECIMAL(10,0) NOT NULL,
  `TermMonth` INT NOT NULL,
  `StartUtc`DATETIME NULL DEFAULT NULL,
  `Status` INT NULL DEFAULT NULL,
  `UpdatedUtc` DATETIME NULL,
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `IsActive` TINYINT NULL,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `LoanBranch_idx` (`BranchId` ASC) VISIBLE,
  INDEX `LoanAccount_idx` (`AccountId` ASC) VISIBLE,
  INDEX `LoanStatus_fk_idx` (`Status` ASC) VISIBLE,
  CONSTRAINT `LoanAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`),
  CONSTRAINT `LoanBranch`
    FOREIGN KEY (`BranchId`)
    REFERENCES `bank_db`.`branches` (`Id`),
  CONSTRAINT `LoanStatus_fk`
    FOREIGN KEY (`Status`)
    REFERENCES `bank_db`.`loanstatus` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`loanpayments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`loanpayments` (
  `Id` INT NOT NULL,
  `LoanId` INT NOT NULL,
  `Amount` DECIMAL(15,2) NOT NULL,
  `PaidDateUtc`DATETIME NOT NULL,
  `PrincipalPortion` DECIMAL(15,2) NULL DEFAULT NULL,
  `InterestPortion` DECIMAL(15,2) NULL DEFAULT NULL,
  `Reference` VARCHAR(45) NULL DEFAULT NULL,
  `DueDateUTC`DATETIME NOT NULL,
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `IsActive` TINYINT NULL,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `LoanPaymentLoan_idx` (`LoanId` ASC) VISIBLE,
  CONSTRAINT `LoanPaymentLoan`
    FOREIGN KEY (`LoanId`)
    REFERENCES `bank_db`.`loans` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`transactionkinds`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`transactionkinds` (
  `Id` INT NOT NULL,
  `Type` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`transfers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`transfers` (
  `Id` INT NOT NULL,
  `FromAccountId` INT NOT NULL,
  `ToAccountId` INT NOT NULL,
  `InitiatedByUserId` INT NOT NULL,
  `Amount` DECIMAL(14,2) NOT NULL,
  `Memo` VARCHAR(255) NULL DEFAULT NULL,
  `ExecutedUtc` DATETIME NULL DEFAULT NULL,
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `IsActive` TINYINT NULL,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `TransferFromAccount_idx` (`FromAccountId` ASC) VISIBLE,
  INDEX `TransferToAccount_idx` (`ToAccountId` ASC) VISIBLE,
  INDEX `TransferInitiatedByUser_idx` (`InitiatedByUserId` ASC) VISIBLE,
  CONSTRAINT `TransferFromAccount`
    FOREIGN KEY (`FromAccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`),
  CONSTRAINT `TransferInitiatedByUser`
    FOREIGN KEY (`InitiatedByUserId`)
    REFERENCES `bank_db`.`users` (`Id`),
  CONSTRAINT `TransferToAccount`
    FOREIGN KEY (`ToAccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`withdrawals`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`withdrawals` (
  `Id` INT NOT NULL,
  `AccountId` INT NOT NULL,
  `Method` VARCHAR(45) NOT NULL,
  `ReceivedUtc` DATETIME NULL DEFAULT NULL,
  `Amount` DECIMAL(14,2) NULL DEFAULT NULL,
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `IsActive` TINYINT NULL,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `DepositAccount_idx` (`AccountId` ASC) VISIBLE,
  CONSTRAINT `WithdrawalAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`transactions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`transactions` (
  `Id` INT NOT NULL,
  `AccountId` INT NOT NULL,
  `Kind` INT NOT NULL,
  `Amount` DECIMAL(14,2) NOT NULL,
  `Memo` VARCHAR(255) NULL DEFAULT NULL,
  `PostedUtc` DATETIME NULL DEFAULT NULL,
  `RelatedEntityId` INT NOT NULL,
  `UpdatedUtc` DATETIME NULL,
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `IsActive` TINYINT NULL,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `TransactionKind_idx` (`Kind` ASC) VISIBLE,
  INDEX `TransactionAccount_idx` (`AccountId` ASC) VISIBLE,
  CONSTRAINT `TransactionAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`),
  CONSTRAINT `TransactionKind`
    FOREIGN KEY (`Kind`)
    REFERENCES `bank_db`.`transactionkinds` (`Id`)
)ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS transaction_entity_sequence (
  Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  EntityType INT NOT NULL,
  CreatedUtC DATETIME NOT NULL DEFAULT NOW(),
  INDEX idx_entity_type(EntityType),
  INDEX idx_created_utc(CreatedUtc)
  ) ENGINE = InnoDB; 
-- END TABLES

-- seeding reference tables
-- 🔑 Roles
INSERT INTO Roles (Id, Name, Description, IsAdmin) VALUES
(1, 'Administrator', 'Full system access with ability to manage users and settings', 1),
(2, 'Manager', 'Can oversee employees and approve transactions', 0),
(3, 'Teller', 'Handles customer transactions at the branch level', 0),
(4, 'Customer', 'End user with access to personal accounts and services', 0);

-- 🏦 AccountTypes (from enum AccountType)
INSERT INTO AccountTypes (id, `Type`) VALUES
(1, 'Checking'),
(2, 'Savings'),
(3, 'Credit'),
(4, 'Loan'),
(5, 'CertificateOfDeposit');

-- 💳 CardTypes (from enum CardType)
INSERT INTO CardTypes (id, `Type`) VALUES
(1, 'Debit'),
(2, 'Credit');

-- 📑 TransactionKinds (from enum TransactionKind)
INSERT INTO TransactionKinds (id, `Type`) VALUES
(1, 'Deposit'),
(2, 'Withdrawal'),
(3, 'Transfer'),
(4, 'Fee'),
(5, 'Interest'),
(6, 'Payment');

-- 📌 LoanStatus (from enum LoanStatus)
INSERT INTO LoanStatus (id, `Type`) VALUES
(1, 'Pending'),
(2, 'Active'),
(3, 'Closed'),
(4, 'Delinquent');

USE `bank_db` ;
-- -----------------------------------------------------
-- procedure sp_get_customer_accounts
-- -----------------------------------------------------
DELIMITER $$
USE `bank_db`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_get_customer_accounts`(IN p_username VARCHAR(100))
BEGIN
  SELECT
    CONCAt(u.FirstName,' ', u.LastName) AS CustomerName,
    u.email,
    u.phone,
    a.AccountNumber,
    acct.Type AS AccountType,
    a.CurrentBalance,
    b.City as BranchCity,
    b.State as BranchState
  FROM Accounts a
  JOIN users u ON a.OwnerUserId = u.Id
  JOIN accounttypes acct ON a.AccountType = acct.Id
  JOIN branches b ON a.BranchId = b.id
  WHERE u.UserName = p_username;
END$$
DELIMITER ;

USE `bank_db`;
DELIMITER $$
CREATE TRIGGER trg_deposits_assignId
BEFORE INSERT ON deposits
FOR EACH ROW
BEGIN
  IF NEW.Id IS NULL OR  NEW.Id = 0 THEN
    INSERT INTO transaction_entity_sequence(EntityType) VALUES(1);
    SET NEW.Id = LAST_INSERT_ID();
  END IF;
END $$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER trg_withdrawals_assignId
BEFORE INSERT ON withdrawals
FOR EACH ROW
BEGIN
  IF NEW.Id IS NULL OR  NEW.Id = 0 THEN
    INSERT INTO transaction_entity_sequence(EntityType) VALUES(2);
    SET NEW.Id = LAST_INSERT_ID();
  END IF;
END $$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER trg_transfers_assignId
BEFORE INSERT ON transfers
FOR EACH ROW
BEGIN
  IF NEW.Id IS NULL OR  NEW.Id = 0 THEN
    INSERT INTO transaction_entity_sequence(EntityType) VALUES(3);
    SET NEW.Id = LAST_INSERT_ID();
  END IF;
END $$

DELIMITER ;

DELIMITER $$
CREATE TRIGGER trg_loanpayments_assignId
BEFORE INSERT ON loanpayments
FOR EACH ROW
BEGIN
  IF NEW.Id IS NULL OR  NEW.Id = 0 THEN
    INSERT INTO transaction_entity_sequence(EntityType) VALUES(6);
    SET NEW.Id = LAST_INSERT_ID();
  END IF;
END $$
DELIMITER ;
-- END Id space triggers


DELIMITER $$

-- procedure to find discrepancies in accounts at a specific branch
CREATE PROCEDURE sp_monthly_account_reconciliation(
    IN p_year INT,
    IN p_month INT,
    IN p_branch_id INT,
    OUT p_discrepancies_found INT
)
BEGIN
    DECLARE v_done BOOLEAN DEFAULT FALSE;
    DECLARE v_account_id INT;
    DECLARE v_account_number VARCHAR(45);
    DECLARE v_owner_name VARCHAR(91);
    DECLARE v_stored_balance DECIMAL(15,2);
    DECLARE v_calculated_balance DECIMAL(15,2);
    DECLARE v_transaction_count INT;
    DECLARE v_discrepancy DECIMAL(15,2);
    DECLARE v_accounts_checked INT DEFAULT 0;
    DECLARE v_branch_name VARCHAR(100);
    
    DECLARE account_cursor CURSOR FOR
        SELECT 
            a.Id,
            a.AccountNumber,
            CONCAT(u.FirstName, ' ', u.LastName) AS OwnerName,
            a.CurrentBalance
        FROM accounts a
        JOIN users u ON a.OwnerUserId = u.Id
        WHERE a.IsActive = 1
          AND u.HomeBranchId = p_branch_id
        ORDER BY a.AccountNumber;
    
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET v_done = TRUE;
    
    -- Get branch name for reporting
    SELECT CONCAT(City, ', ', State) INTO v_branch_name
    FROM branches
    WHERE Id = p_branch_id;
    
    DROP TEMPORARY TABLE IF EXISTS tmp_reconciliation_report;
    CREATE TEMPORARY TABLE tmp_reconciliation_report (
        AccountNumber VARCHAR(45),
        OwnerName VARCHAR(91),
        StoredBalance DECIMAL(15,2),
        CalculatedBalance DECIMAL(15,2),
        Discrepancy DECIMAL(15,2),
        TransactionCount INT,
        `Status` VARCHAR(20)
    );
    
    SET p_discrepancies_found = 0;
    
    OPEN account_cursor;
    
    read_loop: LOOP
        FETCH account_cursor INTO v_account_id, v_account_number, v_owner_name, v_stored_balance;
        
        IF v_done THEN
            LEAVE read_loop;
        END IF;
        
        SELECT 
            COUNT(*) AS TxCount,
            COALESCE(SUM(
                CASE t.Kind
                    WHEN 1 THEN t.Amount   -- Deposit: ADD
                    WHEN 5 THEN t.Amount   -- Interest: ADD
                    WHEN 2 THEN -t.Amount  -- Withdrawal: SUBTRACT
                    WHEN 3 THEN -t.Amount  -- Transfer: SUBTRACT
                    WHEN 4 THEN -t.Amount  -- Fee: SUBTRACT
                    WHEN 6 THEN -t.Amount  -- Payment: SUBTRACT
                    ELSE 0
                END
            ), 0) AS CalcBalance
        INTO v_transaction_count, v_calculated_balance
        FROM transactions t
        WHERE t.AccountId = v_account_id
            AND t.PostedUtc <= LAST_DAY(CONCAT(p_year, '-', LPAD(p_month, 2, '0'), '-01'))
            AND t.IsActive = 1;
        
        -- Calculate discrepancy
        SET v_discrepancy = v_stored_balance - v_calculated_balance;
        
        -- Insert into report
        INSERT INTO tmp_reconciliation_report 
        VALUES (
            v_account_number,
            v_owner_name,
            v_stored_balance,
            v_calculated_balance,
            v_discrepancy,
            v_transaction_count,
            CASE 
                WHEN ABS(v_discrepancy) < 0.01 THEN 'OK'
                WHEN ABS(v_discrepancy) < 1.00 THEN 'MINOR'
                ELSE 'DISCREPANCY'
            END
        );
        
        -- Count discrepancies
        IF ABS(v_discrepancy) >= 0.01 THEN
            SET p_discrepancies_found = p_discrepancies_found + 1;
        END IF;
        
        SET v_accounts_checked = v_accounts_checked + 1;
        
    END LOOP;
    
    CLOSE account_cursor;
    
    -- Display branch information
    SELECT 
        p_branch_id AS BranchId,
        v_branch_name AS BranchName,
        CONCAT(p_year, '-', LPAD(p_month, 2, '0')) AS ReconciliationPeriod;
    
    -- Display the reconciliation report
    SELECT * FROM tmp_reconciliation_report
    ORDER BY ABS(Discrepancy) DESC;
    
    -- Display summary
    SELECT 
        v_accounts_checked AS TotalAccountsChecked,
        p_discrepancies_found AS AccountsWithDiscrepancies,
        SUM(CASE WHEN `Status` = 'OK' THEN 1 ELSE 0 END) AS AccountsOK,
        SUM(CASE WHEN `Status` = 'MINOR' THEN 1 ELSE 0 END) AS MinorDiscrepancies,
        SUM(CASE WHEN `Status` = 'DISCREPANCY' THEN 1 ELSE 0 END) AS MajorDiscrepancies,
        SUM(ABS(Discrepancy)) AS TotalDiscrepancyAmount
    FROM tmp_reconciliation_report;
    
END$$

DELIMITER ;

DELIMITER $$
CREATE TRIGGER trg_close_loan_on_zero_balance
AFTER UPDATE ON accounts
FOR EACH ROW
BEGIN
    -- Check if this is a loan account and balance just reached zero
    IF NEW.AccountType = (SELECT Id FROM accounttypes WHERE `Type` = 'Loan')
       AND NEW.CurrentBalance <= 0
       AND OLD.CurrentBalance > 0 THEN

        -- Mark the loan as closed
        UPDATE loans
        SET Status = (SELECT Id FROM loanstatus WHERE `Type` = 'Closed'),
            UpdatedUtc = NOW()
        WHERE AccountId = NEW.Id
          AND Status != (SELECT Id FROM loanstatus WHERE `Type` = 'Closed');
    END IF;
END$$


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
