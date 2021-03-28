
namespace DBMovies
{
    partial class AdminReportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtbMessagetoAdmin = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zpráva pro Admina";
            // 
            // rtbMessagetoAdmin
            // 
            this.rtbMessagetoAdmin.Location = new System.Drawing.Point(15, 35);
            this.rtbMessagetoAdmin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 13);
            this.rtbMessagetoAdmin.Name = "rtbMessagetoAdmin";
            this.rtbMessagetoAdmin.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbMessagetoAdmin.Size = new System.Drawing.Size(352, 96);
            this.rtbMessagetoAdmin.TabIndex = 2;
            this.rtbMessagetoAdmin.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(154, 147);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Poslat";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // AdminReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 183);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbMessagetoAdmin);
            this.Controls.Add(this.label1);
            this.Name = "AdminReportForm";
            this.Text = "Zpráva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbMessagetoAdmin;
        private System.Windows.Forms.Button btnSend;
    }
}