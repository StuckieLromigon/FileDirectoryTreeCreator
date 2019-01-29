using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileDirectoryTreeCreator
{
    class EnterTheDirectory
    {
        public string EnterData()
        {
            Console.WriteLine("Please, enter path to root directory");
            bool validationFailed = true;
            string dataEntry = "";
            while (validationFailed)
            {
                dataEntry = Console.ReadLine();
                validationFailed = false;
                try
                {
                    var files = new DirectoryInfo(dataEntry).GetFiles();
                }
                catch
                {
                    validationFailed = true;
                    Console.WriteLine("you enter wrong root path, please enter again");
                }
            }
            return dataEntry;
        }
    }
}
