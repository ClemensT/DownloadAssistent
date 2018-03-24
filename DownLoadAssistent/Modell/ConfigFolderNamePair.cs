using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DownLoadAssistent
{
    class ConfigFolderNamePair
    {
        public String FolderName { get; set; }
        public String Label { get; set; }
        public bool ItemSelected { get; set; }

        public ConfigFolderNamePair(String pFolderName, String pLabelName)
        {
            FolderName = pFolderName;
            Label = pLabelName;
            ItemSelected = false;
        }

    }
}
