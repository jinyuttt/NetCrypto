#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：CryptoStruct
* 项目描述 ：
* 类 名 称 ：DataProtocol
* 类 描 述 ：
* 命名空间 ：CryptoStruct
* CLR 版本 ：4.0.30319.42000
* 作    者 ：jinyu
* 创建时间 ：2019/3/9 10:06:28
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ jinyu 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion


using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoStruct
{
    /* ============================================================================== 
* 功能描述：DataProtocol 
* 创 建 者：jinyu 
* 创建日期：2019 
* 更新时间 ：2019
* ==============================================================================*/
   public struct TCPData
    {
        //TCP只是解决粘包问题
        public int PackLen;
        public int DataLen;
        public byte[] data;
    }

    public struct UDPData
    {
        //UDP解决分包，包乱序问题
        public int PackLen;//总包大小
        public int PackID;//包ID
        public Subpacket[] Data;//包序号
    }

    public struct Subpacket
    {
        //子包
        public int id;
        public int Len;
        public byte[] data;
    }

}
