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

                for (int i = 0; i < numberOfPoints; i++)
                {
                    vertexList.Add(new Vertex(MainCanvas, i));
                }

                //test wypisywania wspolrzednych
                foreach(Vertex v in vertexList)
                {
                    Debug.WriteLine($"{v.X}, {v.Y}");
                }

                //rysowanie linii do wszystkich punktów
                for (int i = 0; i < numberOfPoints; i++)
                {
                    for (int j = 0; j < numberOfPoints; j++)
                    {
                        var line = new Line();
                        line.Stroke = new BrushConverter().ConvertFromString("#4A148C") as Brush;
                        line.StrokeThickness = 2;
                        line.X1 = vertexList[i].X+12.5;
                        line.Y1 = vertexList[i].Y+12.5;
                        line.X2 = vertexList[j].X+12.5;
                        line.Y2 = vertexList[j].Y+12.5;
                        MainCanvas.Children.Add(line);
                    }
                }
            }

        }
    }
}
