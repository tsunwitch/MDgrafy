using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MDgrafy.Assets
{
    public partial class Vertex
    {
        private int index;
        private double x;
        private double y;
        private static Canvas canvas;

        private Random rnd = new Random();

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public int Index { get { return index; } set { index = value; } }
        public static Canvas Canvas { get { return canvas; } set { canvas = value; } }
        public static List<Vertex> Vertexes = new List<Vertex>();

        public Vertex(int indx)
        {
            X = rnd.Next((int)Canvas.Width);
            Y = rnd.Next((int)Canvas.Height);

            // Poprawa vertexow na krawedziach
            if (X >= (int)Canvas.Width - 35) X -= 35;
            if (X <= 35) X += 35;

            if (Y >= (int)Canvas.Height - 25) Y -= 35;
            if (Y <= 35) Y += 35;

            Index = indx;

            Ellipse ellipse = new Ellipse()
            {
                Width = 27,
                Height = 27,
                Fill = new BrushConverter().ConvertFromString("#4A148C") as Brush
            };

            Label label = new Label()
            {
                FontSize = 13,
                Content = $"v{index + 1}",
                FontWeight = FontWeights.Bold,
                Foreground = new BrushConverter().ConvertFromString("#dec9e9") as Brush
            };

            Canvas.Children.Add(ellipse);
            Canvas.Children.Add(label);

            ellipse.SetValue(Canvas.LeftProperty, this.X);
            ellipse.SetValue(Canvas.TopProperty, this.Y);
            ellipse.SetValue(Canvas.ZIndexProperty, 1);

            // Poprawa ustawienia labela w vertexie
            double labelOffset = (Index <= 8) ? this.x + 2 : this.x - 1;
            label.SetValue(Canvas.LeftProperty, labelOffset);
            label.SetValue(Canvas.TopProperty, this.y + 1);
            label.SetValue(Canvas.ZIndexProperty, 2);

            Vertexes.Add(this);
        }

        public static string ShowVertexes()
        {
            StringBuilder sb = new StringBuilder();
            string txt = "V = { ";

            for (int i = 0; i < Vertexes.Count; i++)
            {
                if (i == Vertexes.Count - 1)
                    sb.Append($"v{i + 1}");
                else
                    sb.Append($"v{i + 1}, ");
            }
            return txt + sb.ToString() + " }\n"; ;
        }
    }
}
