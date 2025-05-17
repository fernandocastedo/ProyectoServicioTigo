using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ProyectoServicioTigo.Modelos;
using ProyectoServicioTigo.Servicios;

namespace ProyectoServicioTigo.Vistas
{
    public partial class CarritoView : UserControl
    {
        public event System.Action<UserControl> NavigationRequested;

        private PackageBase planSeleccionado = null!;
        private List<ServiceExtra> extrasSeleccionados = new();

        public CarritoView()
        {
            InitializeComponent();
            CargarDatosCarrito();
        }

        private void CargarDatosCarrito()
        {
            // Forzar una actualización completa del DataContext
            DataContext = null;
            DataContext = Carrito.PlanesSeleccionados;

            if (Carrito.PlanesSeleccionados.Count > 0)
            {
                var planDecorado = Carrito.PlanesSeleccionados[0];
                planSeleccionado = ObtenerPlanBase(planDecorado);
                extrasSeleccionados = ObtenerExtras(planDecorado);
            }
            else
            {
                planSeleccionado = null!;
                extrasSeleccionados.Clear();
            }

            // Forzar actualización de los bindings
            UpdateLayout();
            RefreshBindings();
        }

        private void RefreshBindings()
        {
            // Actualizar todos los bindings manualmente
            foreach (var child in FindVisualChildren<FrameworkElement>(this))
            {
                var binding = child.GetBindingExpression(ContentProperty);
                binding?.UpdateTarget();
            }
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void ConfirmarCompra_Click(object sender, RoutedEventArgs e)
        {
            if (planSeleccionado == null)
            {
                MessageBox.Show("No hay plan seleccionado.");
                return;
            }

            var factura = new FacturaWindow(planSeleccionado, extrasSeleccionados);

            factura.CompraCompletada += () =>
            {
                LimpiarCarrito1();
                NavigationRequested?.Invoke(new PlanesView());
            };

            factura.ShowDialog();
        }

        private void LimpiarCarrito()
        {
            Carrito.Limpiar(); // Usar el método Limpiar del servicio Carrito
            CargarDatosCarrito(); // Refrescar la vista

            // Opcional: Notificar que el carrito está vacío
            if (Carrito.PlanesSeleccionados.Count == 0)
            {
                MessageBox.Show("El carrito ha sido vaciado.", "Carrito vacío",
                              MessageBoxButton.OK, MessageBoxImage.Information);
            }
            NavigationRequested?.Invoke(new PlanesView());
        }
        private void LimpiarCarrito1()
        {
            planSeleccionado = null!;
            extrasSeleccionados.Clear();
            Carrito.PlanesSeleccionados.Clear();
            DataContext = null;
            CargarDatosCarrito();
        }

        private void EliminarCompra_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCarrito();
        }

        private PackageBase ObtenerPlanBase(PackageBase plan)
        {
            while (plan is DecoratorPlan decorador)
            {
                plan = decorador.Plan;
            }
            return plan;
        }

        private List<ServiceExtra> ObtenerExtras(PackageBase plan)
        {
            var extras = new List<ServiceExtra>();
            while (plan is DecoratorPlan decorador)
            {
                extras.Add(decorador.Extra);
                plan = decorador.Plan;
            }
            return extras;
        }
    }
}