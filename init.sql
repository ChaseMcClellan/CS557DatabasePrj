-- what i got right now 12/10 11:17
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
  `Name` VARCHAR(100) NOT NULL,
  `AddressLine1` VARCHAR(120) NOT NULL,
  `AddressLine2` VARCHAR(120) NULL DEFAULT NULL,
  `City` VARCHAR(80) NOT NULL,
  `State` VARCHAR(40) NOT NULL,
  `PostalCode` VARCHAR(20) NOT NULL,
  `Phone` VARCHAR(25) NULL DEFAULT NULL,
  `UpdatedUtc` DATETIME(6) NULL,
  `CreatedUtc` DATETIME(6)  NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `IsActive` TINYINT(1) NOT NULL DEFAULT 1,
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
  `Name` VARCHAR(50) NOT NULL, -- make name unique
  `Description` VARCHAR(255) NULL DEFAULT NULL,
  `IsAdmin` TINYINT(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`users` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Username` VARCHAR(50) NOT NULL UNIQUE, -- unq
  `FirstName` VARCHAR(60) NULL DEFAULT NULL,
  `LastName` VARCHAR(60) NULL DEFAULT NULL,
  `PasswordHash` VARCHAR(255) NOT NULL,
  `Email` VARCHAR(120) NULL DEFAULT NULL,
  `Phone` VARCHAR(25) NULL DEFAULT NULL,
  `SsnHash` VARCHAR(255) NULL DEFAULT NULL,
  `RoleId` INT NOT NULL,
  `HomeBranchId` INT NULL,
   `UpdatedUtc` DATETIME(6) NULL,
   `CreatedUtc` DATETIME(6)  NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `IsActive` TINYINT(1) NOT  NULL DEFAULT 1,
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
  `AccountNumber` VARCHAR(30) NOT NULL,
  `AccountType` INT NOT NULL,
  `OwnerUserId` INT NOT NULL,
  `BranchId` INT NULL,
  `CurrentBalance` DECIMAL(18,2) NOT NULL DEFAULT 0,
  `CurrencyCode` CHAR(3) NOT NULL DEFAULT 'USD',
  `CreatedUtc` DATETIME(6)  NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `UpdatedUtc` DATETIME(6) NULL,
  `IsActive` TINYINT(1) NOT  NULL DEFAULT 1,
  `UpdatedByUserId` INT NULL,
  `CreatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `AccountOwner_idx` (`OwnerUserId` ASC) VISIBLE,
  INDEX `AccountBranch_idx` (`BranchId` ASC) VISIBLE,
  INDEX `AccountType_idx` (`AccountType` ASC) VISIBLE,
  CONSTRAINT UQ_Accounts_Number UNIQUE (AccountNumber),
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
  `Id` INT NOT NULL AUTO_INCREMENT,
  `CardNumberMasked` VARCHAR(25) NOT NULL,
  `ExpirationUtc`DATETIME(6) NOT NULL,
  `CardHolderName` VARCHAR(120) NOT NULL,
  `AccountId` INT NOT NULL,
  `OwnerUserId` INT NOT NULL,
  `CardType` INT NOT NULL,
  `CreatedUtc` DATETIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `IsActive` TINYINT(1) NOT NULL DEFAULT 1,
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
  `Id` INT NOT NULL DEFAULT 0,
  `AccountId` INT NOT NULL,
  `Source` VARCHAR(100) NOT NULL,
  `ReceivedUtc` DATETIME(6) NOT NULL,
  `Amount` DECIMAL(18,2) NOT NULL CHECK (Amount >= 0),
  `UpdatedUtc` DATETIME(6) NULL,
  `CreatedUtc` DATETIME(6)  NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `IsActive` TINYINT(1) NOT  NULL DEFAULT 1,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  
  
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
  `EmployeeNumber` VARCHAR(40) NOT NULL,
  `FirstName` VARCHAR(60) NOT NULL,
  `LastName` VARCHAR(60) NOT NULL,
  `BranchId` INT NOT NULL,
  `UserId` INT NULL,
  `UpdatedUtc` DATETIME(6) NULL,
  `CreatedUtc` DATETIME(6)  NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `IsActive` TINYINT(1) NOT  NULL DEFAULT 1,
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
  `Id` INT NOT NULL AUTO_INCREMENT,
  `AccountId` INT NOT NULL, -- unique
  `Principal` DECIMAL(18,2) NOT NULL CHECK(Principal > 0),
  `AnnualInterestRate` DECIMAL(9,6) NOT NULL CHECK(AnnualInterestRate > 0),
  `TermMonths` INT NOT NULL CHECK(TermMonths > 0),
  `StartUtc`DATETIME(6) NOT NULL,
  `Status` INT NOT NULL,
  `UpdatedUtc` DATETIME(6) NULL,
  `CreatedUtc` DATETIME(6)  NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `IsActive` TINYINT(1) NOT  NULL DEFAULT 1,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `LoanAccount_idx` (`AccountId` ASC) VISIBLE,
  INDEX `LoanStatus_fk_idx` (`Status` ASC) VISIBLE,
  CONSTRAINT `LoanAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`),
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
  `Id` INT NOT NULL DEFAULT 0,
  `LoanId` INT NOT NULL,
  `Amount` DECIMAL(18,2) NOT NULL CHECK(Amount >=0),
  `DueDateUTC`DATETIME(6)NOT NULL,
  `PaidDateUtc`DATETIME(6) NULL,
  `PrincipalPortion` DECIMAL(18,2) NULL DEFAULT NULL,
  `InterestPortion` DECIMAL(18,2) NULL DEFAULT NULL,
  `Reference` VARCHAR(45) NULL DEFAULT NULL,
  `CreatedUtc` DATETIME(6)  NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `UpdatedUtc` DATETIME(6) NULL,
  `IsActive` TINYINT(1) NOT  NULL DEFAULT 1,
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
  `Id` INT NOT NULL DEFAULT 0,
  `FromAccountId` INT NOT NULL,
  `ToAccountId` INT NOT NULL,
  `InitiatedByUserId` INT NOT NULL,
  `Amount` DECIMAL(18,2) NOT NULL CHECK(Amount >=0),
  `Memo` VARCHAR(255) NULL DEFAULT NULL,
  `ExecutedUtc` DATETIME(6)NOT NULL,
  `CreatedUtc` DATETIME(6)  NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `UpdatedUtc` DATETIME(6) NULL,
  `IsActive` TINYINT(1) NOT NULL DEFAULT 1,
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
  `Id` INT NOT NULL DEFAULT 0,
  `AccountId` INT NOT NULL,
  `Amount` DECIMAL(18,2) NOT NULL CHECK (Amount >= 0),
  `Method` VARCHAR(100) NOT NULL,
  `ProcessedUtc` DATETIME(6) NOT NULL,
  `CreatedUtc` DATETIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `IsActive` TINYINT(1) NOT  NULL DEFAULT 1,
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
  `Id` INT NOT NULL AUTO_INCREMENT,
  `AccountId` INT NOT NULL,
  `Kind` INT NOT NULL,
  `Amount` DECIMAL(18,2) NOT NULL,
  `Memo` VARCHAR(255) NULL DEFAULT NULL,
  `PostedUtc` DATETIME(6) NULL DEFAULT NULL,
  `RelatedEntityId` INT NULL,
  `UpdatedUtc` DATETIME(6) NULL,
  `CreatedUtc` DATETIME(6)NULL DEFAULT CURRENT_TIMESTAMP(6),
  `IsActive` TINYINT(1) NOT  NULL DEFAULT 1,
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
  CreatedUtC DATETIME(6)NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  INDEX idx_entity_type(EntityType),
  INDEX idx_created_utc(CreatedUtc)
  ) AUTO_INCREMENT=100
  ENGINE = InnoDB; 
-- END TABLES

-- seeding reference tables
INSERT INTO Roles (Id, Name, Description, IsAdmin) VALUES
(1, 'Administrator', 'Full system access with ability to manage users and settings', 1),
(2, 'Manager', 'Can oversee employees and approve transactions', 0),
(3, 'Teller', 'Handles customer transactions at the branch level', 0),
(4, 'Customer', 'End user with access to personal accounts and services', 0);

INSERT INTO AccountTypes (id, `Type`) VALUES
(1, 'Checking'),
(2, 'Savings'),
(3, 'Credit'),
(4, 'CertificateOfDeposit');

INSERT INTO CardTypes (id, `Type`) VALUES
(1, 'Debit'),
(2, 'Credit');

INSERT INTO TransactionKinds (id, `Type`) VALUES
(1, 'Deposit'),
(2, 'Withdrawal'),
(3, 'Transfer'),
(4, 'Fee'),
(5, 'Interest'),
(6, 'Payment');

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
  WHERE u.Username = p_username;
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
    DECLARE v_stored_balance DECIMAL(18,2);
    DECLARE v_calculated_balance DECIMAL(18,2);
    DECLARE v_transaction_count INT;
    DECLARE v_discrepancy DECIMAL(18,2);
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
        StoredBalance DECIMAL(18,2),
        CalculatedBalance DECIMAL(18,2),
        Discrepancy DECIMAL(18,2),
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

-- SEEDING

INSERT INTO branches
    (Id, Name, AddressLine1, AddressLine2, City, State, PostalCode, Phone,
     CreatedUtc, IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    (1, 'HQ',
     '100 Main St', 'Downtown HQ',
     'Milwaukee', 'WI', '53201',
     '414-555-0100',
     NOW(), 1, NULL, NULL);

INSERT INTO users
    (Id, Username, FirstName, LastName,
     PassWordHash, Email, Phone, SsnHash,
     RoleId, HomeBranchId,
     UpdatedUtc, CreatedUtc, IsActive,
     CreatedByUserId, UpdatedByUserId)
VALUES
    (1, 'admin', 'System', 'Admin',
     '$2b$12$BbZPc.vCFy20XGXBX0urWOwCKguw7LV0PgcsPgJGz0kEFoateXklO', 'admin@bank.local', '555-0000', NULL,
     1, 1,
     NOW(), NOW(), 1,
     NULL, NULL);


INSERT INTO employees
    (Id, EmployeeNumber, BranchId, FirstName, LastName, UserId,
     UpdatedUtc, CreatedUtc, IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    (1, 'EMP-0001', 1, 'System', 'Admin', 1,
     NOW(), NOW(), 1, 1, NULL),
    (2, 'EMP-0002', 1, 'Nick', 'User', 2,
     NOW(), NOW(), 1, 1, NULL),
    (3, 'EMP-0003', 1, 'Chase', 'User', 3,
     NOW(), NOW(), 1, 1, NULL);

INSERT INTO accounts
    (Id, AccountNumber, OwnerUserId, BranchId, CurrentBalance,
     AccountType, Createdutc, UpdatedUtc, CurrencyCode,
     IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    -- Admin accounts
    (1, '1000000001', 1, 1, 25000.00,
     1, NOW(), NULL, 'USD', 1, 1, NULL);


-- Start of seeding data for reconciliation demo.
-- =============================================================================
-- 1. INSERT TEST BRANCH
-- =============================================================================
use bank_db;
INSERT INTO branches
    (Name, AddressLine1, AddressLine2, City, State, PostalCode, Phone,
     CreatedUtc, IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    ('Test Branch',
     '200 Test St', 'Suite 100',
     'Madison', 'WI', '53703',
     '608-555-0200',
     NOW(), 1, 1, NULL);

-- =============================================================================
-- 2. INSERT TEST USERS
-- =============================================================================
INSERT INTO users
    (Username, FirstName, LastName,
     PasswordHash, Email, Phone, SsnHash,
     RoleId, HomeBranchId,
     UpdatedUtc, CreatedUtc, IsActive,
     CreatedByUserId, UpdatedByUserId)
VALUES
    ('alice.test', 'Alice', 'Johnson',
     'p', 'alice@test.local', '555-1001', NULL,
     3, 2,
     NOW(), NOW(), 1,
     1, NULL),
    ('bob.test', 'Bob', 'Smith',
     'p', 'bob@test.local', '555-1002', NULL,
     3, 2,
     NOW(), NOW(), 1,
     1, NULL),
    ('carol.test', 'Carol', 'Davis',
     'p', 'carol@test.local', '555-1003', NULL,
     3, 2,
     NOW(), NOW(), 1,
     1, NULL),
    ('dave.test', 'Dave', 'Wilson',
     'p', 'dave@test.local', '555-1004', NULL,
     3, 1,
     NOW(), NOW(), 1,
     1, NULL);

-- =============================================================================
-- 3. INSERT TEST ACCOUNTS
-- =============================================================================
INSERT INTO accounts
    (AccountNumber, OwnerUserId, BranchId, CurrentBalance,
     AccountType, CreatedUtc, UpdatedUtc, CurrencyCode,
     IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    -- Alice's account - Perfect balance (1400.00)
    ('2000000100', 2, 2, 1400.00,
     1, '2024-01-15 00:00:00', NOW(), 'USD', 1, 1, NULL),
    
    -- Bob's account - Minor discrepancy (stored 2500.50, should be 2500.00)
    ('2000000101', 3, 2, 2500.50,
     1, '2024-02-01 00:00:00', NOW(), 'USD', 1, 1, NULL),
    
    -- Carol's account - Major discrepancy (stored 5000.00, should be 4850.00)
    ('2000000102', 4, 2, 5000.00,
     2, '2024-03-10 00:00:00', NOW(), 'USD', 1, 1, NULL),
    
    -- Dave's account - Different branch (for testing branch filtering)
    ('1000000103', 5, 1, 3000.00,
     1, '2024-01-20 00:00:00', NOW(), 'USD', 1, 1, NULL);

-- =============================================================================
-- 4. TRANSACTIONS FOR ACCOUNT 100 (Alice - Perfect Balance)
-- Target: $1,400.00 = 1000 + 750 - 200 + 25 - 75 - 100
-- =============================================================================

-- Initial deposit: $1,000
INSERT INTO deposits (AccountId, `Source`, ReceivedUtc, Amount, CreatedUtc, IsActive, CreatedByUserId)
VALUES (2, 'Cash', '2024-01-15 10:00:00', 1000.00, NOW(), 1, 1);
SET @deposit_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (1, 2, 1000.00, '2024-01-15 10:00:00', 1, @deposit_id,
     NOW(), 1);

-- Second deposit: $750
INSERT INTO deposits (AccountId, `Source`, ReceivedUtc, Amount, CreatedUtc, IsActive, CreatedByUserId)
VALUES (2, 'Check', '2024-02-10 14:30:00', 750.00, NOW(), 1, 1);
SET @deposit_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (1, 2, 750.00, '2024-02-10 14:30:00', 1, @deposit_id,
     NOW(), 1);

-- Withdrawal: $200
INSERT INTO withdrawals (AccountId, Amount, Method, ProcessedUtc, CreatedUtc, IsActive, CreatedByUserId)
VALUES (2, 200.00, 'ATM', '2024-03-05 09:15:00', NOW(), 1, 1);
SET @withdrawal_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (2, 2, 200.00, '2024-03-05 09:15:00', 1, @withdrawal_id,
     NOW(), 1);

-- Interest: $25 (using deposits table as interests table doesn't exist in schema)
INSERT INTO deposits (AccountId, `Source`, ReceivedUtc, Amount, CreatedUtc, IsActive, CreatedByUserId)
VALUES (2, 'Interest Payment - March 2024', '2024-03-31 23:59:59', 25.00, NOW(), 1, 1);
SET @interest_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (5, 2, 25.00, '2024-03-31 23:59:59', 1, @interest_id,
     NOW(), 1);

-- Fee: $75 (using withdrawals table as fees table doesn't exist in schema)
INSERT INTO withdrawals (AccountId, Amount, Method, ProcessedUtc, CreatedUtc, IsActive, CreatedByUserId)
VALUES (2, 75.00, 'Monthly Maintenance Fee', '2024-04-01 00:00:01', NOW(), 1, 1);
SET @fee_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (4, 2, 75.00, '2024-04-01 00:00:01', 1, @fee_id,
     NOW(), 1);

INSERT INTO loans (AccountId, Principal, AnnualInterestRate, TermMonths, StartUtc, Status, CreatedUtc, IsActive, CreatedByUserId)
VALUES (2, 5000.00, 5.500000, 36, '2024-01-15 00:00:00', 1, NOW(), 1, 1);
SET @loan_id = LAST_INSERT_ID();

-- Loan payment: $100
INSERT INTO loanpayments (LoanId, Amount, DueDateUTC, PaidDateUtc, CreatedUtc, IsActive, CreatedByUserId)
VALUES (@loan_id, 100.00, '2024-04-25 00:00:00', '2024-04-25 14:00:00', NOW(), 1, 1);
SET @payment_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (6, 2, 100.00, '2024-04-25 14:00:00', 1, @payment_id,
     NOW(), 1);

-- Expected: 1000 + 750 - 200 + 25 - 75 - 100 = 1400.00 ✓

-- =============================================================================
-- 5. TRANSACTIONS FOR ACCOUNT2(Bob - Minor Discrepancy)
-- Stored: $2,500.50, Calculated: $2,500.00 (Discrepancy: $0.50)
-- =============================================================================

-- Initial deposit: $2,000
INSERT INTO deposits (AccountId, `Source`, ReceivedUtc, Amount, CreatedUtc, IsActive, CreatedByUserId)
VALUES ( 3 , 'Wire Transfer', '2024-02-01 11:00:00', 2000.00, NOW(), 1, 1);
SET @deposit_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (1,  3 , 2000.00, '2024-02-01 11:00:00', 1, @deposit_id,
     NOW(), 1);

-- Second deposit: $800
INSERT INTO deposits (AccountId, `Source`, ReceivedUtc, Amount, CreatedUtc, IsActive, CreatedByUserId)
VALUES ( 3 , 'Cash', '2024-03-15 16:45:00', 800.00, NOW(), 1, 1);
SET @deposit_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (1,  3 , 800.00, '2024-03-15 16:45:00', 1, @deposit_id,
     NOW(), 1);

-- Withdrawal: $300
INSERT INTO withdrawals (AccountId, Amount, Method, ProcessedUtc, CreatedUtc, IsActive, CreatedByUserId)
VALUES ( 3 , 300.00, 'Teller', '2024-04-20 10:30:00', NOW(), 1, 1);
SET @withdrawal_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (2,  3 , 300.00, '2024-04-20 10:30:00', 1, @withdrawal_id,
     NOW(), 1);

-- Expected: 2000 + 800 - 300 = 2500.00
-- Stored: 2500.50 → $0.50 discrepancy

-- =============================================================================
-- 6. TRANSACTIONS FOR ACCOUNT 102 (Carol - Major Discrepancy)
-- Stored: $5,000.00, Calculated: $4,850.00 (Discrepancy: $150.00)
-- =============================================================================

-- Initial deposit: $5,000
INSERT INTO deposits (AccountId, `Source`, ReceivedUtc, Amount, CreatedUtc, IsActive, CreatedByUserId)
VALUES (4, 'Wire Transfer', '2024-03-10 13:00:00', 5000.00, NOW(), 1, 1);
SET @deposit_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (1, 4, 5000.00, '2024-03-10 13:00:00', 1, @deposit_id,
     NOW(), 1);

-- Transfer out: $150 (this should have reduced balance but didn't)
INSERT INTO transfers (FromAccountId, ToAccountId, InitiatedByUserId, Amount, ExecutedUtc, CreatedUtc, IsActive, CreatedByUserId)
VALUES (4, 100, 12, 150.00, '2024-04-15 12:00:00', NOW(), 1, 1);
SET @transfer_id = LAST_INSERT_ID();

INSERT INTO transactions 
    (Kind, AccountId, Amount, PostedUtc, IsActive, RelatedEntityId,
     CreatedUtc, CreatedByUserId)
VALUES 
    (3, 4, 150.00, '2024-04-15 12:00:00', 1, @transfer_id,
     NOW(), 1);

-- Expected: 5000 - 150 = 4850.00
-- Stored: 5000.00 → $150.00 discrepancy
SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


