namespace MyTimer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPauseContinue = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxHour1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxHour2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDot1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMin1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMin2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDot2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSec1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSec2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHour1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHour2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSec1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSec2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.Location = new System.Drawing.Point(34, 116);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(79, 40);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPauseContinue
            // 
            this.buttonPauseContinue.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPauseContinue.Location = new System.Drawing.Point(141, 116);
            this.buttonPauseContinue.Name = "buttonPauseContinue";
            this.buttonPauseContinue.Size = new System.Drawing.Size(79, 40);
            this.buttonPauseContinue.TabIndex = 6;
            this.buttonPauseContinue.Text = "暂停";
            this.buttonPauseContinue.UseVisualStyleBackColor = true;
            this.buttonPauseContinue.Click += new System.EventHandler(this.buttonPauseContinue_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.Location = new System.Drawing.Point(248, 116);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(79, 40);
            this.buttonStop.TabIndex = 7;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 250;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBoxHour1
            // 
            this.pictureBoxHour1.Image = global::MyTimer.Properties.Resources._0;
            this.pictureBoxHour1.Location = new System.Drawing.Point(25, 27);
            this.pictureBoxHour1.Name = "pictureBoxHour1";
            this.pictureBoxHour1.Size = new System.Drawing.Size(40, 70);
            this.pictureBoxHour1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHour1.TabIndex = 10;
            this.pictureBoxHour1.TabStop = false;
            // 
            // pictureBoxHour2
            // 
            this.pictureBoxHour2.Image = global::MyTimer.Properties.Resources._0;
            this.pictureBoxHour2.Location = new System.Drawing.Point(65, 27);
            this.pictureBoxHour2.Name = "pictureBoxHour2";
            this.pictureBoxHour2.Size = new System.Drawing.Size(40, 70);
            this.pictureBoxHour2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHour2.TabIndex = 10;
            this.pictureBoxHour2.TabStop = false;
            // 
            // pictureBoxDot1
            // 
            this.pictureBoxDot1.Image = global::MyTimer.Properties.Resources.dot2;
            this.pictureBoxDot1.Location = new System.Drawing.Point(105, 27);
            this.pictureBoxDot1.Name = "pictureBoxDot1";
            this.pictureBoxDot1.Size = new System.Drawing.Size(40, 70);
            this.pictureBoxDot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDot1.TabIndex = 10;
            this.pictureBoxDot1.TabStop = false;
            // 
            // pictureBoxMin1
            // 
            this.pictureBoxMin1.Image = global::MyTimer.Properties.Resources._0;
            this.pictureBoxMin1.Location = new System.Drawing.Point(145, 27);
            this.pictureBoxMin1.Name = "pictureBoxMin1";
            this.pictureBoxMin1.Size = new System.Drawing.Size(40, 70);
            this.pictureBoxMin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMin1.TabIndex = 10;
            this.pictureBoxMin1.TabStop = false;
            // 
            // pictureBoxMin2
            // 
            this.pictureBoxMin2.Image = global::MyTimer.Properties.Resources._0;
            this.pictureBoxMin2.Location = new System.Drawing.Point(185, 27);
            this.pictureBoxMin2.Name = "pictureBoxMin2";
            this.pictureBoxMin2.Size = new System.Drawing.Size(40, 70);
            this.pictureBoxMin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMin2.TabIndex = 10;
            this.pictureBoxMin2.TabStop = false;
            // 
            // pictureBoxDot2
            // 
            this.pictureBoxDot2.Image = global::MyTimer.Properties.Resources.dot2;
            this.pictureBoxDot2.Location = new System.Drawing.Point(225, 27);
            this.pictureBoxDot2.Name = "pictureBoxDot2";
            this.pictureBoxDot2.Size = new System.Drawing.Size(40, 70);
            this.pictureBoxDot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDot2.TabIndex = 10;
            this.pictureBoxDot2.TabStop = false;
            // 
            // pictureBoxSec1
            // 
            this.pictureBoxSec1.Image = global::MyTimer.Properties.Resources._0;
            this.pictureBoxSec1.Location = new System.Drawing.Point(265, 27);
            this.pictureBoxSec1.Name = "pictureBoxSec1";
            this.pictureBoxSec1.Size = new System.Drawing.Size(40, 70);
            this.pictureBoxSec1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSec1.TabIndex = 10;
            this.pictureBoxSec1.TabStop = false;
            // 
            // pictureBoxSec2
            // 
            this.pictureBoxSec2.Image = global::MyTimer.Properties.Resources._0;
            this.pictureBoxSec2.Location = new System.Drawing.Point(305, 27);
            this.pictureBoxSec2.Name = "pictureBoxSec2";
            this.pictureBoxSec2.Size = new System.Drawing.Size(40, 70);
            this.pictureBoxSec2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSec2.TabIndex = 10;
            this.pictureBoxSec2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 176);
            this.Controls.Add(this.pictureBoxSec2);
            this.Controls.Add(this.pictureBoxSec1);
            this.Controls.Add(this.pictureBoxDot2);
            this.Controls.Add(this.pictureBoxMin2);
            this.Controls.Add(this.pictureBoxMin1);
            this.Controls.Add(this.pictureBoxDot1);
            this.Controls.Add(this.pictureBoxHour2);
            this.Controls.Add(this.pictureBoxHour1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPauseContinue);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计时器";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHour1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHour2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSec1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSec2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPauseContinue;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBoxHour1;
        private System.Windows.Forms.PictureBox pictureBoxHour2;
        private System.Windows.Forms.PictureBox pictureBoxDot1;
        private System.Windows.Forms.PictureBox pictureBoxMin1;
        private System.Windows.Forms.PictureBox pictureBoxMin2;
        private System.Windows.Forms.PictureBox pictureBoxDot2;
        private System.Windows.Forms.PictureBox pictureBoxSec1;
        private System.Windows.Forms.PictureBox pictureBoxSec2;
    }
}

