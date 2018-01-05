namespace Graphify
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SideBar = new System.Windows.Forms.Panel();
            this.btnRailFence = new System.Windows.Forms.Button();
            this.btnHill = new System.Windows.Forms.Button();
            this.btnTransposition = new System.Windows.Forms.Button();
            this.btnVigenere = new System.Windows.Forms.Button();
            this.btnPlayfair = new System.Windows.Forms.Button();
            this.btnCeasar = new System.Windows.Forms.Button();
            this.panelArea = new System.Windows.Forms.Panel();
            this.railfence1 = new Graphify.railfence();
            this.transposition1 = new Graphify.transposition();
            this.vigenere1 = new Graphify.vigenere();
            this.hill1 = new Graphify.hill();
            this.ceasar1 = new Graphify.ceasar();
            this.playfair1 = new Graphify.playfair();
            this.panel1.SuspendLayout();
            this.panelArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.SideBar);
            this.panel1.Controls.Add(this.btnRailFence);
            this.panel1.Controls.Add(this.btnHill);
            this.panel1.Controls.Add(this.btnTransposition);
            this.panel1.Controls.Add(this.btnVigenere);
            this.panel1.Controls.Add(this.btnPlayfair);
            this.panel1.Controls.Add(this.btnCeasar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 550);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.Maroon;
            this.SideBar.Location = new System.Drawing.Point(0, 100);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(10, 50);
            this.SideBar.TabIndex = 3;
            // 
            // btnRailFence
            // 
            this.btnRailFence.FlatAppearance.BorderSize = 0;
            this.btnRailFence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRailFence.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRailFence.ForeColor = System.Drawing.Color.White;
            this.btnRailFence.Location = new System.Drawing.Point(12, 380);
            this.btnRailFence.Name = "btnRailFence";
            this.btnRailFence.Size = new System.Drawing.Size(190, 50);
            this.btnRailFence.TabIndex = 8;
            this.btnRailFence.Text = "Rail Fence Cipher";
            this.btnRailFence.UseVisualStyleBackColor = true;
            this.btnRailFence.Click += new System.EventHandler(this.btnRailFence_Click);
            // 
            // btnHill
            // 
            this.btnHill.FlatAppearance.BorderSize = 0;
            this.btnHill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHill.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHill.ForeColor = System.Drawing.Color.White;
            this.btnHill.Location = new System.Drawing.Point(12, 212);
            this.btnHill.Name = "btnHill";
            this.btnHill.Size = new System.Drawing.Size(190, 50);
            this.btnHill.TabIndex = 7;
            this.btnHill.Text = "Hill Cypher";
            this.btnHill.UseVisualStyleBackColor = true;
            this.btnHill.Click += new System.EventHandler(this.btnHill_Click);
            // 
            // btnTransposition
            // 
            this.btnTransposition.FlatAppearance.BorderSize = 0;
            this.btnTransposition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransposition.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransposition.ForeColor = System.Drawing.Color.White;
            this.btnTransposition.Location = new System.Drawing.Point(12, 324);
            this.btnTransposition.Name = "btnTransposition";
            this.btnTransposition.Size = new System.Drawing.Size(190, 50);
            this.btnTransposition.TabIndex = 6;
            this.btnTransposition.Text = "Transposition Cipher";
            this.btnTransposition.UseVisualStyleBackColor = true;
            this.btnTransposition.Click += new System.EventHandler(this.btnTransposition_Click);
            // 
            // btnVigenere
            // 
            this.btnVigenere.FlatAppearance.BorderSize = 0;
            this.btnVigenere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVigenere.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVigenere.ForeColor = System.Drawing.Color.White;
            this.btnVigenere.Location = new System.Drawing.Point(12, 268);
            this.btnVigenere.Name = "btnVigenere";
            this.btnVigenere.Size = new System.Drawing.Size(190, 50);
            this.btnVigenere.TabIndex = 5;
            this.btnVigenere.Text = "Vigenère Cipher";
            this.btnVigenere.UseVisualStyleBackColor = true;
            this.btnVigenere.Click += new System.EventHandler(this.btnVigenere_Click);
            // 
            // btnPlayfair
            // 
            this.btnPlayfair.FlatAppearance.BorderSize = 0;
            this.btnPlayfair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayfair.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayfair.ForeColor = System.Drawing.Color.White;
            this.btnPlayfair.Location = new System.Drawing.Point(12, 156);
            this.btnPlayfair.Name = "btnPlayfair";
            this.btnPlayfair.Size = new System.Drawing.Size(190, 50);
            this.btnPlayfair.TabIndex = 4;
            this.btnPlayfair.Text = "Playfair Cipher";
            this.btnPlayfair.UseVisualStyleBackColor = true;
            this.btnPlayfair.Click += new System.EventHandler(this.btnPlayfair_Click);
            // 
            // btnCeasar
            // 
            this.btnCeasar.FlatAppearance.BorderSize = 0;
            this.btnCeasar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCeasar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCeasar.ForeColor = System.Drawing.Color.White;
            this.btnCeasar.Location = new System.Drawing.Point(12, 100);
            this.btnCeasar.Name = "btnCeasar";
            this.btnCeasar.Size = new System.Drawing.Size(190, 50);
            this.btnCeasar.TabIndex = 3;
            this.btnCeasar.Text = "Ceasar Cipher";
            this.btnCeasar.UseVisualStyleBackColor = true;
            this.btnCeasar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelArea
            // 
            this.panelArea.Controls.Add(this.railfence1);
            this.panelArea.Controls.Add(this.transposition1);
            this.panelArea.Controls.Add(this.vigenere1);
            this.panelArea.Controls.Add(this.hill1);
            this.panelArea.Controls.Add(this.ceasar1);
            this.panelArea.Controls.Add(this.playfair1);
            this.panelArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelArea.Location = new System.Drawing.Point(200, 0);
            this.panelArea.Name = "panelArea";
            this.panelArea.Size = new System.Drawing.Size(750, 550);
            this.panelArea.TabIndex = 7;
            // 
            // railfence1
            // 
            this.railfence1.Location = new System.Drawing.Point(0, 0);
            this.railfence1.Name = "railfence1";
            this.railfence1.Size = new System.Drawing.Size(750, 550);
            this.railfence1.TabIndex = 5;
            // 
            // transposition1
            // 
            this.transposition1.Location = new System.Drawing.Point(0, 0);
            this.transposition1.Name = "transposition1";
            this.transposition1.Size = new System.Drawing.Size(750, 550);
            this.transposition1.TabIndex = 4;
            // 
            // vigenere1
            // 
            this.vigenere1.Location = new System.Drawing.Point(0, 0);
            this.vigenere1.Name = "vigenere1";
            this.vigenere1.Size = new System.Drawing.Size(750, 550);
            this.vigenere1.TabIndex = 3;
            // 
            // hill1
            // 
            this.hill1.Location = new System.Drawing.Point(0, 0);
            this.hill1.Name = "hill1";
            this.hill1.Size = new System.Drawing.Size(750, 550);
            this.hill1.TabIndex = 2;
            // 
            // ceasar1
            // 
            this.ceasar1.Location = new System.Drawing.Point(0, 0);
            this.ceasar1.Name = "ceasar1";
            this.ceasar1.Size = new System.Drawing.Size(750, 550);
            this.ceasar1.TabIndex = 1;
            // 
            // playfair1
            // 
            this.playfair1.Location = new System.Drawing.Point(0, 0);
            this.playfair1.Name = "playfair1";
            this.playfair1.Size = new System.Drawing.Size(750, 550);
            this.playfair1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.panelArea);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panelArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCeasar;
        private System.Windows.Forms.Button btnPlayfair;
        private System.Windows.Forms.Button btnRailFence;
        private System.Windows.Forms.Button btnHill;
        private System.Windows.Forms.Button btnTransposition;
        private System.Windows.Forms.Button btnVigenere;
        private System.Windows.Forms.Panel SideBar;
        private System.Windows.Forms.Panel panelArea;
        private ceasar ceasar1;
        private playfair playfair1;
        private hill hill1;
        private vigenere vigenere1;
        private transposition transposition1;
        private railfence railfence1;
    }
}

