using System;
// Prompt the user to enter the initial budget
// Prompt the user to enter expenses with amount and description
// Display the all expenses and the remaining amount

namespace BudgetApp{

    class Program {

        public static void Main (string[] args) {

            Account firstAccount = new SavingsAccount("Orb", 1000);
            Account secondAccount = new SavingsAccount("Slab", 4000);
            Account thirdAccount = new SavingsAccount("Heagle", 2400);

            Console.WriteLine(firstAccount.DisplayBalance());
            Console.WriteLine(secondAccount.DisplayBalance());
            Console.WriteLine(thirdAccount.DisplayBalance());

            secondAccount.MakeDeposit(500);

            Console.WriteLine(secondAccount.DisplayBalance());

        }

    }

}