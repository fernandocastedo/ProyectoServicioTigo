using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoServicioTigo.Modelos
{
    public static class ServiceExtraCatalog
    {
        public static readonly IReadOnlyList<ServiceExtra> All = new[]
        {
            new ServiceExtra("Amazon Prime Video", 40m),
            new ServiceExtra("HBO Max",            50m),
            new ServiceExtra("Star +",             35m)
        };
    }
}
