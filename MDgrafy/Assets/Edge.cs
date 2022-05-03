using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MDgrafy.Assets
{
    public class Edge
    {
        private int index;
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private static Canvas canvas;

        public double X1 { get { return x1; } set { x1 = value; } }
        public double Y1 { get { return y1; } set { y1 = value; } }
        public double X2 { get { return x2; } set { x2 = value; } }
        public double Y2 { get { return y2; } set { y2 = value; } }
        public int Index { get { return index; } set { index = value; } }
        public static Canvas Canvas { get { return canvas; } set { canvas = value; } }
        public static List<List<int>> Connections = new List<List<int>>();


        public Edge(List<Vertex> vertexList, int indx)
        {
            Random random = new Random();

            int numberOfEdges = random.Next(1, vertexList.Count);
            int numberOfVertexes = vertexList.Count;
            int tempIndex;

            List<int> vertexesToLinkIndexes = new List<int>();

            // Losowanie punktów indexów vertexów do połączenia do danego punktu
            for (int i = 0; i < numberOfEdges; i++)
            {
                do { tempIndex = random.Next(numberOfVertexes) ;} 
                while(vertexesToLinkIndexes.Contains(tempIndex) || tempIndex == indx);
                vertexesToLinkIndexes.Add(tempIndex);
            }

            X1 = vertexList[indx].X;
            Y1 = vertexList[indx].Y;

            // Informacja czy zapisujemy połączenie do Connections
            bool isUnique = true;

            for (int i = 0; i < vertexesToLinkIndexes.Count; i++)
            {
                X2 = vertexList[vertexesToLinkIndexes[i]].X;
                Y2 = vertexList[vertexesToLinkIndexes[i]].Y;
                Index = indx;

                // Rysowawnie linii
                var line = new Line();
                line.Stroke = new BrushConverter().ConvertFromString("#e09b22") as Brush;
                line.StrokeThickness = 2;
                line.X1 = X1 + 12.5;
                line.Y1 = Y1 + 12.5;
                line.X2 = X2 + 12.5;
                line.Y2 = Y2 + 12.5;
                line.SetValue(Canvas.ZIndexProperty, 0);
                Canvas.Children.Add(line);

                // Szukanie powtórzeń
                for (int j = 0; j < Connections.Count(); j++)
                {
                    if(indx == Connections[j][1] && vertexesToLinkIndexes[i] == Connections[j][0])
                    {
                        isUnique = false;
                    }
                }

                // Zapisywanie do Connections
                if(isUnique == true)
                {
                    Connections.Add(new List<int> { Index, vertexesToLinkIndexes[i] });
                }
            }
        }

        public static string ShowConnections()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Connections.Count; i++)
            {
                for (int j = 0; j < Connections[i].Count; j++)
                {
                    if (j == 0)
                        sb.Append($"e{i + 1} = ( v{Connections[i][j] + 1},");
                    else
                        sb.Append($" v{Connections[i][j] + 1} )\n");
                }
            }
            return sb.ToString();
        }

        public static string ShowEdges()
        {
            StringBuilder sb = new StringBuilder();
            string txt = "E = { ";

            for (int i = 0; i < Connections.Count; i++)
            {
                if (i == Connections.Count - 1)
                    sb.Append($"e{i + 1}");
                else
                    sb.Append($"e{i + 1}, ");
            }
            return txt + sb.ToString() + " }\n"; ;
        }
    }
}
