using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoServicioTigo.Modelos
{
    public class ServiceExtra
    {
        public string Nombre { get; }
        public decimal Costo { get; }

        public ServiceExtra(string nombre, decimal costo)
        {
            Nombre = nombre;
            Costo = costo;
        }

        public override string ToString() => $"{Nombre} (+Bs {Costo})";
    }
}
