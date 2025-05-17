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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoServicioTigo.Vistas
{
    /// <summary>
    /// Interaction logic for CarouselView.xaml
    /// </summary>
    public partial class CarouselView : UserControl
    {
        private List<string> imagePaths = new List<string>()
        {
            "pack://application:,,,/Imagenes/carousel1.jpg",
            "pack://application:,,,/Imagenes/carousel2.jpg",
            "pack://application:,,,/Imagenes/carousel3.jpg"
        };
        private int currentIndex = 0;
        public CarouselView()
        {
            InitializeComponent();
            ShowImage(currentIndex);
        }
        private void ShowImage(int index)
        {
            if (index >= 0 && index < imagePaths.Count)
            {
                BitmapImage bitmap = new BitmapImage(new System.Uri(imagePaths[index]));
                ImageDisplay.Source = bitmap;
            }
        }

        private void PrevImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = imagePaths.Count - 1;
            ShowImage(currentIndex);
        }

        private void NextImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex >= imagePaths.Count)
                currentIndex = 0;
            ShowImage(currentIndex);
        }
    }
}
