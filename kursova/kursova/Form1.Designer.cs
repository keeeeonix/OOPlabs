namespace kursova
{
    partial class MainMenu
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_pvp = new System.Windows.Forms.Button();
            this.btn_CPU = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TicTacToe";
            // 
            // btn_pvp
            // 
            this.btn_pvp.Location = new System.Drawing.Point(148, 78);
            this.btn_pvp.Name = "btn_pvp";
            this.btn_pvp.Size = new System.Drawing.Size(400, 23);
            this.btn_pvp.TabIndex = 1;
            this.btn_pvp.Text = "vs Player";
            this.btn_pvp.UseVisualStyleBackColor = true;
            this.btn_pvp.Click += new System.EventHandler(this.btn_pvp_Click);
            // 
            // btn_CPU
            // 
            this.btn_CPU.Location = new System.Drawing.Point(148, 107);
            this.btn_CPU.Name = "btn_CPU";
            this.btn_CPU.Size = new System.Drawing.Size(400, 23);
            this.btn_CPU.TabIndex = 2;
            this.btn_CPU.Text = "vs CPU";
            this.btn_CPU.UseVisualStyleBackColor = true;
            this.btn_CPU.Click += new System.EventHandler(this.btn_CPU_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(148, 242);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(400, 23);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 345);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_CPU);
            this.Controls.Add(this.btn_pvp);
            this.Controls.Add(this.label1);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_pvp;
        private System.Windows.Forms.Button btn_CPU;
        private System.Windows.Forms.Button btn_Exit;
    }
}

