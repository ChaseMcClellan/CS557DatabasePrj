USE bank_db;

-- 1) Users → Accounts
ALTER TABLE accounts
  DROP FOREIGN KEY AccountOwner;

ALTER TABLE accounts
  ADD CONSTRAINT AccountOwner
    FOREIGN KEY (OwnerUserId)
    REFERENCES users(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

-- 2) Users → Cards
ALTER TABLE cards
  DROP FOREIGN KEY CardOwner;

ALTER TABLE cards
  ADD CONSTRAINT CardOwner
    FOREIGN KEY (OwnerUserId)
    REFERENCES users(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

-- 3) Users → Transfers (initiated by)
ALTER TABLE transfers
  DROP FOREIGN KEY TransferInitiatedByUser;

ALTER TABLE transfers
  ADD CONSTRAINT TransferInitiatedByUser
    FOREIGN KEY (InitiatedByUserId)
    REFERENCES users(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

-- 4) Users → Employees (you can choose CASCADE or SET NULL)
ALTER TABLE employees
  DROP FOREIGN KEY EmployeeUser;

ALTER TABLE employees
  ADD CONSTRAINT EmployeeUser
    FOREIGN KEY (UserId)
    REFERENCES users(Id)
    ON UPDATE CASCADE
    ON DELETE SET NULL;   -- or ON DELETE CASCADE if you want employee rows gone too

-- Accounts → Cards
ALTER TABLE cards
  DROP FOREIGN KEY CardAccount;

ALTER TABLE cards
  ADD CONSTRAINT CardAccount
    FOREIGN KEY (AccountId)
    REFERENCES accounts(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

-- Accounts → Deposits
ALTER TABLE deposits
  DROP FOREIGN KEY DepositAccount;

ALTER TABLE deposits
  ADD CONSTRAINT DepositAccount
    FOREIGN KEY (AccountId)
    REFERENCES accounts(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

-- Accounts → Withdrawals
ALTER TABLE withdrawals
  DROP FOREIGN KEY WithdrawalAccount;

ALTER TABLE withdrawals
  ADD CONSTRAINT WithdrawalAccount
    FOREIGN KEY (AccountId)
    REFERENCES accounts(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

-- Accounts → Transactions
ALTER TABLE transactions
  DROP FOREIGN KEY TransactionAccount;

ALTER TABLE transactions
  ADD CONSTRAINT TransactionAccount
    FOREIGN KEY (AccountId)
    REFERENCES accounts(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

-- Accounts → Loans
ALTER TABLE loans
  DROP FOREIGN KEY LoanAccount;

ALTER TABLE loans
  ADD CONSTRAINT LoanAccount
    FOREIGN KEY (AccountId)
    REFERENCES accounts(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

-- Accounts → Transfers (from)
ALTER TABLE transfers
  DROP FOREIGN KEY TransferFromAccount;

ALTER TABLE transfers
  ADD CONSTRAINT TransferFromAccount
    FOREIGN KEY (FromAccountId)
    REFERENCES accounts(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

-- Accounts → Transfers (to)
ALTER TABLE transfers
  DROP FOREIGN KEY TransferToAccount;

ALTER TABLE transfers
  ADD CONSTRAINT TransferToAccount
    FOREIGN KEY (ToAccountId)
    REFERENCES accounts(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

-- Loans → LoanPayments
ALTER TABLE loanpayments
  DROP FOREIGN KEY LoanPaymentLoan;

ALTER TABLE loanpayments
  ADD CONSTRAINT LoanPaymentLoan
    FOREIGN KEY (LoanId)
    REFERENCES loans(Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;
