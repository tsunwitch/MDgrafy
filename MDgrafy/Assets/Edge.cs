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


        public Edge(List<Vertex> vertexList, int indx)
        {
            Random random = new Random();

            int numberOfEdges = random.Next(1, vertexList.Count);
            int tempIndex;

            List<int> vertexesToLinkIndexes = new List<int>();

            // Losowanie punktów indexów vertexów do połączenia do danego punktu
            for (int i = 0; i < numberOfEdges; i++)
            {
                do
                {
                    tempIndex = random.Next(numberOfEdges);
                } while(vertexesToLinkIndexes.Contains(tempIndex));
                vertexesToLinkIndexes.Add(tempIndex);
            }

            X1 = vertexList[indx].X;
            Y1 = vertexList[indx].Y;

            for (int i = 0; i < vertexesToLinkIndexes.Count; i++)
            {
                X2 = vertexList[vertexesToLinkIndexes[i]].X;
                Y2 = vertexList[vertexesToLinkIndexes[i]].Y;
                Index = indx;

                var line = new Line();
                line.Stroke = new BrushConverter().ConvertFromString("#e09b22") as Brush;
                line.StrokeThickness = 2;
                line.X1 = X1 + 12.5;
                line.Y1 = Y1 + 12.5;
                line.X2 = X2 + 12.5;
                line.Y2 = Y2 + 12.5;
                line.SetValue(Canvas.ZIndexProperty, 0);
                Canvas.Children.Add(line);
            }
        }
    }
}
