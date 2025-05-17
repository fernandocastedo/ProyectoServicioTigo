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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoServicioTigo.Vistas
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
            MostrarVistaLogin(); // Vista inicial
        }
        public void MostrarVistaLogin()
        {
            var loginView = new LoginView(this);
            MostrarVistaConAnimacion(loginView);

        }


        public void MostrarVistaRecuperar()
        {
            var forgotView = new ForgotPasswordView(this);
            MostrarVistaConAnimacion(forgotView);
        }

        private void MostrarVistaConAnimacion(UserControl vista)
        {
            vista.Opacity = 0;
            MainContent.Content = vista;

            var fadeIn = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromMilliseconds(1600))
            };

            vista.BeginAnimation(OpacityProperty, fadeIn);
        }
    }
}
