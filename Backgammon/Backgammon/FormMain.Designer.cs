namespace Backgammon
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemGame = new System.Windows.Forms.ToolStripMenuItem();
            this.经典ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemIntroduction = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonHardGame = new System.Windows.Forms.Button();
            this.buttonCommonGame = new System.Windows.Forms.Button();
            this.buttonEasyGame = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemGame,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(287, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemGame
            // 
            this.ToolStripMenuItemGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.经典ToolStripMenuItem,
            this.ToolStripMenuItemRestart,
            this.ToolStripMenuItemQuit});
            this.ToolStripMenuItemGame.Name = "ToolStripMenuItemGame";
            this.ToolStripMenuItemGame.Size = new System.Drawing.Size(77, 21);
            this.ToolStripMenuItemGame.Text = "游戏（G）";
            // 
            // 经典ToolStripMenuItem
            // 
            this.经典ToolStripMenuItem.Name = "经典ToolStripMenuItem";
            this.经典ToolStripMenuItem.Size = new System.Drawing.Size(149, 6);
            // 
            // ToolStripMenuItemRestart
            // 
            this.ToolStripMenuItemRestart.Name = "ToolStripMenuItemRestart";
            this.ToolStripMenuItemRestart.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemRestart.Text = "重新开始(R)";
            this.ToolStripMenuItemRestart.Click += new System.EventHandler(this.ToolStripMenuItemRestart_Click);
            // 
            // ToolStripMenuItemQuit
            // 
            this.ToolStripMenuItemQuit.Name = "ToolStripMenuItemQuit";
            this.ToolStripMenuItemQuit.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemQuit.Text = "退出（X）";
            this.ToolStripMenuItemQuit.Click += new System.EventHandler(this.ToolStripMenuItemQuit_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemIntroduction});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.帮助HToolStripMenuItem.Text = "帮助（H）";
            // 
            // ToolStripMenuItemIntroduction
            // 
            this.ToolStripMenuItemIntroduction.Name = "ToolStripMenuItemIntroduction";
            this.ToolStripMenuItemIntroduction.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItemIntroduction.Text = "玩法介绍(I)";
            this.ToolStripMenuItemIntroduction.Click += new System.EventHandler(this.ToolStripMenuItemIntroduction_Click);
            // 
            // buttonHardGame
            // 
            this.buttonHardGame.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonHardGame.Font = new System.Drawing.Font("华文隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonHardGame.Location = new System.Drawing.Point(77, 226);
            this.buttonHardGame.Name = "buttonHardGame";
            this.buttonHardGame.Size = new System.Drawing.Size(133, 47);
            this.buttonHardGame.TabIndex = 1;
            this.buttonHardGame.Text = "进阶(6·6)";
            this.buttonHardGame.UseVisualStyleBackColor = false;
            this.buttonHardGame.Click += new System.EventHandler(this.buttonHardGame_Click);
            // 
            // buttonCommonGame
            // 
            this.buttonCommonGame.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonCommonGame.Font = new System.Drawing.Font("华文隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCommonGame.Location = new System.Drawing.Point(77, 151);
            this.buttonCommonGame.Name = "buttonCommonGame";
            this.buttonCommonGame.Size = new System.Drawing.Size(133, 47);
            this.buttonCommonGame.TabIndex = 1;
            this.buttonCommonGame.Text = "经典(4·4)";
            this.buttonCommonGame.UseVisualStyleBackColor = false;
            this.buttonCommonGame.Click += new System.EventHandler(this.buttonCommonGame_Click);
            // 
            // buttonEasyGame
            // 
            this.buttonEasyGame.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonEasyGame.Font = new System.Drawing.Font("华文隶书", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEasyGame.Location = new System.Drawing.Point(77, 76);
            this.buttonEasyGame.Name = "buttonEasyGame";
            this.buttonEasyGame.Size = new System.Drawing.Size(133, 47);
            this.buttonEasyGame.TabIndex = 1;
            this.buttonEasyGame.Text = "简单(3·3)";
            this.buttonEasyGame.UseVisualStyleBackColor = false;
            this.buttonEasyGame.Click += new System.EventHandler(this.buttonEasyGame_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTime.Location = new System.Drawing.Point(58, 44);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(56, 16);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "用时：";
            this.labelTime.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(287, 289);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonEasyGame);
            this.Controls.Add(this.buttonCommonGame);
            this.Controls.Add(this.buttonHardGame);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "十五子经典小游戏";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemGame;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRestart;
        private System.Windows.Forms.ToolStripSeparator 经典ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQuit;
        private System.Windows.Forms.Button buttonHardGame;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemIntroduction;
        private System.Windows.Forms.Button buttonCommonGame;
        private System.Windows.Forms.Button buttonEasyGame;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelTime;

    }
}

