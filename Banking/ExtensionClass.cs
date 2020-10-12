using System;

namespace ExtensionClass
{
    public static class ExtensionClass
    {
        public static string GetPercentageChange(this double percentage)
        {
            string str = String.Format("0:0.00%");
            return str;
        }

        public static string ToNaMoneyFormat(this bool roundUp, bool roundDown)
        {
            double moneyValue = 0;
            double moneyValueRounded = Math.Round(moneyValue);
            string formattedMoney = string.Format("${0:0.00}", moneyValueRounded);
            return formattedMoney;
        }
    }
}