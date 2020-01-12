using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
//using System.Random;

namespace MyPen
{
   
    public partial class FormMain : Form
    {
        private List<Shape> _listShape = new List<Shape>();

        private List<Shape> _listTempShape = new List<Shape>();

        private Shape _tempShape = null;

        //保存当前的绘图类型（默认为直线）
        private DrawType _drawType = DrawType.Line;

        private Color _drawColor = Color.Black;

        private int _drawWidth = 5;

        BufferedGraphicsContext _bufGraphCont = null;
        BufferedGraphics _bufGraph = null;

        private string _fileName = "";
        private Boolean _needSave = false;

        //保存图形缩放比例
        private double _zoomRatio = 1;
        //保存panelDraw窗口的初始窗口
        private Size _panelDrawnInitSize = new Size(0, 0);

        private Bitmap _screenBmp = null;
        private Graphics _screenBmpGraohics = null;
        
        //========================================
        public struct KeyMSG
        {
            public int vkCode;          //键值虚拟码
            public int scanCode;        //硬件扫描码
            public int flags;           //键盘按下时=128，键盘抬起时=0
            public int time;            //windows运行时间
            public int dwExtraInfo;
        }
        //定义变量
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        static int hKeyboardHook = 0;
        HookProc KeyboardHookProcedure;
        
        //安装钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadld);
        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        //继续下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);
        
        //钩子处理
        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KeyMSG m = (KeyMSG)Marshal.PtrToStructure(lParam, typeof(KeyMSG));
                if (m.flags == 0 && m.vkCode == (int)(Keys.F3))
                {
                    MenuItemScreenPen_Click(this, null);
                    return 1;
                }
                else if (m.flags == 0 && m.vkCode == (int)(Keys.F4))
                {
                    ExitScreenPen();
                    return 1;
                }
                return 0;
            }
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }

        //安装钩子
        public void HookStart()
        {
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                hKeyboardHook = SetWindowsHookEx(13, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                if (hKeyboardHook == 0)
                {
                    HookStop();
                    throw new Exception("SetWindowsHookEx failed.");
                }

            }
        }

        //卸载钩子
        public void HookStop()
        {
            bool retKeyboard = true;
            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }
            if (!(retKeyboard))
                throw new Exception("UnhookWindowsHookEx failed.");

        }
        //=====================================
        public FormMain()
        {
            InitializeComponent();
            //安装钩子
            try
            {
                HookStart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("钩子安装失败！提示信息：" + ex.Message);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _bufGraphCont = BufferedGraphicsManager.Current;

            _bufGraph = _bufGraphCont.Allocate(this.CreateGraphics(), this.ClientRectangle);
            
            _bufGraph.Graphics.Clear(Color.White);

            _bufGraph.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            _screenBmp = new Bitmap(screenWidth, screenHeight);
            _screenBmpGraohics = Graphics.FromImage(_screenBmp);
            _screenBmpGraohics.Clear(Color.White);

            _panelDrawnInitSize.Width = panelDraw.Width;
            _panelDrawnInitSize.Height = panelDraw.Height;

            MenuItemUndo.Enabled = false;
            toolStripButtonUndo.Enabled = false;

            MenuItemRedo.Enabled = false;
            toolStripButtonRedo.Enabled = false;

            Cursor penCur = new Cursor("pencil.cur");
            this.Cursor = penCur;
            this.toolStrip1.Cursor = Cursors.Arrow;
            this.menuStrip1.Cursor = Cursors.Arrow;
            this.statusStrip1.Cursor = Cursors.Arrow;
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void MenuItemLine_Click(object sender, EventArgs e)
        {
            _drawType = DrawType.Line;
        }

        public void MenuItemRectangle_Click(object sender, EventArgs e)
        {
            _drawType = DrawType.Rectangle;
        }

        public void MenuItemCircle_Click(object sender, EventArgs e)
        {
            _drawType = DrawType.Circle;
        }

        public void MenuItemTriangle_Click(object sender, EventArgs e)
        {
            _drawType = DrawType.Triangle;
        }

        public void MenuItemSketch_Click(object sender, EventArgs e)
        {
            _drawType = DrawType.Sketch;
        }

        private void MenuItemStop_Click(object sender, EventArgs e)
        {
            _drawType = DrawType.Stop;
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void MenuItemUndo_Click(object sender, EventArgs e)
        {
            if (_listShape.Count != 0)
            {
                _listTempShape.Add(_listShape[_listShape.Count - 1]);
                _listShape.RemoveAt(_listShape.Count - 1);

                _bufGraph.Graphics.Clear(Color.White);
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics,DashStyle.Solid,_zoomRatio);
                _bufGraph.Render(panelDraw.CreateGraphics());

                if (_listShape.Count == 0) 
                {
                    MenuItemUndo.Enabled = false;
                    toolStripButtonUndo.Enabled = false;
                }
                MenuItemRedo.Enabled = true;
                toolStripButtonRedo.Enabled = true;

                _needSave = true;
            }
        }

        private void MenuItemRedo_Click(object sender, EventArgs e)
        {
            if (_listTempShape.Count != 0)
            {
                //把_listTemoShape中的最后一个图元保存到_listShape
                _listShape.Add(_listTempShape[_listTempShape.Count - 1]);

                //删除_listTempShape中的最后一个图元
                _listTempShape.RemoveAt(_listTempShape.Count - 1);

                //清空图形缓存区，逐一绘制所有的图元到图形缓冲区，将图形缓冲区的图元绘制到当前窗口
                _bufGraph.Graphics.Clear(Color.White);
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                _bufGraph.Render(panelDraw.CreateGraphics());

                //判断是否需要禁用MenultemRedo菜单
                if (_listTempShape.Count == 0)
                {
                    MenuItemRedo.Enabled = false;
                    toolStripButtonRedo.Enabled = false;
                }
                MenuItemUndo.Enabled = true;
                toolStripButtonUndo.Enabled = true;

                _needSave = true;
            }

        }

        public void MenuItemColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _drawColor;

            if(colorDialog1.ShowDialog(this) == DialogResult.OK)
                _drawColor = colorDialog1.Color;
            
        }

        private void MenuItemColorRed_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.Red;
            _drawColor = Color.Red;
        }

        private void MenuItemColorYellow_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.Yellow;
            _drawColor = Color.Yellow;
        }

        private void MenuItemColorBlue_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.Blue;
            _drawColor = Color.Blue;
        }

        private void MenuItemColorGreen_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.Green;
            _drawColor = Color.Green;
        }

        private void MenuItemColorBlack_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.Black;
            _drawColor = Color.Black;
        }

        public Color randomColor(Color col)
        {
            Random random = new Random();
            col = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            return col;
        }

        private void MenuItemColorRandom_Click(object sender, EventArgs e)
        {
            Color _col = new Color();
            colorDialog1.Color = randomColor(_col);
            _drawColor = colorDialog1.Color;
        }

        public void MenuItemWidth_Click(object sender, EventArgs e)
        {
            DlgPenWidth dlgPenWidth = new DlgPenWidth();
            dlgPenWidth._PenWidth = _drawWidth;
            if (dlgPenWidth.ShowDialog(this) == DialogResult.OK)
            {
                _drawWidth = dlgPenWidth._PenWidth;
            }
        }

        private void MenuItemWidth5px_Click(object sender, EventArgs e)
        {
            _drawWidth = 5;
        }

        private void MenuItemWidth10px_Click(object sender, EventArgs e)
        {
            _drawWidth = 10;
        }

        private void MenuItemWidth20px_Click(object sender, EventArgs e)
        {
            _drawWidth = 20;
        }

        private void MenuItemWidth40px_Click(object sender, EventArgs e)
        {
            _drawWidth = 40;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            Cursor deleteCur = new Cursor("delete.cur");
            this.Cursor = deleteCur;

        }

        private void MenuItemNew_Click(object sender, EventArgs e)
        {
            if (_needSave == true)
            {
                if (MessageBox.Show("你是否需要保存当前图元", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    MenuItemSave_Click(null, null);
            }

            _listShape.Clear();
            _listTempShape.Clear();
            
            _bufGraph.Graphics.Clear(Color.White);
            _bufGraph.Render(panelDraw.CreateGraphics());
            
            _fileName = "";
            this.Text = "画笔-无标题";

            _needSave = false;

            MenuItemUndo.Enabled = false;
            MenuItemRedo.Enabled = false;

            toolStripButtonUndo.Enabled = false;
            toolStripButtonRedo.Enabled = false;
        }

        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            if (_fileName == "")
            {
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    _fileName = saveFileDialog1.FileName;
                    this.Text = "画图-" + _fileName;
                }
                else 
                    return; 
            }
            
            FileStream fs = new FileStream(_fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            //保存图元的数量和链表中每一个图元的信息
            bw.Write(_listShape.Count);
            foreach (Shape temp in _listShape)
            {
                bw.Write(temp.GetType().ToString());
                temp.Write(bw);
            }
            bw.Close();
            fs.Close();

            _needSave = false;
        }

        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            //弹出一个对话框，并点击了确定按钮
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MenuItemNew_Click(null, null);
                _fileName = openFileDialog1.FileName;
                this.Text = "画图-" + _fileName;

                FileStream fs = new FileStream(_fileName, FileMode.Open,FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                //保存图元的数量和链表中每一个图元的信息
                int count = br.ReadInt32();

                for (int i = 1; i <= count; i++)
                {
                    //读取 + 判断 图元类型
                    string shapeType = br.ReadString();
                    if (shapeType == "MyPen.Line")
                    {
                        Line temp = new Line();
                        temp.Read(br);
                        _listShape.Add(temp);
                    }
                    else if (shapeType == "MyPen.Rectangle")
                    {
                        Rectangle temp = new Rectangle();
                        temp.Read(br);
                        _listShape.Add(temp);
                    }
                    else if (shapeType == "MyPen.Circle")
                    {
                        Circle temp = new Circle();
                        temp.Read(br);
                        _listShape.Add(temp);
                    }
                    else if (shapeType == "MyPen.Triangle")
                    {
                        Triangle temp = new Triangle();
                        temp.Read(br);
                        _listShape.Add(temp);
                    }
                    else if (shapeType == "MyPen.Sketch")
                    {
                        Sketch shape = new Sketch();
                        shape.Read(br);
                        _listShape.Add(shape);
                    }
                    else
                        MessageBox.Show("图元类型错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                br.Close();
                fs.Close();

                _needSave = false;

                _bufGraph.Graphics.Clear(Color.White);
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                _bufGraph.Render(panelDraw.CreateGraphics());
            }
        }

        private void MenuItemSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                _fileName = saveFileDialog1.FileName;
                this.Text = "画笔-" + _fileName;

                FileStream fs = new FileStream(_fileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);

                bw.Write(_listShape.Count);
                foreach (Shape tempShape in _listShape)
                {
                    bw.Write(_listShape.GetType().ToString());
                    tempShape.Write(bw);
                }
                bw.Close();
                fs.Close();

                _needSave = false;
            }
            
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_needSave == true)
            {
                if(MessageBox.Show("你是否需要保存当前图元", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    MenuItemSave_Click(null,null);
            }
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItemSaveAsPic_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog(this) == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
                Graphics gBitmap = Graphics.FromImage(bitmap);
                _bufGraph.Render(gBitmap);
                string extension = System.IO.Path.GetExtension(saveFileDialog2.FileName);
                if (extension == ".jpg")
                    bitmap.Save(saveFileDialog2.FileName, ImageFormat.Jpeg);
                else if (extension == ".gif")
                    bitmap.Save(saveFileDialog2.FileName, ImageFormat.Gif);
                else if (extension == ".bmp")
                    bitmap.Save(saveFileDialog2.FileName, ImageFormat.Bmp);
                else MessageBox.Show("对不起，暂不支持该图片格式", extension, MessageBoxButtons.OK, MessageBoxIcon.Error);

                _needSave = false;
            }
        }


        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (_drawType != DrawType.Stop)
            {
                if (_drawType == DrawType.Line)
                {
                    _tempShape = new Line();
                    ((Line)_tempShape)._P1 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                }
                else if (_drawType == DrawType.Rectangle)
                {
                    _tempShape = new Rectangle();
                    ((Rectangle)_tempShape)._P1 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                }
                else if (_drawType == DrawType.Circle)
                {
                    _tempShape = new Circle();
                    ((Circle)_tempShape)._PCenter = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                }
                else if (_drawType == DrawType.Triangle)
                {
                    _tempShape = new Triangle();
                    ((Triangle)_tempShape)._P1 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                }
                else if (_drawType == DrawType.Sketch)
                {
                    _tempShape = new Sketch();
                    ((Sketch)_tempShape)._PointList.Add(new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio)));
                }
                _tempShape._PenColor = _drawColor;
                _tempShape._PenWidth = _drawWidth;
            }
        }

        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_drawType != DrawType.Stop)
                {
                    //清空缓存区
                    _bufGraph.Graphics.Clear(Color.White);

                    _bufGraph.Graphics.DrawImage(_screenBmp, new Point(0, 0));

                    //逐一绘制所有图元到缓存区
                    foreach (Shape shape in _listShape)
                        shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                    //保存相应信息
                    if (_drawType == DrawType.Line)
                    {
                        ((Line)_tempShape)._P2 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                    }
                    else if (_drawType == DrawType.Rectangle)
                    {
                        ((Rectangle)_tempShape)._P2 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                    }
                    else if (_drawType == DrawType.Circle)
                    {
                        ((Circle)_tempShape)._R = (float)Math.Sqrt(Math.Pow(((int)(e.X / _zoomRatio) - ((Circle)_tempShape)._PCenter.X), 2) +
                                                                   Math.Pow(((int)(e.Y / _zoomRatio) - ((Circle)_tempShape)._PCenter.Y), 2));
                    }
                    else if (_drawType == DrawType.Triangle)
                    {
                        ((Triangle)_tempShape)._P2 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                    }
                    else if (_drawType == DrawType.Sketch)
                    {
                        ((Sketch)_tempShape)._PointList.Add(new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio)));
                    }

                    //绘制当前临时图元到缓存区
                    if (_drawType == DrawType.Sketch)
                        _tempShape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                    else
                        _tempShape.Draw(_bufGraph.Graphics, DashStyle.Dot, _zoomRatio);
                    //绘制缓存区的图元到当前窗口
                    _bufGraph.Render(panelDraw.CreateGraphics());
                }
            }

            StatusLabelMousePosition.Text = "鼠标：x=" + e.X + ",y=" + e.Y;
        }

        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if (_drawType != DrawType.Stop)
            {
                if (_drawType == DrawType.Line)
                {
                    ((Line)_tempShape)._P2 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                }
                else if (_drawType == DrawType.Rectangle)
                {
                    ((Rectangle)_tempShape)._P2 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                }
                else if (_drawType == DrawType.Circle)
                {
                    ((Circle)_tempShape)._R = (float)Math.Sqrt(Math.Pow((e.X / _zoomRatio - ((Circle)_tempShape)._PCenter.X), 2) + Math.Pow((e.Y / _zoomRatio - ((Circle)_tempShape)._PCenter.Y), 2));
                }
                else if (_drawType == DrawType.Triangle)
                {
                    ((Triangle)_tempShape)._P2 = new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio));
                }
                else if (_drawType == DrawType.Sketch)
                {
                    ((Sketch)_tempShape)._PointList.Add(new Point((int)(e.X / _zoomRatio), (int)(e.Y / _zoomRatio)));
                }

                _listShape.Add(_tempShape);

                _needSave = true;

                MenuItemUndo.Enabled = true;
                toolStripButtonUndo.Enabled = true;

                //清空_listTempShape,以禁止Redo操作
                _listTempShape.Clear();
                MenuItemRedo.Enabled = false;
                toolStripButtonRedo.Enabled = false;

                //_tempShape.Draw(this.CreateGraphics());
                //将绘制图元更改为：
                //（1）清空缓冲区 （2）绘制图元到缓存区 （3）将缓存区绘制到窗口
                _bufGraph.Graphics.Clear(Color.White);

                _bufGraph.Graphics.DrawImage(_screenBmp, new Point(0, 0));

                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                _bufGraph.Render(panelDraw.CreateGraphics());
            }
        }

        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            //foreach (Shape tempShape in _listShape)
            //    tempShape.Draw(e.Graphics);
            //将 绘制所有图元 更改为：与绘图相同步骤
            _bufGraph.Graphics.Clear(Color.White);
            _bufGraph.Graphics.DrawImage(_screenBmp, new Point(0, 0));
            foreach (Shape shape in _listShape)
                shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
            _bufGraph.Render(panelDraw.CreateGraphics());
        }

        private void MenuItemZoomIn_Click(object sender, EventArgs e)
        {
            if (_zoomRatio <= 3)
            {
                _zoomRatio = _zoomRatio * 1.1;
                panelDraw.Width = (int)(_panelDrawnInitSize.Width * _zoomRatio);
                panelDraw.Height = (int)(_panelDrawnInitSize.Height * _zoomRatio);

                //构造新的缓存区，与panleDraw一样大
                _bufGraph = _bufGraphCont.Allocate(panelDraw.CreateGraphics(), panelDraw.ClientRectangle);
                _bufGraph.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                _bufGraph.Graphics.Clear(Color.White);
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                _bufGraph.Render(panelDraw.CreateGraphics());
            }
            else
            {
                MessageBox.Show("已经够大了，再大会爆炸！");
            }
        }

        private void MenuItemZoomOut_Click(object sender, EventArgs e)
        {
            if (_zoomRatio >= 0.3)
            {
                _zoomRatio = _zoomRatio * 0.9;
                panelDraw.Width = (int)(_panelDrawnInitSize.Width * _zoomRatio);
                panelDraw.Height = (int)(_panelDrawnInitSize.Height * _zoomRatio);

                _bufGraph = _bufGraphCont.Allocate(panelDraw.CreateGraphics(), panelDraw.ClientRectangle);
                _bufGraph.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                _bufGraph.Graphics.Clear(Color.White);
                foreach (Shape shape in _listShape)
                    shape.Draw(_bufGraph.Graphics, DashStyle.Solid, _zoomRatio);
                _bufGraph.Render(panelDraw.CreateGraphics());
            }
            else
            {
                MessageBox.Show("不能再小了，再小就没啦！");
            }
        }

        private void MenuItemScreenPen_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                this.WindowState = FormWindowState.Minimized;

                menuStrip1.Visible = false;
                toolStrip1.Visible = false;
                statusStrip1.Visible = false;
                this.FormBorderStyle = FormBorderStyle.None;

                Thread.Sleep(300);
                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;
                _screenBmpGraohics.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));
                panelDraw.Width = screenWidth;
                panelDraw.Height = screenHeight;
                _zoomRatio = 1;
                _panelDrawnInitSize = new Size(panelDraw.Width, panelDraw.Height);
                _bufGraph = _bufGraphCont.Allocate(panelDraw.CreateGraphics(), panelDraw.ClientRectangle);
                _bufGraph.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                _bufGraph.Graphics.Clear(Color.White);
                _bufGraph.Graphics.DrawImage(_screenBmp, new Point(0, 0));
                _bufGraph.Render(panelDraw.CreateGraphics());
                this.WindowState = FormWindowState.Maximized;

                DlgDrawTools myDlgDrawTools = new DlgDrawTools();
                myDlgDrawTools._formMain = this;
                myDlgDrawTools.Show();
            }
        }

        public void ExitScreenPen()
        {
            menuStrip1.Visible = true;
            toolStrip1.Visible = true;
            statusStrip1.Visible = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}
