using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextMenuWorker
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                return;
            }
            string selectedFilePath = args[0];
            string commandName = args[1];
            switch (commandName)
            {
                case "复制文件路径":
                    Worker.CopyFileNameToClipBoard(selectedFilePath);
                    break;
                default:
                    break;                 
            }
        }
    }
}
