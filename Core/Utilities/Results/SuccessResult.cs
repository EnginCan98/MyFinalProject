using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)  //buradaki base result içindeki constructor u çalıştırır.
        {

        }

        public SuccessResult(): base(true)
        {

        }

    }
}
