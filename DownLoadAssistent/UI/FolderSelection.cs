using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace DownLoadAssistent
{
    class FolderSelection : INotifyPropertyChanged
    {
        public ObservableCollection<FolderVM> SelectedFolders { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public FolderSelection()
        {
            SelectedFolders = new ObservableCollection<FolderVM>();
        }

        public void SelectionChangedEventHandler(object source, EventArgs args)
        {
            try
            {
                var ChangedFolderVM = source as FolderVM;
                if (null != ChangedFolderVM)
                {
                    if (ChangedFolderVM.Marked)
                    {
                        SelectedFolders.Add(ChangedFolderVM);
                    }
                    else
                    {
                        SelectedFolders.Remove(ChangedFolderVM);
                    }
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedFolders"));
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}