using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyTimer
{
    public partial class Form1 : Form
    {
        private int _nowSecond = 0;


        public Form1()
        {
            InitializeComponent();
            _nowSecond = 0;

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;

            if(textBoxCount.Text.Trim()==String.Empty)
            {
                _nowSecond = 0;
                
                labelHour.Text = "00";
                labelMinute.Text = "00";
                labelSecond.Text = "00.0";
                
            }

            else
            {
                _nowSecond = Convert.ToInt32(textBoxCount.Text)*10;
                int hour = _nowSecond / 36000;
                int minute = (_nowSecond % 36000) / 600;
                double second = (_nowSecond % 36000) % 600 / 10.0;
                
                labelHour.Text = hour.ToString("00");
                labelMinute.Text = minute.ToString("00");
                labelSecond.Text = second.ToString("00.0");

            }
            labelColon1.Visible = true;
            labelColon2.Visible = true;
            buttonStart.Enabled = false;
            buttonPauseContinue.Enabled = true;
            buttonStop.Enabled = true;
            buttonPauseContinue.Text = "暂停";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBoxCount.Text.Trim() == String.Empty)
            {
                _nowSecond++;
            }
            else 
            {
                _nowSecond--;
                if (_nowSecond <= 0) 
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    MessageBox.Show ("Time is over.");
                }
            }
            int hour = _nowSecond / 36000;
            int minute = (_nowSecond % 36000) / 600;
            double second = (_nowSecond % 36000) % 600 / 10.0;
            labelHour.Text = hour.ToString("00");
            labelMinute.Text = minute.ToString("00");
            labelSecond.Text = second.ToString("00.0");
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (labelColon1.Visible == true)
            {
                labelColon1.Visible = false;
                labelColon2.Visible = false;

            }
            else
            {
                labelColon1.Visible = true;
                labelColon2.Visible = true;

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
            timer1.Enabled = false;
            timer2.Enabled = false;
            buttonStart.Enabled = true;
            buttonPauseContinue.Enabled = false;
            buttonStop.Enabled = false;
            labelColon1.Visible = true;
            labelColon2.Visible = true;
            buttonPauseContinue.Text = "暂停";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonPauseContinue.Enabled = false;
            buttonStop.Enabled = false;
            buttonPauseContinue.Text = "暂停";
            labelColon1.Visible = true;
            labelColon2.Visible = true;
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

        private void labelColon1_Click(object sender, EventArgs e)
        {

        }

    }
}
