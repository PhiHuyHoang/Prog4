using prog4_lesson5.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prog4_lesson5.VM
{
    class ViewModel
    {
        // INotifyPropertyChanged => whereever VM changes, send an event        
        public IEnumerable<DirectoryEntry> Entries { get; set; }
        public DirectoryEntry SelectedEntry { get; set; }
        public string CurrentDirectory { get; set; }

        public ICommand SelectEntryCommand { get; private set; }

        public ILogic Logic;

        public ViewModel(ILogic logic, string currentDir)
        {
            this.CurrentDirectory = currentDir;
            this.Logic = logic;
            this.Entries = logic.CollectEntries(currentDir);
            SelectEntryCommand = new RelayCommand((obj) => { logic.OpenEntry(SelectedEntry); });
        }

        public ViewModel(string currentDir) : this(new Logic(), currentDir) { }

        // No zero param ctor can not be created in xaml ... x:arrguments
    }
}
