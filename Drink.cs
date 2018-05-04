using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tapper
{
    class Drink
    {
        Point pos;
        int size = 50;
        double speed = 2;
        Canvas canvas;
        MainWindow window;
        Rectangle sprite = new Rectangle();
       public Rect boundingBox { get => box; }
        Rect box;
        public Drink(Canvas c, MainWindow w, double xLevel, double yLevel)
        {
            canvas = c;
            window = w;
            pos.X = xLevel;
            pos.Y = yLevel;
            sprite.Height = size;
            sprite.Width = size;
            box = new Rect(pos, new Size(size, size));
            sprite.Fill = new ImageBrush(new BitmapImage(new Uri("Root_beer.png", UriKind.Relative)));
            Canvas.SetTop(sprite, pos.Y);
            Canvas.SetLeft(sprite, pos.X);
            canvas.Children.Add(sprite);
        }

        public void update()
        {
                pos.X -= speed;
                Canvas.SetLeft(sprite, pos.X);
                box.X = pos.X;
        }
    }
}
