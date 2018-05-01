using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tapper
{
    class Player
    {
        Point point;
        Canvas canvas;
        Window window;
        Rectangle playerRectangle;

        public Player(Canvas c, Window w)
        {
            canvas = c;
            window = w;
            point = new Point(0, 0);
            playerRectangle = new Rectangle();
            playerRectangle.Fill = Brushes.White;
            playerRectangle.Width = 100;
            playerRectangle.Height = 100;
            canvas.Children.Add(playerRectangle);
            Canvas.SetTop(playerRectangle, point.Y);
            Canvas.SetLeft(playerRectangle, point.X);
        }


    }
}
