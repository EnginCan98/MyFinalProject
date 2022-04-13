using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)  //tüm bilgileri verdiği versiyonu.
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)  //T nin defaultu.Bir şey döndürmek istemezsek kullanacağız.
        {

        }
        public ErrorDataResult() : base(default, false)                        //buda mesajsız versiyon.
        {

        }
    }
}
