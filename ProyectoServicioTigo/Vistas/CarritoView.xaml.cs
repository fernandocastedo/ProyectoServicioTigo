using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProyectoServicioTigo.Modelos;
using ProyectoServicioTigo.Servicios;

namespace ProyectoServicioTigo.Vistas
{
    public partial class CarritoView : UserControl
    {
        // Campos privados necesarios para la facturación
        private PackageBase planSeleccionado = null!;
        private List<ServiceExtra> extrasSeleccionados = new();



        public CarritoView()
        {
            InitializeComponent();

            // Actualizamos el DataContext con el contenido del carrito
            DataContext = Carrito.PlanesSeleccionados;

            // Suponemos que solo hay un plan en el carrito (según tu modelo)
            if (Carrito.PlanesSeleccionados.Count > 0)
            {
                var planDecorado = Carrito.PlanesSeleccionados[0];

                // Guardamos el plan base
                planSeleccionado = ObtenerPlanBase(planDecorado);

                // Extraemos los extras si es un plan decorado
                extrasSeleccionados = ObtenerExtras(planDecorado);
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
            factura.ShowDialog();
        }

        // Desenrolla los decoradores hasta encontrar el plan base
        private PackageBase ObtenerPlanBase(PackageBase plan)
        {
            while (plan is DecoratorPlan decorador)
            {
                plan = decorador.Plan;
            }
            return plan;
        }

        // Recolecta todos los servicios extra desde el decorador
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
