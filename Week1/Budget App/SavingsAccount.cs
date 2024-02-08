namespace BudgetApp {

    class SavingsAccount : Account {

        private double interestRate;

        public SavingsAccount (string ownerName, double initialBalance, double interestRate = .01) : base (owner, initialBalance) {
            this.interestRate = interestRate;
        }

        public override string DisplayBalance () {
            return ("From SavingsAccount: " +  base.DisplayBalance());
        }

    }

}