using ProyectoServicioTigo.Controladores;
using ProyectoServicioTigo.Modelos;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private LoadingWindow _main;
        private readonly AuthController _auth = new AuthController();
        public LoginView(LoadingWindow main)
        {
            InitializeComponent();
            _main = main;
        }
        private void ForgotPassword_Click(object sender, MouseButtonEventArgs e)
        {
            _main.MostrarVistaRecuperar();
        }
        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            string email    = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            Usuario? user = _auth.Login(email, password);

            if (user is null)
            {
                MessageBox.Show("Credenciales incorrectas", "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Guarda sesión (Singleton)
            Session.Actual.Login(user);

            // Abre la ventana principal
            MainWindow main = new MainWindow();
            main.Show();

            // Cierra login
            _main.Close();
        }
    }
}
