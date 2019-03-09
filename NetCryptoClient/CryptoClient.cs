#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：NetCryptoClient
* 项目描述 ：
* 类 名 称 ：CryptoClient
* 类 描 述 ：
* 命名空间 ：NetCryptoClient
* CLR 版本 ：4.0.30319.42000
* 作    者 ：jinyu
* 创建时间 ：2019/3/8 23:38:22
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ jinyu 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion


using CryptoStruct;
using NetEncrypt;
using NetEncrypt.Encrypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetCryptoClient
{
    /* ============================================================================== 
* 功能描述：CryptoClient 
* 创 建 者：jinyu 
* 创建日期：2019 
* 更新时间 ：2019
* ==============================================================================*/
   public class CryptoClient
    {
  

        /// <summary>
        /// 默认授权请求
        /// </summary>
        public void  Request()
        {
            HashEncryptProvider provider = new HashEncryptProvider();
            ClientLoginRequest request = new ClientLoginRequest();
            request.Version = 1;
            request.ReqTime = DateTime.Now.Ticks;
            request.Limit = 0;
            request.LastTime = 0;
            request.HashCode = provider.Encrypt(CipherReply.RequestInfo);
        }

        /// <summary>
        /// 文件授权
        /// </summary>
        /// <param name="file"></param>
        public void RequestFile(string file)
        {
            HashEncryptProvider provider = new HashEncryptProvider();
            ClientLoginRequest request = new ClientLoginRequest();
            request.Version = 1;
            request.ReqTime = DateTime.Now.Ticks;
            request.Limit = 0;
            FileStream fs = new  FileStream(file, FileMode.Open, FileAccess.Read);
            var result=provider.Encrypt(fs);
            request.HashCode = Convert.ToBase64String(result);
        }

        
        public void  Send(byte[] data)
        {
            //数据加密
            AesEncryptProvider aesEncrypt = new AesEncryptProvider();
            RsaSrvEncryptProvider rsaSrvEncrypt = new RsaSrvEncryptProvider();
            //AES加密数据
            var  aesencrypt= aesEncrypt.Encrypt(data, CipherReply.Singleton.AESKeys);
            //RSA加密AES秘钥
            var keycrypt =Encoding.UTF8.GetBytes(rsaSrvEncrypt.Encrypt(CipherReply.Singleton.AESKeys, CipherReply.Singleton.RSAPublicKeys));//
            //组包
            ArraySegment<byte> buf;
            BufferPool.Singleton.TryGet(out buf, aesencrypt.Length + keycrypt.Length + 8);
            Array.Copy(BitConverter.GetBytes(buf.Count),0,buf.Array,buf.Offset,4);
            Array.Copy(BitConverter.GetBytes(aesencrypt.Length), 0, buf.Array, buf.Offset+4, 4);
            Array.Copy(aesencrypt, 0, buf.Array, buf.Offset +8, aesencrypt.Length);
            Array.Copy(keycrypt, 0, buf.Array, buf.Offset + 8+aesencrypt.Length, keycrypt.Length);

            //网络发送
        }
    }
}
