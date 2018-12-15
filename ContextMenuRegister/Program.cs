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
        static void Main(string[] args)
        {
            NameValueCollection commands = ConfigUtil.ExtractConfig();
            foreach(string commandName in ConfigUtil.ExtractConfig())
            {
                Register.RegisterKey(commandName, commands.Get(commandName));
            }
            Console.WriteLine("按任意键结束程序");
            Console.ReadKey();
        }
    }
}
