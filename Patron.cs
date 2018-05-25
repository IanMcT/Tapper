using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tapper
{
    /// <summary>
    /// PlayerState determines what animation to run
    /// </summary>
    enum PlayerState { waiting, serving }

    class Player
    {
        //Global variables
        Point playerPos = new Point();//where player is on screen
        Boolean previousSpaceBarStatus = false;//used to ensure one press per serve
        int counter = 0;//used in various calculations
        private Point point;//data hiding

        ImageBrush sprite;//Image for the player
        BitmapImage bitmapImage;//Image file to use

        TranslateTransform translateTransform;//used for animation

        PlayerState playerState = PlayerState.waiting;//starting state
        int framesBeforeUpdate = 15;//smaller numbers to speed up animation - 30 is change frame every 0.5 seconds (just to clearly see it works)
        int countOfFrame = 0;//keep track of frames
        int currentFrame = 0;//what is the current frame
        int NumberOfFrames = 6;//how many frames in the sprite sheet

        public Point Point
        {
            get { return point; }
        }
        Canvas canvas;//Canvas used to get position
        MainWindow window;//What the program runs in
        Rectangle playerRectangle;//rectangle on the screen where the player is

        /// <summary>
        /// Constructor - runs when player created
        /// </summary>
        /// <param name="c">Canvas where the player will be drawn</param>
        /// <param name="w">Window that the program runs in</param>
        public Player(Canvas c, MainWindow w)
        {
            //Generate player
            canvas = c;
            window = w;
            point = new Point(810, 406);
            playerPos = point;
            playerRectangle = new Rectangle();
            playerRectangle.Height = 100;
            playerRectangle.Width = 100;

            //load image for the spritesheet
            bitmapImage = new BitmapImage(new Uri("spritesheet.png", UriKind.Relative));
            sprite = new ImageBrush(bitmapImage);

            //set properties to ensure only one frame is drawn
            sprite.Stretch = Stretch.None;
            sprite.AlignmentX = AlignmentX.Left;
            sprite.AlignmentY = AlignmentY.Top;
            sprite.Viewport = new Rect(0, 0, 100, 100);//This is required to ensure you can look at different frames - Ian Markham - this is what we were missing.
            translateTransform = new TranslateTransform(0, 0);
            playerRectangle.Fill = sprite;
            sprite.Transform = translateTransform;//Displays the first frame

            playerRectangle.Width = 100;

            canvas.Children.Add(playerRectangle);//adds the image
            Canvas.SetTop(playerRectangle, point.Y);//positions it
            Canvas.SetLeft(playerRectangle, point.X);
        }

        /// <summary>
        /// Update runs every frame
        /// </summary>
        public void update()
        {
            //update animation
            if (countOfFrame >= framesBeforeUpdate)
            {
                //each row has the animation frames for the state
                if (playerState == PlayerState.waiting)
                {
                    countOfFrame = 0;
                    currentFrame = (currentFrame + 1) % NumberOfFrames;
                    sprite.Transform = new TranslateTransform(-100 * currentFrame, 0);
                }
                else if (playerState == PlayerState.serving)
                {
                    countOfFrame = 0;
                    currentFrame = (currentFrame + 1) % NumberOfFrames;
                    sprite.Transform = new TranslateTransform(-100 * currentFrame, -100);
                    if (currentFrame >= NumberOfFrames - 1)
                    {

                        playerState = PlayerState.waiting;//Go back to waiting after serving is done
                    }
                    else if (currentFrame >= NumberOfFrames - 2) {
                        window.addDrink();//adds so the animation works
                    }
                }
            }
            countOfFrame++;//update the count

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
            }

            //Serve rootbeer when space bar pressed and not currently serving
            if (Keyboard.IsKeyDown(Key.Space) &&
                !previousSpaceBarStatus &&
                playerState != PlayerState.serving)
            {
                //could move this to animation code so it happens at end of animation
                playerState = PlayerState.serving;
                currentFrame = -1;
                previousSpaceBarStatus = true;
            }

            //Don't allow a press to register until the space bar is released.
            if (Keyboard.IsKeyUp(Key.Space) &&
                previousSpaceBarStatus)
            {
                previousSpaceBarStatus = false;
            }
        }
    }
}
