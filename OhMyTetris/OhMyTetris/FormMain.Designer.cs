namespace OhMyTetris
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelIntroduction = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.buttonBegin = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxHole = new System.Windows.Forms.PictureBox();
            this.buttonPlayMusic = new System.Windows.Forms.Button();
            this.labelGameover = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHole)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(6, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 361);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelIntroduction
            // 
            this.labelIntroduction.BackColor = System.Drawing.Color.Transparent;
            this.labelIntroduction.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelIntroduction.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelIntroduction.Location = new System.Drawing.Point(328, 126);
            this.labelIntroduction.Name = "labelIntroduction";
            this.labelIntroduction.Size = new System.Drawing.Size(139, 104);
            this.labelIntroduction.TabIndex = 1;
            this.labelIntroduction.Text = "游戏说明：\r\n\r\n通过方向键控制砖块。\r\n\r\n向上键：变形\r\n向左键：左移\r\n向下键：下移\r\n向右键：右移";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(352, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 85);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScore.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelScore.Location = new System.Drawing.Point(328, 241);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(51, 12);
            this.labelScore.TabIndex = 3;
            this.labelScore.Text = "得分 ：";
            // 
            // buttonBegin
            // 
            this.buttonBegin.BackColor = System.Drawing.Color.Transparent;
            this.buttonBegin.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBegin.FlatAppearance.BorderSize = 0;
            this.buttonBegin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Linen;
            this.buttonBegin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Linen;
            this.buttonBegin.Font = new System.Drawing.Font("幼圆", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonBegin.Location = new System.Drawing.Point(358, 263);
            this.buttonBegin.Name = "buttonBegin";
            this.buttonBegin.Size = new System.Drawing.Size(75, 23);
            this.buttonBegin.TabIndex = 4;
            this.buttonBegin.Text = "开   始";
            this.buttonBegin.UseVisualStyleBackColor = false;
            this.buttonBegin.Click += new System.EventHandler(this.buttonBegin_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.Transparent;
            this.buttonStop.Font = new System.Drawing.Font("幼圆", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.Location = new System.Drawing.Point(358, 299);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "暂   停";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.Font = new System.Drawing.Font("幼圆", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.Location = new System.Drawing.Point(358, 335);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "退出游戏";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBoxHole
            // 
            this.pictureBoxHole.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxHole.BackgroundImage")));
            this.pictureBoxHole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxHole.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxHole.Name = "pictureBoxHole";
            this.pictureBoxHole.Size = new System.Drawing.Size(476, 373);
            this.pictureBoxHole.TabIndex = 5;
            this.pictureBoxHole.TabStop = false;
            // 
            // buttonPlayMusic
            // 
            this.buttonPlayMusic.BackColor = System.Drawing.Color.Transparent;
            this.buttonPlayMusic.FlatAppearance.BorderSize = 0;
            this.buttonPlayMusic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonPlayMusic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPlayMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayMusic.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPlayMusic.ForeColor = System.Drawing.Color.White;
            this.buttonPlayMusic.Location = new System.Drawing.Point(437, 4);
            this.buttonPlayMusic.Name = "buttonPlayMusic";
            this.buttonPlayMusic.Size = new System.Drawing.Size(30, 31);
            this.buttonPlayMusic.TabIndex = 6;
            this.buttonPlayMusic.Text = "🈲";
            this.buttonPlayMusic.UseVisualStyleBackColor = false;
            this.buttonPlayMusic.Click += new System.EventHandler(this.buttonPlayMusic_Click);
            // 
            // labelGameover
            // 
            this.labelGameover.AutoSize = true;
            this.labelGameover.BackColor = System.Drawing.Color.Transparent;
            this.labelGameover.Font = new System.Drawing.Font("黑体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelGameover.ForeColor = System.Drawing.Color.Red;
            this.labelGameover.Location = new System.Drawing.Point(26, 95);
            this.labelGameover.Name = "labelGameover";
            this.labelGameover.Size = new System.Drawing.Size(270, 48);
            this.labelGameover.TabIndex = 7;
            this.labelGameover.Text = "GAME OVER!";
            this.labelGameover.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 373);
            this.Controls.Add(this.labelGameover);
            this.Controls.Add(this.buttonPlayMusic);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonBegin);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelIntroduction);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxHole);
            this.Font = new System.Drawing.Font("宋体", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "俄罗斯方块";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelIntroduction;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Button buttonBegin;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBoxHole;
        private System.Windows.Forms.Button buttonPlayMusic;
        private System.Windows.Forms.Label labelGameover;
    }
}

