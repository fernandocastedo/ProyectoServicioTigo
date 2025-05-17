using ProyectoServicioTigo.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoServicioTigo.Vistas
{
    public class PlanesViewModel
    {
        public ObservableCollection<PackageBase> Planes { get; } = new()
        {
            new HogarInicial(),
            new HogarIntermedio(),
            new HogarAvanzado()
        };
    }
}
