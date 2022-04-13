using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>          //T:Çalışacağı tipi çalışırken söylemek için.T için IDataResult implamantasyonu.
    {                                                            
        public DataResult(T data, bool success, string massage) : base(success, massage) //result void'ler için bunda data da olduğu için T data eklenir.
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)   //mesajı göndermek istemediğimiz senaryo için.
        {
            Data = data;    //data'yı set ettik.
        }
        public T Data { get; }
    }
}
