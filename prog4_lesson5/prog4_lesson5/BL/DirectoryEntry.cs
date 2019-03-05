using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog4_lesson5.BL
{
    class DirectoryEntry
    {
        public string Name { get; set; }
        public bool isDir { get; set; }

        public DirectoryEntry(string name, bool isDir)
        {
            this.Name = name;
            this.isDir = isDir;
        }

        public override string ToString()
        {
            return isDir ? $"[{Name}]" : Name;
        }

    }
}
