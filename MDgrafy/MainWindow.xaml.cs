using MDgrafy.Assets;
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

namespace MDgrafy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

            //funkcja generująca losowe punkty
            int pointCount = rnd.Next(3, 10); //max ilosc punktow

            for (int i = 0; i < pointCount; i++)
            {
                new Vertex(MainCanvas, i);
            }

        }
    }
}
