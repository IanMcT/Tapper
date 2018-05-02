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

namespace Tapper
{
    enum GameState {SplashScreen, GameOn, GameOver }
    /*
     * Credits:
     * Pine Apple Rag (Scott Joplin piano roll) by Scott Joplin is licensed under a Attribution-NonCommercial-ShareAlike License.
     * http://freemusicarchive.org/music/Scott_Joplin/Frog_Legs_Ragtime_Era_Favorites/Scott_Joplin_-_08_-_Pine_Apple_Rag_1908_piano_roll
     */


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global Variables
        MediaPlayer musicPlayer = new MediaPlayer();
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        int counter = 0;
        Background background;
        GameState gameState;
        int lives;
        int level;
        Player player;

        public MainWindow()
        {
            InitializeComponent();

            //start Timer
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0,0,0,1000/60);//fps
            gameTimer.Start();
            //start music
            musicPlayer.Open(new Uri("tapperSong.mp3", UriKind.Relative));
            //   musicPlayer.Play();
            background = new Tapper.Background(canvas, this);
            gameState = GameState.SplashScreen;
        }

        private void setupGame()
        {
            lives = 3;
            level = 0;
            gameState = GameState.GameOn;
            player = new Player(canvas, this);
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameState == GameState.SplashScreen)
            {
                this.Title = "Splash Screen";
                if (Keyboard.IsKeyDown(Key.Enter)) {
                    setupGame();
                }
            }
            else if (gameState == GameState.GameOn)
            {
                this.Title = "Game on: Lives: " + lives.ToString();
                player.update();

                //copy where the mouse was clicked so I can paste into notepad for getting locations
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    Clipboard.SetText(Mouse.GetPosition(this).ToString());
                }
            }
            else if (gameState == GameState.GameOver)
            {
                this.Title = "Game Over";
            }
        }
    }
}
