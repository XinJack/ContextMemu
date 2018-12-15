using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextMenuRegister
{
    /// <summary>
    /// 注册工具类
    /// </summary>
    class Register
    {
        public static string DEFAULT_WORKER_DIRECTORY = "worker";

        /// <summary>
        /// 注册命令到右键菜单
        /// </summary>
        /// <param name="commandName">命令名</param>
        /// <param name="workerPath">处理程序路径</param>
        public static void RegisterKey(string commandName, string workerName)
        {
            RegistryKey shellKey = null;
            RegistryKey workerKey = null;
            RegistryKey commandKey = null;
            try
            {
                shellKey = Registry.ClassesRoot.OpenSubKey(@"*\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                if (shellKey == null)
                {
                    shellKey = Registry.ClassesRoot.CreateSubKey(@"*\shell");
                }
                workerKey = shellKey.OpenSubKey(commandName);
                if(workerKey != null)
                {
                    Console.WriteLine(string.Format("右键命令【{0}】已存在", commandName));
                }else
                {
                    workerKey = shellKey.CreateSubKey(commandName);
                    workerKey.SetValue(string.Empty, commandName);
                    workerKey.SetValue("MultiSelectModel", "Single");
                    commandKey = workerKey.CreateSubKey("command");
                    string workerPath = Path.Combine(System.Environment.CurrentDirectory, DEFAULT_WORKER_DIRECTORY, workerName);
                    commandKey.SetValue(string.Empty, string.Format("\"{0}\" \"%1\" \"{1}\"", workerPath, commandName));
                    Console.WriteLine(string.Format("添加右键菜单命令[{0}]成功", commandName));
                }
            }
            catch (Exception why)
            {
                Console.WriteLine(string.Format("无法添加右键菜单命令：{0}", why.Message));
            }
            finally
            {
                if (commandKey != null) commandKey.Close();
                if (workerKey != null) workerKey.Close();
                if (shellKey != null) shellKey.Close();
            }
        }
    }
}
