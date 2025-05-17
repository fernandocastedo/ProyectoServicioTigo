using ProyectoServicioTigo.Modelos;
using System.Collections.ObjectModel;

namespace ProyectoServicioTigo.Vistas
{
    public class ExtrasViewModel
    {
        public ObservableCollection<ServiceExtra> Extras { get; set; }

        public ExtrasViewModel()
        {
            Extras = new ObservableCollection<ServiceExtra>(ServiceExtraCatalog.All);
        }
    }
}
