using ProyectoServicioTigo.Vistas;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoServicioTigo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeNavigation();
            ShowPlans(); // Mostrar vista inicial
        }

        private void InitializeNavigation()
        {
            // Configurar el manejador de eventos de navegación del HeaderView
            if (headerView != null)
            {
                headerView.NavigateRequested += OnNavigateRequested;
            }
        }

        private void OnNavigateRequested(object sender, UserControl view)
        {
            MainContent.Content = view;
        }

        public void ShowPlans()
        {
            MainContent.Content = new PlanesView();
        }

        public void ShowExtras()
        {
            MainContent.Content = new ExtrasView();
        }

        public void ShowCart()
        {
            MainContent.Content = new CarritoView();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Limpiar eventos
            if (headerView != null)
            {
                headerView.NavigateRequested -= OnNavigateRequested;
            }
            base.OnClosing(e);
        }
    }
}