using System.Collections.Generic;
using System.Linq;

namespace ProyectoServicioTigo.Modelos
{
    public class PlanInternetDecorado : PackageBase
    {
        private readonly PackageBase _planBase;
        private readonly List<ServiceExtra> _extras;

        public PlanInternetDecorado(PackageBase planBase)
        {
            _planBase = planBase;
            _extras = new List<ServiceExtra>();

            // Copiar las propiedades base del plan
            Nombre = _planBase.Nombre;
            Descripcion = _planBase.Descripcion;
            Canales = _planBase.Canales;
            CostoBase = _planBase.CostoBase;
        }

        public void AgregarExtra(ServiceExtra extra)
        {
            _extras.Add(extra);
        }

        public IReadOnlyList<ServiceExtra> ObtenerExtras() => _extras;

        public override decimal CalcularTotal(IEnumerable<ServiceExtra>? extras = null)
        {
            // Calcula base + extras agregados
            decimal totalExtras = _extras.Sum(e => e.Costo);
            return CostoBase + totalExtras;
        }
    }
}
