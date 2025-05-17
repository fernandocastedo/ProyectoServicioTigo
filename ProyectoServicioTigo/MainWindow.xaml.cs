using ProyectoServicioTigo.Vistas;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoServicioTigo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeNavigation();
            ShowPlans();
        }

        private void InitializeNavigation()
        {
            if (headerView != null)
            {
                headerView.NavigateRequested += OnNavigateRequested;
            }
        }

        private void OnNavigateRequested(object sender, UserControl view)
        {
            if (view is CarritoView carritoView)
            {
                carritoView.NavigationRequested += OnNavigationRequested;
            }
            MainContent.Content = view;
        }

        private void OnNavigationRequested(UserControl view)
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
            var carritoView = new CarritoView();
            carritoView.NavigationRequested += OnNavigationRequested;
            MainContent.Content = carritoView;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (headerView != null)
            {
                headerView.NavigateRequested -= OnNavigateRequested;
            }

            if (MainContent.Content is CarritoView carritoView)
            {
                carritoView.NavigationRequested -= OnNavigationRequested;
            }

            base.OnClosing(e);
        }
    }
}