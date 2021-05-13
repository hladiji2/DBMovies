
namespace DBMovies.forms
{
    partial class NewCastForm
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
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.btnRegisterCast = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Celé jméno";
            // 
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(16, 30);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(134, 20);
            this.tbFullName.TabIndex = 1;
            // 
            // btnRegisterCast
            // 
            this.btnRegisterCast.Location = new System.Drawing.Point(16, 56);
            this.btnRegisterCast.Name = "btnRegisterCast";
            this.btnRegisterCast.Size = new System.Drawing.Size(134, 23);
            this.btnRegisterCast.TabIndex = 6;
            this.btnRegisterCast.Text = "Register";
            this.btnRegisterCast.UseVisualStyleBackColor = true;
            this.btnRegisterCast.Click += new System.EventHandler(this.btnRegisterCast_Click);
            // 
            // NewCastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 107);
            this.Controls.Add(this.btnRegisterCast);
            this.Controls.Add(this.tbFullName);
            this.Controls.Add(this.label1);
            this.Name = "NewCastForm";
            this.Text = "NewCastForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Button btnRegisterCast;
    }
}