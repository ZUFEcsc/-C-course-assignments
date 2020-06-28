using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OhMyTetris
{
    //田字砖
    class Brick1:Brick
    {
        //定义新砖块的各个值
        public Brick1() 
        {
            this.m_CurTransforIndex = 0;
            this.m_NeedfulRows = 2;
            this.m_NeedfulColumns = 2;
            m_Range = new int[2, 2]{{1,1},
                                    {1,1}};
            this.m_Center = new Point(0, 0);
            this.m_Pos = new Point();
        }

        //重写判断能否变形的方法
        public override bool CanTransform(int[,] arr, int rows, int columns)
        {
            return false;
        }

        //重写变形的方法
        public override void Transform()
        {
            return;
        }

        //重写判断是否可以左移的方法
        public override bool CanLeftMove(int[,] arr, int rows, int columns)
        {
            if (m_Pos.X < 0)
            {
                if (m_Pos.Y == 0 || arr[m_Pos.X + 1, m_Pos.Y - 1] == 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            if (m_Pos.Y == 0 || arr[m_Pos.X, m_Pos.Y - 1] == 1 || arr[m_Pos.X + 1, m_Pos.Y - 1] == 1)
                return false;
            else
                return true;
        }

        //重写判断是否可以右移的方法
        public override bool CanRightMove(int[,] arr, int rows, int columns)
        {
            if (m_Pos.X < 0)
            {
                if (m_Pos.Y == columns - 2 || arr[m_Pos.X + 1, m_Pos.Y + 2] == 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            if (m_Pos.Y == columns - 2 || arr[m_Pos.X, m_Pos.Y + 2] == 1 || arr[m_Pos.X + 1, m_Pos.Y + 2] == 1)
                return false;
            else
                return true;
        }

        //重写判断是否可以下移的方法
        public override bool CanDropMove(int[,] arr, int rows, int columns)
        {
            if (m_Pos.X < rows - 2 && arr[m_Pos.X + 2, m_Pos.Y] == 0 && arr[m_Pos.X + 2, m_Pos.Y + 1] == 0)
                return true;
            return false;
        }

        //重写获取砖块出现时y的坐标方法
        public override int Appear()
        {
            return -1;
        }
    }
}
