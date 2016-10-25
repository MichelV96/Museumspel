﻿namespace MuseumSpel
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pauzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geluidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.schilderijenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.speeltijdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauzeToolStripMenuItem,
            this.geluidToolStripMenuItem,
            this.toolStripMenuItem3,
            this.schilderijenToolStripMenuItem,
            this.toolStripMenuItem2,
            this.scoreToolStripMenuItem,
            this.toolStripMenuItem1,
            this.speeltijdToolStripMenuItem,
            this.restartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 549);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(848, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // pauzeToolStripMenuItem
            // 
            this.pauzeToolStripMenuItem.Name = "pauzeToolStripMenuItem";
            this.pauzeToolStripMenuItem.Size = new System.Drawing.Size(50, 28);
            this.pauzeToolStripMenuItem.Text = "Pauze";
            this.pauzeToolStripMenuItem.ToolTipText = "pauzeerd de game";
            this.pauzeToolStripMenuItem.Click += new System.EventHandler(this.pauzeToolStripMenuItem_Click);
            // 
            // geluidToolStripMenuItem
            // 
            this.geluidToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("geluidToolStripMenuItem.Image")));
            this.geluidToolStripMenuItem.Name = "geluidToolStripMenuItem";
            this.geluidToolStripMenuItem.Size = new System.Drawing.Size(36, 28);
            this.geluidToolStripMenuItem.ToolTipText = "Geluid aan/uit";
            this.geluidToolStripMenuItem.Click += new System.EventHandler(this.geluidToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(36, 28);
            this.toolStripMenuItem3.Text = "0/0";
            this.toolStripMenuItem3.ToolTipText = "gepakt/max";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // schilderijenToolStripMenuItem
            // 
            this.schilderijenToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.schilderijenToolStripMenuItem.Name = "schilderijenToolStripMenuItem";
            this.schilderijenToolStripMenuItem.Size = new System.Drawing.Size(80, 28);
            this.schilderijenToolStripMenuItem.Text = "Schilderijen";
            this.schilderijenToolStripMenuItem.ToolTipText = "hoeveel schilderijen je hebt";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(25, 28);
            this.toolStripMenuItem2.Text = "0";
            this.toolStripMenuItem2.ToolTipText = "aantal punten";
            // 
            // scoreToolStripMenuItem
            // 
            this.scoreToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.scoreToolStripMenuItem.Name = "scoreToolStripMenuItem";
            this.scoreToolStripMenuItem.Size = new System.Drawing.Size(48, 28);
            this.scoreToolStripMenuItem.Text = "Score";
            this.scoreToolStripMenuItem.ToolTipText = "hoeveel punten je hebt";
            this.scoreToolStripMenuItem.Click += new System.EventHandler(this.scoreToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 28);
            this.toolStripMenuItem1.Text = "00:00:00";
            this.toolStripMenuItem1.ToolTipText = "hoe lang je al aan het spelen bent.";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // speeltijdToolStripMenuItem
            // 
            this.speeltijdToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.speeltijdToolStripMenuItem.Name = "speeltijdToolStripMenuItem";
            this.speeltijdToolStripMenuItem.Size = new System.Drawing.Size(64, 28);
            this.speeltijdToolStripMenuItem.Text = "Speeltijd";
            this.speeltijdToolStripMenuItem.ToolTipText = "hoe lang je al aan het spelen bent.";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(55, 28);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.ToolTipText = "hier kun je opnieuw beginnen.";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseumSpel.Properties.Resources.bc4;
            this.ClientSize = new System.Drawing.Size(848, 581);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Museum Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pauzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geluidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speeltijdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem schilderijenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}

