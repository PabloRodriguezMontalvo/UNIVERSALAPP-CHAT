using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChatClientSignal.Model;

namespace ChatClientSignal.ViewModel
{
   public class InicioViewModel:BaseViewModel
    {
       public String MiUsuario { get; set; }

       public InicioViewModel()
       {
           MiUsuario = "Como te llamas?";
       }


       public void Conectar()
       {
           chatService.Conectar(MiUsuario);
       }


    }
}
