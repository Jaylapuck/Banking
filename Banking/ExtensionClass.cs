using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionClass
{
    public static class ExtensionClass
    {

        public static string getPercentageChange(double startingBalance, double currentBalance)
        {    
           double  pst = ((currentBalance / startingBalance) * 100);
            string str = String.Format("{0:0.00}", pst);
            return str;
        }
        
        public static string toNaMoneyFormat(bool roundUp, bool roundDown)
        {
            double moneyValue = 0;
            double moneyValueRounded = Math.Round(moneyValue);
            string formattedMoney = string.Format("${0:0.00}", moneyValueRounded);
            return formattedMoney;
        }



    }
}
