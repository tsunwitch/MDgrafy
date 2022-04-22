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
using System.Diagnostics;

namespace MDgrafy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rnd = new Random();
        private int numberOfPoints;
        private List<Vertex> vertexList = new List<Vertex>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_GenerateGraph_Click(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
            vertexList.Clear();

            if (TB_NumberOfPoints.Text == "")
            {
                MessageBox.Show("Nie wpisano ilości punktów", "Uwaga!");
            }
            else
            {
                numberOfPoints = Convert.ToInt32(TB_NumberOfPoints.Text);

                //Vertexy przy tworzeniu dodają się do listy
                for (int i = 0; i < numberOfPoints; i++)
                {
                    vertexList.Add(new Vertex(MainCanvas, i));
                }

                //Tworzenie krawędzi
                for (int i = 0; i < numberOfPoints; i++)
                {
                    for (int j = 0; j < numberOfPoints; j++)
                    {
                        new Edge(MainCanvas, vertexList[i], vertexList[j], i);
                    }
                }
            }

        }
    }
}
