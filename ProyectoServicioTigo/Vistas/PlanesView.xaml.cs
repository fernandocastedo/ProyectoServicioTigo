using ProyectoServicioTigo.Modelos;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoServicioTigo.Vistas
{
    public partial class PlanesView : UserControl
    {
        public PlanesView()
        {
            InitializeComponent();
        }

        private void AgregarAlCarrito_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button boton && boton.DataContext is PackageBase plan)
            {
                Servicios.Carrito.Agregar(plan);
                MessageBox.Show($"Se agregó el plan {plan.Nombre} al carrito.");
            }
        }
    }
}
