
namespace DBMovies.forms
{
    partial class NewGenreForm
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
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.btnRegisterGenre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Název";
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(16, 30);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(178, 20);
            this.tbGenre.TabIndex = 1;
            // 
            // btnRegisterGenre
            // 
            this.btnRegisterGenre.Location = new System.Drawing.Point(16, 58);
            this.btnRegisterGenre.Name = "btnRegisterGenre";
            this.btnRegisterGenre.Size = new System.Drawing.Size(178, 23);
            this.btnRegisterGenre.TabIndex = 2;
            this.btnRegisterGenre.Text = "Register";
            this.btnRegisterGenre.UseVisualStyleBackColor = true;
            this.btnRegisterGenre.Click += new System.EventHandler(this.btnRegisterGenre_Click);
            // 
            // NewGenreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 93);
            this.Controls.Add(this.btnRegisterGenre);
            this.Controls.Add(this.tbGenre);
            this.Controls.Add(this.label1);
            this.Name = "NewGenreForm";
            this.Text = "NewGenreForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.Button btnRegisterGenre;
    }
}