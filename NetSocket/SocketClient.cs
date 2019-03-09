#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：NetSocket
* 项目描述 ：
* 类 名 称 ：SocketClient
* 类 描 述 ：
* 命名空间 ：NetSocket
* CLR 版本 ：4.0.30319.42000
* 作    者 ：jinyu
* 创建时间 ：2019/3/9 12:27:32
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ jinyu 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion


using System.Net.Sockets;

namespace NetSocket
{
    /* ============================================================================== 
* 功能描述：SocketClient 
* 创 建 者：jinyu 
* 创建日期：2019 
* 更新时间 ：2019
* ==============================================================================*/
    public class SocketTCPClient
    {
        private Socket socket = null;
        public SocketTCPClient(string host,int port)
        {
            socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        }

        public void Connect(string host,int port)
        {
            socket.Connect(host, port);
        }

        public void Send(byte[] data,int offset=0,int len=-1)
        {
            if(len==-1)
            {
                len = data.Length;
            }
            socket.Send(data,offset,len,SocketFlags.None);
        }

        public void Rec()
        {
            byte[] buf = new byte[1024];
            socket.Receive(buf, SocketFlags.None);
        }
    }
}
