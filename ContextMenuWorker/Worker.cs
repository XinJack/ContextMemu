using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContextMenuWorker
{
    class Worker
    {
        /// <summary>
        /// 复制当前文件名到剪切板
        /// </summary>
        /// <param name="fileName"></param>
        public static void CopyFileNameToClipBoard(string fileName)
        {
            try
            {
                Clipboard.SetDataObject(fileName, true, 3, 100);
            }catch(Exception why)
            {
            }
        }
    }
}
