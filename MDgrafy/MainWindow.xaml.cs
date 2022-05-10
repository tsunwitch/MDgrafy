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
        private List<Edge> edgeList = new List<Edge>();

        public MainWindow()
        {
            InitializeComponent();

            Edge.Canvas = MainCanvas;
            Vertex.Canvas = MainCanvas;
        }

        private void BTN_GenerateGraph_Click(object sender, RoutedEventArgs e)
        {
            Vertex.Vertexes.Clear();
            Edge.Connections.Clear();
            Edge.EdgeCount = 1;
            
            MainCanvas.Children.Clear();
            vertexList.Clear();
            TBlock_Connections.Text = "";
            TBlock_Weights.Text = "";
            TBlock_Degrees.Text = "";
            TBlock_Cycle3.Text = "";

            if (TBox_NumberOfPoints.Text == "")
            {
                MessageBox.Show("Nie wpisano ilości punktów", "Uwaga!");
            }
            else
            {
                numberOfPoints = Convert.ToInt32(TBox_NumberOfPoints.Text);

                // Vertexy przy tworzeniu dodają się do listy
                for (int i = 0; i < numberOfPoints; i++)
                {
                    vertexList.Add(new Vertex(i));
                }

                // Edge dodają się do własnej listy
                for (int i = 0; i < numberOfPoints; i++)
                {
                    edgeList.Add(new Edge(vertexList, i));
                }

                Cycle.Vertexes = vertexList;
                Cycle.Edges = edgeList;
            }

            //Dane
            TBlock_Connections.Text = "G = ( V, E )\n" + Edge.ShowEdges() + Vertex.ShowVertexes() + "\n" + Edge.ShowConnections();
            //Wagi
            TBlock_Weights.Text = Edge.ShowWeights();
            //Stopnie
            TBlock_Degrees.Text = Vertex.ShowDegrees();
            //Cykle3
            TBlock_Cycle3.Text = Cycle.ShowCycles3();
        }

        private async void BTN_GenerateRaport_Click(object sender, RoutedEventArgs e)
        {
            await Writer.GenerateRaport();
        }
    }
}
