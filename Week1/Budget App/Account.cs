using System;

namespace BudgetApp {

    abstract class Account {
        
        // Fields
        private string owner;
        private static int accountNumberSeed = 883;
        public int accountNumber { get; set; } 
        /*public void setAccountNumber (int num) {
            if (num == null) {
                //throw new Exception(MessageProcessingHandler: "value cannot be null", paramName: nameOf(ValueTask));
                Console.WriteLine("Exception: Value cannot be null.");
                return;
            }
            this.accountNumber = num;
        }
        */
        protected double balance;

        private List<Transaction> transactionHistory = new List<Transaction>();

        // Constructors
        public Account (string ownerName) {
            this.accountNumber = accountNumberSeed++;
            this.owner = ownerName;
            MakeDeposit(0);
        }

        public Account (string ownerName, double initialBalance) {
            this.accountNumber = accountNumberSeed++;
            this.owner = ownerName;
            MakeDeposit(initialBalance);
        }

        // Methods
        public double getBalance () {
            return this.balance;
        }
        
        public double MakeWithdrawal (double withdrawal, string note = "") {  // Returns balance after withdrawal
            if (withdrawal <= 0) {
                //throw new Exception(MessageProcessingHandler: "cannot withdraw zero or negative dollars", paramName: nameOf(ValueTask));
                Console.WriteLine("Exception: You cannot withdraw a zero or negative amount.");
                return -1.0;
            }
            if (this.balance < withdrawal) {
                //throw new Exception(MessageProcessingHandler: "cannot withdraw more money than in your balance", paramName: nameOf(ValueTask));
                Console.WriteLine("Exception: You cannot withdraw more money than the account has.");
                return -1.0;
            }
            this.balance -= withdrawal;
            Transaction withdrawalTransaction = new Transaction(withdrawal * -1, DateTime.Now, note);
            transactionHistory.Add(withdrawalTransaction);
            return this.balance;
        }

        public double MakeDeposit (double deposit, string note = "") {        // Returns balance after deposist
            if (deposit <= 0) {
                //throw new Exception(MessageProcessingHandler: "cannot deposit zero or negative dollars", paramName: nameOf(ValueTask));
                Console.WriteLine("Exception: You cannot deposit a zero or negative amount.");
                return -1.0;
            }
            this.balance += deposit;
            Transaction depositTransaction = new Transaction(deposit, DateTime.Now, note);
            transactionHistory.Add(depositTransaction);
            return this.balance;
        }      

        // Abstract methods MUST be overridden by a derived class.
        // Virtual methods CAN be overridden by a derived class (not mandatory).
        public virtual string DisplayBalance () {
            return "Account # " + this.accountNumber + " has a balnce of: " + this.balance;
        }  

        public string DisplayTransactionHistory () {
            var history = new System.Text.StringBuilder();
            history.AppendLine("Date\t\tAmount\t\tNote");

            foreach (Transaction item in transactionHistory) {
                history.AppendLine($"{item.date.ToShortDateString()}\t{item.amount}\t{item.note}");
            }
            return history.ToString();
        }

        public void associateAccount (Account associate) {
            return;
        }

    }

}