using System.Windows;
using System.Windows.Controls;
using ProyectoServicioTigo.Servicios;

namespace ProyectoServicioTigo.Vistas
{
    public partial class CarritoView : UserControl
    {
        public CarritoView()
        {
            InitializeComponent();
        }

        private void Confirmar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "¡Gracias por tu compra!",
                "Compra exitosa",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            if (result == MessageBoxResult.OK)
            {
                Carrito.Limpiar();
                ((MainWindow)Application.Current.MainWindow).MainContent.Content = new PlanesView();
            }
        }
    }
}

