using System;
using ProyectoServicioTigo.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoServicioTigo.Controladores
{
    //Esto es un singleton
    public sealed class Session
    {
        private Session() { }

        public static Session Actual { get; } = new();

        public Usuario? UsuarioLogueado { get; private set; }
        public PackageBase? PaqueteSeleccion { get; private set; }
        public List<ServiceExtra> Extras { get; } = new();

        public void Login(Usuario u) => UsuarioLogueado = u;
        public void Logout()
        {
            UsuarioLogueado = null;
            PaqueteSeleccion = null;
            Extras.Clear();
        }
        public void SeleccionarPaquete(PackageBase p) => PaqueteSeleccion = p;
    }
}
