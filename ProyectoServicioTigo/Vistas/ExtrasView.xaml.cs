using ProyectoServicioTigo.Modelos;
using ProyectoServicioTigo.Servicios;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoServicioTigo.Vistas
{
    public partial class ExtrasView : UserControl
    {
        public ExtrasView()
        {
            InitializeComponent();
            DataContext = new ExtrasViewModel();
        }

        private void AgregarExtra_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is ServiceExtra extra)
            {
                // Obtener el plan base seleccionado (ejemplo simple: el primero en carrito)
                var planBase = Carrito.PlanesSeleccionados.Count > 0 ? Carrito.PlanesSeleccionados[0] : null;

                if (planBase == null)
                {
                    MessageBox.Show("Primero agrega un plan base al carrito antes de añadir servicios extra.");
                    return;
                }

                // Decorar el plan base con el extra seleccionado
                var planDecorado = new DecoratorPlan(planBase, extra);

                // Limpiar carrito y agregar el plan decorado para mostrar el efecto
                Carrito.Limpiar();
                Carrito.Agregar(planDecorado);

                MessageBox.Show($"Se agregó el servicio extra '{extra.Nombre}' al plan '{planBase.Nombre}'.");
            }
        }
    }
}
