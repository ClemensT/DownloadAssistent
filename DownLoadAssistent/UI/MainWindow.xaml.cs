using DownLoadAssistent.Modell;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DownLoadAssistent
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DownloadManager downloadManager = new DownloadManager();

        public String Buttonlabel = "asdf";

        private List<ConfigFolderNamePair> SelectedItems = new List<ConfigFolderNamePair>();

        public MainWindow()
        {

            InitializeComponent();
            FolderSelection selectedFolders = new FolderSelection();

            FolderPairList.ItemsSource = downloadManager.folderPairs;
            downloadManager.Add(new ConfigFolderNamePair("c:\\folder1", "DGC"));
            downloadManager.Add(new ConfigFolderNamePair("c:\\folder2", "CVA"));
            downloadManager.Add(new ConfigFolderNamePair("c:\\folder3", "BM"));

            this.DataContext = downloadManager;

            ConfigSelector.ItemsSource = downloadManager.folderPairs;

            /*this.Loaded += (this, null) =>
            {
                downloadManager.SubscribeToDeleteEvent();
            };*/
            //FileSystem.ListDirectory(TestTree, "c:\\ti");

            FolderVM myFOlder = new FolderVM("c:\\testfolder");
            //TestTree.ItemsSource = myFOlder.SubFolderList;
            // TestTree2.ItemsSource =  myFOlder.FolderList;
            myFOlder.CreateFolderTree();

            TestTree.ItemsSource = myFOlder.SubFolderList;

            myFOlder.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(selectedFolders.SelectionChangedEventHandler);
            SelectedFolders.ItemsSource = selectedFolders.SelectedFolders;

            JobManager manager = new JobManager();

            new Thread(new ThreadStart(() =>
                        {
                            

                            manager.AddJob(new DemoJob("a"));
                            manager.AddJob(new DemoJob("b"));
                            manager.AddJob(new DemoJob("c"));
                            manager.AddJob(new DemoJob("d"));
                            manager.AddJob(new DemoJob("e"));

                            manager.ProcessJobs();
                        })).Start();

            JobList.ItemsSource = manager.JobList;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            downloadManager.Add(new ConfigFolderNamePair("",""));
            
        }
    }
}
