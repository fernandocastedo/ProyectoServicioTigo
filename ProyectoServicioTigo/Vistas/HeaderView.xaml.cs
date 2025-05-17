using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace ProyectoServicioTigo.Vistas
{
    public partial class HeaderView : UserControl
    {
        // Evento para solicitud de navegación
        public event NavigateEventHandler NavigateRequested;

        // Delegado para el evento de navegación
        public delegate void NavigateEventHandler(object sender, UserControl view);

        public HeaderView()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                // Configuración solo en tiempo de ejecución
            }
        }

        private void RaiseNavigateRequest(UserControl view)
        {
            NavigateRequested?.Invoke(this, view);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseNavigateRequest(new PlanesView());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RaiseNavigateRequest(new ExtrasView());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RaiseNavigateRequest(new CarritoView());
        }
    }
}