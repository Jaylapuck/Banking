using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class Program
    {
        public static Savings savings = new Savings(5, 0.05);
        public static Chequings chequings = new Chequings(5, 0.5);
        public static GlobalSavingsAccount globalSavingsAccount = new GlobalSavingsAccount(5, 0.05);
        public static InputCoverter inputCoverter = new InputCoverter();
        public static double input;
        public static string output = "0";
                    
        static void Main(string[] args)
        {

            BankMenu(savings, chequings, globalSavingsAccount);
        }

        public static void BankMenu(Savings savings, Chequings chequings, GlobalSavingsAccount globalSavingsAccount)
        {
            string option = null;

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
                    Console.WriteLine("NOT VALID OPTION");
                    BankMenu(savings, chequings, globalSavingsAccount);
                    break;
            }



        }

        private static void GlobalSavingsMenu()
        {
            
            string option = null;


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
                    Console.WriteLine("Enter Desired Deposit Amount :" );
                    isNumber();
                    double depositAmount;
                    depositAmount = inputCoverter.ConvertedInputToNumeric(output);
                    globalSavingsAccount.MakeDeposit(depositAmount);
                    GlobalSavingsMenu();
                    break;
                case "B":
                    Console.WriteLine("Enter Desired Withdrawl Amount :");
                    isNumber();
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
                    globalSavingsAccount.USvalue(0.75);
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

            string option = null;

       
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
                    isNumber();
                    double depositAmount;
                    depositAmount = inputCoverter.ConvertedInputToNumeric(output);
                    chequings.MakeDeposit(depositAmount);
                    CheckingMenu();
                    break;
                case "B":
                    Console.WriteLine("Enter Desired Withdrawl Amount :");
                    isNumber();
                    double withdrawlAmount;
                    withdrawlAmount = inputCoverter.ConvertedInputToNumeric(output);
                    chequings.MakeWithdrawl(withdrawlAmount);
                    CheckingMenu();
                    break;
                case "C":
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

            string option = null;

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
                    isNumber();
                    double depositAmount;
                    depositAmount = inputCoverter.ConvertedInputToNumeric(output);
                    savings.MakeDeposit(depositAmount);
                    SavingsMenu();
                    break;
                case "B":
                    Console.WriteLine("Enter Desired Withdrawl Amount :");
                    isNumber();
                    double withdrawlAmount;
                    withdrawlAmount = inputCoverter.ConvertedInputToNumeric(output);
                    savings.MakeWithdrawl(withdrawlAmount);
                    SavingsMenu();
                    break;
                case "C":
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

        private static void isNumber()
        {
            while (!double.TryParse(Console.ReadLine(), out input))
                Console.WriteLine("The value must be a number, please try again, try a number from 1 to 10 for example");
            output = input.ToString();
        }
    }
}









