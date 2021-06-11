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
using System.Diagnostics;
using System.Timers;


namespace Game_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string StartTimeDisplay = "00:00:00";
        private Stopwatch stopwatch;
        private Timer timer;
        private Process proc;

        public MainWindow()
        {
            InitializeComponent();
            TimeDisplay.Text = StartTimeDisplay;
            proc = new Process();
            stopwatch = new Stopwatch();
            timer = new Timer(interval:1000);
            timer.Elapsed += OnTimerElapse;

        }

        private void OnTimerElapse(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(()=> TimeDisplay.Text = stopwatch.Elapsed.ToString(format:@"hh\:mm\:ss"));
        }

        private void btnplaysnake_Click(object sender, RoutedEventArgs e)
        {
            Process proc = Process.Start(@"C:\Users\Sherlon\Desktop\Repository\Launcher and Games\Snake game\Snake\bin\Debug\net5.0-windows\Snake.exe");
            stopwatch.Start();
            timer.Start();
            proc.WaitForExit();
            timer.Stop();
           
        }



        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
            stopwatch.Stop();
            timer.Stop();

        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void btnplayrockpaperscissors_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"C:\Users\Sherlon\Desktop\Repository\Launcher and Games\rock papaer scissor\rock paper scissor windows app\bin\Debug\rock paper scissor windows app.exe");
        }

        private void btn_snakedesc_Click(object sender, RoutedEventArgs e)
        {
              txt_snake.Text = "Snake \nIn the game of Snake, the player uses the arrow keys to move a snake around the board. As the snake finds food, it eats the food, and thereby grows larger. The game ends when the snake either moves off the screen or moves into itself. The goal is to make the snake as large as possible before that happens.";
        

        }

        private void btn_flappydesc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_rpsdesc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_descclearsnake_Click(object sender, RoutedEventArgs e)
        {
            txt_snake.Text = "";
        }

        private void popupOpen(object sender, RoutedEventArgs e)
        {
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
            media.Play();
            StandardPopup.Visibility = System.Windows.Visibility.Visible;
            StandardPopup.IsOpen = true;

        }

        private void popupClose(object sender, RoutedEventArgs e)
        {
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }
    }
}
