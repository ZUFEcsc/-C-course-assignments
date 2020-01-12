using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace MyTimer
{

    public partial class FormMain : Form
    {
        private int _nowSecond = 0;
        private int _dotBlink = 0;
        private List<Bitmap> img = new List<Bitmap>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
                _nowSecond = 0;
                _dotBlink = 0;
            buttonStart.Enabled = false;
            buttonPauseContinue.Enabled = true;
            buttonStop.Enabled = true;
            buttonPauseContinue.Text = "暂停";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             _nowSecond++;
            
            int hour = _nowSecond / 3600;
            int minute = (_nowSecond % 3600) / 60;
            int second = (_nowSecond % 3600) % 60;

            this.pictureBoxSec1.Image = img[second / 10];
            this.pictureBoxSec2.Image = img[second % 10];
            this.pictureBoxMin1.Image = img[minute / 10];
            this.pictureBoxMin2.Image = img[minute % 10];
            this.pictureBoxHour1.Image = img[hour / 10];
            this.pictureBoxHour2.Image = img[hour % 10];

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _dotBlink++;
            if (_dotBlink % 2 == 1)
            {
                this.pictureBoxDot1.Image = img[11];
                this.pictureBoxDot2.Image = img[11];
            }
            else
            {
                this.pictureBoxDot1.Image = img[10];
                this.pictureBoxDot2.Image = img[10];
            }
        }

        private void buttonPauseContinue_Click(object sender, EventArgs e)
        {
            if (buttonPauseContinue.Text == "暂停")
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                buttonPauseContinue.Text = "继续";
            }
            else
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                buttonPauseContinue.Text = "暂停";
            }

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _nowSecond = 0;
            _dotBlink = 0;
            timer1.Enabled = false;
            timer2.Enabled = false;
            buttonStart.Enabled = true;
            buttonPauseContinue.Enabled = false;
            buttonStop.Enabled = false;
            pictureBoxDot1.Image = MyTimer.Properties.Resources.dot2;
            pictureBoxDot2.Image = MyTimer.Properties.Resources.dot2;
            buttonPauseContinue.Text = "暂停";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            img.Add(new Bitmap("image/0.bmp"));
            img.Add(new Bitmap("image/1.bmp"));
            img.Add(new Bitmap("image/2.bmp"));
            img.Add(new Bitmap("image/3.bmp"));
            img.Add(new Bitmap("image/4.bmp"));
            img.Add(new Bitmap("image/5.bmp"));
            img.Add(new Bitmap("image/6.bmp"));
            img.Add(new Bitmap("image/7.bmp"));
            img.Add(new Bitmap("image/8.bmp"));
            img.Add(new Bitmap("image/9.bmp"));
            img.Add(new Bitmap("image/dot2.bmp"));
            img.Add(new Bitmap("image/blank.bmp"));

            buttonStart.Enabled = true;
            buttonPauseContinue.Enabled = false;
            buttonStop.Enabled = false;
            buttonPauseContinue.Text = "暂停";
            pictureBoxDot1.Image = MyTimer.Properties.Resources.dot2;
            pictureBoxDot2.Image = MyTimer.Properties.Resources.dot2;
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            int screenRight = Screen.PrimaryScreen.Bounds.Right;
            int formRight = this.Left + this.Size.Width;
            if (Math.Abs(screenRight - formRight) <= 60)
                this.Left=screenRight-this.Size.Width;
            if (Math.Abs(this.Left) <= 60)
                this.Left=0;
            int screenBottom = Screen.PrimaryScreen.Bounds.Bottom;
            int formBottom = this.Top + this.Size.Height;
            if (Math.Abs(screenBottom - formBottom) <= 60)
                this.Top=screenBottom-this.Size.Height;
            if (Math.Abs(this.Top) <= 100)
                this.Top=0;
        }

    }
}
