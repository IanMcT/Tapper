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
    class Background
    {
        Canvas canvas;
        private Polygon leftWall;
        private Polygon rightWall;
        private Polygon backWall;
        private Polygon floor;
        Window mainWindow;

        public Background() {
            canvas = new Canvas();
            mainWindow = new Window();
            drawBackground();
        }
        public Background(Canvas c, Window w) {
            canvas = c;
            mainWindow = w;
            drawBackground();
        }
        private void drawBackground() {
            drawLeftWall();
            drawRightWall();
            drawBackWall();
            drawFloor();
            drawServingBars();
        }

        private void drawServingBars()
        {
            Brush b = Brushes.SaddleBrown;
            Rectangle topBar = new Rectangle();
            topBar.Width = 420;
            topBar.Height = 55;
            topBar.Fill = b;
            canvas.Children.Add(topBar);
            Canvas.SetTop(topBar, 125);
            Canvas.SetLeft(topBar, 200);

            Rectangle secondBar = new Rectangle();
            secondBar.Width = 540;
            secondBar.Height = 55;
            secondBar.Fill = b;
            canvas.Children.Add(secondBar);
            Canvas.SetTop(secondBar, 234);
            Canvas.SetLeft(secondBar, 140);

            Rectangle thirdBar = new Rectangle();
            thirdBar.Width = secondBar.Width + (secondBar.Width - topBar.Width);
            thirdBar.Height = 55;
            thirdBar.Fill = b;
            canvas.Children.Add(thirdBar);
            Canvas.SetTop(thirdBar, Canvas.GetTop(secondBar) + (Canvas.GetTop(secondBar) - Canvas.GetTop(topBar)));
            Canvas.SetLeft(thirdBar, Canvas.GetLeft(secondBar) + (Canvas.GetLeft(secondBar) - Canvas.GetLeft(topBar)));

            Rectangle bottomBar = new Rectangle();
            bottomBar.Width = thirdBar.Width + (thirdBar.Width - secondBar.Width);
            bottomBar.Height = 55;
            bottomBar.Fill = b;
            canvas.Children.Add(bottomBar);
            Canvas.SetTop(bottomBar, Canvas.GetTop(thirdBar) + (Canvas.GetTop(thirdBar) - Canvas.GetTop(secondBar)));
            Canvas.SetLeft(bottomBar, Canvas.GetLeft(thirdBar) + (Canvas.GetLeft(thirdBar) - Canvas.GetLeft(secondBar)));
        }

        private void drawFloor()
        {
            floor = new Polygon();
            floor.Fill = Brushes.DarkGray;
            floor.Points.Add(new Point(236, 124));
            floor.Points.Add(new Point(674, 123));
            floor.Points.Add(new Point(911, mainWindow.Height));
            floor.Points.Add(new Point(10, mainWindow.Height));
            canvas.Children.Add(floor);
        }

        private void drawBackWall()
        {
            backWall = new Polygon();
            backWall.Fill = Brushes.Blue;
            backWall.Points.Add(new Point(236, 124));
            backWall.Points.Add(new Point(674, 123));
            backWall.Points.Add(new Point(673, 0));
            backWall.Points.Add(new Point(236, 0));
            canvas.Children.Add(backWall);
        }

        private void drawRightWall()
        {
            rightWall = new Polygon();
            rightWall.Fill = Brushes.Navy;
            rightWall.Points.Add(new Point(673, 0));
            rightWall.Points.Add(new Point(674, 123));
            rightWall.Points.Add(new Point(911, mainWindow.Height));
            rightWall.Points.Add(new Point(mainWindow.Width, mainWindow.Height));
            rightWall.Points.Add(new Point(mainWindow.Width, 0));
            canvas.Children.Add(rightWall);
        }

        private void drawLeftWall()
        {
            leftWall = new Polygon();
            leftWall.Fill = Brushes.Navy;
            leftWall.Points.Add(new Point(0, 0));
            leftWall.Points.Add(new Point(236, 0));
            leftWall.Points.Add(new Point(236, 124));
            leftWall.Points.Add(new Point(10, mainWindow.Height));
            leftWall.Points.Add(new Point(0, mainWindow.Height));
            canvas.Children.Add(leftWall);
        }
    }
}
