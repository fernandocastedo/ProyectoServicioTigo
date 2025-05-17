using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoServicioTigo.Modelos
{
    public sealed class HogarInicial : PackageBase
    {
        public HogarInicial()
        {
            Nombre = "Hogar Inicial";
            Descripcion = "60 canales + Internet ilimitado";
            Canales = 60;
            CostoBase = 150m;
        }
    }

    public sealed class HogarIntermedio : PackageBase
    {
        public HogarIntermedio()
        {
            Nombre = "Hogar Intermedio";
            Descripcion = "120 canales + Internet ilimitado";
            Canales = 120;
            CostoBase = 250m;
        }
    }

    public sealed class HogarAvanzado : PackageBase
    {
        public HogarAvanzado()
        {
            Nombre = "Hogar Avanzado";
            Descripcion = "180 canales + Internet ilimitado";
            Canales = 180;
            CostoBase = 350m;
        }
    }
}
