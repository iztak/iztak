using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Othello
{
    class Circles
    {
        public SolidColorBrush fill;
        public Ellipse piece = new Ellipse()
        {
            Width = 60,
            Height = 60,
            StrokeThickness = 3,
        };

        public Point position;
        public SolidColorBrush border;

    }
}
