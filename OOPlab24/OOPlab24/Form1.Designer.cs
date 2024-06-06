namespace OOPlab24
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnSkipjack = new System.Windows.Forms.Button();
            this.btnSnefru = new System.Windows.Forms.Button();
            this.btnPKZIP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(94, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(94, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(200, 20);
            this.textBox3.TabIndex = 2;
            // 
            // btnSkipjack
            // 
            this.btnSkipjack.Location = new System.Drawing.Point(13, 13);
            this.btnSkipjack.Name = "btnSkipjack";
            this.btnSkipjack.Size = new System.Drawing.Size(75, 23);
            this.btnSkipjack.TabIndex = 3;
            this.btnSkipjack.Text = "button1";
            this.btnSkipjack.UseVisualStyleBackColor = true;
            this.btnSkipjack.Click += new System.EventHandler(this.btnSkipjack_Click);
            // 
            // btnSnefru
            // 
            this.btnSnefru.Location = new System.Drawing.Point(13, 43);
            this.btnSnefru.Name = "btnSnefru";
            this.btnSnefru.Size = new System.Drawing.Size(75, 23);
            this.btnSnefru.TabIndex = 4;
            this.btnSnefru.Text = "button2";
            this.btnSnefru.UseVisualStyleBackColor = true;
            this.btnSnefru.Click += new System.EventHandler(this.btnSnefru_Click);
            // 
            // btnPKZIP
            // 
            this.btnPKZIP.Location = new System.Drawing.Point(13, 73);
            this.btnPKZIP.Name = "btnPKZIP";
            this.btnPKZIP.Size = new System.Drawing.Size(75, 23);
            this.btnPKZIP.TabIndex = 5;
            this.btnPKZIP.Text = "button3";
            this.btnPKZIP.UseVisualStyleBackColor = true;
            this.btnPKZIP.Click += new System.EventHandler(this.btnPKZIP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPKZIP);
            this.Controls.Add(this.btnSnefru);
            this.Controls.Add(this.btnSkipjack);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnSkipjack;
        private System.Windows.Forms.Button btnSnefru;
        private System.Windows.Forms.Button btnPKZIP;
    }
}

