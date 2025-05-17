using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoServicioTigo.Modelos
{
    public abstract class PackageBase
    {
        public string Nombre { get; protected set; } = "";
        public string Descripcion { get; protected set; } = "";
        public int Canales { get; protected set; }
        public decimal CostoBase { get; protected set; }

        public virtual decimal CalcularTotal(IEnumerable<ServiceExtra> extras) =>
            CostoBase + extras.Sum(e => e.Costo);
    }
}
