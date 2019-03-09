using NetEncrypt;
using NetEncrypt.Decrypt;
using NetEncrypt.Encrypt;
using NetEncrypt.RSACrypto;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //AES
            string key= EncryptProviderKey.GetKeys();
            string data = "我哎祖国c#？";
            Console.WriteLine("数据:{0},Key:{1}", data,key);
            AesEncryptProvider provider = new AesEncryptProvider();
            string result= provider.Encrypt(data, key);
            Console.WriteLine("加密后:{0},Key:{1}", result, key);
            AesDecryptProvider decryptProvider = new AesDecryptProvider();
            result=decryptProvider.Decrypt(result, key);
            Console.WriteLine("解密后:{0},Key:{1}", result, key);
            //
            ManagerKeys.Singleton.GenerateKeys(AppDomain.CurrentDomain.BaseDirectory);
            var keyrsa= ManagerKeys.Singleton.GetRSAKey(AppDomain.CurrentDomain.BaseDirectory);
            ManagerKeys.Singleton.SetKey(null, keyrsa);
            ManagerKeys.Singleton.SaveLocal("d:", keyrsa.PublicKey);
            RsaEncryptProvider rsaEncrypt = new RsaEncryptProvider();
            result= rsaEncrypt.Encrypt(data, keyrsa.PublicKey);
            Console.WriteLine("RSA加密后:{0}", result);
            RsaDecryptProvider rsaDecrypt = new RsaDecryptProvider();
            result = rsaDecrypt.Decrypt(result, keyrsa.PrivateKey);
            Console.WriteLine("RSA解密后:{0}", result);
            //
            RSAParametersKey.CreateKeys(AppDomain.CurrentDomain.BaseDirectory);
            var rsaKey = RSAParametersKey.GetRSAKey(AppDomain.CurrentDomain.BaseDirectory);

            RsaSrvEncryptProvider rsaSrvEncrypt = new RsaSrvEncryptProvider();
            
            result =rsaSrvEncrypt.Encrypt(data, rsaKey.PublicKey);
            Console.WriteLine("RSASRV加密后:{0}", result);
            RsaSrvDecryptProvider rsaSrvDecrypt = new RsaSrvDecryptProvider();
            result = rsaSrvDecrypt.Decrypt(result, rsaKey.PrivateKey);
            Console.WriteLine("RSASRV解密后:{0}", result);
            Console.Read();
        }
    }
}
