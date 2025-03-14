﻿namespace LayoutBXLYT.CTR
{
    partial class PaneMatCTRColorEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkAlphaInterpolation = new Toolbox.Library.Forms.STCheckBox();
            this.stLabel1 = new Toolbox.Library.Forms.STLabel();
            this.stLabel2 = new Toolbox.Library.Forms.STLabel();
            this.whiteColorPB = new Toolbox.Library.Forms.ColorAlphaBox();
            this.blackColorBP = new Toolbox.Library.Forms.ColorAlphaBox();
            this.tevColor1PB = new Toolbox.Library.Forms.ColorAlphaBox();
            this.stLabel5 = new Toolbox.Library.Forms.STLabel();
            this.tevColor2PB = new Toolbox.Library.Forms.ColorAlphaBox();
            this.stLabel6 = new Toolbox.Library.Forms.STLabel();
            this.tevColor4PB = new Toolbox.Library.Forms.ColorAlphaBox();
            this.tevColor3PB = new Toolbox.Library.Forms.ColorAlphaBox();
            this.stLabel7 = new Toolbox.Library.Forms.STLabel();
            this.stLabel8 = new Toolbox.Library.Forms.STLabel();
            this.SuspendLayout();
            // 
            // chkAlphaInterpolation
            // 
            this.chkAlphaInterpolation.AutoSize = true;
            this.chkAlphaInterpolation.Location = new System.Drawing.Point(16, 12);
            this.chkAlphaInterpolation.Name = "chkAlphaInterpolation";
            this.chkAlphaInterpolation.Size = new System.Drawing.Size(102, 16);
            this.chkAlphaInterpolation.TabIndex = 0;
            this.chkAlphaInterpolation.Text = "Alpha阈值混合";
            this.chkAlphaInterpolation.UseVisualStyleBackColor = true;
            // 
            // stLabel1
            // 
            this.stLabel1.AutoSize = true;
            this.stLabel1.Location = new System.Drawing.Point(112, 50);
            this.stLabel1.Name = "stLabel1";
            this.stLabel1.Size = new System.Drawing.Size(29, 12);
            this.stLabel1.TabIndex = 2;
            this.stLabel1.Text = "白色";
            // 
            // stLabel2
            // 
            this.stLabel2.AutoSize = true;
            this.stLabel2.Location = new System.Drawing.Point(277, 47);
            this.stLabel2.Name = "stLabel2";
            this.stLabel2.Size = new System.Drawing.Size(29, 12);
            this.stLabel2.TabIndex = 4;
            this.stLabel2.Text = "黑色";
            // 
            // whiteColorPB
            // 
            this.whiteColorPB.BackColor = System.Drawing.Color.Black;
            this.whiteColorPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.whiteColorPB.Color = System.Drawing.Color.Empty;
            this.whiteColorPB.DisplayAlphaSolid = true;
            this.whiteColorPB.Location = new System.Drawing.Point(16, 33);
            this.whiteColorPB.Name = "whiteColorPB";
            this.whiteColorPB.Size = new System.Drawing.Size(90, 42);
            this.whiteColorPB.TabIndex = 5;
            this.whiteColorPB.Click += new System.EventHandler(this.ColorPB_Click);
            // 
            // blackColorBP
            // 
            this.blackColorBP.BackColor = System.Drawing.Color.Black;
            this.blackColorBP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blackColorBP.Color = System.Drawing.Color.Empty;
            this.blackColorBP.DisplayAlphaSolid = true;
            this.blackColorBP.Location = new System.Drawing.Point(180, 33);
            this.blackColorBP.Name = "blackColorBP";
            this.blackColorBP.Size = new System.Drawing.Size(90, 42);
            this.blackColorBP.TabIndex = 6;
            this.blackColorBP.Click += new System.EventHandler(this.ColorPB_Click);
            // 
            // tevColor1PB
            // 
            this.tevColor1PB.BackColor = System.Drawing.Color.Black;
            this.tevColor1PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tevColor1PB.Color = System.Drawing.Color.Empty;
            this.tevColor1PB.DisplayAlphaSolid = true;
            this.tevColor1PB.Location = new System.Drawing.Point(16, 80);
            this.tevColor1PB.Name = "tevColor1PB";
            this.tevColor1PB.Size = new System.Drawing.Size(90, 42);
            this.tevColor1PB.TabIndex = 12;
            this.tevColor1PB.Click += new System.EventHandler(this.ColorPB_Click);
            // 
            // stLabel5
            // 
            this.stLabel5.AutoSize = true;
            this.stLabel5.Location = new System.Drawing.Point(113, 97);
            this.stLabel5.Name = "stLabel5";
            this.stLabel5.Size = new System.Drawing.Size(107, 12);
            this.stLabel5.TabIndex = 11;
            this.stLabel5.Text = "Tev 颜色 1";
            // 
            // tevColor2PB
            // 
            this.tevColor2PB.BackColor = System.Drawing.Color.Black;
            this.tevColor2PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tevColor2PB.Color = System.Drawing.Color.Empty;
            this.tevColor2PB.DisplayAlphaSolid = true;
            this.tevColor2PB.Location = new System.Drawing.Point(180, 80);
            this.tevColor2PB.Name = "tevColor2PB";
            this.tevColor2PB.Size = new System.Drawing.Size(90, 42);
            this.tevColor2PB.TabIndex = 14;
            this.tevColor2PB.Click += new System.EventHandler(this.ColorPB_Click);
            // 
            // stLabel6
            // 
            this.stLabel6.AutoSize = true;
            this.stLabel6.Location = new System.Drawing.Point(283, 97);
            this.stLabel6.Name = "stLabel6";
            this.stLabel6.Size = new System.Drawing.Size(71, 12);
            this.stLabel6.TabIndex = 13;
            this.stLabel6.Text = "Tev 颜色 2";
            // 
            // tevColor4PB
            // 
            this.tevColor4PB.BackColor = System.Drawing.Color.Black;
            this.tevColor4PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tevColor4PB.Color = System.Drawing.Color.Empty;
            this.tevColor4PB.DisplayAlphaSolid = true;
            this.tevColor4PB.Location = new System.Drawing.Point(180, 127);
            this.tevColor4PB.Name = "tevColor4PB";
            this.tevColor4PB.Size = new System.Drawing.Size(90, 42);
            this.tevColor4PB.TabIndex = 18;
            this.tevColor4PB.Click += new System.EventHandler(this.ColorPB_Click);
            // 
            // tevColor3PB
            // 
            this.tevColor3PB.BackColor = System.Drawing.Color.Black;
            this.tevColor3PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tevColor3PB.Color = System.Drawing.Color.Empty;
            this.tevColor3PB.DisplayAlphaSolid = true;
            this.tevColor3PB.Location = new System.Drawing.Point(16, 127);
            this.tevColor3PB.Name = "tevColor3PB";
            this.tevColor3PB.Size = new System.Drawing.Size(90, 42);
            this.tevColor3PB.TabIndex = 16;
            this.tevColor3PB.Click += new System.EventHandler(this.ColorPB_Click);
            // 
            // stLabel7
            // 
            this.stLabel7.AutoSize = true;
            this.stLabel7.Location = new System.Drawing.Point(283, 142);
            this.stLabel7.Name = "stLabel7";
            this.stLabel7.Size = new System.Drawing.Size(71, 12);
            this.stLabel7.TabIndex = 17;
            this.stLabel7.Text = "Tev 颜色 4";
            // 
            // stLabel8
            // 
            this.stLabel8.AutoSize = true;
            this.stLabel8.Location = new System.Drawing.Point(113, 142);
            this.stLabel8.Name = "stLabel8";
            this.stLabel8.Size = new System.Drawing.Size(71, 12);
            this.stLabel8.TabIndex = 15;
            this.stLabel8.Text = "Tev 颜色 3";
            // 
            // PaneMatCTRColorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tevColor4PB);
            this.Controls.Add(this.tevColor2PB);
            this.Controls.Add(this.tevColor3PB);
            this.Controls.Add(this.tevColor1PB);
            this.Controls.Add(this.stLabel7);
            this.Controls.Add(this.stLabel8);
            this.Controls.Add(this.stLabel6);
            this.Controls.Add(this.stLabel5);
            this.Controls.Add(this.blackColorBP);
            this.Controls.Add(this.whiteColorPB);
            this.Controls.Add(this.stLabel2);
            this.Controls.Add(this.stLabel1);
            this.Controls.Add(this.chkAlphaInterpolation);
            this.Name = "PaneMatCTRColorEditor";
            this.Size = new System.Drawing.Size(414, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Toolbox.Library.Forms.STCheckBox chkAlphaInterpolation;
        private Toolbox.Library.Forms.STLabel stLabel1;
        private Toolbox.Library.Forms.STLabel stLabel2;
        private Toolbox.Library.Forms.ColorAlphaBox whiteColorPB;
        private Toolbox.Library.Forms.ColorAlphaBox blackColorBP;
        private Toolbox.Library.Forms.ColorAlphaBox tevColor1PB;
        private Toolbox.Library.Forms.STLabel stLabel5;
        private Toolbox.Library.Forms.ColorAlphaBox tevColor2PB;
        private Toolbox.Library.Forms.STLabel stLabel6;
        private Toolbox.Library.Forms.ColorAlphaBox tevColor4PB;
        private Toolbox.Library.Forms.ColorAlphaBox tevColor3PB;
        private Toolbox.Library.Forms.STLabel stLabel7;
        private Toolbox.Library.Forms.STLabel stLabel8;
    }
}
