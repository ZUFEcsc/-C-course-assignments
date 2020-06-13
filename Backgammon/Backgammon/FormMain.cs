using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Backgammon
{
    public partial class FormMain : Form
    {
        private double _nowSecond = 0;
        private double second = 0;

        public FormMain()
        {
            InitializeComponent();
        }


        public int n;
        private Button[,] buttons = new Button[6, 6];

        public void GenerateAllButtons(int n)
        {
            int x0 = 50, y0 = 85, w = 45, d = 50;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    int num = r * n + c;
                    Button btn = new Button();
                    btn.Text = (num + 1).ToString();
                    btn.Top = y0 + r * d;
                    btn.Left = x0 + c * d;
                    btn.Width = w;
                    btn.Height = w;
                    btn.Visible = true;
                    //类似按钮的ID，这里用来表示按钮所在的行列位置
                    btn.Tag = r * n + c;
                    //注册事件(Tab)
                    btn.Click += new EventHandler(btn_click);
                    buttons[r, c] = btn;
                    this.Controls.Add(btn);
                }
            }
            buttons[n - 1, n - 1].Visible = false;
        }

        public void Swap(Button btna, Button btnb)
        {
            //交换值和可见属性
            string t = btna.Text;
            btna.Text = btnb.Text;
            btnb.Text = t;
            bool v = btna.Visible;
            btna.Visible = btnb.Visible;
            btnb.Visible = v;
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int a = rnd.Next(n);
                int b = rnd.Next(n);
                int c = rnd.Next(n);
                int d = rnd.Next(n);
                Swap(buttons[a, b], buttons[c, d]);
            }
        }

        public Button FindHiddenButton()
        {
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (!buttons[r, c].Visible)
                    {
                        return buttons[r, c];
                    }
                }
            }
            return null;
        }

        public bool IsNeighbor(Button btna, Button btnb)
        {
            int a = (int)btna.Tag;
            int b = (int)btnb.Tag;
            int r1 = a / n;
            int c1 = a % n;
            int r2 = b / n;
            int c2 = b % n;
            if ((r1 == r2 && (c1 == c2 - 1 || c1 == c2 + 1)) || (c1 == c2) && (r1 == r2 - 1 || r1 == r2 + 1))
            {
                return true;
            }
            return false;
        }

        public bool ResultIsOK()
        {
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (buttons[r, c].Text != (r * n + c + 1).ToString())
                        return false;
                }
            }
            return true;
        }

        public void Btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Button blank = FindHiddenButton();

            if (IsNeighbor(btn, blank))
            {
                Swap(btn, blank);
                blank.Focus();
            }

            if (ResultIsOK())
            {
                timer1.Enabled = false;
                MessageBox.Show("恭喜你，用时为："+second+"秒！");
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ToolStripMenuItemRestart.Enabled = false;
        }

        private void ToolStripMenuItemEasy_Click(object sender, EventArgs e)
        {
            
        }

        private void ToolStripMenuItemCommon_Click(object sender, EventArgs e)
        {
            
        }

        private void ToolStripMenuItemHard_Click(object sender, EventArgs e)
        {
            
        }

        private void ToolStripMenuItemIntroduction_Click(object sender, EventArgs e)
        {
            Introdution i = new Introdution();
            i.ShowDialog();
        }

        private void ToolStripMenuItemRestart_Click(object sender, EventArgs e)
        {
            _nowSecond = 0;
            second = 0;
            labelTime.Text = "用时：" + second.ToString() + " 秒.";
            Shuffle();
        }

        private void buttonEasyGame_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemRestart.Enabled = true;

            labelTime.Visible = true;
            timer1.Enabled = true;
            _nowSecond = 0;
            second = 0;
            buttonEasyGame.Visible = false;
            buttonCommonGame.Visible = false;
            buttonHardGame.Visible = false;
            this.Width = 260;
            this.Height = 300;

            //Button[,] buttonsEasy = new Button[3, 3];
            //buttons = buttonsEasy;
            n = 3;
            GenerateAllButtons(n);

            Shuffle();
        }

        private void buttonCommonGame_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemRestart.Enabled = true;

            labelTime.Visible = true;
            timer1.Enabled = true;
            _nowSecond = 0;
            second = 0;
            buttonEasyGame.Visible = false;
            buttonCommonGame.Visible = false;
            buttonHardGame.Visible = false;
            this.Width = 310;
            this.Height = 350;

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    this.buttons[r, c] = new Button();
                }
            }

            //Button[,] buttonsCommon = new Button[4, 4];
            n = 4;
            GenerateAllButtons(n);

            Shuffle();
        }

        private void buttonHardGame_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemRestart.Enabled = true;

            timer1.Enabled = true;
            labelTime.Visible = true;
            _nowSecond = 0;
            second = 0;
            buttonEasyGame.Visible = false;
            buttonCommonGame.Visible = false;
            buttonHardGame.Visible = false;
            this.Width = 410;
            this.Height = 450;

            //Button[,] buttonsHard = new Button[6, 6];
            //buttons = buttonsHard;

            n = 6;
            GenerateAllButtons(n);

            Shuffle();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _nowSecond++;
            second = _nowSecond / 10;
            labelTime.Text = "用时：" + second.ToString() + " 秒.";
        }

        private void ToolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
