namespace FacebookParser
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
          this.button1 = new System.Windows.Forms.Button();
          this.button2 = new System.Windows.Forms.Button();
          this.button3 = new System.Windows.Forms.Button();
          this.dataGridView1 = new System.Windows.Forms.DataGridView();
          this.pictureBox1 = new System.Windows.Forms.PictureBox();
          this.progressBar1 = new System.Windows.Forms.ProgressBar();
          this.textBox1 = new System.Windows.Forms.TextBox();
          this.button4 = new System.Windows.Forms.Button();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
          this.SuspendLayout();
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(599, 194);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(100, 21);
          this.button1.TabIndex = 0;
          this.button1.Text = "查詢";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // button2
          // 
          this.button2.Location = new System.Drawing.Point(600, 139);
          this.button2.Name = "button2";
          this.button2.Size = new System.Drawing.Size(100, 21);
          this.button2.TabIndex = 1;
          this.button2.Text = "獲取資料";
          this.button2.UseVisualStyleBackColor = true;
          this.button2.Click += new System.EventHandler(this.button2_Click);
          // 
          // button3
          // 
          this.button3.Location = new System.Drawing.Point(601, 337);
          this.button3.Name = "button3";
          this.button3.Size = new System.Drawing.Size(100, 21);
          this.button3.TabIndex = 2;
          this.button3.Text = "登出";
          this.button3.UseVisualStyleBackColor = true;
          this.button3.Click += new System.EventHandler(this.button3_Click);
          // 
          // dataGridView1
          // 
          this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dataGridView1.Location = new System.Drawing.Point(12, 12);
          this.dataGridView1.Name = "dataGridView1";
          this.dataGridView1.Size = new System.Drawing.Size(582, 302);
          this.dataGridView1.TabIndex = 3;
          this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
          // 
          // pictureBox1
          // 
          this.pictureBox1.Location = new System.Drawing.Point(601, 12);
          this.pictureBox1.Name = "pictureBox1";
          this.pictureBox1.Size = new System.Drawing.Size(100, 92);
          this.pictureBox1.TabIndex = 5;
          this.pictureBox1.TabStop = false;
          // 
          // progressBar1
          // 
          this.progressBar1.Location = new System.Drawing.Point(13, 337);
          this.progressBar1.Name = "progressBar1";
          this.progressBar1.Size = new System.Drawing.Size(581, 23);
          this.progressBar1.TabIndex = 6;
          // 
          // textBox1
          // 
          this.textBox1.Location = new System.Drawing.Point(600, 166);
          this.textBox1.Name = "textBox1";
          this.textBox1.Size = new System.Drawing.Size(100, 22);
          this.textBox1.TabIndex = 7;
          // 
          // button4
          // 
          this.button4.Location = new System.Drawing.Point(599, 112);
          this.button4.Name = "button4";
          this.button4.Size = new System.Drawing.Size(100, 21);
          this.button4.TabIndex = 8;
          this.button4.Text = "登入";
          this.button4.UseVisualStyleBackColor = true;
          this.button4.Click += new System.EventHandler(this.button4_Click);
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(723, 378);
          this.Controls.Add(this.button4);
          this.Controls.Add(this.textBox1);
          this.Controls.Add(this.progressBar1);
          this.Controls.Add(this.pictureBox1);
          this.Controls.Add(this.dataGridView1);
          this.Controls.Add(this.button3);
          this.Controls.Add(this.button2);
          this.Controls.Add(this.button1);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Name = "Form1";
          this.Text = "點單小幫手 v2.0";
          this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
          this.Load += new System.EventHandler(this.Form1_Load);
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
    }
}

