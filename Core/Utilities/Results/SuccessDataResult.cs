using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T> 
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)  //tüm bilgileri verdiği versiyonu.
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        public SuccessDataResult(string message) : base(default, true, message)  //T nin defaultu.Bir şey döndürmek istemezsek kullanacağız.
        {                                                                      

        }
        public SuccessDataResult() : base(default, true)                         //buda mesajsız versiyon.
        {

        }
    }
}
