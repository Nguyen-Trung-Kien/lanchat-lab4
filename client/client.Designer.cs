
namespace client
{
    partial class client
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
            this.btnclient = new System.Windows.Forms.Button();
            this.txtbclient = new System.Windows.Forms.TextBox();
            this.listclient = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnclient
            // 
            this.btnclient.Location = new System.Drawing.Point(334, 374);
            this.btnclient.Name = "btnclient";
            this.btnclient.Size = new System.Drawing.Size(75, 23);
            this.btnclient.TabIndex = 5;
            this.btnclient.Text = "Gửi";
            this.btnclient.UseVisualStyleBackColor = true;
            this.btnclient.Click += new System.EventHandler(this.btnclient_Click);
            // 
            // txtbclient
            // 
            this.txtbclient.Location = new System.Drawing.Point(12, 374);
            this.txtbclient.Multiline = true;
            this.txtbclient.Name = "txtbclient";
            this.txtbclient.Size = new System.Drawing.Size(304, 27);
            this.txtbclient.TabIndex = 4;
            // 
            // listclient
            // 
            this.listclient.HideSelection = false;
            this.listclient.Location = new System.Drawing.Point(12, 12);
            this.listclient.Name = "listclient";
            this.listclient.Size = new System.Drawing.Size(415, 341);
            this.listclient.TabIndex = 3;
            this.listclient.UseCompatibleStateImageBehavior = false;
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 413);
            this.Controls.Add(this.btnclient);
            this.Controls.Add(this.txtbclient);
            this.Controls.Add(this.listclient);
            this.Name = "client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclient;
        private System.Windows.Forms.TextBox txtbclient;
        private System.Windows.Forms.ListView listclient;
    }
}

