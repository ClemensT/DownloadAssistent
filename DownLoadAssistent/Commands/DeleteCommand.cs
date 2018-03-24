using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DownLoadAssistent
{
    public class DeleteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public delegate void DeleteEventHandler(Object Selection);
        public event DeleteEventHandler Subscriber;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (null != Subscriber)
            {
                Subscriber(this);
            }
        }
    }
}
