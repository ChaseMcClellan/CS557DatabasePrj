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
-- Table `bank_db`.`Branches`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Branches` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `AdressLine1` VARCHAR(45) NOT NULL,
  `AdressLine2` VARCHAR(45) NULL,
  `City` VARCHAR(45) NOT NULL,
  `State` VARCHAR(45) NOT NULL,
  `PostalCode` VARCHAR(45) NOT NULL,
  `Phone` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bank_db`.`Roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Roles` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Description` VARCHAR(255) NULL,
  `IsAdmin` TINYINT NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bank_db`.`Users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Users` (
  `Id` INT NOT NULL,
  `UserName` VARCHAR(100) NULL,
  `FirstName` VARCHAR(45) NULL,
  `LastName` VARCHAR(45) NULL,
  `PassWordHash` VARCHAR(255) NOT NULL,
  `Email` VARCHAR(100) NULL,
  `Phone` VARCHAR(45) NULL,
  `SsnHash` VARCHAR(255) NULL,
  `RoleId` INT NOT NULL,
  `HomeBranchId` INT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `UserBranch`
    FOREIGN KEY (`HomeBranchId`)
    REFERENCES `bank_db`.`Branches` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `UserRole`
    FOREIGN KEY (`RoleId`)
    REFERENCES `bank_db`.`Roles` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `UserBranch_idx` ON `bank_db`.`Users` (`HomeBranchId` ASC) VISIBLE;

CREATE INDEX `UserRole_idx` ON `bank_db`.`Users` (`RoleId` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `bank_db`.`AccountTypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`AccountTypes` (
  `Id` INT NOT NULL,
  `Type` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bank_db`.`Accounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Accounts` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `AccountNumber` VARCHAR(45) NOT NULL,
  `OwnerUserId` INT NOT NULL,
  `BranchId` INT NOT NULL,
  `CurrentBalance` DECIMAL(14,2) NULL,
  `AccountType` INT NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `AccountOwner`
    FOREIGN KEY (`OwnerUserId`)
    REFERENCES `bank_db`.`Users` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `AccountBranch`
    FOREIGN KEY (`BranchId`)
    REFERENCES `bank_db`.`Branches` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `AccountType`
    FOREIGN KEY (`AccountType`)
    REFERENCES `bank_db`.`AccountTypes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `AccountOwner_idx` ON `bank_db`.`Accounts` (`OwnerUserId` ASC) VISIBLE;

CREATE INDEX `AccountBranch_idx` ON `bank_db`.`Accounts` (`BranchId` ASC) VISIBLE;

CREATE INDEX `AccountType_idx` ON `bank_db`.`Accounts` (`AccountType` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `bank_db`.`Employees`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Employees` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `EmployeeNumber` VARCHAR(45) NULL,
  `BranchId` INT NOT NULL,
  `FirstName` VARCHAR(45) NOT NULL,
  `LastName` VARCHAR(45) NOT NULL,
  `UserId` INT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `EmployeeBranch`
    FOREIGN KEY (`BranchId`)
    REFERENCES `bank_db`.`Branches` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `EmployeeUser`
    FOREIGN KEY (`UserId`)
    REFERENCES `bank_db`.`Users` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE UNIQUE INDEX `EmployeeNumber_UNIQUE` ON `bank_db`.`Employees` (`EmployeeNumber` ASC) VISIBLE;

CREATE INDEX `EmployeeBranch_idx` ON `bank_db`.`Employees` (`BranchId` ASC) VISIBLE;

CREATE INDEX `EmployeeUser_idx` ON `bank_db`.`Employees` (`UserId` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `bank_db`.`CardTypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`CardTypes` (
  `Id` INT NOT NULL,
  `Type` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bank_db`.`Cards`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Cards` (
  `Id` INT NOT NULL,
  `CardNumberMasked` VARCHAR(255) NOT NULL,
  `ExpiratationUtc` DATE NOT NULL,
  `CardHolderName` VARCHAR(91) NOT NULL,
  `AccountId` INT NOT NULL,
  `OwnerUserId` INT NOT NULL,
  `CardType` INT NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `CardOwner`
    FOREIGN KEY (`OwnerUserId`)
    REFERENCES `bank_db`.`Users` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `CardAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`Accounts` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `CardCardType`
    FOREIGN KEY (`CardType`)
    REFERENCES `bank_db`.`CardTypes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `CardOwner_idx` ON `bank_db`.`Cards` (`OwnerUserId` ASC) VISIBLE;

CREATE INDEX `CardAccount_idx` ON `bank_db`.`Cards` (`AccountId` ASC) VISIBLE;

CREATE INDEX `CardCardType_idx` ON `bank_db`.`Cards` (`CardType` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `bank_db`.`LoanStatus`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`LoanStatus` (
  `Id` INT NOT NULL,
  `Type` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bank_db`.`Loans`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Loans` (
  `Id` INT NOT NULL,
  `BranchId` INT NOT NULL,
  `AccountId` INT NOT NULL,
  `Principal` DECIMAL NOT NULL,
  `AnualInterest` DECIMAL NOT NULL,
  `TermMonth` INT NOT NULL,
  `StartUtc` DATE NULL,
  `Status` INT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `LoanBranch`
    FOREIGN KEY (`BranchId`)
    REFERENCES `bank_db`.`Branches` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `LoanAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`Accounts` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `LoanStatus_fk`
    FOREIGN KEY (`Status`)
    REFERENCES `bank_db`.`LoanStatus` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `LoanBranch_idx` ON `bank_db`.`Loans` (`BranchId` ASC) VISIBLE;

CREATE INDEX `LoanAccount_idx` ON `bank_db`.`Loans` (`AccountId` ASC) VISIBLE;

CREATE INDEX `LoanStatus_fk_idx` ON `bank_db`.`Loans` (`Status` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `bank_db`.`TransactionKinds`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`TransactionKinds` (
  `Id` INT NOT NULL,
  `Type` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bank_db`.`Deposits`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Deposits` (
  `Id` INT NOT NULL,
  `AccountId` INT NOT NULL,
  `Source` VARCHAR(45) NOT NULL,
  `ReceivedUtc` DATETIME NULL,
  `Amount` DECIMAL(14,2) NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `DepositAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`Accounts` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `DepositAccount_idx` ON `bank_db`.`Deposits` (`AccountId` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `bank_db`.`Withdrawals`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Withdrawals` (
  `Id` INT NOT NULL,
  `AccountId` INT NOT NULL,
  `Method` VARCHAR(45) NOT NULL,
  `ReceivedUtc` DATETIME NULL,
  `Amount` DECIMAL(14,2) NULL,
  `Withdrawlcol` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `WithdrawalAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`Accounts` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `DepositAccount_idx` ON `bank_db`.`Withdrawals` (`AccountId` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `bank_db`.`Transfers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Transfers` (
  `Id` INT NOT NULL,
  `FromAccountId` INT NOT NULL,
  `ToAccountId` INT NOT NULL,
  `InitiatedByUserId` INT NOT NULL,
  `Amount` DECIMAL(14,2) NOT NULL,
  `Memo` VARCHAR(255) NULL,
  `ExecutedUtc` DATETIME NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `TransferFromAccount`
    FOREIGN KEY (`FromAccountId`)
    REFERENCES `bank_db`.`Accounts` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TransferToAccount`
    FOREIGN KEY (`ToAccountId`)
    REFERENCES `bank_db`.`Accounts` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TransferInitiatedByUser`
    FOREIGN KEY (`InitiatedByUserId`)
    REFERENCES `bank_db`.`Users` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `TransferFromAccount_idx` ON `bank_db`.`Transfers` (`FromAccountId` ASC) VISIBLE;

CREATE INDEX `TransferToAccount_idx` ON `bank_db`.`Transfers` (`ToAccountId` ASC) VISIBLE;

CREATE INDEX `TransferInitiatedByUser_idx` ON `bank_db`.`Transfers` (`InitiatedByUserId` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `bank_db`.`LoanPayments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`LoanPayments` (
  `Id` INT NOT NULL,
  `LoanId` INT NOT NULL,
  `Amount` DECIMAL(14,2) NOT NULL,
  `PaidDateUtc` DATE NOT NULL,
  `PrincipalPortion` DECIMAL(14,2) NULL,
  `InterestPortion` DECIMAL(14,2) NULL,
  `Reference` VARCHAR(45) NULL,
  `DueDateUTC` DATE NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `LoanPaymentLoan`
    FOREIGN KEY (`LoanId`)
    REFERENCES `bank_db`.`Loans` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `LoanPaymentLoan_idx` ON `bank_db`.`LoanPayments` (`LoanId` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `bank_db`.`Transactions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bank_db`.`Transactions` (
  `Id` INT NOT NULL,
  `AccountId` INT NOT NULL,
  `Kind` INT NOT NULL,
  `Amount` DECIMAL(14,2) NOT NULL,
  `Memo` VARCHAR(255) NULL,
  `PostedUtc` DATETIME NULL,
  `DepositId` INT NULL,
  `WithdrawalId` INT NULL,
  `TrasnferId` INT NULL,
  `LoanPaymentId` INT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `TransactionDeposit`
    FOREIGN KEY (`DepositId`)
    REFERENCES `bank_db`.`Deposits` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TransactionKind`
    FOREIGN KEY (`Kind`)
    REFERENCES `bank_db`.`TransactionKinds` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TransactionTransfer`
    FOREIGN KEY (`TrasnferId`)
    REFERENCES `bank_db`.`Transfers` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TransactionWithdrawal`
    FOREIGN KEY (`WithdrawalId`)
    REFERENCES `bank_db`.`Withdrawals` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TransactionLoanPayment`
    FOREIGN KEY (`LoanPaymentId`)
    REFERENCES `bank_db`.`LoanPayments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TransactionAccount`
    FOREIGN KEY (`AccountId`)
    REFERENCES `bank_db`.`Accounts` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `TransactionDeposit_idx` ON `bank_db`.`Transactions` (`DepositId` ASC) VISIBLE;

CREATE INDEX `TransactionKind_idx` ON `bank_db`.`Transactions` (`Kind` ASC) VISIBLE;

CREATE INDEX `TransactionTransfer_idx` ON `bank_db`.`Transactions` (`TrasnferId` ASC) VISIBLE;

CREATE INDEX `TransactionWithdrawal_idx` ON `bank_db`.`Transactions` (`WithdrawalId` ASC) VISIBLE;

CREATE INDEX `TransactionAccount_idx` ON `bank_db`.`Transactions` (`AccountId` ASC) VISIBLE;

CREATE INDEX `TransactionLoanPayment_idx` ON `bank_db`.`Transactions` (`LoanPaymentId` ASC) VISIBLE;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
