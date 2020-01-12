using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyPen
{
    public partial class DlgDrawTools : Form
    {
        public FormMain _formMain;

        public DlgDrawTools()
        {
            InitializeComponent();
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemLine_Click(null, null);
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemRectangle_Click(null, null);
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
           _formMain.MenuItemCircle_Click(null, null);
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemTriangle_Click(null, null);
        }

        private void buttonSketch_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemSketch_Click(null, null);
        }

        private void buttonPenWidth_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemWidth_Click(null, null);
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemColor_Click(null, null);
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            _formMain.MenuItemUndo_Click(null, null);
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            _formMain.ExitScreenPen();
            this.Close();
        }

        private void DlgDrawTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formMain.ExitScreenPen();
        }
    }
}
