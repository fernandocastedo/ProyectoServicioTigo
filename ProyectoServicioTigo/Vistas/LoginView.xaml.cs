using System;
using ProyectoServicioTigo.Controladores;
using ProyectoServicioTigo.Modelos;
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
        private readonly AuthController _authController;
        public LoginView()
        {
            InitializeComponent();
            _authController = new AuthController();
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            var usuario = _authController.Login(email, password);

            if (usuario != null)
            {
                // Si el usuario es admin, redirige a la vista de administración, sino a la vista de selección de paquetes
                if (usuario.EsAdmin)
                {
                    MessageBox.Show("Bienvenido, Administrador");
                    // Lógica para abrir vista de administración
                }
                else
                {
                    MessageBox.Show("Bienvenido, Usuario");
                    // Lógica para abrir vista de selección de paquete
                }
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }
    }
}
