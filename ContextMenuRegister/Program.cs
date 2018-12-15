using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextMenuRegister
{
    class Program
    {
        public static string FILE_REGISTRY_PATH = @"*\shell";
        public static string DIRECTORY_REGISTRY_PATH = @"Directory\shell";

        static void Main(string[] args)
        {
            NameValueCollection commands = ConfigUtil.ExtractConfig();
            foreach(string commandName in ConfigUtil.ExtractConfig())
            {
                Register.RegisterKey(FILE_REGISTRY_PATH, commandName, commands.Get(commandName));
                Register.RegisterKey(DIRECTORY_REGISTRY_PATH, commandName, commands.Get(commandName));
            }
            Console.WriteLine("按任意键结束程序");
            Console.ReadKey();
        }
    }
}
