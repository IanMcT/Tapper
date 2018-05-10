using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tapper
{
    class Patron
    {
        Point[] parray = { new Point(200, 75), new Point(141, 184), new Point(79, 293), new Point(19, 402) };
        Point pos;
        int barNum;
        int delay = 0;
        double delayAmount;
        int size = 50;
        Canvas canvas;
        MainWindow window;
        Rectangle sprite = new Rectangle();
        Random r = new Random();
        Rect boundingBox { get => box; }
        Rect box;
        public Patron(Canvas c, MainWindow w, int levelnum)
        {
            delayAmount = 60 / levelnum;
            canvas = c;
            window = w;
            barNum = r.Next(0, 4);
            pos = parray[barNum];
            sprite.Height = size;
            sprite.Width = size;
            box = new Rect(pos, new Size(size, size));
            ImageBrush darth = new ImageBrush(new BitmapImage(new Uri("darth.png", UriKind.Relative)));
            sprite.Fill = darth;
            Canvas.SetTop(sprite, pos.Y);
            Canvas.SetLeft(sprite, pos.X);
            canvas.Children.Add(sprite);
        }
        public void update()
        {
            delay++;
            if (delay >= delayAmount)
            {
                delay = 0;
                pos.X += size;
                box.X = pos.X;
                Canvas.SetLeft(sprite, pos.X);
            }
        }
        public bool collidesWith(Drink d)
        {
            return !(this.boundingBox.X > d.boundingBox.X + d.boundingBox.Width
                || this.boundingBox.X + this.boundingBox.Width < d.boundingBox.X
                || this.boundingBox.Y > d.boundingBox.Y + d.boundingBox.Height
                || this.boundingBox.Y + this.boundingBox.Height < d.boundingBox.Y);
        }
        public void destroy()
        {
            canvas.Children.Remove(sprite);
        }
        public bool checkIfAtEnd()
         {		
             if (barNum == 0)		
             {		
                 if (pos.X >= 593)		
                 {		
                     return true;		
                 }		
 		
                 else		
                 {		
                     return false;		
                 }		
             }		
 		
             else if (barNum == 1)		
             {		
                 if (pos.X >= 630)		
                 {		
                     return true;		
                 }		
 		
                 else		
                 {		
                     return false;		
                 }		
             }		
 		
             else if (barNum == 2)		
             {		
                 if (pos.X >= 710)		
                 {		
                     return true;		
                 }		
 		
                 else		
                 {		
                     return false;		
                 }		
             }		
 		
             else		
             {		
                 if (pos.X >= 770)		
                 {		
                     return true;		
                 }		
 		
                else		
                {		
                     return false;		
                 }		
            }		
 		
 		
         }
            }
}
