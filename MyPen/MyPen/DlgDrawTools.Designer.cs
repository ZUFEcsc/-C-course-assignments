namespace MyPen
{
    partial class DlgDrawTools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgDrawTools));
            this.buttonTriangle = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonSketch = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonPenWidth = new System.Windows.Forms.Button();
            this.buttonLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.Image = ((System.Drawing.Image)(resources.GetObject("buttonTriangle.Image")));
            this.buttonTriangle.Location = new System.Drawing.Point(191, 57);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(75, 23);
            this.buttonTriangle.TabIndex = 7;
            this.buttonTriangle.Text = "三角形";
            this.buttonTriangle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonTriangle.UseVisualStyleBackColor = true;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuit.Image")));
            this.buttonQuit.Location = new System.Drawing.Point(191, 105);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 6;
            this.buttonQuit.Text = "退出";
            this.buttonQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonSketch
            // 
            this.buttonSketch.Image = global::MyPen.Properties.Resources.sketch;
            this.buttonSketch.Location = new System.Drawing.Point(29, 105);
            this.buttonSketch.Name = "buttonSketch";
            this.buttonSketch.Size = new System.Drawing.Size(75, 23);
            this.buttonSketch.TabIndex = 9;
            this.buttonSketch.Text = "徒手画";
            this.buttonSketch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSketch.UseVisualStyleBackColor = true;
            this.buttonSketch.Click += new System.EventHandler(this.buttonSketch_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Image = global::MyPen.Properties.Resources.undo;
            this.buttonUndo.Location = new System.Drawing.Point(110, 105);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(75, 23);
            this.buttonUndo.TabIndex = 8;
            this.buttonUndo.Text = "撤销";
            this.buttonUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Image = global::MyPen.Properties.Resources.circle;
            this.buttonCircle.Location = new System.Drawing.Point(191, 11);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(75, 23);
            this.buttonCircle.TabIndex = 5;
            this.buttonCircle.Text = "画圆";
            this.buttonCircle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.Image = global::MyPen.Properties.Resources.color;
            this.buttonColor.Location = new System.Drawing.Point(110, 57);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(75, 23);
            this.buttonColor.TabIndex = 2;
            this.buttonColor.Text = "颜色";
            this.buttonColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Image = global::MyPen.Properties.Resources.rectangle;
            this.buttonRectangle.Location = new System.Drawing.Point(110, 11);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(75, 23);
            this.buttonRectangle.TabIndex = 1;
            this.buttonRectangle.Text = "矩形";
            this.buttonRectangle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonPenWidth
            // 
            this.buttonPenWidth.Image = global::MyPen.Properties.Resources.width;
            this.buttonPenWidth.Location = new System.Drawing.Point(29, 57);
            this.buttonPenWidth.Name = "buttonPenWidth";
            this.buttonPenWidth.Size = new System.Drawing.Size(75, 23);
            this.buttonPenWidth.TabIndex = 4;
            this.buttonPenWidth.Text = "线宽";
            this.buttonPenWidth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPenWidth.UseVisualStyleBackColor = true;
            this.buttonPenWidth.Click += new System.EventHandler(this.buttonPenWidth_Click);
            // 
            // buttonLine
            // 
            this.buttonLine.Image = global::MyPen.Properties.Resources.line;
            this.buttonLine.Location = new System.Drawing.Point(29, 11);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(75, 23);
            this.buttonLine.TabIndex = 3;
            this.buttonLine.Text = "画线";
            this.buttonLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // DlgDrawTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 139);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonSketch);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.buttonPenWidth);
            this.Controls.Add(this.buttonLine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DlgDrawTools";
            this.Text = "绘图工具";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgDrawTools_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTriangle;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonSketch;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonPenWidth;
        private System.Windows.Forms.Button buttonLine;
    }
}