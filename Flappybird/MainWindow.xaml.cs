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

namespace FlappyBird.zip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer gameTimer = new DispatcherTimer();

        double score;
        int gravity = 8;
        bool gameOver;
        Rect flappyBirdHitBox;

        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Tick += MainEventTimer;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            StartGame();

        }

        private void MainEventTimer(object sender, EventArgs e)
        {
            txtScore.Content = "Score: " + score;

            flappyBirdHitBox = new Rect(Canvas.GetLeft(FlappyBird), Canvas.GetTop(FlappyBird), FlappyBird.Height - 6, FlappyBird.Width - 12);

            Canvas.SetTop(FlappyBird, Canvas.GetTop(FlappyBird) + gravity);

            if (Canvas.GetTop(FlappyBird) < -30 || Canvas.GetTop(FlappyBird) > 490) //If FlappyBird is gone outside the boundries
            {
                EndGame();
            }

            foreach (var x in MyCanvas.Children.OfType<Image>()) //Creating obstacles
            {
                if ((string)x.Tag == "obs1" || (string)x.Tag == "obs2" || (string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5);

                    if (Canvas.GetLeft(x) < -100)
                    {
                        Canvas.SetLeft(x, 800);

                        score += 0.5; //Incrementing the score
                    }

                    Rect pipeHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Height, x.Width);


                    if (flappyBirdHitBox.IntersectsWith(pipeHitBox))
                    {
                        EndGame();
                    }
                }

                if ((string)x.Tag == "cloud")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 0.6);

                    if (Canvas.GetLeft(x) < -220) // If cloud left the canvas
                    {
                        Canvas.SetLeft(x, 550); // Repositioning the clouds
                    }
                }
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e) //FlappyBird movement
        {

            if (e.Key == Key.Space)
            {
                FlappyBird.RenderTransform = new RotateTransform(-20, FlappyBird.Height / 2, FlappyBird.Width / 2);
                gravity = -8;
            }
            if (gameOver == true && e.Key == Key.Enter)
            {
                StartGame();
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e) //FlappyBird movement
        {
            FlappyBird.RenderTransform = new RotateTransform(5, FlappyBird.Height / 2, FlappyBird.Width / 2);
            gravity = 8;
        }

        private void StartGame()
        {
            MyCanvas.Focus();

            int temp = 200;
            score = 0;
            gameOver = false;
            Canvas.SetTop(FlappyBird, 100);

            foreach (var x in MyCanvas.Children.OfType<Image>()) //creating pipes/obstacles
            {
                if (x is Image && (string)x.Tag == "obs1")
                {
                    Canvas.SetLeft(x, 500);
                }
                if (x is Image && (string)x.Tag == "obs2")
                {
                    Canvas.SetLeft(x, 800);
                }
                if (x is Image &&(string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, 1000);
                }

                if ((string)x.Tag == "cloud")
                {
                    Canvas.SetLeft(x, 300 + temp);
                    temp = 800;
                }
            }

            gameTimer.Start();

        }

        private void EndGame()
        {
            gameTimer.Stop();
            gameOver = true;
            txtScore.Content += "  Game over! Press Enter to restart";
        }
    }
}
