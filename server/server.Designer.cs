
namespace server
{
    partial class server
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
            this.listserver = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bntserver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listserver
            // 
            this.listserver.HideSelection = false;
            this.listserver.Location = new System.Drawing.Point(12, 12);
            this.listserver.Name = "listserver";
            this.listserver.Size = new System.Drawing.Size(415, 341);
            this.listserver.TabIndex = 0;
            this.listserver.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 374);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(304, 27);
            this.textBox1.TabIndex = 1;
            // 
            // bntserver
            // 
            this.bntserver.Location = new System.Drawing.Point(337, 374);
            this.bntserver.Name = "bntserver";
            this.bntserver.Size = new System.Drawing.Size(75, 23);
            this.bntserver.TabIndex = 2;
            this.bntserver.Text = "Gửi";
            this.bntserver.UseVisualStyleBackColor = true;
            this.bntserver.Click += new System.EventHandler(this.button1_Click);
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 411);
            this.Controls.Add(this.bntserver);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listserver);
            this.Name = "server";
            this.Text = "server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listserver;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bntserver;
    }
}

