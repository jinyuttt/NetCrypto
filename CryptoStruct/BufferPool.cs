#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：CryptoStruct
* 项目描述 ：
* 类 名 称 ：BufferPool
* 类 描 述 ：
* 命名空间 ：CryptoStruct
* CLR 版本 ：4.0.30319.42000
* 作    者 ：jinyu
* 创建时间 ：2019/3/9 14:16:36
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ jinyu 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion


using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CryptoStruct
{
    /* ============================================================================== 
* 功能描述：BufferPool 
* 创 建 者：jinyu 
* 创建日期：2019 
* 更新时间 ：2019
* ==============================================================================*/
  public  class BufferPool
    {
        static Lazy<BufferPool> instance = new Lazy<BufferPool>();
        private const int MaxSize = 100;//M
        private readonly byte[] Buffer = new byte[1024 * 1024 * MaxSize];
        private int index = 0;
        public static BufferPool Singleton
        {
            get { return instance.Value; }
        }
        public  bool TryGet(out ArraySegment<byte> buf,int len)
        {
            buf = new ArraySegment<byte>(Buffer, index, len);
            return true;
        }

        public void Free(ArraySegment<byte> buf)
        {

        }
    }
}
