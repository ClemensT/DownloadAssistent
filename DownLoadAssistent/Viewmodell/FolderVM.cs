using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace DownLoadAssistent
{
    class FolderVM : INotifyPropertyChanged
    {
        private bool _marked;

        public List<FolderVM> SubFolderList { get; set; }
        private DirectoryInfo rootDirectoryInfo;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Marked
        {
            get
            {
                return _marked;
            }
            set
            {
                if (_marked != value)
                {
                    _marked = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Marked"));
                }
            }
        }

        public String rootPath
        {
            get
            {
                return rootDirectoryInfo.Name;
            }
            set
            {
            }
        }

        public String fullRootPath
        {
            get
            {
                return rootDirectoryInfo.FullName;
            }

            set { }
        }

        public FolderVM(string RootPath)
        {
            rootDirectoryInfo = new DirectoryInfo(RootPath);
            SubFolderList = new List<FolderVM>();
            _marked = false;
        }

        public void CreateFolderTree()
        {
            CreateFolderTree(rootDirectoryInfo);
        }

        public void CreateFolderTree(DirectoryInfo root)
        {
            var FolderList = root.GetDirectories("*");
            foreach (var subfolder in FolderList)
            {
                FolderVM subFolderVM = new FolderVM(subfolder.FullName);
                subFolderVM.CreateFolderTree(subfolder);
                SubFolderList.Add(subFolderVM);
                subFolderVM.PropertyChanged += MarkedChangeEventHandler;
            }
        }

        public void MarkedChangeEventHandler(object send, PropertyChangedEventArgs args)
        {
            PropertyChanged(send, args);
        }
    }
}