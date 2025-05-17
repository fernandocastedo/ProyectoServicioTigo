using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoServicioTigo.Modelos
{
    public abstract class PackageBase
    {
        public virtual string Nombre { get; protected set; } = "";
        public virtual string Descripcion { get; protected set; } = "";
        public virtual int Canales { get; protected set; }
        public virtual decimal CostoBase { get; protected set; }

        public virtual decimal CalcularTotal(IEnumerable<ServiceExtra>? extras = null) =>
            CostoBase + (extras?.Sum(e => e.Costo) ?? 0m);

        public override string ToString() => $"{Nombre} - Bs {CostoBase}";
    }

}
