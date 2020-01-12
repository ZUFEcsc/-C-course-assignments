using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MyPen
{
    //绘图枚举类型
    public enum DrawType 
    {
        Stop,Line,Rectangle,Circle,Triangle,Sketch
    }

    public abstract class Shape
    {
        private int _penWidth = 5;
        private Color _penColor = Color.Black;
        private Pen _pen = new Pen(Color.Black, 5);

        public int _PenWidth
        {
            get { return _penWidth; }
            set { _penWidth = value; }
        }

        public Color _PenColor
        {
            get { return _penColor; }
            set { _penColor = value; }
        }

        public Pen _Pen
        {
            get 
            {
                _pen.Color = _PenColor;
                _pen.Width = _penWidth;
                return _pen; 
            }
            set 
            {
                _pen = value;
            }
        }

        //绘制图元方法（抽象方法）
        public abstract void Draw(Graphics g,DashStyle ds,double zoomRatio);

        public abstract void Write(BinaryWriter bw);
        public abstract void Read(BinaryReader br);

    }

    public class Line : Shape
    {
        //类字段
        private Point _p1;
        private Point _p2;

        //类属性
        public Point _P1
        {
            get { return _p1; }
            set { _p1 = value; }
        }
         public Point _P2
        {
            get { return _p2; }
            set { _p2 = value; }
        }

         public Line() 
         {
         }
         public Line(Point p1, Point p2) 
         {
             _p1 = p1;
             _p2 = p2;
         }
         public override void Draw(Graphics g, DashStyle ds, double zoomRatio) 
         {
             DrawLine(g, ds,zoomRatio);
         }

         private void DrawLine(Graphics g, DashStyle ds,double zoomRatio)
         {
             Pen pen = new Pen(_PenColor, (int)(_PenWidth * zoomRatio));
             pen.DashStyle = ds;

             Point p1 = new Point((int)(_p1.X * zoomRatio), (int)(_p1.Y * zoomRatio));
             Point p2 = new Point((int)(_p2.X * zoomRatio), (int)(_p2.Y * zoomRatio));

             g.DrawLine(pen, p1, p2);
         }

         public override void Write(BinaryWriter bw)
         {
             bw.Write(_PenWidth);
             bw.Write(_PenColor.ToArgb());
             bw.Write(_p1.X);
             bw.Write(_p1.Y);
             bw.Write(_p2.X);
             bw.Write(_p2.Y);
         }

         public override void Read(BinaryReader br)
         {
             _PenWidth = br.ReadInt32();
             _PenColor = Color.FromArgb(br.ReadInt32());
             _p1.X = br.ReadInt32();
             _p1.Y = br.ReadInt32();
             _p2.X = br.ReadInt32();
             _p2.Y = br.ReadInt32();
         }
    }

    public class Rectangle : Shape 
    {
        private Point _p1;

        public Point _P1
        {
            get { return _p1; }
            set { _p1 = value; }
        }
       
        private Point _p2;

        public Point _P2
        {
            get { return _p2; }
            set { _p2 = value; }
        }

        public Rectangle() 
        {
        }
        public Rectangle(Point p1, Point p2) 
        {
            _p1 = p1;
            _p2 = p2;
        }

        public override void Draw(Graphics g, DashStyle ds, double zoomRatio)
        {
            DrawRectangle(g, ds, zoomRatio);
        }

        private void DrawRectangle(Graphics g, DashStyle ds, double zoomRatio)
        {
            Pen pen = new Pen(_PenColor, (int)(_PenWidth * zoomRatio));
            pen.DashStyle = ds;

            Point leftTop = new Point();


            Point p1 = new Point((int)(_p1.X * zoomRatio), (int)(_p1.Y * zoomRatio));
            Point p2 = new Point((int)(_p2.X * zoomRatio), (int)(_p2.Y * zoomRatio));

            leftTop.X = (p1.X <= p2.X) ? p1.X : p2.X;
            leftTop.Y = (p1.Y <= p2.Y) ? p1.Y : p2.Y;
            g.DrawRectangle(pen, leftTop.X, leftTop.Y, Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y));
        }

        public override void Write(BinaryWriter bw)
        {
            bw.Write(_PenWidth);
            bw.Write(_PenColor.ToArgb());
            bw.Write(_p1.X);
            bw.Write(_p1.Y);
            bw.Write(_p2.X);
            bw.Write(_p2.Y);
        }

        public override void Read(BinaryReader br)
        {
            _PenWidth = br.ReadInt32();
            _PenColor = Color.FromArgb(br.ReadInt32());
            _p1.X = br.ReadInt32();
            _p1.Y = br.ReadInt32();
            _p2.X = br.ReadInt32();
            _p2.Y = br.ReadInt32();
        }
    }

    public class Circle : Shape 
    {
        private Point _pCenter;

        public Point _PCenter
        {
            get { return _pCenter; }
            set { _pCenter = value; }
        }

        private float _r;

        public float _R
        {
            get { return _r; }
            set { _r = value; }
        }

        public Circle() 
        {
        }
        public Circle(Point pCenter, float r) 
        {
            _pCenter = pCenter;
            _r = r;
        }

        public override void Draw(Graphics g, DashStyle ds, double zoomRatio)
        {
            DrawCircle(g, ds, zoomRatio);
        }

        private void DrawCircle(Graphics g, DashStyle ds, double zoomRatio)
        {
            Pen pen = new Pen(_PenColor, (int)(_PenWidth * zoomRatio));
            pen.DashStyle = ds;

            Point pCenter = new Point((int)(_pCenter.X * zoomRatio), (int)(_pCenter.Y * zoomRatio));
            float r = (float)(_r * zoomRatio);
            g.DrawEllipse(pen, pCenter.X - r, pCenter.Y - r, 2 * r, 2 * r);
        }

        public override void Write(BinaryWriter bw)
        {
            bw.Write(_PenWidth);
            bw.Write(_PenColor.ToArgb());
            bw.Write(_pCenter.X);
            bw.Write(_pCenter.Y);
            bw.Write(_r);
        }

        public override void Read(BinaryReader br)
        {
            _PenWidth = br.ReadInt32();
            _PenColor = Color.FromArgb(br.ReadInt32());
            _pCenter.X = br.ReadInt32();
            _pCenter.Y = br.ReadInt32();
            _r = br.ReadSingle();
        }
    }

    public class Triangle : Shape
    {
        private Point _p1;

        public Point _P1
        {
            get { return _p1; }
            set { _p1 = value; }
        }

        private Point _p2;

        public Point _P2
        {
            get { return _p2; }
            set { _p2 = value; }
        }

        public Triangle() 
        {
        }

        public Triangle(Point p1, Point p2)
        {
            p1 = _p1;
            p2 = _p2;
        }

        public override void Draw(Graphics g, DashStyle ds, double zoomRatio)
        {
            DrawTriangle(g, ds, zoomRatio);
        }

        private void DrawTriangle(Graphics g, DashStyle ds, double zoomRatio)
        {
            Pen pen = new Pen(_PenColor, (int)(_PenWidth * zoomRatio));
            pen.DashStyle = ds;

            Point p1 = new Point((int)(_p1.X * zoomRatio), (int)(_p1.Y * zoomRatio));
            Point p2 = new Point((int)(_p2.X * zoomRatio), (int)(_p2.Y * zoomRatio));

            Point[] pit = { new Point((p1.X + p2.X) / 2, p1.Y), new Point(p1.X, p2.Y), new Point(p2.X, p2.Y), new Point((p1.X + p2.X) / 2, p1.Y), new Point(p1.X, p2.Y), };
            g.DrawLines(pen, pit);
        }

        public override void Write(BinaryWriter bw)
        {
            bw.Write(_PenWidth);
            bw.Write(_PenColor.ToArgb());
            bw.Write(_p1.X);
            bw.Write(_p1.Y);
            bw.Write(_p2.X);
            bw.Write(_p2.Y);
        }

        public override void Read(BinaryReader br)
        {
            _PenWidth = br.ReadInt32();
            _PenColor = Color.FromArgb(br.ReadInt32());
            _p1.X = br.ReadInt32();
            _p1.Y = br.ReadInt32();
            _p2.X = br.ReadInt32();
            _p2.Y = br.ReadInt32();
        }
    }

    public class Sketch : Shape
    {
        private List<Point> _pointList = new List<Point>();

        public List<Point> _PointList
        {
            get { return _pointList; }
            set { _pointList = value; }
        }

        public Sketch()
        {
        }

        public override void Draw(Graphics g, DashStyle ds, double zoomRatio)
        {
            Pen pen = new Pen(_PenColor, (int)(_PenWidth * zoomRatio));
            pen.DashStyle = ds;
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            for (int i = 1; i <= _pointList.Count - 1; i++)
            {
                Point p1 = new Point((int)(_pointList[i - 1].X * zoomRatio), (int)(_pointList[i - 1].Y * zoomRatio));
                Point p2 = new Point((int)(_pointList[i].X * zoomRatio), (int)(_pointList[i].Y * zoomRatio));
                //g.DrawLines(pen, _pointList.ToArray());
                g.DrawLine(pen,p1,p2);
            }
                
        }

        public override void Write(BinaryWriter bw)
        {
            bw.Write(_PenWidth);
            bw.Write(_PenColor.ToArgb());
            bw.Write(_pointList.Count);
            foreach (Point tempPoint in _pointList)
            {
                bw.Write(tempPoint.X);
                bw.Write(tempPoint.Y);
            }
        }

        public override void Read(BinaryReader br)
        {
            _pointList.Clear();
            _PenWidth = br.ReadInt32();
            _PenColor = Color.FromArgb(br.ReadInt32());
            int pointCount = br.ReadInt32();

            for(int i=0; i<=pointCount-1;i++)
            {
                int x=br.ReadInt32();
                int y=br.ReadInt32();
                Point point = new Point(x,y);
                _pointList.Add(point);
            }
        }
    }
}
