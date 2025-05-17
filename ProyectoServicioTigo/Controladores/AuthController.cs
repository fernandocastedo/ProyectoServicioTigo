using ProyectoServicioTigo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoServicioTigo.Controladores
{
    public class AuthController
    {
        //  TEMPORAL: lista en memoria que se reemplazará por una consulta a BD
        private readonly List<Usuario> _usuarios = new()
        {
            new Usuario { Id = 1, Email = "admin@tigo.com", Password = "admin", Nombre = "Administrador", EsAdmin = true  },
            new Usuario { Id = 2, Email = "user@tigo.com",  Password = "user",  Nombre = "Cliente Demo",  EsAdmin = false }
        };

        public Usuario? Login(string email, string password)
        {
            return _usuarios.FirstOrDefault
                (u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                      && u.Password == password);
        }


        public bool ExisteCorreo(string email)
            => _usuarios.Any(u => u.Email == email);

        // Futuro: Registro con hash + persistencia
        public void Registrar(Usuario nuevo) => _usuarios.Add(nuevo);
    }
}
