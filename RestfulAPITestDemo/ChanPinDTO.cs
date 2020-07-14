using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestfulAPITestDemo
{
    public class ChanPinDTO
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ChanPinMc { get; set; }
        /// <summary>
        /// 网关路径
        /// </summary>
        public string WangGuanLj { get; set; }
        /// <summary>
        /// GIT服务器
        /// </summary>
        public string GitFuWuQ { get; set; }
        /// <summary>
        /// 群组名称
        /// </summary>
        public string QunZuMc { get; set; }

        /// <summary>
        /// 产品标识
        /// </summary>
        /// <value></value>
        public string ChanPinBS { get; set; }

        /// <summary>
        /// GIT用户名
        /// </summary>
        public string GitYongHuM { get; set; }
        /// <summary>
        /// GIT密码
        /// </summary>
        public string GitMiMa { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 产品负责人
        /// </summary>
        public string ChanPinFZR { get; set; }
        /// <summary>
        /// 产品负责人姓名
        /// </summary>
        public string ChanPinFZRXM { get; set; }
        /// <summary>
        /// 开发负责人
        /// </summary>
        public string KaiFaFZR { get; set; }
        /// <summary>
        /// 开发负责人姓名
        /// </summary>
        public string KaiFaFZRXM { get; set; }
        /// <summary>
        /// 体验负责人
        /// </summary>
        public string TiYanFZR { get; set; }
        /// <summary>
        /// 体验负责人姓名
        /// </summary>
        public string TiYanFZRXM { get; set; }
        /// <summary>
        /// 测试负责人
        /// </summary>
        public string CeShiFZR { get; set; }
        /// <summary>
        /// 测试负责人姓名
        /// </summary>
        public string CeShiFZRXM { get; set; }
    }
}
