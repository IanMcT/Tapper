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
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            counter++;
            this.Title = counter.ToString();
        }
    }
}
