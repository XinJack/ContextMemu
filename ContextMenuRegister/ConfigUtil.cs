using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextMenuRegister
{
    /// <summary>
    /// 配置辅助类
    /// </summary>
    class ConfigUtil
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public static NameValueCollection ExtractConfig()
        {
            return ConfigurationManager.AppSettings;
        }
    }
}
