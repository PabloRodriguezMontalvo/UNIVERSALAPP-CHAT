using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ChatClientSignal.Annotations;
using ChatClientSignal.Locator;
using ChatClientSignal.Servicios;

namespace ChatClientSignal.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
   {
       protected IChatService chatService = ServiceLocator.Resolve<IChatService>();

       public event PropertyChangedEventHandler PropertyChanged;

       [NotifyPropertyChangedInvocator]
       protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
       {
           PropertyChangedEventHandler handler = PropertyChanged;
           if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
       }
   }
}
