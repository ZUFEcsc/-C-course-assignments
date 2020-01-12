using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//添加以下命名空间
using System.IO;
using System.Reflection;
using System.Resources;

namespace MyTimer
{

    public partial class Form1 : Form
    {
        private int _nowSecond = 0;
        private Boolean _colonFlag = true;
        
        //数码管位图数组
        private Bitmap[] _bmpShow = new Bitmap[13];
        
        //自定义方法：由显示字符获取对应的数码管位图
        private Image GetResourceImage(string displayStr) 
        {
            if (displayStr == "0")
                return _bmpShow[0];
            else if (displayStr == "1")
                return _bmpShow[1];
            else if (displayStr == "2")
                return _bmpShow[2];
            else if (displayStr == "3")
                return _bmpShow[3];
            else if (displayStr == "4")
                return _bmpShow[4];
            else if (displayStr == "5")
                return _bmpShow[5];
            else if (displayStr == "6")
                return _bmpShow[6];
            else if (displayStr == "7")
                return _bmpShow[7];
            else if (displayStr == "8")
                return _bmpShow[8];
            else if (displayStr == "9")
                return _bmpShow[9];
            else if (displayStr == ".")
                return _bmpShow[10];
            else if (displayStr == ":")
                return _bmpShow[11];
            else
                return _bmpShow[12];
        }
        
        //构造函数
        public Form1()
        {
            InitializeComponent();

            //初始化时间
            _nowSecond = 0;

            //装载数码管位图文件
            _bmpShow[0] = new Bitmap("image/0.bmp");
            _bmpShow[1] = new Bitmap("image/1.bmp");
            _bmpShow[2] = new Bitmap("image/2.bmp");
            _bmpShow[3] = new Bitmap("image/3.bmp");
            _bmpShow[4] = new Bitmap("image/4.bmp");
            _bmpShow[5] = new Bitmap("image/5.bmp");
            _bmpShow[6] = new Bitmap("image/6.bmp");
            _bmpShow[7] = new Bitmap("image/7.bmp");
            _bmpShow[8] = new Bitmap("image/8.bmp");
            _bmpShow[9] = new Bitmap("image/9.bmp");
            _bmpShow[10] = new Bitmap("image/dot1.bmp");
            _bmpShow[11] = new Bitmap("image/dot2.bmp");
            _bmpShow[12] = new Bitmap("image/blank.bmp");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            
            buttonStart.Enabled = false;
            buttonPauseContinue.Enabled = true;
            buttonStop.Enabled = true;
            buttonPauseContinue.Text = "暂停";
            _colonFlag = true;
            pictureBoxDot1.Image = GetResourceImage(" ");
            pictureBoxDot2.Image = GetResourceImage(" ");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             _nowSecond++;
            
            int hour = _nowSecond / 3600;
            int minute = (_nowSecond % 3600) / 60;
            int second = (_nowSecond % 3600) % 60;

            this.pictureBoxSec1.Image = GetResourceImage((second / 10).ToString());
            this.pictureBoxSec2.Image = GetResourceImage((second % 10).ToString());

            this.pictureBoxMin1.Image = GetResourceImage((minute / 10).ToString());
            this.pictureBoxMin2.Image = GetResourceImage((minute % 10).ToString());

            this.pictureBoxHour1.Image = GetResourceImage((hour / 10).ToString());
            this.pictureBoxHour2.Image = GetResourceImage((hour % 10).ToString());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _colonFlag = !_colonFlag;
            if (_colonFlag)
            {
                pictureBoxDot1.Image = GetResourceImage(" ");
                pictureBoxDot2.Image = GetResourceImage(" ");
            }
            else 
            {
                pictureBoxDot1.Image = GetResourceImage(":");
                pictureBoxDot2.Image = GetResourceImage(":");
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
            
            buttonPauseContinue.Text = "暂停";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBoxDot1.Image = GetResourceImage(":");
            //pictureBoxDot2.Image = GetResourceImage(":");
            //pictureBoxHour1.Image = GetResourceImage("0");
            //pictureBoxHour2.Image = GetResourceImage("0");
            //pictureBoxMin1.Image = GetResourceImage("0");
            //pictureBoxMin2.Image = GetResourceImage("0");
            //pictureBoxSec1.Image = GetResourceImage("0");
            //pictureBoxSec2.Image = GetResourceImage("0");

            buttonStart.Enabled = true;
            buttonPauseContinue.Enabled = false;
            buttonStop.Enabled = false;
            buttonPauseContinue.Text = "暂停";
            
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
