using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DownLoadAssistent.Commands
{
    class NewElement : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public delegate void NewItemEventhandler(String name, String folderName);
        public event NewItemEventhandler Subscriber;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            if (Subscriber != null)
            {
                Subscriber("", "");
            }
        }
    }
}
