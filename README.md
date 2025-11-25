# CS557DatabasePrj

A simple educational **banking system** built in C# WinForms for CS 557 (Database Systems).  
The app demonstrates a classic 3-layer architecture (UI / Business Logic / Data Access) on top of a MySQL database using Dapper.

---

## Features

### Core banking domain

- **Branches**
  - Create, view, update, and delete branches
  - Store address, phone, and other contact details

- **Users**
  - Application users with:
    - Username & password hash
    - First & last name
    - Email, phone, SSN hash
    - Role (admin vs regular user)
    - Home branch
  - Admin UI to view / edit / delete users

- **Employees**
  - Employees linked to a branch and a user login
  - Admin UI to view employees by branch and edit their details

- **Accounts**
  - Accounts linked to a user and branch
  - Account types (Checking, Savings, Credit, Loan, CD)
  - Current balance and currency

- **Transactions & Deposits**
  - Domain model for `Transaction` and `Deposit`
  - Transaction kinds: Deposit, Withdrawal, Transfer, Fee, Interest, Payment
  - Admin can:
    - View all transactions in a DataGridView
    - Edit transaction details (amount, kind, memo, date)
    - “Undo” a transaction:
      - Creates a reversing transaction that negates the original
      - Adjusts the account balance while preserving audit history
  - Admin can record **deposits** (acting like an ATM deposit):
    - Select a user → load their accounts
    - Select an account
    - Enter amount and source (Cash, Check, Wire, etc.)
    - Inserts a row into `Deposits`
    - Updates the account’s balance
    - Writes a corresponding transaction

- **Audit fields**
  - All major entities inherit from `AuditableEntity`:
    - `CreatedUtc`, `CreatedByUserId`
    - `UpdatedUtc`, `UpdatedByUserId`
    - `IsActive`
  - Enables basic auditability across the system

---

## Solution structure

The repo is organised into separate projects for each layer:

- `CS557DatabasePrj.BL`  
  Business entities and enums:
  - `User`, `Employee`, `Branch`, `Account`, `Card`, `Transaction`, `Deposit`, etc.
  - Common base types like `Entity` and `AuditableEntity`
  - Enums: `AccountType`, `CardType`, `TransactionKind`, `LoanStatus`

- `CS557DatabasePrj.DL`  
  Data access layer using **Dapper**:
  - `BaseRepository` (opens MySQL connections)
  - Repositories:
    - `UserRepository`
    - `EmployeeRepository`
    - `BranchRepository`
    - `AccountRepository`
    - `TransactionRepository`
    - `DepositRepository`
  - Repositories encapsulate CRUD logic and balance updates  
    (e.g. `DepositRepository.InsertAsync` inserts a deposit, updates balance, and writes a `Transaction` inside a transaction scope)

- `CS557DatabasePrj`  
  C# **WinForms** UI:
  - `frmLogin` – login screen using `UserRepository`
  - `frmAddDeposit` – admin deposit entry
  - `FrmViewTransactions` – admin transaction viewer/editor + undo
  - `FrmViewBranches` – branch manager
  - `FrmViewEmployees` – employee manager
  - `FrmViewUsers` – user manager
  - Various other forms for creating/maintaining domain data

- `CS557DatabasePrj.Tests`  
  Placeholder for unit/integration tests.

- `init.sql`  
  Database schema and initial seed data for MySQL.

---

## Technologies

- **Language:** C#  
- **Desktop UI:** Windows Forms  
- **Database:** MySQL or MariaDB  
- **ORM / Data Access:** [Dapper](https://github.com/DapperLib/Dapper)  
- **IDE:** Visual Studio 2022+ (recommended)

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/ChaseMcClellan/CS557DatabasePrj.git
cd CS557DatabasePrj
