using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ChatClientSignal.Model;

namespace ChatClientSignal.ViewModel
{
   public class ConversacionesViewModel:BaseViewModel
    {
       public ObservableCollection<Mensaje> Mensajes { get; set; }
       public ObservableCollection<Usuario> Usuarios { get; set; }
       public Mensaje Mensaje { get; set; }
       public Usuario Usuario { get; set; }

       public ConversacionesViewModel()
       {
           Mensajes=new ObservableCollection<Mensaje>();
           Usuarios=new ObservableCollection<Usuario>();
       }

       public void EnviarMensaje()
       {
           chatService.EnviarMensaje(Usuario.Nombre,Mensaje.Contenido);
       }


    }
}
