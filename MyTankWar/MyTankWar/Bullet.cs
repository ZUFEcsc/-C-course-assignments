using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyTankWar
{
    class Bullet
    {
        #region
        //子弹坐标位置
        private Point _position = new Point(200, 200);

        //子弹发射方向
        private Direction _dircetion = Direction.Up;

        //子弹运动步长
        private int _step = 10;

        //敌我子弹标志
        Side _side;

        //子弹位图
        private Bitmap _bulletBmp = new Bitmap(16, 16);

        #endregion

        #region

        public Point _Position
        {
            get { return _position; }
            set { _position = value; }
        }


        public Direction _Dircetion
        {
            get { return _dircetion; }
            set { _dircetion = value; }
        }

        public int _Step
        {
            get { return _step; }
            set { _step = value; }
        }

        public Side _Side
        {
            get { return _side; }
            set { _side = value; }
        }

        #endregion

        //构造方法
        public Bullet(Side side, Direction direction)
        {
            //保存敌我方标志
            _side = side;

            //保存子弹发射方向
            _dircetion = direction;

            //根据敌我方和子弹发射方向，装载相应的子弹位图
            if (side == Side.Me)
            {
                if (direction == Direction.Up)
                    _bulletBmp = new Bitmap("Images\\MyBulletUp.gif");
                else if (_dircetion == Direction.Down)
                    _bulletBmp = new Bitmap("Images\\MyBulletDown.gif");
                else if (_dircetion == Direction.Left)
                    _bulletBmp = new Bitmap("Images\\MyBulletLeft.gif");
                else if (_dircetion == Direction.Right)
                    _bulletBmp = new Bitmap("Images\\MyBulletRight.gif");
            }
            else
            {
                if (direction == Direction.Up)
                    _bulletBmp = new Bitmap("Images\\EnemyBulletUp.gif");
                else if (_dircetion == Direction.Down)
                    _bulletBmp = new Bitmap("Images\\EnemyBulletDown.gif");
                else if (_dircetion == Direction.Left)
                    _bulletBmp = new Bitmap("Images\\EnemyBulletLeft.gif");
                else if (_dircetion == Direction.Right)
                    _bulletBmp = new Bitmap("Images\\EnemyBulletRight.gif");
            }

            //设置坦克位图的透明色
            _bulletBmp.MakeTransparent(Color.Black);
        }

        //子弹移动
        public void Move()
        {
            //设置子弹所在位置
            if (_dircetion == Direction.Up)
            {
                _position.Y = _position.Y - _step;
            }
            else if(_dircetion == Direction.Down)
            {
                _position.Y = _position.Y + _step;
            }
            else if (_dircetion == Direction.Left)
            {
                _position.X = _position.X - _step;
            }
            else if (_dircetion == Direction.Right)
            {
                _position.X = _position.X + _step;
            }
        }

        //子弹绘制
        public void DrawMe(Graphics g)
        {
            g.DrawImage(_bulletBmp, _position);
        }
    }
}
