using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.Runtime.InteropServices; 

namespace OhMyTetris
{
    public partial class FormMain : Form
    {
        #region 私有属性

        //画布模型
        private Canvas m_canvas;   
 
        //画布
        private Graphics m_picture;  

        //用于显示下一个砖块的画布
        private Graphics m_nextpic;

        //装载声音文件
        private SoundPlayer m_bgm = new SoundPlayer("bgm.wav");
        private SoundPlayer m_gameover = new SoundPlayer("gameover.wav");
        private SoundPlayer m_disappear = new SoundPlayer("disappear.wav");

        private float m_x;
        private float m_y;
        private bool m_isrun;

        #endregion

        #region 停止背景音乐的播放

        [DllImport("winmm.DLL",EntryPoint = "PlaySound",
            SetLastError = true,CharSet = CharSet.Unicode,ThrowOnUnmappableChar = true)]
        private static extern bool PlaySound(string szSound, System.IntPtr hMod,PlaySoundFlags flags);
        [System.Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000, //同步播放声音，在播放完后PlaySound函数才返回
            SND_ASYNC = 0x0001, //用异步方式播放声音，PlaySound函数在开始播放后立即返回
            SND_NODEFAULT = 0x0002, //不播放缺省声音，若无此标志，则PlaySound在没找到声音时会播放缺省声音
            SND_LOOP = 0x0008, //重复播放声音，必须与SND_ASYNC标志一块使用
            SND_NOSTOP = 0x0010, //PlaySound不打断原来的声音播出并立即返回FALSE
            SND_NOWAIT = 0x00002000, //如果驱动程序正忙则函数就不播放声音并立即返回
            SND_FILENAME = 0x00020000, //pszSound参数指定了WAVE文件名
            SND_RESOURCE = 0x00040004 //pszSound参数是WAVE资源的标识符，这时要用到hmod参数
        }

        public void runSound()
        {
            PlaySound("bgm.wav", IntPtr.Zero,PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_LOOP);
        }
        #endregion

        //开启或禁止背景音乐事件：
        private void buttonPlayMusic_Click(object sender, EventArgs e)
        {
            //如果是音符，就停止播放背景乐
            if (buttonPlayMusic.Text == "🈲")
            {
                PlaySound(null, IntPtr.Zero, PlaySoundFlags.SND_ASYNC);
                buttonPlayMusic.Text = "🎵";
            }
            //如果显示是音乐，就重新播放背景乐
            else
            {
                m_bgm.PlayLooping();
                buttonPlayMusic.Text = "🈲";
            }
        }

        public FormMain()
        {
            InitializeComponent();

            //设置label和picture的Parent属性为pictureHole，显示更自然
            labelIntroduction.Parent = pictureBoxHole;
            labelScore.Parent = pictureBoxHole;
            labelGameover.Parent = pictureBox1;
            pictureBox2.Parent = pictureBoxHole;
            pictureBox1.Parent = pictureBoxHole;
            buttonPlayMusic.Parent = pictureBoxHole;

            pictureBox1.Focus();

            m_canvas = new Canvas();

            m_picture = pictureBox1.CreateGraphics();
            m_nextpic = pictureBox2.CreateGraphics();

            m_x = pictureBox1.Width / m_canvas.m_Columns;
            m_y = pictureBox1.Height / m_canvas.m_Rows;

            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //如果有些还没结束
            //错误:无法将方法组“Run”转换为非委托类型“bool”。
            //改正：在后面加个括号就好了
            if (m_canvas.Run() == true)
            {
                Draw();
                DrawNext();
                DrawScore();
            }
            else
            {
                timer1.Enabled = false;
                if (m_canvas.m_Score >= 100)
                {
                    //MessageBox.Show("游戏结束！胜利！");
                }
                else
                {
                    Graphics g = CreateGraphics();
                    labelGameover.Visible = true;
                    m_gameover.Play();
                    buttonStop.Enabled = false;
                }
            }
        }

        //自定义方法：创建画布
        private void Draw()
        {
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            //从canvas创建新的graphics
            Graphics g = Graphics.FromImage(canvas);

            for (int i = 0; i < m_canvas.m_Rows; i++)
            {
                for (int j = 0; j < m_canvas.m_Columns; j++)
                {
                    if (m_canvas.m_Arr[i, j] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        DrawItem(g, i, j);
                    }
                }
            }
            pictureBox1.BackgroundImage = canvas;
            pictureBox1.Refresh();
        }

        //自定义方法：显示游戏窗口
        private void DrawItem(Graphics g, int row, int column)
        {
            float xpos = column * m_x - 1;
            float ypos = row * m_y - 1;
            g.FillRectangle(Brushes.Orange, xpos, ypos, m_x - 2, m_y - 2);
        }

        //自定义方法：显示下一个砖块
        private void DrawNext()
        {
            pictureBox2.Refresh();
            m_canvas.DrawNewxBrick(m_nextpic, m_x, m_y);
        }

        //自定义方法：显示当前得分
        private void DrawScore()
        {
            string temp = "当前得分：" + (m_canvas.m_Score*10).ToString() + "分";
            labelScore.Text = temp;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
            {
                return false;
            }
            return base.ProcessDialogKey(keyData);
        }

        //键盘响应事件：
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            if (m_isrun == true)
            {
                if (key == Keys.Up)
                {
                    pictureBox1.Refresh();
                    m_canvas.BrickUp();
                    Draw();
                }
                if (key == Keys.Left)
                {
                    pictureBox1.Refresh();
                    m_canvas.BrickLeft();
                    Draw();
                }
                if (key == Keys.Right)
                {
                    pictureBox1.Refresh();
                    m_canvas.BrickRight();
                    Draw();
                }
                if (key == Keys.Down)
                {
                    pictureBox1.Refresh();
                    m_canvas.BrickDown();
                    Draw();
                }
            }
        }

        //开始事件：
        private void buttonBegin_Click(object sender, EventArgs e)
        {
            if (buttonBegin.Text == "开   始")
            {
                buttonBegin.Text = "重新开始";
            }
            else 
            {
                m_isrun = false;
                timer1.Enabled = false;
            }
            m_canvas = new Canvas();
            buttonStop.Enabled = true;
            labelGameover.Visible = false;
            m_bgm.PlayLooping();
            m_isrun = true;
            timer1.Enabled = true;
        }

        //暂停继续事件：
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (buttonStop.Text == "暂   停")
            {
                m_isrun = false;
                timer1.Enabled = false;
                PlaySound(null, IntPtr.Zero, PlaySoundFlags.SND_ASYNC);
                buttonStop.Text = "继   续";
            }
            else
            {
                m_isrun = true;
                timer1.Enabled = true;
                m_bgm.PlayLooping();
                buttonStop.Text = "暂   停";
            }
        }

        //退出事件：
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
