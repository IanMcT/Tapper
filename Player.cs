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
        //Global variables
        Point playerPos = new Point();
        int counter = 0;
        private Point point;
        public Point Point { get => point;  }
        Canvas canvas;
        MainWindow window;
        Rectangle playerRectangle;

        public Player(Canvas c, MainWindow w)
        {
            //Generate player
            canvas = c;
            window = w;
            point = new Point(810, 406);
            playerPos = point;
            playerRectangle = new Rectangle();
            playerRectangle.Fill = Brushes.White;
            playerRectangle.Height = 100;
            playerRectangle.Width = 100;
            canvas.Children.Add(playerRectangle);
            Canvas.SetTop(playerRectangle, point.Y);
            Canvas.SetLeft(playerRectangle, point.X);
        }
        public void update()
        {
            if (playerPos == new Point(630, 85)) //block on ascension to infinity
            {
                if (Keyboard.IsKeyDown(Key.Down))
                {
                    point = new Point(point.X + 60, point.Y + 107);
                    Canvas.SetTop(playerRectangle, point.Y);
                    Canvas.SetLeft(playerRectangle, point.X);
                    counter++;
                    playerPos = point;
                }
            }
            else if (playerPos == new Point(810, 406)) //block on decesion to infinity
            {
                if (Keyboard.IsKeyDown(Key.Up))
                {
                    point = new Point(point.X - 60, point.Y - 107);
                    Canvas.SetTop(playerRectangle, point.Y);
                    Canvas.SetLeft(playerRectangle, point.X);
                    counter++;
                    playerPos = point;
                }
            }
            else //General movement
            {
                if (counter > 0) //Prevent constant movement
                {
                    if (Keyboard.IsKeyUp(Key.Up))
                    {
                        if (Keyboard.IsKeyUp(Key.Down))
                        {
                            counter = 0;
                        }
                    }
                    if (Keyboard.IsKeyUp(Key.Down))
                    {
                        if (Keyboard.IsKeyUp(Key.Up))
                        {
                            counter = 0;
                        }
                    }
                }
                else //Re-installs player up or down depending on input
                {
                    if (Keyboard.IsKeyDown(Key.Up))
                    {
                        point = new Point(point.X - 60, point.Y - 107);
                        Canvas.SetTop(playerRectangle, point.Y);
                        Canvas.SetLeft(playerRectangle, point.X);
                        counter++;
                        playerPos = point;
                    }
                    if (Keyboard.IsKeyDown(Key.Down))
                    {
                        point = new Point(point.X + 60, point.Y + 107);
                        Canvas.SetTop(playerRectangle, point.Y);
                        Canvas.SetLeft(playerRectangle, point.X);
                        counter++;
                        playerPos = point;
                    }
                }
                if(Keyboard.IsKeyDown(Key.Space))
                {
                    window.addDrink();
                    counter++;
                }
            }
        }
    }
}
