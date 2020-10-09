using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class InputCoverter
    {
        public double ConvertedInputToNumeric(string argTextInput) => double.TryParse(argTextInput, out double converteNumber) ? converteNumber :
       throw new ArgumentException("Numeric value expected");
    }
}
