SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

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
  `Name` VARCHAR(100) NOT NULL DEFAULT '',
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
  `Id` INT NOT NULL AUTO_INCREMENT,
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
  `Id` INT NOT NULL AUTO_INCREMENT,
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
    REFERENCES `bank_db`.`branches` (`Id`)
    ON UPDATE CASCADE,
  CONSTRAINT `UserRole`
    FOREIGN KEY (`RoleId`)
    REFERENCES `bank_db`.`roles` (`Id`)
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`accounttypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`accounttypes` (
  `Id` INT NOT NULL AUTO_INCREMENT,
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
    REFERENCES `bank_db`.`branches` (`Id`)
    ON UPDATE CASCADE,
  CONSTRAINT `AccountOwner`
    FOREIGN KEY (`OwnerUserId`)
    REFERENCES `bank_db`.`users` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
  CONSTRAINT `AccountType`
    FOREIGN KEY (`AccountType`)
    REFERENCES `bank_db`.`accounttypes` (`Id`)
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`cardtypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`cardtypes` (
  `Id` INT NOT NULL AUTO_INCREMENT,
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
    REFERENCES `bank_db`.`accounts` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
  CONSTRAINT `CardCardType`
    FOREIGN KEY (`CardType`)
    REFERENCES `bank_db`.`cardtypes` (`Id`)
    ON UPDATE CASCADE,
  CONSTRAINT `CardOwner`
    FOREIGN KEY (`OwnerUserId`)
    REFERENCES `bank_db`.`users` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE)
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
    REFERENCES `bank_db`.`branches` (`Id`)
    ON UPDATE CASCADE,
  CONSTRAINT `EmployeeUser`
    FOREIGN KEY (`UserId`)
    REFERENCES `bank_db`.`users` (`Id`)
    ON UPDATE CASCADE
    ON DELETE SET NULL)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`loanstatus`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`loanstatus` (
  `Id` INT NOT NULL AUTO_INCREMENT,
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
  `AccountId` INT NOT NULL,
  `Principal` DECIMAL(10,0) NOT NULL,
  `AnnualInterestRate` DECIMAL(10,0) NOT NULL,
  `TermMonths` INT NOT NULL,
  `StartUtc`DATETIME NULL DEFAULT NULL,
  `Status` INT NULL DEFAULT NULL,
  `UpdatedUtc` DATETIME NULL,
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `IsActive` TINYINT NULL,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `LoanAccount_idx` (`AccountId` ASC) VISIBLE,
  INDEX `LoanStatus_fk_idx` (`Status` ASC) VISIBLE,
  CONSTRAINT `LoanAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
  CONSTRAINT `LoanStatus_fk`
    FOREIGN KEY (`Status`)
    REFERENCES `bank_db`.`loanstatus` (`Id`)
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`loanpayments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`loanpayments` (
  `Id` INT NOT NULL AUTO_INCREMENT,
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
    REFERENCES `bank_db`.`loans` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`transactionkinds`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`transactionkinds` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Type` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `bank_db`.`transfers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`transfers` (
  `Id` INT NOT NULL AUTO_INCREMENT,
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
    REFERENCES `bank_db`.`accounts` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
  CONSTRAINT `TransferInitiatedByUser`
    FOREIGN KEY (`InitiatedByUserId`)
    REFERENCES `bank_db`.`users` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
  CONSTRAINT `TransferToAccount`
    FOREIGN KEY (`ToAccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE)
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
  `CreatedUtc` DATETIME NULL DEFAULT current_timestamp,
  `CreatedByUserId` INT NULL,
  `UpdatedByUserId` INT NULL,
    `IsActive` TINYINT NULL,
  PRIMARY KEY (`Id`),
  INDEX `DepositAccount_idx` (`AccountId` ASC) VISIBLE,
  CONSTRAINT `DepositAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE)
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
  `ProcessedUtc` DATETIME NULL DEFAULT current_timestamp,
  PRIMARY KEY (`Id`),
  INDEX `DepositAccount_idx` (`AccountId` ASC) VISIBLE,
  CONSTRAINT `WithdrawalAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`accounts` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE)
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
    REFERENCES `bank_db`.`accounts` (`Id`)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
  CONSTRAINT `TransactionKind`
    FOREIGN KEY (`Kind`)
    REFERENCES `bank_db`.`transactionkinds` (`Id`)
    ON UPDATE CASCADE
)ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS transaction_entity_sequence (
  Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  EntityType INT NOT NULL,
  CreatedUtC DATETIME NOT NULL DEFAULT NOW(),
  INDEX idx_entity_type(EntityType),
  INDEX idx_created_utc(CreatedUtC)
  ) ENGINE = InnoDB; 
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
DELIMITER ;

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
    (Id, UserName, FirstName, LastName,
     PassWordHash, Email, Phone, SsnHash,
     RoleId, HomeBranchId,
     UpdatedUtc, CreatedUtc, IsActive,
     CreatedByUserId, UpdatedByUserId)
VALUES
    (1, 'admin', 'System', 'Admin',
     '$2b$12$BbZPc.vCFy20XGXBX0urWOwCKguw7LV0PgcsPgJGz0kEFoateXklO', 'admin@bank.local', '555-0000', NULL,
     1, 1,
     NOW(), NOW(), 1,
     NULL, NULL),

    (2, 'nick', 'Nick', 'User',
     'p', 'nick@bank.local', '555-0001', NULL,
     4, 1,
     NOW(), NOW(), 1,
     1, NULL),

    (3, 'chase', 'Chase', 'User',
     'p', 'chase@bank.local', '555-0002', NULL,
     4, 1,
     NOW(), NOW(), 1,
     1, NULL),

    (4, 'noah', 'Noah', 'User',
     'p', 'noah@bank.local', '555-0003', NULL,
     4, 1,
     NOW(), NOW(), 1,
     1, NULL),

    (5, 'braydon', 'Braydon', 'User',
     'p', 'braydon@bank.local', '555-0004', NULL,
     4, 1,
     NOW(), NOW(), 1,
     1, NULL),

    (6, 'harshitha', 'Harshitha', 'User',
     'p', 'harshitha@bank.local', '555-0005', NULL,
     4, 1,
     NOW(), NOW(), 1,
     1, NULL);

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
     1, NOW(), NULL, 'USD', 1, 1, NULL),
    (2, '1000000002', 1, 1, 5000.00,
     2, NOW(), NULL, 'USD', 1, 1, NULL),

    (3, '1000000003', 2, 1, 1200.00,
     1, NOW(), NULL, 'USD', 1, 1, NULL),
    (4, '1000000004', 2, 1, 800.00,
     2, NOW(), NULL, 'USD', 1, 1, NULL),

    (5, '1000000005', 3, 1, 3400.00,
     1, NOW(), NULL, 'USD', 1, 1, NULL),
    (6, '1000000006', 3, 1, 15000.00,
     2, NOW(), NULL, 'USD', 1, 1, NULL),

    (7, '1000000007', 4, 1, 600.00,
     1, NOW(), NULL, 'USD', 1, 1, NULL),

    (8, '1000000008', 5, 1, 2200.00,
     1, NOW(), NULL, 'USD', 1, 1, NULL),

    (9, '1000000009', 6, 1, 900.00,
     1, NOW(), NULL, 'USD', 1, 1, NULL), 

    (10, '2000000001', 3, 1, 5000.00,
     4, NOW(), NULL, 'USD', 1, 1, NULL);

INSERT INTO cards
    (Id, CardNumberMasked, ExpiratationUtc, CardHolderName,
     AccountId, OwnerUserId, CardType,
     CreatedUtc, IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    (1, '**** **** **** 0001', '2028-01-31 00:00:00',
     'Nick User', 3, 2, 1, NOW(), 1, 1, NULL),
    (2, '**** **** **** 0002', '2028-02-28 00:00:00',
     'Chase User', 5, 3, 1, NOW(), 1, 1, NULL),
    (3, '**** **** **** 0003', '2029-03-31 00:00:00',
     'Harshitha User', 9, 6, 1, NOW(), 1, 1, NULL),
    (4, '**** **** **** 9001', '2030-04-30 00:00:00',
     'Chase User', 10, 3, 2, NOW(), 1, 1, NULL); -- credit for loan account

INSERT INTO deposits
    (Id, AccountId, Source, ReceivedUtc, Amount)
VALUES
    (1, 3, 'Payroll',      '2024-03-01 09:00:00', 1000.00),
    (2, 5, 'Payroll',      '2024-03-01 09:15:00', 2000.00),
    (3, 6, 'Bonus',        '2024-03-15 10:00:00', 5000.00),
    (4, 9, 'Transfer In',  '2024-03-05 12:30:00', 300.00);

INSERT INTO withdrawals
    (Id, AccountId, Method, ReceivedUtc, Amount,
     CreatedUtc, IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    (1, 3, 'ATM',      '2024-03-02 13:00:00', 200.00, NOW(), 1, 2, NULL),
    (2, 5, 'DebitCard','2024-03-03 18:30:00', 150.00, NOW(), 1, 3, NULL),
    (3, 7, 'ATM',      '2024-03-04 11:45:00', 100.00, NOW(), 1, 4, NULL);

INSERT INTO transfers
    (Id, FromAccountId, ToAccountId, InitiatedByUserId,
     Amount, Memo, ExecutedUtc, CreatedUtc,
     IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    (1, 3, 4, 2, 150.00, 'Nick move to savings',
     '2024-03-06 08:30:00', NOW(), 1, 2, NULL),
    (2, 5, 6, 3, 300.00, 'Chase move to savings',
     '2024-03-06 09:00:00', NOW(), 1, 3, NULL),
    (3, 8, 9, 5, 250.00, 'Braydon send to Harshitha',
     '2024-03-07 14:10:00', NOW(), 1, 5, NULL);

INSERT INTO loans
    (Id, AccountId, Principal, AnnualInterestRate,
     TermMonths, StartUtc, Status,
     UpdatedUtc, CreatedUtc, IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    (1, 10, 5000.00, 5.00,
     24, '2024-01-15 00:00:00', 2,  -- Status 2 = Active
     NOW(), NOW(), 1, 3, NULL);

INSERT INTO loanpayments
    (Id, LoanId, Amount, PaidDateUtc,
     PrincipalPortion, InterestPortion, Reference,
     DueDateUTC, CreatedUtc, IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    (1, 1, 230.00, '2024-02-15 00:00:00',
     210.00, 20.00, 'First payment',
     '2024-02-15 00:00:00', NOW(), 1, 3, NULL),
    (2, 1, 230.00, '2024-03-15 00:00:00',
     211.00, 19.00, 'Second payment',
     '2024-03-15 00:00:00', NOW(), 1, 3, NULL);

INSERT INTO transactions
    (Id, AccountId, Kind, Amount, Memo,
     PostedUtc, RelatedEntityId, UpdatedUtc,
     CreatedUtc, IsActive, CreatedByUserId, UpdatedByUserId)
VALUES
    -- From deposits
    (1, 3, 1, 1000.00, 'Payroll deposit',
     '2024-03-01 09:00:00', 1, NULL, NOW(), 1, 2, NULL),
    (2, 5, 1, 2000.00, 'Payroll deposit',
     '2024-03-01 09:15:00', 2, NULL, NOW(), 1, 3, NULL),
    (3, 6, 1, 5000.00, 'Bonus deposit',
     '2024-03-15 10:00:00', 3, NULL, NOW(), 1, 3, NULL),
    (4, 9, 1, 300.00, 'Transfer in deposit',
     '2024-03-05 12:30:00', 4, NULL, NOW(), 1, 6, NULL),

    -- From withdrawals
    (5, 3, 2, -200.00, 'ATM withdrawal',
     '2024-03-02 13:00:00', 1, NULL, NOW(), 1, 2, NULL),
    (6, 5, 2, -150.00, 'Debit card purchase',
     '2024-03-03 18:30:00', 2, NULL, NOW(), 1, 3, NULL),
    (7, 7, 2, -100.00, 'ATM withdrawal',
     '2024-03-04 11:45:00', 3, NULL, NOW(), 1, 4, NULL),

    -- From transfers
    (8, 3, 3, -150.00, 'Transfer to savings',
     '2024-03-06 08:30:00', 1, NULL, NOW(), 1, 2, NULL),
    (9, 5, 3, -300.00, 'Transfer to savings',
     '2024-03-06 09:00:00', 2, NULL, NOW(), 1, 3, NULL),
    (10, 8, 3, -250.00, 'Transfer to Harshitha',
     '2024-03-07 14:10:00', 3, NULL, NOW(), 1, 5, NULL),

    -- From transfers
    (11, 4, 3, 150.00, 'Transfer from checking',
     '2024-03-06 08:30:00', 1, NULL, NOW(), 1, 2, NULL),
    (12, 6, 3, 300.00, 'Transfer from checking',
     '2024-03-06 09:00:00', 2, NULL, NOW(), 1, 3, NULL),
    (13, 9, 3, 250.00, 'Transfer from Braydon',
     '2024-03-07 14:10:00', 3, NULL, NOW(), 1, 6, NULL),

    -- Loan payments
    (14, 10, 6, -230.00, 'Loan payment 1',
     '2024-02-15 00:00:00', 1, NULL, NOW(), 1, 3, NULL),
    (15, 10, 6, -230.00, 'Loan payment 2',
     '2024-03-15 00:00:00', 2, NULL, NOW(), 1, 3, NULL);

ALTER TABLE transaction_entity_sequence AUTO_INCREMENT = 100;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;