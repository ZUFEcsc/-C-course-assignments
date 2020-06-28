using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace OhMyTetris
{
    class Bricks
    {
        //lock线程锁，所以方法和属性都要用静态的
        public static ArrayList _brickList = new ArrayList();

        //静态方法:随机获取一个砖块
        //非静态的字段、方法或属性“member”要求对象引用
        public static Brick GetBrick()
        {
            Random random = new Random(DateTime.Now.Second);
            int index = random.Next(7);
            Brick brick;
            switch (index)
            {
                case 0:
                    brick = new Brick1(); break;
                case 1:
                    brick = new Brick2(); break;
                case 2:
                    brick = new Brick3(); break;
                case 3:
                    brick = new Brick4(); break;
                case 4:
                    brick = new Brick5(); break;
                case 5:
                    brick = new Brick6(); break;
                case 6:
                    brick = new Brick7(); break;
                //default:
                    //brick = new Brick1(); break;
            }
            return brick;
        }
    }
}
