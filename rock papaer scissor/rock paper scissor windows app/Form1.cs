using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rock_paper_scissor_windows_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int playerScore, cpuScore = 0;
        int randomInt;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //rock
            play(3);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //paper
            play(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //scissor
            play(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Playagain
            playerScore = 0;
            cpuScore = 0;
            playerpicture.Image = null;
            cpupicture.Image = null;
            resultlabel.Text = "Start Over";
            Playerscorelabel.Text = "0";
            Cpuscorelabel.Text = "0";
        }

        private void play(int selection)
        {
            Random rnd = new Random();
            randomInt = rnd.Next(1, 4);

            setimage(playerpicture, selection);
            setimage(cpupicture, randomInt);

            if (randomInt == selection)
            {
                resultlabel.Text = "DRAW";
                return;
            }

            switch(selection)
            {
                case 1:
                    if (randomInt == 2)
                        updatescore(true);
                    else
                        updatescore(false);
                    break;

                case 2:
                    if (randomInt == 3)
                        updatescore(true);
                    else
                        updatescore(false);
                    break;

                case 3:
                    if (randomInt == 1)
                        updatescore(true);
                    else
                        updatescore(false);
                    break;
            }


        }

        private void updatescore(bool playerwon)
        {
            if (playerwon)
            {
                playerScore++;
                resultlabel.Text = "WIN";
                Playerscorelabel.Text = playerScore.ToString();
            }
            else
            {
                cpuScore++;
                resultlabel.Text = "LOSE";
                Cpuscorelabel.Text = playerScore.ToString();
            }

        }
        private void setimage(PictureBox pb, int img)
        {
            if (img == 1)
                pb.Image = global::rock_paper_scissor_windows_app.Properties.Resources.rock;
            else if (img == 2)
                pb.Image = global::rock_paper_scissor_windows_app.Properties.Resources.scissor;
            else if (img == 3)
                pb.Image = global::rock_paper_scissor_windows_app.Properties.Resources.Paper;

        }
    }
}
