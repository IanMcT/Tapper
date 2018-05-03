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
<<<<<<< HEAD
<<<<<<< HEAD
        int counter = 0;
        private Point point;
        public Point Point { get => point;  }
=======
=======
>>>>>>> parent of f5b82df... Merge pull request #1 from IanMcT/master
        int upCount = 0;
        int downCount = 0;
        Point point;
>>>>>>> parent of f5b82df... Merge pull request #1 from IanMcT/master
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
<<<<<<< HEAD
<<<<<<< HEAD
                    counter++;
                }
                if(Keyboard.IsKeyDown(Key.Space))
                {
                    MainWindow.addDrink();
                    counter++;
                }
=======
                }*/
>>>>>>> parent of f5b82df... Merge pull request #1 from IanMcT/master
=======
                }*/
>>>>>>> parent of f5b82df... Merge pull request #1 from IanMcT/master
            }
        }

    }
}
