using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using System.Windows;

namespace Tapper
{
    class GameOver
    {
        StreamReader streamReader = new StreamReader("highscores");
        string line;
        int score;
        int counter;

        Canvas canvas;
        Window window;

        public GameOver(Canvas c, Window w, int score)
        {
            window = w;
            canvas = c;
        }

        public void getscores()
        {
            try
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    int temp = line.IndexOf(" ");
                    string pastscore = line.Substring(temp);


                    int pastint = Convert.ToInt32(pastscore);

                    if (score > pastint)
                    {
                        if (counter < 10)
                        {
                            MessageBox.Show("High Score!");


                        }
                    }
                    else if (counter < 10)
                    {
                        counter++;
                    }
                    else
                    {
                        //Display high score list
                    }

                }
            }
            catch
            {

            }
        }
    }
}
