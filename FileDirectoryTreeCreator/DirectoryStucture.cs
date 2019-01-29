using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDirectoryTreeCreator
{
    class DirectoryStucture
    {
        public DirectoryNode Root { get; set; }
        public DirectoryStucture(string path)
        {
            Root = new DirectoryNode(0);
            Root.Name = path;
            Root.Files = new List<string>();
            Root.Folders = new List<DirectoryNode>();
        }
    }
}
