using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominionCardGame
{
    public partial class mneuScreen : UserControl
    {
        int currentImage = 1;
        public mneuScreen()
        {
            InitializeComponent();
            tutorialDisplay.BackgroundImage = Properties.Resources.tutImage1;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new playerHandScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if(currentImage == 1)
            {
                tutorialDisplay.BackgroundImage = Properties.Resources.tutImage2;
                currentImage = 2;
                Refresh();
            }
            else if(currentImage == 2)
            {
                tutorialDisplay.BackgroundImage= Properties.Resources.tutImage3;
                currentImage = 3;
                Refresh();
            }
            else if (currentImage == 3)
            {
                tutorialDisplay.BackgroundImage = Properties.Resources.tutImage1;
                currentImage = 1;
                Refresh();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (currentImage == 1)
            {
                tutorialDisplay.BackgroundImage = Properties.Resources.tutImage3;
                currentImage = 3;
                Refresh();
            }
            else if (currentImage == 2)
            {
                tutorialDisplay.BackgroundImage = Properties.Resources.tutImage1;
                currentImage = 1;
                Refresh();
            }
            else if (currentImage == 3)
            {
                tutorialDisplay.BackgroundImage = Properties.Resources.tutImage2;
                currentImage = 2;
                Refresh();
            }
        }
    }
}
