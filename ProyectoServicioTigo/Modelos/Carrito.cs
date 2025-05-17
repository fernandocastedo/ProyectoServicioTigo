using ProyectoServicioTigo.Modelos;
using System.Collections.Generic;

namespace ProyectoServicioTigo.Servicios
{
    public static class Carrito
    {
        public static List<PackageBase> PlanesSeleccionados { get; } = new List<PackageBase>();

        public static void Agregar(PackageBase paquete)
        {
            PlanesSeleccionados.Add(paquete);
        }

        public static void Limpiar()
        {
            PlanesSeleccionados.Clear();
        }
    }
}
