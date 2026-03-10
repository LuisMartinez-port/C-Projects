using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkateboardWPF.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

        protected void RaisePropertyChangedEvent([CallerMemberName] string? propertyname = null)
        {
            if (PropertyChanged == null)
            {
                throw new InvalidOperationException("this is null, make it not null cmon mannnn");
            }
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyname));


        }
    }
}
