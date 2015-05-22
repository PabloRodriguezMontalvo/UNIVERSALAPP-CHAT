using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ChatClientSignal.Model;

namespace ChatClientSignal.ViewModel
{
 
    public class ConversacionesViewModel : BaseViewModel
   {

       private ObservableCollection<Mensaje> _mensajes;
       private ObservableCollection<Usuario> _usuarios; 
       public ObservableCollection<Mensaje> Mensajes {
           get { return _mensajes; }
           set
           {
               _mensajes = value;
               NotifyPropertyChanged();

           }
       }
       public ObservableCollection<Usuario> Usuarios {
           get { return _usuarios; }
           set
           {
               _usuarios = value;
               NotifyPropertyChanged();
           }
       }
       public String Mensaje { get; set; }
       public Usuario Usuario { get; set; }

       public ConversacionesViewModel()
       {
           Mensajes = new ObservableCollection<Mensaje>();
           Usuarios = new ObservableCollection<Usuario>();
       }

       public void EnviarMensaje()
       {
           chatService.EnviarMensaje(Usuario.Nombre,Mensaje);
       }

     

       
   }
}
