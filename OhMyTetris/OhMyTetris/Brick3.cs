using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OhMyTetris
{
    class Brick3:Brick
    {
        //定义新砖块的各个值
        public Brick3() 
        {
            this.m_CurTransforIndex = 0;
            this.m_NeedfulColumns = 3;
            this.m_NeedfulRows = 3;
            m_Range = new int[3, 3] { { 0, 1, 0 },
                                      { 1, 1, 1 },
                                      { 0, 0, 0 }};
            this.m_Center = new Point(1, 1);
            this.m_Pos = new Point();
        }

        //重写判断能否变形的方法
        public override bool CanTransform(int[,] arr, int rows, int columns)
        {
            bool result = true;
            if (m_Pos.X - 1 >= 0 && m_Pos.X + 1 <= rows - 1 && m_Pos.Y - 1 >= 0 && m_Pos.Y + 1 <= columns - 1)
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        switch (m_CurTransforIndex)
                        {
                            case 0:
                                if (i == -1 && j == 0 || i == 0 && j == -1 || i == 0 && j == 0 || i == 0 && j == 1)
                                {
                                    continue;
                                }
                                break;
                            case 1:
                                if (i == -1 && j == 0 || i == 0 && j == 0 || i == 0 && j == 1 || i == 1 && j == 0)
                                {
                                    continue;
                                }
                                break;
                            case 2:
                                if (i == 0 && j == -1 || i == 0 && j == 0 || i == 0 && j == 1 || i == 1 && j == 0)
                                {
                                    continue;
                                }
                                break;
                            case 3:
                                if (i == -1 && j == 0 || i == 0 && j == -1 || i == 0 && j == 0 || i == 1 && j == 0)
                                {
                                    continue;
                                }
                                break;
                            default:
                                break;
                        }
                        if (arr[m_Pos.X + i, m_Pos.Y + j] == 1)
                        {
                            result = false;
                        }
                    }
                }
            }
            return result;
        }

        //重写变形的方法
        public override void Transform()
        {
            switch (m_CurTransforIndex)
            {
                case 0:
                    m_Range = new int[3, 3]{{0,1,0},
                                            {0,1,1},
                                            {0,1,0}};
                    m_CurTransforIndex = 1;
                    break;
                case 1:
                    m_Range = new int[3, 3]{{0,0,0},
                                            {1,1,1},
                                            {0,1,0}};
                    m_CurTransforIndex = 2;
                    break;
                case 2:
                    m_Range = new int[3, 3]{{0,1,0},
                                           {1,1,0},
                                           {0,1,0}};
                    m_CurTransforIndex = 3;
                    break;
                case 3:
                    m_Range = new int[3, 3]{{0,1,0},
                                            {1,1,1},
                                            {0,0,0}};
                    m_CurTransforIndex = 0;
                    break;
                default:
                    break;
            }
        }

        //重写判断是否可以左移的方法
        public override bool CanLeftMove(int[,] arr, int rows, int columns)
        {
            bool result = false;
            switch (m_CurTransforIndex)
            {
                case 0:
                    if (m_Pos.Y - 1 != 0)
                    {
                        if (m_Pos.X == 0)
                        {
                            if (arr[m_Pos.X, m_Pos.Y - 2] == 0)
                                result = true;
                        }
                        else
                        {
                            if (arr[m_Pos.X - 1, m_Pos.Y - 1] == 0 && arr[m_Pos.X, m_Pos.Y - 2] == 0)
                                result = true;
                        }
                    }
                    break;
                case 1:
                    if (m_Pos.Y != 0)
                    {
                        if (m_Pos.X == -1)
                        {
                            if (arr[m_Pos.X + 1, m_Pos.Y - 1] == 0)
                                result = true;
                        }
                        else if (m_Pos.X == 0)
                        {
                            if (arr[m_Pos.X, m_Pos.Y - 1] == 0 && arr[m_Pos.X + 1, m_Pos.Y - 1] == 0)
                                result = true;
                        }
                        else
                        {
                            if (arr[m_Pos.X - 1, m_Pos.Y - 1] == 0 && arr[m_Pos.X, m_Pos.Y - 1] == 0 && arr[m_Pos.X + 1, m_Pos.Y - 1] == 0)
                                result = true;
                        }
                    }
                    break;
                case 2:
                    if (m_Pos.Y - 1 != 0)
                    {
                        if (m_Pos.X == -1)
                        {
                            if (arr[m_Pos.X + 1, m_Pos.Y - 1] == 0)
                                result = true;
                        }
                        else
                        {
                            if (arr[m_Pos.X, m_Pos.Y - 2] == 0 && arr[m_Pos.X + 1, m_Pos.Y - 1] == 0)
                                result = true;
                        }
                    }
                    break;
                case 3:
                    if (m_Pos.Y - 1 != 0)
                    {
                        if (m_Pos.X == -1)
                        {
                            if (arr[m_Pos.X + 1, m_Pos.Y - 1] == 0)
                                result = true;
                        }
                        else if (m_Pos.X == 0)
                        {
                            if (arr[m_Pos.X, m_Pos.Y - 2] == 0 && arr[m_Pos.X + 1, m_Pos.Y - 1] == 0)
                                result = true;
                        }
                        else
                        {
                            if (arr[m_Pos.X - 1, m_Pos.Y - 1] == 0 && arr[m_Pos.X, m_Pos.Y - 2] == 0 && arr[m_Pos.X + 1, m_Pos.Y - 1] == 0)
                                result = true;
                        }
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        //重写判断是否可以右移的方法
        public override bool CanRightMove(int[,] arr, int rows, int columns)
        {
            bool result = false;
            switch (m_CurTransforIndex)
            {
                case 0:
                    if (m_Pos.Y + 1 < columns - 1)
                    {
                        if (m_Pos.X == 0)
                        {
                            if (arr[m_Pos.X, m_Pos.Y + 2] == 0)
                                result = true;
                        }
                        else
                        {
                            if (arr[m_Pos.X - 1, m_Pos.Y + 1] == 0 && arr[m_Pos.X, m_Pos.Y + 2] == 0)
                                result = true;
                        }
                    }
                    break;
                case 1:
                    if (m_Pos.Y + 1 < columns - 1)
                    {
                        if (m_Pos.X == -1)
                        {
                            if (arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                                result = true;
                        }
                        else if (m_Pos.X == 0)
                        {
                            if (arr[m_Pos.X, m_Pos.Y + 2] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                                result = true;
                        }
                        else
                        {
                            if (arr[m_Pos.X - 1, m_Pos.Y + 1] == 0 && arr[m_Pos.X, m_Pos.Y + 2] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                                result = true;
                        }
                    }
                    break;
                case 2:
                    if (m_Pos.Y + 1 < columns - 1)
                    {
                        if (m_Pos.X == -1)
                        {
                            if (arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                                result = true;
                        }
                        else
                        {
                            if (arr[m_Pos.X, m_Pos.Y + 2] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                                result = true;
                        }
                    }
                    break;
                case 3:
                    if (m_Pos.Y < columns - 1)
                    {
                        if (m_Pos.X == -1)
                        {
                            if (arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                                result = true;
                        }
                        else if (m_Pos.X == 0)
                        {
                            if (arr[m_Pos.X, m_Pos.Y + 1] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                                result = true;
                        }
                        else
                        {
                            if (arr[m_Pos.X - 1, m_Pos.Y + 1] == 0 && arr[m_Pos.X, m_Pos.Y + 1] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                                result = true;
                        }
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        //重写判断是否可以下移的方法
        public override bool CanDropMove(int[,] arr, int rows, int columns)
        {
            bool result = false;
            switch (m_CurTransforIndex)
            {
                case 0:
                    if (m_Pos.X != rows - 1)
                    {
                        if (arr[m_Pos.X + 1, m_Pos.Y - 1] == 0 && arr[m_Pos.X + 1, m_Pos.Y] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                            result = true;
                    }
                    break;
                case 1:
                    if (m_Pos.X + 1 != rows - 1)
                    {
                        if (arr[m_Pos.X + 2, m_Pos.Y] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                            result = true;
                    }
                    break;
                case 2:
                    if (m_Pos.X + 1 != rows - 1)
                    {
                        if (arr[m_Pos.X + 2, m_Pos.Y] == 0 && arr[m_Pos.X + 1, m_Pos.Y - 1] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                            result = true;
                    }
                    break;
                case 3:
                    if (m_Pos.X + 1 != rows - 1)
                    {
                        if (arr[m_Pos.X + 2, m_Pos.Y] == 0 && arr[m_Pos.X + 1, m_Pos.Y - 1] == 0)
                            result = true;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        //重写获取砖块出现时y的坐标方法
        public override int Appear()
        {
            int result = 0;
            switch (m_CurTransforIndex)
            {
                case 0:
                    result = 0;
                    break;
                case 1:
                    result = -1;
                    break;
                case 2:
                    result = -1;
                    break;
                case 3:
                    result = -1;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
