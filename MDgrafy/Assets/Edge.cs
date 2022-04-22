﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MDgrafy.Assets
{
    internal class Edge
    {
        private int index;
        private double x1;
        private double y1;
        private double x2;
        private double y2;

        public double X1 { get { return x1; } set { x1 = value; } }
        public double Y1 { get { return y1; } set { y1 = value; } }
        public double X2 { get { return x2; } set { x2 = value; } }
        public double Y2 { get { return y2; } set { y2 = value; } }
        public int Index { get { return index; } set { index = value; } }

        public Edge(Canvas cnvs,Vertex v1, Vertex v2, int indx)
        {
            X1 = v1.X;
            Y1 = v1.Y;
            X2 = v2.X;
            Y2 = v2.Y;

            Index = indx + 1;

            var line = new Line();
            line.Stroke = new BrushConverter().ConvertFromString("#e09b22") as Brush;
            line.StrokeThickness = 2;
            line.X1 = X1 + 12.5;
            line.Y1 = Y1 + 12.5;
            line.X2 = X2 + 12.5;
            line.Y2 = Y2 + 12.5;
            line.SetValue(Canvas.ZIndexProperty, 0);
            cnvs.Children.Add(line);
        }
    }
}
