using ProyectoServicioTigo.Controladores;
using ProyectoServicioTigo.Modelos;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoServicioTigo.Vistas
{
    public partial class RegistroView : UserControl
    {
        private readonly LoadingWindow _main;
        private readonly AuthController _auth = new AuthController();

        public RegistroView(LoadingWindow main)
        {
            InitializeComponent();
            _main = main;
        }

        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            string nombre = NombreTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor complete todos los campos", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var nuevoUsuario = new Usuario
                {
                    Nombre = nombre,
                    Email = email,
                    Password = password, // En producción usar hash
                    EsAdmin = false
                };

                _auth.Registrar(nuevoUsuario);

                MessageBox.Show("Registro exitoso. Por favor inicie sesión.", "Éxito",
                              MessageBoxButton.OK, MessageBoxImage.Information);

                _main.MostrarVistaLogin();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error de registro",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: {ex.Message}", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
        private void VolverALogin_Click(object sender, RoutedEventArgs e)
        {
            _main.MostrarVistaLogin();
        }
    }
}