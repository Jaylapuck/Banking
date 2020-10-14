using System;
using ExtensionClass;

namespace Banking
{
    internal class Program
    {
        private static Savings savings = new Savings(5, 0.05);
        private static Chequings chequings = new Chequings(5, 0.05);
        private static GlobalSavingsAccount globalSavingsAccount = new GlobalSavingsAccount(5, 0.05);
        private static InputCoverter inputCoverter = new InputCoverter();
        private static double input;
        private static string output = "0";
        private static string option;

        private static void Main(string[] args)
        {
            BankMenu(savings, chequings, globalSavingsAccount);
        }

        private static void BankMenu(Savings savings, Chequings chequings, GlobalSavingsAccount globalSavingsAccount)
        {
            Console.WriteLine("Select the Type of Account");
            Console.WriteLine("A: Savings \n" +
                "B: Checking \n" +
                "C: GlobalSavings \n" +
                "Q: Exit \n");
            option = Console.ReadLine();
            option = option.ToUpper();

            switch (option.ToUpper())
            {
                case "A":
                    SavingsMenu();
                    break;

                case "B":
                    CheckingMenu();
                    break;

                case "C":
                    GlobalSavingsMenu();

                    break;

                case "Q":

                    break;

                default:
                    Console.WriteLine("NOT A VALID OPTION");
                    BankMenu(savings, chequings, globalSavingsAccount);
                    break;
            }
        }

        private static void GlobalSavingsMenu()
        {
            Console.WriteLine("Select action to do");
            Console.WriteLine("A: Deposit \n" +
               "B: Withdrawl \n" +
               "C: Close + Report \n" +
               "D: Report Balance in USD \n" +
               "R: Return to Bank Menu \n");
            option = Console.ReadLine();
            option = option.ToUpper();

            switch (option.ToUpper())
            {
                case "A":
                    Console.WriteLine("Enter Desired Deposit Amount :");
                    IsNumber();
                    double depositAmount;
                    depositAmount = inputCoverter.ConvertedInputToNumeric(output);
                    globalSavingsAccount.MakeDeposit(depositAmount);
                    GlobalSavingsMenu();
                    break;

                case "B":
                    Console.WriteLine("Enter Desired Withdrawl Amount :");
                    IsNumber();
                    double withdrawlAmount;
                    withdrawlAmount = inputCoverter.ConvertedInputToNumeric(output);
                    globalSavingsAccount.MakeWithdrawl(withdrawlAmount);
                    GlobalSavingsMenu();
                    break;

                case "C":
                    Console.WriteLine(globalSavingsAccount.CloseAndReport());
                    GlobalSavingsMenu();
                    break;

                case "D":
                    Console.WriteLine("Percentage Change: " + globalSavingsAccount.GetPercentageChange() + "%");
                    Console.WriteLine("US value: " + globalSavingsAccount.USvalue(0.75) + "\n");
                    GlobalSavingsMenu();

                    break;

                case "R":
                    BankMenu(savings, chequings, globalSavingsAccount);
                    break;

                default:
                    Console.WriteLine("NOT VALID OPTION");
                    GlobalSavingsMenu();
                    break;
            }
        }

        private static void CheckingMenu()
        {
            Console.WriteLine("Select action to do");
            Console.WriteLine("A: Deposit \n" +
               "B: Withdrawl \n" +
               "C: Close + Report \n" +
               "R: Return to Bank Menu \n");
            option = Console.ReadLine();
            option = option.ToUpper();

            switch (option.ToUpper())
            {
                case "A":
                    Console.WriteLine("Enter Desired Deposit Amount :");
                    IsNumber();
                    double depositAmount;
                    depositAmount = inputCoverter.ConvertedInputToNumeric(output);
                    chequings.MakeDeposit(depositAmount);
                    CheckingMenu();
                    break;

                case "B":
                    Console.WriteLine("Enter Desired Withdrawl Amount :");
                    IsNumber();
                    double withdrawlAmount;
                    withdrawlAmount = inputCoverter.ConvertedInputToNumeric(output);
                    chequings.MakeWithdrawl(withdrawlAmount);
                    CheckingMenu();
                    break;

                case "C":
                    Console.WriteLine("Percentage Change: " + chequings.GetPercentageChange() + "%");
                    Console.WriteLine(chequings.CloseAndReport());
                    CheckingMenu();
                    break;

                case "R":
                    BankMenu(savings, chequings, globalSavingsAccount);
                    break;

                default:
                    Console.WriteLine("NOT VALID OPTION");
                    CheckingMenu();
                    break;
            }
        }

        private static void SavingsMenu()
        {
            Console.WriteLine("Select action to do");
            Console.WriteLine("A: Deposit \n" +
               "B: Withdrawl \n" +
               "C: Close + Report \n" +
               "R: Return to Bank Menu \n");
            string option = Console.ReadLine();
            option = option.ToUpper();

            switch (option.ToUpper())
            {
                case "A":
                    Console.WriteLine("Enter Desired Deposit Amount :");
                    IsNumber();
                    double depositAmount;
                    depositAmount = inputCoverter.ConvertedInputToNumeric(output);
                    savings.MakeDeposit(depositAmount);
                    SavingsMenu();
                    break;

                case "B":
                    Console.WriteLine("Enter Desired Withdrawl Amount :");
                    IsNumber();
                    double withdrawlAmount;
                    withdrawlAmount = inputCoverter.ConvertedInputToNumeric(output);
                    savings.MakeWithdrawl(withdrawlAmount);
                    SavingsMenu();
                    break;

                case "C":
                    Console.WriteLine("Percentage Change: " + savings.GetPercentageChange() + "%");
                    Console.WriteLine(savings.CloseAndReport());
                    SavingsMenu();
                    break;

                case "R":
                    BankMenu(savings, chequings, globalSavingsAccount);
                    break;

                default:
                    Console.WriteLine("NOT VALID OPTION");
                    SavingsMenu();
                    break;
            }
        }

        private static void IsNumber()
        {
            while (!double.TryParse(Console.ReadLine(), out input))
                Console.WriteLine("The value must be a number, please try again, try a number from 1 to 10 for example");
            output = input.ToString();
        }
    }
}