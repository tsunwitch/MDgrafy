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
        private Random rnd = new Random();

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public int Index { get { return index; } set { index = value; } }

        public Vertex(Canvas cnvs, int indx)
        {
            X = rnd.Next((int)cnvs.Width);
            Y = rnd.Next((int)cnvs.Height);

            // Poprawa vertexow na krawedziach
            if (X >= (int)cnvs.Width - 35) X -= 35;
            if (X <= 35) X += 35;

            if (Y >= (int)cnvs.Height - 25) Y -= 35;
            if (Y <= 35) Y += 35;

            Index = indx + 1;

            Ellipse ellipse = new Ellipse()
            {
                Width = 25,
                Height = 25,
                Fill = new BrushConverter().ConvertFromString("#4A148C") as Brush
            };

            Label label = new Label()
            {
                FontSize = 13,
                Content = Convert.ToString(index + 1),
                FontWeight = FontWeights.Bold,
                Foreground = new BrushConverter().ConvertFromString("#dec9e9") as Brush
            };

            cnvs.Children.Add(ellipse);
            cnvs.Children.Add(label);

            ellipse.SetValue(Canvas.LeftProperty, this.X);
            ellipse.SetValue(Canvas.TopProperty, this.Y);

            // Poprawa ustawienia labela w vertexie
            double labelOffset = (Index <= 8) ? this.x + 5 : this.x;
            label.SetValue(Canvas.LeftProperty, labelOffset);
            label.SetValue(Canvas.TopProperty, this.y);
        }
    }
}
