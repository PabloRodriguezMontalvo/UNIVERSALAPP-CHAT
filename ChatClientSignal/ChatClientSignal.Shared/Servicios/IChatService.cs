using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientSignal.Servicios
{
   public interface IChatService
   {
       Task Init();
       void Conectar(String nombre);
       void Desconectar();
       void EnviarMensaje(String usuario, String mensaje);
       void EnviarMensajePrivado(String destino, String mensaje);
   }
}
