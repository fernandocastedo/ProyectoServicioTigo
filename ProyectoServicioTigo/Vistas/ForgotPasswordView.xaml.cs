using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
    /// Interaction logic for ForgotPasswordView.xaml
    /// </summary>
    public partial class ForgotPasswordView : UserControl
    {
        private LoadingWindow _main;
        public ForgotPasswordView(LoadingWindow main)
        {
            InitializeComponent();
            _main = main;
        }
        private void OnBackClick(object sender, RoutedEventArgs e)
        {
            _main.MostrarVistaLogin();
        }
    }
}
