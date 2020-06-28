using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace OhMyTetris
{
    class Canvas
    {
        #region 私有属性
        private int m_rows;
        private int m_columns;
        private int[,] m_arr;

        //装载声音文件
        private SoundPlayer m_bgm = new SoundPlayer("bgm.wav");
        private SoundPlayer m_disappear = new SoundPlayer("disappear.wav");

        //分数
        private int m_score;

        //当前砖块
        private Brick m_curBrick = null;
        
        //下一个砖块
        private Brick m_nextBrick = null;

        //判断是否消除行
        private bool m_flag = false;

        //当前高度
        private int m_height;

        private System.Windows.Forms.Timer m_timer = new System.Windows.Forms.Timer();

        #endregion 

        #region 公有属性

        public int m_Rows
        {
            get { return m_rows; }
            set { m_rows = value; }
        }

        public int m_Columns
        {
            get { return m_columns; }
            set { m_columns = value; }
        }

        public int[,] m_Arr
        {
            get { return m_arr; }
            set { m_arr = value; }
        }

        public int m_Score
        {
            get { return m_score; }
            set { m_score = value; }
        }
        #endregion

        //构造方法
        public Canvas()
        {
            m_rows = 20;
            m_columns = 20;
            m_arr = new int[m_rows, m_columns];
            for (int i = 0; i < m_rows; i++)
            {
                for (int j = 0; j < m_columns; j++)
                {
                    m_arr[i, j] = 0;
                }
            }
            m_score = 0;
            m_height = 0;

            m_timer.Interval = 2400;
            m_timer.Enabled = false;
            m_timer.Tick += new EventHandler(m_timer_Tick);

        }

        #region 移动
        //左移
        public void BrickLeft()
        {
            lock (m_arr)
            {
                if (m_curBrick != null && m_curBrick.CanLeftMove(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.LeftMove();
                    SetArrayValue();
                }
            }
        }

        //右移
        public void BrickRight()
        {
            lock (m_arr)
            {
                if (m_curBrick != null && m_curBrick.CanRightMove(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.RightMove();
                    SetArrayValue();
                }
            }
        }

        //下移
        public void BrickDown()
        {
            lock (m_arr)
            {
                if (m_curBrick != null && m_curBrick.CanDropMove(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.DropMove();
                    SetArrayValue();
                }
            }
        }

        #endregion

        //自定义方法：变形
        public void BrickUp()
        {
            lock (m_arr)
            {
                if (m_curBrick != null && m_curBrick.CanTransform(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.Transform();
                    SetArrayValue();
                }
            }
        }

        //自定义方法：计算当期高度
        private void SetCurHeight()
        {
            for (int i = 0; i < m_rows; i++)
            {
                for (int j = 0; j < m_columns; j++)
                {
                    if (m_arr[i, j] == 1)
                    {
                        m_height = m_rows - i;
                        return;
                    }
                }
            }
        }

        //自定义方法：定时器 判断砖块定时下降或无法下降时生成下一个新砖块
        public bool Run()
        {
            //lock 关键字可确保当一个线程位于代码的临界区时，另一个线程不会进入该临界区。
            //如果其他线程试图进入锁定的代码，则它将一直等待（即被阻止），直到该对象被释放。
            //lock 应避免锁定 public 类型，否则实例将超出代码的控制范围。
            lock (m_arr)
            {
                if (m_flag == true)
                {
                    m_bgm.PlayLooping();
                    m_flag = false;
                }
                if (m_curBrick == null && m_nextBrick == null)
                {
                    m_curBrick = Bricks.GetBrick();
                    m_nextBrick = Bricks.GetBrick();
                    m_nextBrick.RandomShape();
                    m_curBrick.SetCenterPos(m_curBrick.Appear(), m_columns / 2 - 1);
                    SetArrayValue();
                }
                else if (m_curBrick == null)
                {
                    m_curBrick = m_nextBrick;
                    m_nextBrick = Bricks.GetBrick();
                    m_nextBrick.RandomShape();
                    m_curBrick.SetCenterPos(m_curBrick.Appear(), m_columns / 2 - 1);
                    SetArrayValue();
                }
                else
                {
                    if (m_curBrick.CanDropMove(m_arr, m_rows, m_columns) == true)
                    {
                        ClearCurBrick();
                        m_curBrick.DropMove();
                        SetArrayValue();
                    }
                    else
                    {
                        m_curBrick = null;
                        SetCurHeight();
                        ClearRow();
                    }
                }
                if (m_score >= 100)
                    return false;
                if (m_height < m_rows)
                    return true;
                else
                    return false;
            }
        }

        //自定义方法：根据清除当前砖块在m_arr中的值
        private void ClearCurBrick()
        {
            int centerX = m_curBrick.m_Center.X;
            int centerY = m_curBrick.m_Center.Y;
            for (int i = 0; i < m_curBrick.m_NeedfulRows; i++)
            {
                for (int j = 0; j < m_curBrick.m_NeedfulColumns; j++)
                {
                    int realX = m_curBrick.m_Pos.X - (centerX - i);
                    int realY = m_curBrick.m_Pos.Y - (centerY - j);
                    if (realX < 0 || realX >= m_columns || realY < 0 || realY >= m_rows)
                    {
                        continue;
                    }
                    else
                    {
                        if (m_curBrick.m_Range[i, j] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            m_arr[realX, realY] = 0;
                        }
                    }
                }
            }
        }

        //自定义方法：判断当前砖块设置m_arr的值
        public void SetArrayValue()
        {
            int centerX = m_curBrick.m_Center.X;
            int centerY = m_curBrick.m_Center.Y;
            for (int i = 0; i < m_curBrick.m_NeedfulRows; i++)
            {
                for (int j = 0; j < m_curBrick.m_NeedfulColumns; j++)
                {
                    int realX = m_curBrick.m_Pos.X - (centerX - i);
                    int realY = m_curBrick.m_Pos.Y - (centerY - j);
                    if (realX < 0 || realX >= m_columns || realY < 0 || realY >= m_rows)
                    {
                        continue;
                    }
                    else
                    {
                        if (m_curBrick.m_Range[i, j] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            m_arr[realX, realY] = 1;
                        }
                    }
                }
            }
        }

        //自定义方法：画出下一个砖块
        public void DrawNewxBrick(Graphics gra, float width, float heigth)
        {
            int[,] arr = new int[5, 5]{{0,0,0,0,0},
                                         {0,0,0,0,0},
                                         {0,0,0,0,0},
                                         {0,0,0,0,0},
                                         {0,0,0,0,0,}};
            switch (m_nextBrick.m_NeedfulColumns)
            {
                case 2:
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[3, 2] = 1;
                    arr[3, 3] = 1;
                    break;
                case 3:
                    for (int i = 1, m = 0; i < 4; i++, m++)
                    {
                        for (int j = 1, n = 0; j < 4; j++, n++)
                        {
                            arr[i, j] = m_nextBrick.m_Range[m, n];
                        }
                    }
                    break;
                case 5:
                    arr = m_nextBrick.m_Range;
                    break;
                default:
                    return;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        gra.FillRectangle(Brushes.Orange, j * width, i * heigth, width - 2, heigth - 2);
                    }
                }
            }
        }

        //自定义方法：播放声音文件
        private void PlaySound(SoundPlayer soundFile)
        {
            //使用新线程播放声音
            soundFile.Play();
        }
        //自定义方法：消除音乐的计时器
        void m_timer_Tick(object sender, EventArgs e)
        {
            m_flag = true;
            m_timer.Enabled = false;
        }

        //自定义方法：判断有没有填满的行，有就消除,更新得分
        private void ClearRow()
        {
            int clearrows = 0;
            for (int i = m_rows - m_height; i < m_rows; i++)
            {
                bool isfull = true;
                for (int j = 0; j < m_columns; j++)
                {
                    if (m_arr[i, j] == 0)
                    {
                        isfull = false;
                        break;
                    }
                }
                if (isfull == true)
                {
                    m_timer.Enabled = true;
                    m_disappear.Play();
                    clearrows++;
                    m_score++;
                    for (int k = 0; k < m_columns; k++)
                    {
                        m_arr[i, k] = 0;
                    }
                }
            }
            for (int i = m_rows - 1; i > m_rows - m_height - 1; i--)
            {
                bool isfull = true;
                for (int j = 0; j < m_columns; j++)
                {
                    if (m_arr[i, j] == 1)
                    {
                        isfull = false;
                        break;
                    }
                }
                if (isfull == true)
                {
                    
                    int n = i;
                    for (int m = n - 1; m > m_rows - m_height - 2; m--)
                    {
                        if (n == 0)
                        {
                            for (int k = 0; k < m_columns; k++)
                            {
                                m_arr[n, k] = 0;
                            }
                        }
                        else
                        {
                            for (int k = 0; k < m_columns; k++)
                            {
                                m_arr[n, k] = m_arr[m, k];
                            }
                            n--;
                        }
                    }
                }
            }
            m_height -= clearrows;
        }

    }
}
