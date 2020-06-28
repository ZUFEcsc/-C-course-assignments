using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OhMyTetris
{
    public abstract class Brick
    {
        #region 私有属性
        //当前变形次序
        private int m_curTransforIndex;

        //必要的行数、列数
        private int m_needfulRows;
        private int m_needfulColumns;
        
        //变形范围
        private int[,] m_range;

        //中心点
        private Point m_center;

        //中心点的位置
        private Point m_pos;

        #endregion
        
        #region 公有属性

        public int m_CurTransforIndex
        {
            get { return m_curTransforIndex; }
            set { m_curTransforIndex = value; }
        }

        public int m_NeedfulRows
        {
            get { return m_needfulRows; }
            set { m_needfulRows = value; }
        }
        public int m_NeedfulColumns
        {
            get { return m_needfulColumns; }
            set { m_needfulColumns = value; }
        }

        public int[,] m_Range
        {
            get { return m_range; }
            set { m_range = value; }
        }

        public Point m_Center
        {
            get { return m_center; }
            set { m_center = value; }
        }
        public Point m_Pos
        {
            get { return m_pos; }
            set { m_pos = value; }
        }
        #endregion

        //自定义方法：判断能否变形
        public abstract bool CanTransform(int[,] arr, int rows, int columns);

        //自定义方法：变形
        public abstract void Transform();

        //自定义方法：判断能否左移
        public abstract bool CanLeftMove(int[,] arr, int rows, int columns);

        //自定义方法：左移
        public void LeftMove()
        {
            m_pos.Y -= 1;
        }

        //自定义方法：判断能否右移
        public abstract bool CanRightMove(int[,] arr, int rows, int columns);

        //自定义方法：右移
        public void RightMove()
        {
            m_pos.Y += 1;
        }

        //自定义方法：判断能否下移
        public abstract bool CanDropMove(int[,] arr, int rows, int columns);

        //自定义方法：下移
        public void DropMove()
        {
            m_pos.X += 1;
        }

        //自定义方法：随机生成形状
        public void RandomShape()
        {
            Random random = new Random();
            this.m_curTransforIndex = random.Next(4);
            this.Transform();
        }

        //自定义方法：设置中心点在画布的位置
        public void SetCenterPos(int x, int y)
        {
            this.m_pos = new Point(x, y);
        }

        //自定义方法：获取砖块出现时y的坐标
        public abstract int Appear();
    }
}
