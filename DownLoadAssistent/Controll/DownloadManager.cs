using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using DownLoadAssistent.Commands;

namespace DownLoadAssistent
{
    class DownloadManager
    {
        public ObservableCollection<ConfigFolderNamePair> folderPairs = new ObservableCollection<ConfigFolderNamePair>();

        public DeleteCommand DeleteCommand { set; get; }
        public NewElement NewCommand { set; get; }

        public List<ConfigFolderNamePair> SelectedFolderPairs = new List<ConfigFolderNamePair>();

        static readonly object FolderPairListLock = new object();

        public DownloadManager()
        {
            DeleteCommand = new DeleteCommand();
            DeleteCommand.Subscriber += DeleteItemsEventhandler;

            NewCommand = new NewElement();
        }

        public void Add(ConfigFolderNamePair pair)
        {
            folderPairs.Add(pair);
        }

        public void RemoveElemente(ConfigFolderNamePair pairToRemove)
        {
            folderPairs.Remove(pairToRemove);
        }

        public void DeleteItemsEventhandler(Object selection)
        {
            // Selekt many 
            foreach (var pair in folderPairs.Where(x => x.ItemSelected).ToList())
            {
                folderPairs.Remove(pair);
            }
        }

        public void NewElement(String name, String foldeName)
        {
            
        }

        
   }
}
