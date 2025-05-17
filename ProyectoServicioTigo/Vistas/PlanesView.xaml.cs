using ProyectoServicioTigo.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PlanesView.xaml
    /// </summary>
    public partial class PlanesView : UserControl
    {
        public PlanesView()
        {
            InitializeComponent();
        }
        private void AgregarAlCarrito_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button boton && boton.DataContext is PackageBase plan)
            {
                Servicios.Carrito.Agregar(plan);
                MessageBox.Show($"Se agregó el plan {plan.Nombre} al carrito.");
            }
        }


    }
}
