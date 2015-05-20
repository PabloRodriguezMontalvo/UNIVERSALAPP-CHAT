﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatClientSignal.Locator;
using ChatClientSignal.Model;
using ChatClientSignal.Utilidades;
using ChatClientSignal.ViewModel;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace ChatClientSignal.Servicios
{
    public class ServicioChatImpl:IChatService
    {
        private HubConnection _conexion;
        private IHubProxy _proxy;

        public ServicioChatImpl()
        {
            _conexion = new HubConnection(Cadenas.UrlChat);
            _proxy = _conexion.CreateHubProxy("ChatHub");

            Init();


        }


        public async Task Init()
        {
            _proxy.On("onConnected", (String id, String nombre, List<Usuario> Usuarios, List<Mensaje> Mensajes) =>
            {

                var viewModel = ServiceLocator.Resolve<ConversacionesViewModel>();
                viewModel.Usuario=new Usuario(){Id = id,Nombre = nombre};

                foreach (var usuario in Usuarios)
                {
                    viewModel.Usuarios.Add(usuario);
                }

                foreach (var mensaje in Mensajes)
                {
                    viewModel.Mensajes.Add(mensaje);
                }




            });


            _proxy.On("onNewUserConnected", (String id,String nombre) =>
            {
                var viewModel = ServiceLocator.Resolve<ConversacionesViewModel>();
                viewModel.Usuarios.Add(new Usuario(){Id=id,Nombre = nombre});
            });

            _proxy.On("mensaje", (String usuario, String mensaje) =>
            {
                var viewModel = ServiceLocator.Resolve<ConversacionesViewModel>();
                viewModel.Mensajes.Add(new Mensaje() { Usuario = usuario,Contenido = mensaje});
            });

            _proxy.On("usuarioDesconectado", (String id, String nombre) =>
            {
                var viewModel = ServiceLocator.Resolve<ConversacionesViewModel>();

                var u = viewModel.Usuarios.FirstOrDefault(o => o.Id == id);
                if (u != null)
                {
                    viewModel.Usuarios.Remove(u);
                    viewModel.Mensajes.Add(new Mensaje() {Usuario = nombre, 
                        Contenido = "Se ha desconectado"});
                }

            });
            await _conexion.Start();
        }

        public void Conectar(string nombre)
        {
            _proxy.Invoke("Conectar", nombre);
        }

        public void Desconectar()
        {
           _conexion.Dispose();
        }

        public void EnviarMensaje(string usuario, string mensaje)
        {
            _proxy.Invoke("EnviarMensaje", usuario, mensaje);
        }

        public void EnviarMensajePrivado(string destino, string mensaje)
        {
            _proxy.Invoke("EnviarMensajePrivado", destino, mensaje);
        }
    }
}