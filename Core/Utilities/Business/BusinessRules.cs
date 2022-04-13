using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)   //params: istediğimiz kadar parametre geçebilmemizi sağlar.Gönderilen parametreleri array haline getirir ve açtığımız array in içine atar.
        {
            foreach (var logic in logics)
            {
                if (!logic.Succes)               //başarısız ise(!)
                {
                    return logic;                //kurala uymayanı dündürüyoruz.
                }
            }

            return null;
        }
    }
}
