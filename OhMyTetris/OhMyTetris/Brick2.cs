using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OhMyTetris
{
    class Brick2:Brick
    {
        //定义新砖块的各个值
        public Brick2() 
        {
            this.m_CurTransforIndex = 0;
            this.m_NeedfulColumns = 5;
            this.m_NeedfulRows = 5;
            m_Range = new int[5, 5] { { 0, 0, 0, 0, 0 },
                                      { 0, 0, 0, 0, 0 },
                                      { 0, 1, 1, 1, 1 },
                                      { 0, 0, 0, 0, 0 },
                                      { 0, 0, 0, 0, 0 }};
            this.m_Center = new Point(2, 2);
            this.m_Pos = new Point();
        }

        //重写判断能否变形的方法
        public override bool CanTransform(int[,] arr, int rows, int columns)
        {
            bool result = false;
            if (m_Pos.X - 2 >= 0 && m_Pos.X + 2 <= rows - 1 && m_Pos.Y - 2 >= 0 && m_Pos.Y + 2 <= columns - 1)
            {
                switch (m_CurTransforIndex)
                {
                    case 0:
                        arr[m_Pos.X, m_Pos.Y - 1] = 0;
                        arr[m_Pos.X, m_Pos.Y] = 0;
                        arr[m_Pos.X, m_Pos.Y + 1] = 0;
                        arr[m_Pos.X, m_Pos.Y + 2] = 0;
                        break;
                    case 1:
                        arr[m_Pos.X - 1, m_Pos.Y] = 0;
                        arr[m_Pos.X, m_Pos.Y] = 0;
                        arr[m_Pos.X + 1, m_Pos.Y] = 0;
                        arr[m_Pos.X + 2, m_Pos.Y] = 0;
                        break;
                    case 2:
                        arr[m_Pos.X, m_Pos.Y - 2] = 0;
                        arr[m_Pos.X, m_Pos.Y - 1] = 0;
                        arr[m_Pos.X, m_Pos.Y] = 0;
                        arr[m_Pos.X, m_Pos.Y + 1] = 0;
                        break;
                    case 3:
                        arr[m_Pos.X - 2, m_Pos.Y] = 0;
                        arr[m_Pos.X - 1, m_Pos.Y] = 0;
                        arr[m_Pos.X, m_Pos.Y] = 0;
                        arr[m_Pos.X + 1, m_Pos.Y] = 0;
                        break;
                    default:
                        break;
                }
                bool temp = true;
                for (int i = -2; i < 3; i++)
                {
                    for (int j = -2; j < 3; j++)
                    {
                        if (arr[m_Pos.X + i, m_Pos.Y + j] == 1)
                        {
                            temp = false;
                            goto break2;
                        }
                    }
                }
            break2:
                result = temp;
                switch (m_CurTransforIndex)
                {
                    case 0:
                        arr[m_Pos.X, m_Pos.Y - 1] = 1;
                        arr[m_Pos.X, m_Pos.Y] = 1;
                        arr[m_Pos.X, m_Pos.Y + 1] = 1;
                        arr[m_Pos.X, m_Pos.Y + 2] = 1;
                        break;
                    case 1:
                        arr[m_Pos.X - 1, m_Pos.Y] = 1;
                        arr[m_Pos.X, m_Pos.Y] = 1;
                        arr[m_Pos.X + 1, m_Pos.Y] = 1;
                        arr[m_Pos.X + 2, m_Pos.Y] = 1;
                        break;
                    case 2:
                        arr[m_Pos.X, m_Pos.Y - 2] = 1;
                        arr[m_Pos.X, m_Pos.Y - 1] = 1;
                        arr[m_Pos.X, m_Pos.Y] = 1;
                        arr[m_Pos.X, m_Pos.Y + 1] = 1;
                        break;
                    case 3:
                        arr[m_Pos.X - 2, m_Pos.Y] = 1;
                        arr[m_Pos.X - 1, m_Pos.Y] = 1;
                        arr[m_Pos.X, m_Pos.Y] = 1;
                        arr[m_Pos.X + 1, m_Pos.Y] = 1;
                        break;
                    default:
                        break;
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
                    m_Range = new int[5, 5]{{0,0,0,0,0},
                                            {0,0,1,0,0},
                                            {0,0,1,0,0},
                                            {0,0,1,0,0},
                                            {0,0,1,0,0}};
                    m_CurTransforIndex = 1;
                    break;
                case 1:
                    m_Range = new int[5, 5]{{0,0,0,0,0},
                                            {0,0,0,0,0},
                                            {1,1,1,1,0},
                                            {0,0,0,0,0},
                                            {0,0,0,0,0}};
                    m_CurTransforIndex = 2;
                    break;
                case 2:
                    m_Range = new int[5, 5]{{0,0,1,0,0},
                                            {0,0,1,0,0},
                                            {0,0,1,0,0},
                                            {0,0,1,0,0},
                                            {0,0,0,0,0}};
                    m_CurTransforIndex = 3;
                    break;
                case 3:
                    m_Range = new int[5, 5]{{0,0,0,0,0},
                                            {0,0,0,0,0},
                                            {0,1,1,1,1},
                                            {0,0,0,0,0},
                                            {0,0,0,0,0}};
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
                    if (m_Pos.Y > 1)
                    {
                        if (arr[m_Pos.X, m_Pos.Y - 2] == 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    break;
                case 1:
                    if (m_Pos.Y > 0)
                    {
                        bool temp = true;
                        for (int i = -1; i < 3; i++)
                        {
                            if (m_Pos.X + i < 0)
                            {
                                continue;
                            }
                            else
                            {
                                if (arr[m_Pos.X + i, m_Pos.Y - 1] == 1)
                                {
                                    temp = false;
                                    break;
                                }
                            }
                        }
                        result = temp;
                    }
                    break;
                case 2:
                    if (m_Pos.Y > 2)
                    {
                        if (arr[m_Pos.X, m_Pos.Y - 3] == 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    break;
                case 3:
                    if (m_Pos.Y > 0)
                    {
                        bool temp = true;
                        for (int i = -2; i < 2; i++)
                        {
                            if (m_Pos.X + i < 0)
                            {
                                continue;
                            }
                            else
                            {
                                if (arr[m_Pos.X + i, m_Pos.Y - 1] == 1)
                                {
                                    temp = false;
                                    break;
                                }
                            }
                        }
                        result = temp;
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
                    if (m_Pos.Y < columns - 3)
                    {
                        if (arr[m_Pos.X, m_Pos.Y + 3] == 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    break;
                case 1:
                    if (m_Pos.Y < columns - 1)
                    {
                        bool temp = true;
                        for (int i = -1; i < 3; i++)
                        {
                            if (m_Pos.X + i < 0)
                            {
                                continue;
                            }
                            else
                            {
                                if (arr[m_Pos.X + i, m_Pos.Y + 1] == 1)
                                {
                                    temp = false;
                                    break;
                                }
                            }
                        }
                        result = temp;
                    }
                    break;
                case 2:
                    if (m_Pos.Y < columns - 2)
                    {
                        if (arr[m_Pos.X, m_Pos.Y + 2] == 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    break;
                case 3:
                    if (m_Pos.Y < columns - 1)
                    {
                        bool temp = true;
                        for (int i = -2; i < 2; i++)
                        {
                            if (m_Pos.X + i < 0)
                            {
                                continue;
                            }
                            else
                            {
                                if (arr[m_Pos.X + i, m_Pos.Y + 1] == 1)
                                {
                                    temp = false;
                                    break;
                                }
                            }
                        }
                        result = temp;
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
                        if (arr[m_Pos.X + 1, m_Pos.Y] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 1] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 2] == 0 && arr[m_Pos.X + 1, m_Pos.Y - 1] == 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    break;
                case 1:
                    if (m_Pos.X != rows - 3)
                    {
                        if (arr[m_Pos.X + 3, m_Pos.Y] == 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    break;
                case 2:
                    if (m_Pos.X != rows - 1)
                    {
                        if (arr[m_Pos.X + 1, m_Pos.Y - 2] == 0 && arr[m_Pos.X + 1, m_Pos.Y - 1] == 0 && arr[m_Pos.X + 1, m_Pos.Y] == 0 && arr[m_Pos.X + 1, m_Pos.Y + 1] == 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    break;
                case 3:
                    if (m_Pos.X != rows - 2)
                    {
                        if (arr[m_Pos.X + 2, m_Pos.Y] == 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
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
                    result = -2;
                    break;
                case 2:
                    result = 0;
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
