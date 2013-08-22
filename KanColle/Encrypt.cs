using System;
using System.Security.Cryptography;
using System.Text;
namespace KanColle
{
    internal class Encrypt
    {
        private static string _password = "A7D700B5FF3A7C7BED92D6F622A0802099E4CED04D96ABD0542B823EED82D1C51DB87FE1AE5CC09EA97B7C20DE919A64479CAA6DF9B314192318B5F4A40AF56C8475E76ED9C9D0EA92635B44B8B03B8FE630DDFF3F7B2BFB4C977CDDC675B1B0F6562E80B46C7D580DAA52D022D2AE55D3399FD068FD1882275C288DC61C63E724F7C0F3F068503A9528269A036365511598803E97A09654C562840DC180F2B039AF9F1BE2964A38AE2CA7F19D489C76E9C9D97318A3DA6FBC5EE2016CFABE34C51C1975093BD4B4F38E98DBB8EFD51034CB399FFC6CA357FC4A0B91A30A7C31F2831285BC20F098B7AECA96B42A3C2164FAB92A9D0A342BFCBC42601BD9ADCE";
        
        public static string EncryptString(string sourceString)
        {
            if (sourceString == "null")
            {
                return "null";
            }

            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            byte[] key;
            byte[] iV;

            Encrypt.GenerateKeyFromPassword(Encrypt._password, rijndaelManaged.KeySize, out key, rijndaelManaged.BlockSize, out iV);

            rijndaelManaged.Key = key;
            rijndaelManaged.IV = iV;

            byte[] bytes = Encoding.UTF8.GetBytes(sourceString);
            ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor();
            byte[] inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
            cryptoTransform.Dispose();
            
            return Convert.ToBase64String(inArray);
        }

        public static string DecryptString(string sourceString)
        {
            if (sourceString == "null")
            {
                return "null";
            }

            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            byte[] key;
            byte[] iV;

            Encrypt.GenerateKeyFromPassword(Encrypt._password, rijndaelManaged.KeySize, out key, rijndaelManaged.BlockSize, out iV);

            rijndaelManaged.Key = key;
            rijndaelManaged.IV = iV;

            byte[] array = Convert.FromBase64String(sourceString);
            ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor();
            byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);

            cryptoTransform.Dispose();
            return Encoding.UTF8.GetString(bytes);
        }

        private static void GenerateKeyFromPassword(string password, int keySize, out byte[] key, int blockSize, out byte[] iv)
        {
            byte[] bytes = Encoding.UTF8.GetBytes("saltは必ず8バイト以上");
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, bytes);
            rfc2898DeriveBytes.IterationCount = 1000;
            key = rfc2898DeriveBytes.GetBytes(keySize / 8);
            iv = rfc2898DeriveBytes.GetBytes(blockSize / 8);
        }
    }
}