#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：CryptoStruct
* 项目描述 ：
* 类 名 称 ：TaskResult
* 类 描 述 ：
* 命名空间 ：CryptoStruct
* CLR 版本 ：4.0.30319.42000
* 作    者 ：jinyu
* 创建时间 ：2019/3/9 15:20:42
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ jinyu 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion


namespace CryptoStruct
{
    /* ============================================================================== 
* 功能描述：TaskResult 
* 创 建 者：jinyu 
* 创建日期：2019 
* 更新时间 ：2019
* ==============================================================================*/
    public struct TaskResult
    {

        /// <summary>
        /// 任务ID
        /// </summary>
        public int TaskID { get; set; }

        /// <summary>
        /// 分配的SessionID
        /// </summary>
        public long Session { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        public ResultCode Code { get; set; }

        /// <summary>
        ///返回结构
        /// </summary>
        public byte[] Reslut { get; set; }

    }
}
