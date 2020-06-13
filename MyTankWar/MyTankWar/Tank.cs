using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MyTankWar
{
    //枚举游戏状态
    public enum GameState
    {
        Close = 1,Open = 2,Pause = 3
    }

    //枚举坦克运动方向
    public enum Direction
    {
        Up = 1,Down = 2,Left = 3, Right = 4
    }

    //枚举敌我双方
    public enum Side
    {
        Me = 1, Enemy = 2
    }

    class Tank
    {
        #region 私有属性
        //坦克坐标位置
        private Point _position = new Point(200, 200);

        //坦克运动方向
        private Direction _dircetion = Direction.Up;

        //坦克运动步长
        private int _step = 5;

        //坦克尺寸大小
        private int _size = 30;

        //敌我标志
        Side _side;

        //坦克位图数组
        private Bitmap[] _tankBmp = new Bitmap[8];

        //当前坦克位图
        private Bitmap _nowTankBmp = new Bitmap(30, 30);

        //坦克位图轮换标志
        private Boolean _tankBmpChange = true;
        #endregion

        #region 公有属性

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

        public int _Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Side _Side
        {
            get { return _side; }
            set { _side = value; }
        }

        #endregion

        //类构造方法
        public Tank(Side side)
        {
            //保存敌我方标志
            _side = side;
            if (side == Side.Me)
            {
                //装载坦克位图
                _tankBmp[0] = new Bitmap("Images\\MyTankUp1.gif");
                _tankBmp[1] = new Bitmap("Images\\MyTankUp2.gif");
                _tankBmp[2] = new Bitmap("Images\\MyTankDown1.gif");
                _tankBmp[3] = new Bitmap("Images\\MyTankDown2.gif");
                _tankBmp[4] = new Bitmap("Images\\MyTankLeft1.gif");
                _tankBmp[5] = new Bitmap("Images\\MyTankLeft2.gif");
                _tankBmp[6] = new Bitmap("Images\\MyTankRight1.gif");
                _tankBmp[7] = new Bitmap("Images\\MyTankRight2.gif");

                //让我方坦克在屏幕正下方中央生成
                _position.X = Screen.PrimaryScreen.Bounds.Width / 2 - _size / 2;
                _position.Y = Screen.PrimaryScreen.Bounds.Height - 150;

                //设置我方坦克默认的运动方向为上
                _dircetion = Direction.Up;
            }
            else
            {
                //装载坦克位图
                _tankBmp[0] = new Bitmap("Images\\EnemyTankUp1.gif");
                _tankBmp[1] = new Bitmap("Images\\EnemyTankUp2.gif");
                _tankBmp[2] = new Bitmap("Images\\EnemyTankDown1.gif");
                _tankBmp[3] = new Bitmap("Images\\EnemyTankDown2.gif");
                _tankBmp[4] = new Bitmap("Images\\EnemyTankLeft1.gif");
                _tankBmp[5] = new Bitmap("Images\\EnemyTankLeft2.gif");
                _tankBmp[6] = new Bitmap("Images\\EnemyTankRight1.gif");
                _tankBmp[7] = new Bitmap("Images\\EnemyTankRight2.gif");

                //让敌方坦克在屏幕正下方中央生成
                _position.X = Screen.PrimaryScreen.Bounds.Width / 2 - _size / 2;
                _position.Y = _size;

                //设置敌方坦克默认的运动方向为上
                _dircetion = Direction.Down;
            }
            //设置坦克的透明度
            for (int i = 0; i <= 7; i++)
                _tankBmp[i].MakeTransparent(Color.Black);
            
            //当前坦克位图为向上运动的位图
            _nowTankBmp = _tankBmp[0];
        }

        //坦克移动
        public void Move(Direction direction)
        {
            //保存运动方向
            _dircetion = direction;

            if (_dircetion == Direction.Up)
            {
                //设定坦克移动后所在的位置
                _position.Y = _position.Y - _step;

                //设置当前显示的坦克位图（为了让坦克移动效果更逼真，需要在两幅位图之间进行切换）
                if (_tankBmpChange == true)
                    _nowTankBmp = _tankBmp[0];
                else
                    _nowTankBmp = _tankBmp[1];
            }

            else if (_dircetion == Direction.Down)
            {
                //设定坦克移动后所在的位置
                _position.Y = _position.Y + _step;

                //设置当前显示的坦克位图（为了让坦克移动效果更逼真，需要在两幅位图之间进行切换）
                if (_tankBmpChange == true)
                    _nowTankBmp = _tankBmp[2];
                else
                    _nowTankBmp = _tankBmp[3];
            }

            else if (_dircetion == Direction.Left)
            {
                //设定坦克移动后所在的位置
                _position.X = _position.X - _step;

                //设置当前显示的坦克位图（为了让坦克移动效果更逼真，需要在两幅位图之间进行切换）
                if (_tankBmpChange == true)
                    _nowTankBmp = _tankBmp[4];
                else
                    _nowTankBmp = _tankBmp[5];
            }

            else if (_dircetion == Direction.Right)
            {
                //设定坦克移动后所在的位置
                _position.X = _position.X + _step;

                //设置当前显示的坦克位图（为了让坦克移动效果更逼真，需要在两幅位图之间进行切换）
                if (_tankBmpChange == true)
                    _nowTankBmp = _tankBmp[6];
                else
                    _nowTankBmp = _tankBmp[7];
            }

            //切换坦克为位图轮换标志
            _tankBmpChange = !_tankBmpChange;

        }

        //坦克绘制
        public void DrawMe(Graphics g)
        {
            g.DrawImage(_nowTankBmp, _position);
        }

        //坦克发射子弹
        public Bullet Fire()
        {
            Bullet myBullet = new Bullet(_side, _dircetion);
            if (_dircetion == Direction.Up)
            {
                myBullet._Position = new Point(_position.X + 8,_position.Y - 15);
            }
            else if (_dircetion == Direction.Down)
            {
                myBullet._Position = new Point(_position.X + 8, _position.Y + 25);
            }
            else if (_dircetion == Direction.Left)
            {
                myBullet._Position = new Point(_position.X - 15, _position.Y + 8);
            }
            else if (_dircetion == Direction.Right)
            {
                myBullet._Position = new Point(_position.X + 25, _position.Y + 8);
            }
            return myBullet;
        }
    }
}
