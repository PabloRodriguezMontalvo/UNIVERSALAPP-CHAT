using System;
using System.Collections.Generic;
using System.Text;
using ChatClientSignal.Locator;
using ChatClientSignal.Servicios;

namespace ChatClientSignal.ViewModel
{
   public class BaseViewModel
   {
       protected IChatService chatService = ServiceLocator.Resolve<IChatService>();

   }
}
