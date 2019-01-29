using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDirectoryTreeCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            EnterTheDirectory enter = new EnterTheDirectory();
            var fd = new FileDirectoryDiver(enter.EnterData());
            fd.CreateDirectoryFile();
        }
    }
}
