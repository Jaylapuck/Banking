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
        static void Main(string[] args)
        {

            string option = null;
            BankMenu(savings, chequings, globalSavingsAccount);
        }

        public static void BankMenu(Savings savings, Chequings chequings, GlobalSavingsAccount globalSavingsAccount)
        {
            string option = null;
            do
            {
                Console.WriteLine("Select the Type of Account");
                Console.WriteLine("A: Savings \n" +
                    "B: Checking \n" +
                    "C: GlobalSavings \n" +
                    "Q: Exit \n");
                option = Console.ReadLine();
                option = option.ToUpper();

            }
            while (option != "A" && option != "B" && option != "C" && option != "Q");

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
                    break;
            }


            
        }

        private static void GlobalSavingsMenu()
        {

            string option = null;

            do
            {
                Console.WriteLine("Select action to do");
                Console.WriteLine("A: Deposit \n" +
                   "B: Withdrawl \n" +
                   "C: Close + Report \n" +
                   "D: Report Balance in USD \n" +
                   "R: Return to Bank Menu \n");
                option = Console.ReadLine();
                option = option.ToUpper();
            }
            while (option != "A" && option != "B" && option != "C" && option != "D" && option != "R");
            switch (option.ToUpper())
                {
                    case "A":
                        
                        break;
                    case "B":

                        break;
                    case "C":

                        break;
                    case "D":

                        break;
                    case "R":
                        BankMenu(savings, chequings, globalSavingsAccount);
                        break;
                    default:
                        break;
                }
            
        }

        private static void CheckingMenu()
        {

            string option = null;

            do
            {
                Console.WriteLine("Select action to do");
                Console.WriteLine("A: Deposit \n" +
                   "B: Withdrawl \n" +
                   "C: Close + Report \n" +
                   "R: Return to Bank Menu \n");
                option = Console.ReadLine();
                option = option.ToUpper();
            }
            while (option != "A" && option != "B" && option != "C" && option != "R");
            switch (option.ToUpper())
                {
                    case "A":

                        break;
                    case "B":

                        break;
                    case "C":

                        break;
                    case "R":
                        BankMenu(savings, chequings, globalSavingsAccount);
                        break;
                    default:
                        break;

                }
            
        }

        private static void SavingsMenu()
        {

            string option = null;

            do
            {
                Console.WriteLine("Select action to do");
                Console.WriteLine("A: Deposit \n" +
                   "B: Withdrawl \n" +
                   "C: Close + Report \n" +
                   "R: Return to Bank Menu \n");
                option = Console.ReadLine();
                option = option.ToUpper();
            }
            while (option != "A" && option != "B" && option != "C" && option != "R");
            switch (option.ToUpper())
                {
                    case "A":

                        break;
                    case "B":

                        break;
                    case "C":

                        break;
                    case "D":

                        break;
                    case "R":
                        BankMenu(savings, chequings, globalSavingsAccount);
                        break;
                    default:
                        break;

                }
            
        }
    }
}
        
             



            
        
    

