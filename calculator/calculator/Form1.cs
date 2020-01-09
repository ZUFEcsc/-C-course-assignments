using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        //10->2
        public string DecToBin(int dec) 
        {
            string bin = "";
            while (dec > 1) 
            {
                bin = Convert.ToChar(dec % 2 + '0') + bin;
                dec = dec / 2;
            }
            bin = Convert.ToChar(dec + '0') + bin;
            return bin;
        }
        //2->10
        public static string BinToDec(string x)
         {
             string z = null;
             int X = Convert.ToInt32(x);
             int i = 0;
             long a, b = 0;
             while (X > 0)
             {
                 a = X%10;
                 X = X/10;
                 b = b + a * (int)Math.Pow(2, i);
                 i++;
             }
             z = Convert.ToString(b);
             return z;
         }
        
        //10->8
        public string DecToOct(int dec) 
        {
            string oct = "";
            while (dec > 1)
            {
                oct = Convert.ToChar(dec % 8 + '0') + oct;
                dec = dec / 8;
            }
            oct = Convert.ToChar(dec + '0') + oct;
            return oct;
        }
        //8->10
        public static string OctToDec(string x)
        {
            string z = null;
            int X = Convert.ToInt32(x);
            int i = 0;
            long a, b = 0;
            while (X > 0)
            {
                a = X % 10;
                X = X / 10;
                b = b + a * (int)Math.Pow(8, i);
                i++;
            }
            z = Convert.ToString(b);
            return z;
        }
        /*public int OctToDec(string oct) 
        {
            int dec = 0;
            for (int i = oct.Length; i >= 1; i--)
            {
                dec = dec + Convert.ToInt32(oct[i - 1] - '0' * (int)Math.Pow(8, oct.Length - i));
            }
            return dec;
        }*/
        private double _num1 = 0, _num2 = 0, _result = 0;
        //定义操作数1，操作数2，运算结果
        private string _operator = "";
        //定义运算符
        private int _operatorCount = 0;
        //定义操作符数目
        private bool _firstNumberFlag = false;
        //定义首位数字标志
        private bool _equalFlag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonNum1_Click(object sender, EventArgs e)
        {
            if (_equalFlag)
            { 
                textBoxResult.Text = "";
                _equalFlag = false;
            }
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = "1";
                _firstNumberFlag = false;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "1";
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonNum2_Click(object sender, EventArgs e)
        {
            if (_equalFlag)
            {
                textBoxResult.Text = "";
                _equalFlag = false;
            }
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = "2";
                _firstNumberFlag = false;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "2";
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonNum3_Click(object sender, EventArgs e)
        {
            if (_equalFlag)
            {
                textBoxResult.Text = "";
                _equalFlag = false;
            }
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = "3";
                _firstNumberFlag = false;

            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "3";
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonNum4_Click(object sender, EventArgs e)
        {
            if (_equalFlag)
            {
                textBoxResult.Text = "";
                _equalFlag = false;
            }
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = "4";
                _firstNumberFlag = false;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "4";
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonNum5_Click(object sender, EventArgs e)
        {
            if (_equalFlag)
            {
                textBoxResult.Text = "";
                _equalFlag = false;
            }
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = "5";
                _firstNumberFlag = false;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "5";
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonNum6_Click(object sender, EventArgs e)
        {
            if (_equalFlag)
            {
                textBoxResult.Text = "";
                _equalFlag = false;
            }
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = "6";
                _firstNumberFlag = false;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "6";
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonNum7_Click(object sender, EventArgs e)
        {
            if (_equalFlag)
            {
                textBoxResult.Text = "";
                _equalFlag = false;
            }
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = "7";
                _firstNumberFlag = false;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "7";
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonNum8_Click(object sender, EventArgs e)
        {
            if (_equalFlag)
            {
                textBoxResult.Text = "";
                _equalFlag = false;
            }
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = "8";
                _firstNumberFlag = false;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "8";
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonNum9_Click(object sender, EventArgs e)
        {
            if (_equalFlag)
            {
                textBoxResult.Text = "";
                _equalFlag = false;
            }
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = "9";
                _firstNumberFlag = false;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "9";
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonNum0_Click(object sender, EventArgs e)
        {
            if (_equalFlag)
            {
                textBoxResult.Text = "";
                _equalFlag = false;
            }
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = "0";
                _firstNumberFlag = false;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + "0";
            }
            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (_firstNumberFlag == true)
            {
                textBoxResult.Text = ".";
                _firstNumberFlag = false;
            }
            else
            {
                if (textBoxResult.Text.IndexOf('.') == -1)
                    textBoxResult.Text = textBoxResult.Text + '.';

            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _firstNumberFlag = true;
            _operatorCount = _operatorCount + 1;
            if (radioButtonTen.Checked == true)
            {
                    if (_operatorCount == 1)
                {
                    _num1 = Convert.ToDouble(textBoxResult.Text);
                    _operator = "+";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 = Convert.ToDouble(textBoxResult.Text);
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "+";
                    textBoxResult.Text =_num1.ToString();
                }

            }
            else if (radioButtonTwo.Checked == true)
            {
                if (_operatorCount == 1)
                {
                    _num1 =Convert.ToInt32( BinToDec(textBoxResult.Text)) ;
                    _operator = "+";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 =  Convert.ToInt32(BinToDec(textBoxResult.Text)); 
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "+";
                    textBoxResult.Text = DecToBin(Convert.ToInt32(_num1));
                }
 
            }
            else if (radioButtonEight.Checked == true) 
            {
                if (_operatorCount == 1)
                {
                    _num1 =Convert.ToInt32(OctToDec(textBoxResult.Text)) ;
                    _operator = "+";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 = Convert.ToInt32(OctToDec(textBoxResult.Text));
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "+";
                    textBoxResult.Text = DecToOct(Convert.ToInt32(_num1));
                }
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            _firstNumberFlag = true;
            _operatorCount = _operatorCount + 1;
            if(radioButtonTen.Checked==true)
            {
                if (_operatorCount == 1)
                {
                    _num1 = Convert.ToDouble(textBoxResult.Text);
                    _operator = "-";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 = Convert.ToDouble(textBoxResult.Text);
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "-";
                    textBoxResult.Text = _num1.ToString();
                }

            }
                
             else if (radioButtonTwo.Checked == true)
            {
                if (_operatorCount == 1)
                {
                    _num1 = Convert.ToInt32(BinToDec(textBoxResult.Text));
                    _operator = "-";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 = Convert.ToInt32(BinToDec(textBoxResult.Text));
                    
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "-";
                    textBoxResult.Text = DecToBin(Convert.ToInt32(_num1));
                }
 
            }
            else if (radioButtonEight.Checked == true) 
            {
                if (_operatorCount == 1)
                {
                    _num1 = Convert.ToInt32(OctToDec(textBoxResult.Text));
                    _operator = "-";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 = Convert.ToInt32(OctToDec(textBoxResult.Text));
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "-";
                    textBoxResult.Text = DecToOct(Convert.ToInt32(_num1));
                }
            }
            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonMultlply_Click(object sender, EventArgs e)
        {
            _firstNumberFlag = true;
            _operatorCount = _operatorCount + 1;

            if (radioButtonTen.Checked == true) 
            {
                if (_operatorCount == 1)
                {
                    _num1 = Convert.ToDouble(textBoxResult.Text);
                    _operator = "*";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 = Convert.ToDouble(textBoxResult.Text);
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "*";
                    textBoxResult.Text = "";
                }

            }

            else if (radioButtonTwo.Checked == true)
            {
                if (_operatorCount == 1)
                {
                    _num1 = Convert.ToInt32(BinToDec(textBoxResult.Text));
                    _operator = "*";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 = Convert.ToInt32(BinToDec(textBoxResult.Text));
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "*";
                    textBoxResult.Text = DecToBin(Convert.ToInt32(_num1));
                }

            }
            else if (radioButtonEight.Checked == true)
            {
                if (_operatorCount == 1)
                {
                    _num1 = Convert.ToInt32(OctToDec(textBoxResult.Text));
                    _operator = "*";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 = Convert.ToInt32(OctToDec(textBoxResult.Text));
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "*";
                    textBoxResult.Text = DecToOct(Convert.ToInt32(_num1));
                }
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            _firstNumberFlag = true;
            _operatorCount = _operatorCount + 1;

            if (radioButtonTen.Checked == true) 
            {
                if (_operatorCount == 1)
                {
                    _num1 = Convert.ToDouble(textBoxResult.Text);
                    _operator = "/";
                    textBoxResult.Text = _num1.ToString();
                }
                else
                {
                    _num2 = Convert.ToDouble(textBoxResult.Text);
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "/";
                    textBoxResult.Text = _num1.ToString();
                }

            }

            else if (radioButtonTwo.Checked == true)
            {
                if (_operatorCount == 1)
                {
                    _num1 = Convert.ToInt32(BinToDec(textBoxResult.Text));
                    _operator = "/";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 = Convert.ToInt32(BinToDec(textBoxResult.Text));
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "/";
                    textBoxResult.Text = DecToBin(Convert.ToInt32(_num1));
                }

            }
            else if (radioButtonEight.Checked == true)
            {
                if (_operatorCount == 1)
                {
                    _num1 = Convert.ToInt32(OctToDec(textBoxResult.Text));
                    _operator = "/";
                    textBoxResult.Text = "";
                }
                else
                {
                    _num2 = Convert.ToInt32(OctToDec(textBoxResult.Text));
                    if (_operator == "+")
                        _num1 = _num1 + _num2;
                    else if (_operator == "-")
                        _num1 = _num1 - _num2;
                    else if (_operator == "*")
                        _num1 = _num1 * _num2;
                    else if (_operator == "/")
                        _num1 = _num1 / _num2;
                    _operator = "/";
                    textBoxResult.Text = DecToOct(Convert.ToInt32(_num1));
                }
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            _equalFlag = true;

            if (radioButtonTen.Checked == true) 
            {
                if (_operatorCount != 0)
                {
                    _num2 = Convert.ToDouble(textBoxResult.Text);

                    if (_operator == "+")
                        _result = _num1 + _num2;
                    else if (_operator == "-")
                        _result = _num1 - _num2;
                    else if (_operator == "*")
                        _result = _num1 * _num2;
                    else if (_operator == "/")
                        _result = _num1 / _num2;
                    _operatorCount = 0;
                }
                else 
                {
                    _result = Convert.ToDouble(textBoxResult.Text);
                }
                textBoxResult.Text = _result.ToString();

            }

            else if (radioButtonTwo.Checked == true) 
            {
                if (_operatorCount != 0)
                {
                    _num2 = Convert.ToInt32(BinToDec(textBoxResult.Text));
                    
                    if (_operator == "+")
                        _result = _num1 + _num2;
                    else if (_operator == "-")
                        _result = _num1 - _num2;
                    else if (_operator == "*")
                        _result = _num1 * _num2;
                    else if (_operator == "/")
                        _result = _num1 / _num2;

                    textBoxResult.Text = DecToBin(Convert.ToInt32(_result));
                    _operatorCount = 0;
                }
                else
                {
                    _result = Convert.ToDouble(textBoxResult.Text);
                }
            }

            else if (radioButtonEight.Checked == true) 
            {
                if (_operatorCount != 0)
                {
                    _num2 = Convert.ToInt32(OctToDec(textBoxResult.Text));

                    if (_operator == "+")
                        _result = _num1 + _num2;
                    else if (_operator == "-")
                        _result = _num1 - _num2;
                    else if (_operator == "*")
                        _result = _num1 * _num2;
                    else if (_operator == "/")
                        _result = _num1 / _num2;

                    textBoxResult.Text = DecToOct(Convert.ToInt32(_result));
                    _operatorCount = 0;
                }
                else
                {
                    _result = Convert.ToDouble(textBoxResult.Text);
                }
            }

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            if(textBoxResult.Text.Length>0)
            //substring(startindex,length)函数从startindex开始截取长度为length的字符串
                textBoxResult.Text=textBoxResult.Text.Substring(0,textBoxResult.Text.Length-1);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Text="";
            _num1=0;
            _num2=0;
            _result = 0;
            _firstNumberFlag=false;
            _operator="";
            _operatorCount=0;

            textBoxResult.Focus();
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text.Length >= 1)
            {
                string firstChar = textBoxResult.Text.Substring(0, 1);

                if (firstChar == "-")
                    textBoxResult.Text = "+" + textBoxResult.Text.Substring(1, textBoxResult.Text.Length - 1);
                else if (firstChar == "+")
                    textBoxResult.Text = "-" + textBoxResult.Text.Substring(1, textBoxResult.Text.Length - 1);
                else
                    textBoxResult.Text = "-" + textBoxResult.Text;
            }
        }


        private void textBoxResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '0')
                buttonNum0_Click(sender, e);
            else if (e.KeyChar == '1')
                buttonNum1_Click(sender, e);
            else if (e.KeyChar == '2')
                buttonNum2_Click(sender, e);
            else if (e.KeyChar == '3')
                buttonNum3_Click(sender, e);
            else if (e.KeyChar == '4')
                buttonNum4_Click(sender, e);
            else if (e.KeyChar == '5')
                buttonNum5_Click(sender, e);
            else if (e.KeyChar == '6')
                buttonNum6_Click(sender, e);
            else if (e.KeyChar == '7')
                buttonNum7_Click(sender, e);
            else if (e.KeyChar == '8')
                buttonNum8_Click(sender, e);
            else if (e.KeyChar == '9')
                buttonNum9_Click(sender, e);
            else if (e.KeyChar == '+')
                buttonAdd_Click(sender, e);
            else if (e.KeyChar == '-')
                buttonSubtract_Click(sender, e);
            else if (e.KeyChar == '*')
                buttonMultlply_Click(sender,e);
            else if (e.KeyChar == '/')
                buttonDivide_Click(sender, e);
            else if (e.KeyChar == '=')
                buttonEqual_Click(sender, e);
            else if (e.KeyChar == 'c')
                buttonClear_Click(sender,e);
            else if (e.KeyChar == '.')
                buttonDot_Click(sender,e);
            else if (e.KeyChar == 8)
                buttonBackSpace_Click(sender, e);
            textBoxResult.Select(textBoxResult.Text.Length, 0);
        }

        private void radioButtonTen_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxResult.Text != "" && buttonNum9.Enabled == false && buttonNum2.Enabled == false)
                textBoxResult.Text = BinToDec(textBoxResult.Text);
            else if (textBoxResult.Text != "" && buttonNum9.Enabled == false && buttonNum2.Enabled == true)
                textBoxResult.Text = OctToDec(textBoxResult.Text);
            buttonNum0.Enabled = true;
            buttonNum1.Enabled = true;
            buttonNum2.Enabled = true;
            buttonNum3.Enabled = true;
            buttonNum4.Enabled = true;
            buttonNum5.Enabled = true;
            buttonNum6.Enabled = true;
            buttonNum7.Enabled = true;
            buttonNum8.Enabled = true;
            buttonNum9.Enabled = true;


        }


        private void radioButtonEight_CheckedChanged(object sender, EventArgs e)
        {
            
            if (textBoxResult.Text != "" && buttonNum9.Enabled == false && buttonNum2.Enabled == false)
                textBoxResult.Text = BinToDec(textBoxResult.Text);

            textBoxResult.Text = DecToOct(Convert.ToInt32(textBoxResult.Text) );

            buttonNum0.Enabled = true;
            buttonNum1.Enabled = true;
            buttonNum2.Enabled = true;
            buttonNum3.Enabled = true;
            buttonNum4.Enabled = true;
            buttonNum5.Enabled = true;
            buttonNum6.Enabled = true;
            buttonNum7.Enabled = true;
            buttonNum8.Enabled = false;
            buttonNum9.Enabled = false;

            
        }


        private void radioButtonTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxResult.Text != "" && buttonNum9.Enabled == false && buttonNum2.Enabled == true)
                textBoxResult.Text = OctToDec(textBoxResult.Text);

            textBoxResult.Text= DecToBin(Convert.ToInt32( textBoxResult.Text));
            
            buttonNum0.Enabled = true;
            buttonNum1.Enabled = true;
            buttonNum2.Enabled = false;
            buttonNum3.Enabled = false;
            buttonNum4.Enabled = false;
            buttonNum5.Enabled = false;
            buttonNum6.Enabled = false;
            buttonNum7.Enabled = false;
            buttonNum8.Enabled = false;
            buttonNum9.Enabled = false;
            
        }
    }
}
