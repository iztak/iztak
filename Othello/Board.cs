using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Othello
{
    class Board
    {
        public SolidColorBrush fill;
        public Rectangle square = new Rectangle()
        {
            Width = 70,
            Height = 70,
            
        };

        public bool IsEmpty = true;
        public bool IsWhite;

    }
}
