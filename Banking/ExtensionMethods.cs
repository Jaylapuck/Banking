using Banking;
using Microsoft.Win32;
using System;

namespace ExtensionClass
{
    public static class ExtensionClass
    {
        internal static string GetPercentageChange(this Account ac)
        {
            double percentageChange = ((ac.balance - ac.StartingBalance) / ac.StartingBalance) * 100;

            string newPercentage = percentageChange.ToString();

            return newPercentage;
        }

        public static string ToNaMoneyFormat(this double value, bool round)
        {
            string valueChanged;
            double moneyValueRounded;
            switch (round)
            {
                case true:
                    moneyValueRounded = Math.Ceiling(value * 100) / 100;
                    valueChanged = ValueUnderOrOver(moneyValueRounded);
                    break;

                case false:
                    moneyValueRounded = Math.Floor(value * 100) / 100;
                    valueChanged = ValueUnderOrOver(moneyValueRounded);
                    break;

                default:
                    valueChanged = "An error just occured. not a double";
                    break;
            }

            return valueChanged;
        }

        public static string ValueUnderOrOver(double value)
        {
            string formattedMoney = null;
            if (value < 0)
            {
                value *= -1;
                formattedMoney = string.Format("(${0:0.00})", value);
            }
            else if (value > 0)
            {
                formattedMoney = string.Format("${0:0.00}", value);
            }
            return formattedMoney;
        }
    }
}