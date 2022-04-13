using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult   //product service'de voidleri result ile döndürdük fakat listelerdeki dataları döndüremedik.
    {                                           //bu dataları result da döndürmek mantıksız çümkü oraya data eklemek gerekir bunu için ve çoğu result data kullanmıyor.
        T Data { get; }                          //bu yüzden data result açtık ve listeleri bunla döndürdük.Bu sistem hem işlem sonucunu hem mesajı hemde döndüreceği listeyi içeren yapı.Mesajla işlem sonucu IResultda var zaten data eklendi.İnterfaceler bu şekilde implemente edilir.
    }                                            
}
