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
    public partial class DlgPenWidth : Form
    {
        public int _PenWidth
        {
            get 
            {
                return (int)numericUpDownWidth.Value;
            }
            set 
            {
                numericUpDownWidth.Value = value;
            }
        }
        public DlgPenWidth()
        {
            InitializeComponent();
        }
    }
}
