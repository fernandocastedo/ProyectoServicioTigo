using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoServicioTigo.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }          // Will come from DB
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";    // TODO: store hash
        public string Nombre { get; set; } = "";
        public bool EsAdmin { get; set; } = false;
    }
}
