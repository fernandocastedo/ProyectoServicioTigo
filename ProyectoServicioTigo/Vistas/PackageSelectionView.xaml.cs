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
    /// Interaction logic for PackageSelectionView.xaml
    /// </summary>
    public partial class PackageSelectionView : UserControl
    {
        public PackageSelectionView()
        {
            InitializeComponent();
        }

        private void OnPackageSelect(object sender, RoutedEventArgs e)
        {
            var selectedPackage = (PackageComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedPackage != null)
            {
                MessageBox.Show($"Has seleccionado el paquete: {selectedPackage}");
                // Lógica para agregar servicios extra y calcular costo total
            }
        }
    }
}
