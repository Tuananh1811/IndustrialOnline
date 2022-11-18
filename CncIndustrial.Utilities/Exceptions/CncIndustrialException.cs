using System;
using System.Collections.Generic;
using System.Text;

namespace CncIndustrial.Utilities.Exceptions
{
   public class CncIndustrialException : Exception
    {
        public CncIndustrialException()
        {
        }

        public CncIndustrialException(string message)
            : base(message)
        {
        }

        public CncIndustrialException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
