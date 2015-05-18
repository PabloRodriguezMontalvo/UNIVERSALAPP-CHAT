using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChatClientSignal.Model;

namespace ChatClientSignal.ViewModel
{
   public class InicioViewModel:BaseViewModel
    {
       public Usuario MiUsuario { get; set; }

       public void Conectar()
       {
           chatService.Conectar(MiUsuario.Nombre);
       }


    }
}
