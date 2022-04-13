using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);   //kullanıcı adı ve şifre yazıldığında eğer doğru ise bu operasyon çalışır.User için veri tabanından claimlerini bulucak, token üretecek, ve bunu verecek.
    }
}
