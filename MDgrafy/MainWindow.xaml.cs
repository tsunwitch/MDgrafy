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
        private Random rnd = new Random();
        private int numberOfPoints;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_GenerateGraph_Click(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();

            if (TB_NumberOfPoints.Text == "")
            {
                MessageBox.Show("Nie wpisano ilości punktów", "Uwaga!");
            }
            else
            {
                numberOfPoints = Convert.ToInt32(TB_NumberOfPoints.Text);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    new Vertex(MainCanvas, i);
                }
            }

        }
    }
}
