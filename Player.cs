using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tapper
{
    class Player
    {
        int upCount = 0;
        int downCount = 0;
        Point point;
        Canvas canvas;
        Window window;
        Rectangle playerRectangle;

        public Player(Canvas c, Window w)
        {
            canvas = c;
            window = w;
            point = new Point(810, 406);
            playerRectangle = new Rectangle();
            playerRectangle.Fill = Brushes.White;
            playerRectangle.Width = 100;
            playerRectangle.Height = 100;
            canvas.Children.Add(playerRectangle);
            Canvas.SetTop(playerRectangle, point.Y);
            Canvas.SetLeft(playerRectangle, point.X);
        }
        public void update()
        {
            if (upCount > 0)
            {
                if (Keyboard.IsKeyUp(Key.Up))
                {
                    upCount = 0;
                }
            }
            else
            {
                if (Keyboard.IsKeyDown(Key.Up))
                {
                    point = new Point(point.X - 60, point.Y - 107);
                    Canvas.SetTop(playerRectangle, point.Y);
                    Canvas.SetLeft(playerRectangle, point.X);
                    upCount++;
                }
                /*if (Keyboard.IsKeyDown(Key.Down))
                {
                    point = new Point(point.X + 60, point.Y + 107);
                    Canvas.SetTop(playerRectangle, point.Y);
                    Canvas.SetLeft(playerRectangle, point.X);
                }*/
            }
        }


    }
}
