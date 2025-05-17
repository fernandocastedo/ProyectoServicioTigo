using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoServicioTigo.Vistas
{
    /// <summary>
    /// Interaction logic for HeaderView.xaml
    /// </summary>
    public partial class HeaderView : UserControl
    {
        public HeaderView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new PlanesView();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var extrasView = new ExtrasView();
            // Suponiendo que tienes un ContentControl llamado MainContent
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = extrasView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new CarritoView();
        }
    }
}
