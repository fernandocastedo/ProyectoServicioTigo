using System.Collections.Generic;
using System.Windows;
using ProyectoServicioTigo.Modelos;

namespace ProyectoServicioTigo.Vistas
{
    public partial class FacturaWindow : Window
    {
        private readonly PackageBase _plan;
        private readonly List<ServiceExtra> _extras;

        public FacturaWindow(PackageBase plan, List<ServiceExtra> extras)
        {
            InitializeComponent();
            _plan = plan;
            _extras = extras;

            // Mostrar datos en la ventana
            txtPlan.Text = $"{_plan.Nombre} - {_plan.Descripcion}";
            lstExtras.ItemsSource = _extras;
            txtTotal.Text = $"Bs {_plan.CalcularTotal(_extras)}";
        }

        private void FinalizarCompra_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCI.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, completa todos los datos del cliente.", "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"¡Gracias por tu compra, {txtNombre.Text}!", "Compra realizada", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
