﻿namespace LayoutBXLYT.CTR
{
    partial class PaneMatCTRTevEditor
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
            this.stPropertyGrid1 = new Toolbox.Library.Forms.STPropertyGrid();
            this.tevStageCB = new Toolbox.Library.Forms.STComboBox();
            this.stageCounterLbl = new Toolbox.Library.Forms.STLabel();
            this.btnRemove = new Toolbox.Library.Forms.STButton();
            this.btnAdd = new Toolbox.Library.Forms.STButton();
            this.SuspendLayout();
            // 
            // stPropertyGrid1
            // 
            this.stPropertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stPropertyGrid1.AutoScroll = true;
            this.stPropertyGrid1.Location = new System.Drawing.Point(0, 42);
            this.stPropertyGrid1.Name = "stPropertyGrid1";
            this.stPropertyGrid1.ShowHintDisplay = false;
            this.stPropertyGrid1.Size = new System.Drawing.Size(421, 346);
            this.stPropertyGrid1.TabIndex = 0;
            // 
            // tevStageCB
            // 
            this.tevStageCB.BorderColor = System.Drawing.Color.Empty;
            this.tevStageCB.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.tevStageCB.ButtonColor = System.Drawing.Color.Empty;
            this.tevStageCB.FormattingEnabled = true;
            this.tevStageCB.IsReadOnly = false;
            this.tevStageCB.Location = new System.Drawing.Point(190, 14);
            this.tevStageCB.Name = "tevStageCB";
            this.tevStageCB.Size = new System.Drawing.Size(121, 20);
            this.tevStageCB.TabIndex = 1;
            this.tevStageCB.SelectedIndexChanged += new System.EventHandler(this.tevStageCB_SelectedIndexChanged);
            // 
            // stageCounterLbl
            // 
            this.stageCounterLbl.AutoSize = true;
            this.stageCounterLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stageCounterLbl.Location = new System.Drawing.Point(3, 14);
            this.stageCounterLbl.Name = "stageCounterLbl";
            this.stageCounterLbl.Size = new System.Drawing.Size(174, 18);
            this.stageCounterLbl.TabIndex = 2;
            this.stageCounterLbl.Text = "共5个阶段，此为第0阶段";
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(354, 11);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(31, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(317, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(31, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // PaneMatCTRTevEditor
            // 
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.stageCounterLbl);
            this.Controls.Add(this.tevStageCB);
            this.Controls.Add(this.stPropertyGrid1);
            this.Name = "PaneMatCTRTevEditor";
            this.Size = new System.Drawing.Size(421, 391);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Toolbox.Library.Forms.STPropertyGrid stPropertyGrid1;
        private Toolbox.Library.Forms.STComboBox tevStageCB;
        private Toolbox.Library.Forms.STLabel stageCounterLbl;
        private Toolbox.Library.Forms.STButton btnRemove;
        private Toolbox.Library.Forms.STButton btnAdd;
    }
}
