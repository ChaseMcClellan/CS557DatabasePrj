

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema bankdb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema bankdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `bankdb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `bankdb` ;

-- -----------------------------------------------------
-- Table `bankdb`.`role`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`role` (
  `role_id` INT NOT NULL,
  `name` VARCHAR(45) NULL,
  `description` VARCHAR(255) NULL,
  `is_admin` TINYINT NULL,
  PRIMARY KEY (`role_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`user` (
  `user_id` INT NOT NULL,
  `first_name` VARCHAR(100) NULL,
  `last_name` VARCHAR(100) NULL,
  `username` VARCHAR(255) NULL,
  `password` VARCHAR(255) NULL,
  `email` VARCHAR(255) NULL,
  `role_id` INT NULL,
  `ssn` VARCHAR(255) NULL,
  `home_branch_id` INT NULL,
  PRIMARY KEY (`user_id`),
  INDEX `role_id_idx` (`role_id` ASC) VISIBLE,
  CONSTRAINT `role_id`
    FOREIGN KEY (`role_id`)
    REFERENCES `bankdb`.`role` (`role_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`branch`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`branch` (
  `branch_id` INT NOT NULL,
  `adress_line_1` VARCHAR(255) NULL,
  `adress_line_1` VARCHAR(255) NULL,
  `name` VARCHAR(255) NULL,
  `state` VARCHAR(45) NULL,
  `postal_code` VARCHAR(45) NULL,
  `phone` VARCHAR(45) NULL,
  PRIMARY KEY (`branch_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`account`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`account` (
  `account_id` INT NOT NULL,
  `user_id` INT NULL,
  `branch_id` INT NULL,
  `balance` DOUBLE NULL,
  `currency_code` VARCHAR(45) NULL,
  PRIMARY KEY (`account_id`),
  INDEX `user_id_idx` (`user_id` ASC) VISIBLE,
  INDEX `branch_id_idx` (`branch_id` ASC) VISIBLE,
  CONSTRAINT `user_id`
    FOREIGN KEY (`user_id`)
    REFERENCES `bankdb`.`user` (`user_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `branch_id`
    FOREIGN KEY (`branch_id`)
    REFERENCES `bankdb`.`branch` (`branch_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`card`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`card` (
  `card_number_masked` VARCHAR(255) NOT NULL,
  `card_type` VARCHAR(45) NULL,
  `expiration_date` DATETIME NULL,
  `owner_user_id` INT NULL,
  `account_id` INT NULL,
  PRIMARY KEY (`card_number_masked`),
  INDEX `account_id_idx` (`account_id` ASC) VISIBLE,
  CONSTRAINT `account_id`
    FOREIGN KEY (`account_id`)
    REFERENCES `bankdb`.`account` (`account_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `user_id`
    FOREIGN KEY ()
    REFERENCES `bankdb`.`user` ()
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`withdrawal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`withdrawal` (
  `withdrawal_id` INT NOT NULL,
  `amount` DOUBLE NULL,
  `account_id` INT NULL,
  `processed_utc` DATETIME NULL,
  `method` VARCHAR(45) NULL,
  `owner_user_id` INT NULL,
  PRIMARY KEY (`withdrawal_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`deposit`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`deposit` (
  `deposit_id` INT NOT NULL,
  `account_id` INT NULL,
  `amount` DOUBLE NULL,
  `recieved_utc` DATETIME NULL,
  `source` VARCHAR(45) NULL,
  `transaction_id` INT NULL,
  PRIMARY KEY (`deposit_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`loan`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`loan` (
  `loan_id` INT NOT NULL,
  `account_id` INT NULL,
  `principal` DOUBLE NULL,
  `anual_interest_rate` DOUBLE NULL,
  `loan_status` INT NULL,
  PRIMARY KEY (`loan_id`),
  INDEX `account_id_idx` (`account_id` ASC) VISIBLE,
  CONSTRAINT `account_id`
    FOREIGN KEY (`account_id`)
    REFERENCES `bankdb`.`account` (`account_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`loan_payment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`loan_payment` (
  `loan_id` INT NULL,
  `amount` DOUBLE NULL,
  `due_date` DATETIME NULL,
  `pay_date` DATETIME NULL,
  `principal` DOUBLE NULL,
  `interest` DOUBLE NULL,
  `loan_payment_id` INT NOT NULL,
  INDEX `loan_id_idx` (`loan_id` ASC) VISIBLE,
  PRIMARY KEY (`loan_payment_id`),
  CONSTRAINT `loan_id`
    FOREIGN KEY (`loan_id`)
    REFERENCES `bankdb`.`loan` (`loan_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`transfer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`transfer` (
  `transfer_id` INT NOT NULL,
  `from_account` INT NULL,
  `to_account` INT NULL,
  `amount` DOUBLE NULL,
  `memo` VARCHAR(255) NULL,
  `execute_utc` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `type` VARCHAR(45) NULL,
  `loan_payment_id` INT NULL,
  `deposit_id` INT NULL,
  `withdrawal_id` INT NULL,
  `transfer_id` INT NULL,
  PRIMARY KEY (`transfer_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`transaction`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`transaction` (
  `transaction_id` INT NOT NULL,
  `type` VARCHAR(45) NULL,
  `amount` DOUBLE NULL,
  `memo` VARCHAR(255) NULL,
  `account_id` INT NULL,
  `transfer_id` INT NULL,
  `deposit_id` INT NULL,
  `withdrawal_id` INT NULL,
  `loan_payment_id` INT NULL,
  PRIMARY KEY (`transaction_id`),
  INDEX `loan_payment_id_idx` (`loan_payment_id` ASC) VISIBLE,
  INDEX `withdrawal_id_idx` (`withdrawal_id` ASC) VISIBLE,
  INDEX `deposit_id_idx` (`deposit_id` ASC) VISIBLE,
  INDEX `transfer_id_idx` (`transfer_id` ASC) VISIBLE,
  CONSTRAINT `loan_payment_id`
    FOREIGN KEY (`loan_payment_id`)
    REFERENCES `bankdb`.`loan_payment` (`loan_payment_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `withdrawal_id`
    FOREIGN KEY (`withdrawal_id`)
    REFERENCES `bankdb`.`withdrawal` (`withdrawal_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `deposit_id`
    FOREIGN KEY (`deposit_id`)
    REFERENCES `bankdb`.`deposit` (`deposit_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `transfer_id`
    FOREIGN KEY (`transfer_id`)
    REFERENCES `bankdb`.`transfer` (`transfer_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankdb`.`employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankdb`.`employee` (
  `employee_id` INT NOT NULL,
  `branch_id` INT NULL,
  `user_id` INT NULL,
  `firstname` VARCHAR(100) NULL,
  `lastname` VARCHAR(100) NULL,
  `employeecol` VARCHAR(45) NULL,
  `CreatedByUserId` INT NULL,
  `is_active` TINYINT NULL,
  PRIMARY KEY (`employee_id`),
  INDEX `branch_id_idx` (`branch_id` ASC) VISIBLE,
  INDEX `user_id_idx` (`user_id` ASC, `CreatedByUserId` ASC) VISIBLE,
  CONSTRAINT `branch_id`
    FOREIGN KEY (`branch_id`)
    REFERENCES `bankdb`.`branch` (`branch_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `user_id`
    FOREIGN KEY (`user_id` , `CreatedByUserId`)
    REFERENCES `bankdb`.`user` (`user_id` , `user_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
