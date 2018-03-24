using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DownLoadAssistent
{
    class FileSystem
    {

        static public void ListDirectory(TreeView treeView, string path)
        {
            treeView.Items.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);

           treeView.ItemsSource = rootDirectoryInfo.GetDirectories("*", SearchOption.TopDirectoryOnly);
        }
    }
}
