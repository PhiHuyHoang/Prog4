using System;
using System.Collections.Generic;
using System.IO;

namespace prog4_lesson5.BL
{
    class Logic : ILogic
    {
        public IEnumerable<DirectoryEntry> CollectEntries(string startDir)
        {

            List<DirectoryEntry> output = new List<DirectoryEntry>();
            if (startDir == null)
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    output.Add(new DirectoryEntry(drive.Name, true));
                }
            }
            else
            {
                try
                {
                    foreach (string dir in Directory.GetDirectories(startDir))
                    {
                        output.Add(new DirectoryEntry(dir, true));
                    }
                    foreach (string dir in Directory.GetFiles(startDir))
                    {
                        output.Add(new DirectoryEntry(dir, false));
                    }
                }
                catch (Exception) { }
            }
            return output;
        }

        public void OpenEntry(DirectoryEntry entry)
        {
            if (entry == null) return;
            if (entry.isDir)
            {
                MainWindow win = new MainWindow(entry.Name);
                win.ShowDialog();
            }
            else
            {
                System.Diagnostics.Process.Start(entry.Name);
            }
        }
    }
}