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
        static void Main(string[] args)
        {

            Savings savings = new Savings(5, 0.05);
            Chequings chequings = new Chequings(5, 0.5);
            GlobalSavingsAccount globalSavingsAccount = new GlobalSavingsAccount(5, 0.05);
            string option = null;
            //Bank Menu
            if (option != "Q")
            {
                do
                {
                    Console.WriteLine("Select the Type of Account");
                    Console.WriteLine("A: Savings \n" +
                        "B: Checking \n" +
                        "C: GlobalSavings \n" +
                        "Q: Exit \n");
                    option = Console.ReadLine();

                }
                while (option != "A" && option != "B" && option != "C" && option != "Q");

                switch (option)
                {
                    case "A":
                        do
                        {
                            Console.WriteLine("Select action to do");
                            Console.WriteLine("A: Deposit \n" +
                               "B: Withdrawl \n" +
                               "C: Close + Report \n" +
                               "R: Return to Bank Menu \n");
                            option = Console.ReadLine();
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

                                    break;
                                default:
                                    break;
                            }
                        }
                        while (option != "A" && option != "B" && option != "C" && option != "D" && option != "R");
                        break;
                }
            }

        }
    }
}
        /*
             public static void BankMenu()
             {
                 string option = null;

             }



             private static void GlobalSavingsMenu(GlobalSavingsAccount globalSavingsAccount)
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
                             BankMenu();
                             break;
                         default:
                             break;
                     }
                 }
                 while (option != "A" && option != "B" && option != "C" && option != "D" && option != "R");
             }
             private static void CheckingMenu(Chequings chequings)
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
                     switch (option.ToUpper())
                     {
                         case "A":

                             break;
                         case "B":

                             break;
                         case "C":

                             break;
                         case "R":

                             break;
                         default:
                             break;

                     }
                 }
                 while (option != "A" && option != "B" && option != "C" && option != "R");
             }

             private static void SavingsMenu(Savings savings)
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

                             break;
                         default:
                             break;

                     }
                 }
                 while (option != "A" && option != "B" && option != "C" && option != "R");
             }
         }
        
    }
*/
