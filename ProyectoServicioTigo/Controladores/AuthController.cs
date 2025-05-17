using ProyectoServicioTigo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoServicioTigo.Controladores
{
    public class AuthController
    {
        private readonly List<Usuario> _usuarios = new()
        {
            new Usuario { Id = 1, Email = "admin@tigo.com", Password = "admin", Nombre = "Administrador", EsAdmin = true },
            new Usuario { Id = 2, Email = "user@tigo.com", Password = "user", Nombre = "Cliente Demo", EsAdmin = false }
        };

        public Usuario? Login(string email, string password)
        {
            return _usuarios.FirstOrDefault(
                u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && u.Password == password);
        }

        public bool ExisteCorreo(string email)
        {
            return _usuarios.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public void Registrar(Usuario nuevoUsuario)
        {
            if (nuevoUsuario == null)
                throw new ArgumentNullException(nameof(nuevoUsuario));

            if (ExisteCorreo(nuevoUsuario.Email))
                throw new InvalidOperationException("El correo ya está registrado");

            nuevoUsuario.Id = _usuarios.Max(u => u.Id) + 1;
            _usuarios.Add(nuevoUsuario);
        }
    }
}