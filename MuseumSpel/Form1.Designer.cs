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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PosXSpeler = new System.Windows.Forms.Label();
            this.PosYSpeler = new System.Windows.Forms.Label();
            this.SpelerNaam = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.GuardX = new System.Windows.Forms.Label();
            this.AantalMuren = new System.Windows.Forms.Label();
            this.AantalPlassen = new System.Windows.Forms.Label();
            this.AantalPaintings = new System.Windows.Forms.Label();
            this.AantalVermommingen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GuardY = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GuardCollision = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.GuardRichting = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SpelerVermomming = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.SpelerCoolDown = new System.Windows.Forms.Label();
            this.StatsPanel = new System.Windows.Forms.Panel();
            this.EindPuntY = new System.Windows.Forms.Label();
            this.EindPuntX = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SpelerStunned = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.StatsPanel.SuspendLayout();
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
            this.menuStrip1.Location = new System.Drawing.Point(0, 551);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1184, 32);
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MuseumSpel.Properties.Resources.thief_front_stat1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 32);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(50, 50);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(50, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MuseumSpel.Properties.Resources.guard1_front_stat;
            this.pictureBox2.Location = new System.Drawing.Point(3, 108);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(50, 50);
            this.pictureBox2.MinimumSize = new System.Drawing.Size(50, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::MuseumSpel.Properties.Resources.waterPuddle_stat;
            this.pictureBox3.Location = new System.Drawing.Point(3, 260);
            this.pictureBox3.MaximumSize = new System.Drawing.Size(50, 50);
            this.pictureBox3.MinimumSize = new System.Drawing.Size(50, 50);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::MuseumSpel.Properties.Resources.wall_normal_stat;
            this.pictureBox4.Location = new System.Drawing.Point(3, 184);
            this.pictureBox4.MaximumSize = new System.Drawing.Size(50, 50);
            this.pictureBox4.MinimumSize = new System.Drawing.Size(50, 50);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 50);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::MuseumSpel.Properties.Resources.painting_dragon_stat;
            this.pictureBox5.Location = new System.Drawing.Point(3, 336);
            this.pictureBox5.MaximumSize = new System.Drawing.Size(50, 50);
            this.pictureBox5.MinimumSize = new System.Drawing.Size(50, 50);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 50);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::MuseumSpel.Properties.Resources.power4_stat;
            this.pictureBox6.Location = new System.Drawing.Point(3, 412);
            this.pictureBox6.MaximumSize = new System.Drawing.Size(50, 50);
            this.pictureBox6.MinimumSize = new System.Drawing.Size(50, 50);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(50, 50);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::MuseumSpel.Properties.Resources.eindpunt_stat;
            this.pictureBox7.Location = new System.Drawing.Point(3, 488);
            this.pictureBox7.MaximumSize = new System.Drawing.Size(50, 50);
            this.pictureBox7.MinimumSize = new System.Drawing.Size(50, 50);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(50, 50);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(59, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(59, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y:";
            // 
            // PosXSpeler
            // 
            this.PosXSpeler.AutoSize = true;
            this.PosXSpeler.BackColor = System.Drawing.Color.Transparent;
            this.PosXSpeler.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PosXSpeler.ForeColor = System.Drawing.Color.DimGray;
            this.PosXSpeler.Location = new System.Drawing.Point(90, 32);
            this.PosXSpeler.Name = "PosXSpeler";
            this.PosXSpeler.Size = new System.Drawing.Size(45, 20);
            this.PosXSpeler.TabIndex = 9;
            this.PosXSpeler.Text = "1000";
            this.PosXSpeler.Click += new System.EventHandler(this.label3_Click);
            // 
            // PosYSpeler
            // 
            this.PosYSpeler.AutoSize = true;
            this.PosYSpeler.BackColor = System.Drawing.Color.Transparent;
            this.PosYSpeler.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PosYSpeler.ForeColor = System.Drawing.Color.DimGray;
            this.PosYSpeler.Location = new System.Drawing.Point(90, 52);
            this.PosYSpeler.Name = "PosYSpeler";
            this.PosYSpeler.Size = new System.Drawing.Size(45, 20);
            this.PosYSpeler.TabIndex = 10;
            this.PosYSpeler.Text = "1000";
            // 
            // SpelerNaam
            // 
            this.SpelerNaam.AutoSize = true;
            this.SpelerNaam.BackColor = System.Drawing.Color.Transparent;
            this.SpelerNaam.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpelerNaam.ForeColor = System.Drawing.Color.DimGray;
            this.SpelerNaam.Location = new System.Drawing.Point(3, 9);
            this.SpelerNaam.Name = "SpelerNaam";
            this.SpelerNaam.Size = new System.Drawing.Size(60, 20);
            this.SpelerNaam.TabIndex = 11;
            this.SpelerNaam.Text = "Speler";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(3, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Bewaker";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(3, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Plas";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(3, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Muur";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(3, 313);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Schilderij";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(3, 389);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Vermomming";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(3, 465);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "EindPunt";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(59, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "X:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(59, 202);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 19;
            this.label13.Text = "Aantal:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(59, 275);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 20);
            this.label14.TabIndex = 20;
            this.label14.Text = "Aantal:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(59, 349);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 20);
            this.label15.TabIndex = 21;
            this.label15.Text = "Aantal:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label16.Location = new System.Drawing.Point(59, 429);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 20);
            this.label16.TabIndex = 22;
            this.label16.Text = "Aantal:";
            // 
            // GuardX
            // 
            this.GuardX.AutoSize = true;
            this.GuardX.BackColor = System.Drawing.Color.Transparent;
            this.GuardX.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardX.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GuardX.Location = new System.Drawing.Point(90, 108);
            this.GuardX.Name = "GuardX";
            this.GuardX.Size = new System.Drawing.Size(45, 20);
            this.GuardX.TabIndex = 24;
            this.GuardX.Text = "1000";
            // 
            // AantalMuren
            // 
            this.AantalMuren.AutoSize = true;
            this.AantalMuren.BackColor = System.Drawing.Color.Transparent;
            this.AantalMuren.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AantalMuren.ForeColor = System.Drawing.Color.DimGray;
            this.AantalMuren.Location = new System.Drawing.Point(129, 202);
            this.AantalMuren.Name = "AantalMuren";
            this.AantalMuren.Size = new System.Drawing.Size(45, 20);
            this.AantalMuren.TabIndex = 25;
            this.AantalMuren.Text = "1000";
            // 
            // AantalPlassen
            // 
            this.AantalPlassen.AutoSize = true;
            this.AantalPlassen.BackColor = System.Drawing.Color.Transparent;
            this.AantalPlassen.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AantalPlassen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AantalPlassen.Location = new System.Drawing.Point(129, 275);
            this.AantalPlassen.Name = "AantalPlassen";
            this.AantalPlassen.Size = new System.Drawing.Size(45, 20);
            this.AantalPlassen.TabIndex = 26;
            this.AantalPlassen.Text = "1000";
            // 
            // AantalPaintings
            // 
            this.AantalPaintings.AutoSize = true;
            this.AantalPaintings.BackColor = System.Drawing.Color.Transparent;
            this.AantalPaintings.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AantalPaintings.ForeColor = System.Drawing.Color.DimGray;
            this.AantalPaintings.Location = new System.Drawing.Point(129, 349);
            this.AantalPaintings.Name = "AantalPaintings";
            this.AantalPaintings.Size = new System.Drawing.Size(45, 20);
            this.AantalPaintings.TabIndex = 27;
            this.AantalPaintings.Text = "1000";
            // 
            // AantalVermommingen
            // 
            this.AantalVermommingen.AutoSize = true;
            this.AantalVermommingen.BackColor = System.Drawing.Color.Transparent;
            this.AantalVermommingen.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AantalVermommingen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AantalVermommingen.Location = new System.Drawing.Point(129, 429);
            this.AantalVermommingen.Name = "AantalVermommingen";
            this.AantalVermommingen.Size = new System.Drawing.Size(45, 20);
            this.AantalVermommingen.TabIndex = 28;
            this.AantalVermommingen.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(59, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Y:";
            // 
            // GuardY
            // 
            this.GuardY.AutoSize = true;
            this.GuardY.BackColor = System.Drawing.Color.Transparent;
            this.GuardY.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardY.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GuardY.Location = new System.Drawing.Point(90, 128);
            this.GuardY.Name = "GuardY";
            this.GuardY.Size = new System.Drawing.Size(45, 20);
            this.GuardY.TabIndex = 30;
            this.GuardY.Text = "1000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(149, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Ziet Muur:";
            // 
            // GuardCollision
            // 
            this.GuardCollision.AutoSize = true;
            this.GuardCollision.BackColor = System.Drawing.Color.Transparent;
            this.GuardCollision.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardCollision.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GuardCollision.Location = new System.Drawing.Point(245, 108);
            this.GuardCollision.Name = "GuardCollision";
            this.GuardCollision.Size = new System.Drawing.Size(41, 20);
            this.GuardCollision.TabIndex = 32;
            this.GuardCollision.Text = "Nee";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label18.Location = new System.Drawing.Point(149, 128);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 20);
            this.label18.TabIndex = 33;
            this.label18.Text = "Richting:";
            // 
            // GuardRichting
            // 
            this.GuardRichting.AutoSize = true;
            this.GuardRichting.BackColor = System.Drawing.Color.Transparent;
            this.GuardRichting.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardRichting.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GuardRichting.Location = new System.Drawing.Point(245, 128);
            this.GuardRichting.Name = "GuardRichting";
            this.GuardRichting.Size = new System.Drawing.Size(58, 20);
            this.GuardRichting.TabIndex = 34;
            this.GuardRichting.Text = "Boven";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DimGray;
            this.label19.Location = new System.Drawing.Point(141, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 20);
            this.label19.TabIndex = 35;
            this.label19.Text = "Vermomming:";
            // 
            // SpelerVermomming
            // 
            this.SpelerVermomming.AutoSize = true;
            this.SpelerVermomming.BackColor = System.Drawing.Color.Transparent;
            this.SpelerVermomming.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpelerVermomming.ForeColor = System.Drawing.Color.DimGray;
            this.SpelerVermomming.Location = new System.Drawing.Point(270, 12);
            this.SpelerVermomming.Name = "SpelerVermomming";
            this.SpelerVermomming.Size = new System.Drawing.Size(41, 20);
            this.SpelerVermomming.TabIndex = 36;
            this.SpelerVermomming.Text = "Nee";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DimGray;
            this.label20.Location = new System.Drawing.Point(141, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 20);
            this.label20.TabIndex = 37;
            this.label20.Text = "Stunned:";
            // 
            // SpelerCoolDown
            // 
            this.SpelerCoolDown.AutoSize = true;
            this.SpelerCoolDown.BackColor = System.Drawing.Color.Transparent;
            this.SpelerCoolDown.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpelerCoolDown.ForeColor = System.Drawing.Color.DimGray;
            this.SpelerCoolDown.Location = new System.Drawing.Point(270, 49);
            this.SpelerCoolDown.Name = "SpelerCoolDown";
            this.SpelerCoolDown.Size = new System.Drawing.Size(41, 20);
            this.SpelerCoolDown.TabIndex = 38;
            this.SpelerCoolDown.Text = "Nee";
            // 
            // StatsPanel
            // 
            this.StatsPanel.BackColor = System.Drawing.Color.Silver;
            this.StatsPanel.Controls.Add(this.EindPuntY);
            this.StatsPanel.Controls.Add(this.EindPuntX);
            this.StatsPanel.Controls.Add(this.label22);
            this.StatsPanel.Controls.Add(this.label17);
            this.StatsPanel.Controls.Add(this.SpelerStunned);
            this.StatsPanel.Controls.Add(this.label21);
            this.StatsPanel.Controls.Add(this.SpelerCoolDown);
            this.StatsPanel.Controls.Add(this.label20);
            this.StatsPanel.Controls.Add(this.SpelerVermomming);
            this.StatsPanel.Controls.Add(this.label19);
            this.StatsPanel.Controls.Add(this.GuardRichting);
            this.StatsPanel.Controls.Add(this.label18);
            this.StatsPanel.Controls.Add(this.GuardCollision);
            this.StatsPanel.Controls.Add(this.label4);
            this.StatsPanel.Controls.Add(this.GuardY);
            this.StatsPanel.Controls.Add(this.label3);
            this.StatsPanel.Controls.Add(this.AantalVermommingen);
            this.StatsPanel.Controls.Add(this.AantalPaintings);
            this.StatsPanel.Controls.Add(this.AantalPlassen);
            this.StatsPanel.Controls.Add(this.AantalMuren);
            this.StatsPanel.Controls.Add(this.GuardX);
            this.StatsPanel.Controls.Add(this.label16);
            this.StatsPanel.Controls.Add(this.label15);
            this.StatsPanel.Controls.Add(this.label14);
            this.StatsPanel.Controls.Add(this.label13);
            this.StatsPanel.Controls.Add(this.label12);
            this.StatsPanel.Controls.Add(this.label11);
            this.StatsPanel.Controls.Add(this.label10);
            this.StatsPanel.Controls.Add(this.label9);
            this.StatsPanel.Controls.Add(this.label8);
            this.StatsPanel.Controls.Add(this.label7);
            this.StatsPanel.Controls.Add(this.label6);
            this.StatsPanel.Controls.Add(this.SpelerNaam);
            this.StatsPanel.Controls.Add(this.PosYSpeler);
            this.StatsPanel.Controls.Add(this.PosXSpeler);
            this.StatsPanel.Controls.Add(this.label2);
            this.StatsPanel.Controls.Add(this.label1);
            this.StatsPanel.Controls.Add(this.pictureBox7);
            this.StatsPanel.Controls.Add(this.pictureBox6);
            this.StatsPanel.Controls.Add(this.pictureBox5);
            this.StatsPanel.Controls.Add(this.pictureBox4);
            this.StatsPanel.Controls.Add(this.pictureBox3);
            this.StatsPanel.Controls.Add(this.pictureBox2);
            this.StatsPanel.Controls.Add(this.pictureBox1);
            this.StatsPanel.Location = new System.Drawing.Point(851, 0);
            this.StatsPanel.Name = "StatsPanel";
            this.StatsPanel.Size = new System.Drawing.Size(333, 551);
            this.StatsPanel.TabIndex = 1;
            this.StatsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // EindPuntY
            // 
            this.EindPuntY.AutoSize = true;
            this.EindPuntY.BackColor = System.Drawing.Color.Transparent;
            this.EindPuntY.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EindPuntY.ForeColor = System.Drawing.Color.DimGray;
            this.EindPuntY.Location = new System.Drawing.Point(180, 503);
            this.EindPuntY.Name = "EindPuntY";
            this.EindPuntY.Size = new System.Drawing.Size(45, 20);
            this.EindPuntY.TabIndex = 44;
            this.EindPuntY.Text = "1000";
            // 
            // EindPuntX
            // 
            this.EindPuntX.AutoSize = true;
            this.EindPuntX.BackColor = System.Drawing.Color.Transparent;
            this.EindPuntX.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EindPuntX.ForeColor = System.Drawing.Color.DimGray;
            this.EindPuntX.Location = new System.Drawing.Point(90, 503);
            this.EindPuntX.Name = "EindPuntX";
            this.EindPuntX.Size = new System.Drawing.Size(45, 20);
            this.EindPuntX.TabIndex = 43;
            this.EindPuntX.Text = "1000";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.DimGray;
            this.label22.Location = new System.Drawing.Point(149, 503);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(25, 20);
            this.label22.TabIndex = 42;
            this.label22.Text = "Y:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(59, 503);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 20);
            this.label17.TabIndex = 41;
            this.label17.Text = "X:";
            // 
            // SpelerStunned
            // 
            this.SpelerStunned.AutoSize = true;
            this.SpelerStunned.BackColor = System.Drawing.Color.Transparent;
            this.SpelerStunned.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpelerStunned.ForeColor = System.Drawing.Color.DimGray;
            this.SpelerStunned.Location = new System.Drawing.Point(270, 32);
            this.SpelerStunned.Name = "SpelerStunned";
            this.SpelerStunned.Size = new System.Drawing.Size(41, 20);
            this.SpelerStunned.TabIndex = 40;
            this.SpelerStunned.Text = "Nee";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Rockwell", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DimGray;
            this.label21.Location = new System.Drawing.Point(141, 49);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 20);
            this.label21.TabIndex = 39;
            this.label21.Text = "Cooldown:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseumSpel.Properties.Resources.bc5;
            this.ClientSize = new System.Drawing.Size(1184, 583);
            this.ControlBox = false;
            this.Controls.Add(this.StatsPanel);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.StatsPanel.ResumeLayout(false);
            this.StatsPanel.PerformLayout();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PosXSpeler;
        private System.Windows.Forms.Label PosYSpeler;
        private System.Windows.Forms.Label SpelerNaam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label GuardX;
        private System.Windows.Forms.Label AantalMuren;
        private System.Windows.Forms.Label AantalPlassen;
        private System.Windows.Forms.Label AantalPaintings;
        private System.Windows.Forms.Label AantalVermommingen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label GuardY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label GuardCollision;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label GuardRichting;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label SpelerVermomming;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label SpelerCoolDown;
        private System.Windows.Forms.Panel StatsPanel;
        private System.Windows.Forms.Label SpelerStunned;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label EindPuntY;
        private System.Windows.Forms.Label EindPuntX;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label17;
    }
}

