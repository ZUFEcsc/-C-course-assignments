using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyTankWar
{
    public partial class FormMian : Form
    {
        #region 私有字段
        
        //游戏状态
        private GameState _gameState = GameState.Close;

        //我方坦克
        private Tank _myTank = new Tank(Side.Me);

        //敌方坦克List集合
        private List<Tank> _listEnemyTank = new List<Tank>();

        //子弹的List集合
        private List<Bullet> _listBullet = new List<Bullet>();

        #endregion

        //导入动态链接库(System.Runtime.InteropServices)
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetAsyncKeyState(int keyCode);

        public FormMian()
        {
            InitializeComponent();
        }

        private void BeginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //开始游戏
            _gameState = GameState.Open;

            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;
        }

        private void EndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //结束游戏
            _gameState = GameState.Close;

            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //绘制我方坦克
            _myTank.DrawMe(e.Graphics);

            //绘制敌方坦克
            for (int i = 0;i <= _listEnemyTank.Count - 1 ;i++)
                _listEnemyTank[i].DrawMe(e.Graphics);

            //逐一绘制子弹
            foreach (Bullet myBullet in _listBullet)
            {
                myBullet.DrawMe(e.Graphics);
            }
        }

        private void FormMian_KeyDown(object sender, KeyEventArgs e)
        {
            if(_gameState == GameState.Open)
            {
                //如果按下Space键，则我方坦克发射子弹
                if (e.KeyCode == Keys.Space)
                {
                    //我方坦克发射子弹，并添加到_listBullet中
                    Bullet myBullet = _myTank.Fire();
                    _listBullet.Add(myBullet);
                }

                //强制刷新pictureBox1控件
                pictureBox1.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_gameState == GameState.Open)
            {
                //产生一辆坦克
                Tank enemyTank = new Tank(Side.Enemy);

                //把坦克加到链表中
                _listEnemyTank.Add(enemyTank);

                //强制刷新
                pictureBox1.Invalidate();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_gameState == GameState.Open)
            {
                //定义一个随机类
                Random myRand = new Random(DateTime.Now.Second);

                //随机控制每一辆敌方坦克的运动方向
                for (int i = 0; i <= _listEnemyTank.Count - 1; i++)
                {
                    int newDircetion = myRand.Next(1, 20);

                    if(newDircetion <= 4)
                        _listEnemyTank[i].Move((Direction)newDircetion);
                    else 
                        _listEnemyTank[i].Move(_listEnemyTank[i]._Dircetion);
                }

                //让子弹飞起来
                foreach (Bullet myBullet in _listBullet)
                {
                    myBullet.Move();
                }

                //强制刷新
                pictureBox1.Invalidate();
            }
        }

        //Timer实现敌方坦克发射子弹功能
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (_gameState == GameState.Open)
            {
                //定义一个随机类
                Random myRand = new Random(DateTime.Now.Second);

                //让子弹飞起来
                foreach (Tank enemyTank in _listEnemyTank)
                {
                    int fireFlag = myRand.Next(1, 10);

                    if (fireFlag <= 4)
                    {
                        Bullet enemyBullet = enemyTank.Fire();
                        _listBullet.Add(enemyBullet);
                    }
                }

                //强制刷新
                pictureBox1.Invalidate();
            }
        }

        //定时测定按下方向键下压状态，解决我方坦克边移动边发射子弹的问题
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (_gameState == GameState.Open)
            {
                bool keyDown = (((ushort)GetAsyncKeyState((int)Keys.Down)) & 0xffff) != 0;
                if (keyDown == true)
                    _myTank.Move(Direction.Down);
                bool keyUp = (((ushort)GetAsyncKeyState((int)Keys.Up)) & 0xffff) != 0;
                if (keyUp == true)
                    _myTank.Move(Direction.Up);
                bool keyLeft = (((ushort)GetAsyncKeyState((int)Keys.Left)) & 0xffff) != 0;
                if (keyLeft == true)
                    _myTank.Move(Direction.Left);
                bool keyRight = (((ushort)GetAsyncKeyState((int)Keys.Right)) & 0xffff) != 0;
                if (keyRight == true)
                    _myTank.Move(Direction.Right);

                pictureBox1.Invalidate();

            }
        }

        
    }
}
