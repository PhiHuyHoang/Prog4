using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog4_lesson5.BL
{
    interface ILogic
    {
        IEnumerable<DirectoryEntry> CollectEntries(string startDir);
        void OpenEntry(DirectoryEntry entry);
        //List isn't included IList 
    }
}
