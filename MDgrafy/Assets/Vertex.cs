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
    internal class Vertex
    {
        private int index;
        private double x;
        private double y;
        private Random rnd = new Random();

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public int Index { get { return index; } set { index = value; } }

        public Vertex(Canvas cnvs, int indx)
        {
            X = rnd.Next((int)cnvs.Width);
            Y = rnd.Next((int)cnvs.Height);
            Index = indx + 1;

            Ellipse ellipse = new Ellipse()
            {
                Width = 25,
                Height = 25,
                Fill = new BrushConverter().ConvertFromString("Aqua") as Brush
            };

            Label label = new Label()
            {
                FontSize = 13,
                Content = Convert.ToString(index + 1),
                FontWeight = FontWeights.Bold
            };

            cnvs.Children.Add(ellipse);
            cnvs.Children.Add(label);

            ellipse.SetValue(Canvas.LeftProperty, this.X);
            ellipse.SetValue(Canvas.TopProperty, this.Y);

            if (index > 9)
            {
                label.SetValue(Canvas.LeftProperty, this.x - 3);
                label.SetValue(Canvas.TopProperty, this.y - 5);
            }
            else
            {
                label.SetValue(Canvas.LeftProperty, this.x + 1);
                label.SetValue(Canvas.TopProperty, this.y - 5);
            }
        }
    }
}
