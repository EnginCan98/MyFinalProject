using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)    //saltı ve hash i üretmek için out kullandık.out keywordleri gönderilen data boş bile olsa doldurur ve geri döndürür.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;         //algoritmanın o an oluşturduğu key.her kullanıcı için ayrı key tutar.oldukça güvenlidir
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));             //password un byte değeri.Encoding ile byte değeri bulunur.
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)      //burda değerleri kendimiz verdiğimiz için out yok.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
