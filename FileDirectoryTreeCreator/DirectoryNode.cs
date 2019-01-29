using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDirectoryTreeCreator
{
    class DirectoryNode
    {
        public string Name { get; set; }
        public List<DirectoryNode> Folders { get; set; }
        public List<string> Files { get; set; }
        public int DeepLevel { get; set; }

        public DirectoryNode(int level)
        {
            DeepLevel = level;
        }

        public void Show()
        {
            for (int j = 0; j < Files?.Count; j++)
            {
                Indent(DeepLevel);
                Console.WriteLine(Files[j]);
            }
            if (Folders == null)
                return;
            foreach(var el in Folders)
            {

                Indent(DeepLevel);
                Console.WriteLine();
                Indent(DeepLevel);
                Console.WriteLine("FOLDER - " + el.Name);
                Console.WriteLine("Inner Structure =>");
                Console.WriteLine();
                el.Show();
            }

        }
        private static void Indent(int distance)
        {
            for (int i = 0; i < distance; i++)
                Console.Write("/");
        }
    }
}
