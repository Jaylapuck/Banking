using Microsoft.Win32;
using System;

namespace ExtensionClass
{
    public static class ExtensionClass
    {
        public static string GetPercentageChange(this double value)
        {
            string str;
            str = string.Format("{0:0.00}", value);
            return str;
        }

        public static string ToNaMoneyFormat(this double value, bool round)
        {
            double moneyValueRounded = 0;
            string valueChanged;
            switch (round)
            {
                case true:
                    moneyValueRounded = Math.Ceiling(value);
                    valueChanged = ValueUnderOrOver(moneyValueRounded);
                    break;

                case false:
                    moneyValueRounded = Math.Floor(value);
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