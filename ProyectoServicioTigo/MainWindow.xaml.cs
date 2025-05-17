using ProyectoServicioTigo.Vistas;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            ShowHeader();
            ShowCarousel();
            ShowPlans();
        }
        private void ShowHeader()
        {
            HeaderView headerView = new HeaderView();
            DockPanel.SetDock(headerView, Dock.Top);
        }

        private void ShowCarousel()
        {
            CarouselView carouselView = new CarouselView();
            DockPanel.SetDock(carouselView, Dock.Top);
        }

        public void ShowPlans()
        {
            MainContent.Content = new PlanesView();
        }
        public void ShowExtras()
        {
            MainContent.Content = new ExtrasView();
        }
    }
}