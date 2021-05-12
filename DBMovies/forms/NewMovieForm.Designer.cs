
namespace DBMovies
{
    partial class NewMovieForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.txtActors = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReleaseDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHelp1 = new System.Windows.Forms.Button();
            this.btnHelp2 = new System.Windows.Forms.Button();
            this.btnAddCast = new System.Windows.Forms.Button();
            this.btnAddGenre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Název Filmu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Režisér**";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Herci***";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Žánr***";
            // 
            // txtMovieName
            // 
            this.txtMovieName.Location = new System.Drawing.Point(94, 6);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(200, 20);
            this.txtMovieName.TabIndex = 4;
            // 
            // txtDirector
            // 
            this.txtDirector.Location = new System.Drawing.Point(94, 52);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(140, 20);
            this.txtDirector.TabIndex = 5;
            // 
            // txtActors
            // 
            this.txtActors.Location = new System.Drawing.Point(94, 75);
            this.txtActors.Name = "txtActors";
            this.txtActors.Size = new System.Drawing.Size(140, 20);
            this.txtActors.TabIndex = 6;
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(94, 98);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(140, 20);
            this.txtGenre.TabIndex = 7;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(214, 145);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(80, 22);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 39);
            this.label5.TabIndex = 9;
            this.label5.Text = "* Formát DD.MM.RRRR\r\n** Zadejte pouze 1 ID\r\n*** Zadejte mezi ID čárku\r\n";
            // 
            // txtReleaseDate
            // 
            this.txtReleaseDate.Location = new System.Drawing.Point(94, 29);
            this.txtReleaseDate.Name = "txtReleaseDate";
            this.txtReleaseDate.Size = new System.Drawing.Size(200, 20);
            this.txtReleaseDate.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Rok Vydání*";
            // 
            // btnHelp1
            // 
            this.btnHelp1.Location = new System.Drawing.Point(240, 52);
            this.btnHelp1.Name = "btnHelp1";
            this.btnHelp1.Size = new System.Drawing.Size(24, 43);
            this.btnHelp1.TabIndex = 12;
            this.btnHelp1.Text = "?";
            this.btnHelp1.UseVisualStyleBackColor = true;
            this.btnHelp1.Click += new System.EventHandler(this.btnHelp1_Click);
            // 
            // btnHelp2
            // 
            this.btnHelp2.Location = new System.Drawing.Point(240, 96);
            this.btnHelp2.Name = "btnHelp2";
            this.btnHelp2.Size = new System.Drawing.Size(24, 22);
            this.btnHelp2.TabIndex = 13;
            this.btnHelp2.Text = "?";
            this.btnHelp2.UseVisualStyleBackColor = true;
            this.btnHelp2.Click += new System.EventHandler(this.btnHelp2_Click);
            // 
            // btnAddCast
            // 
            this.btnAddCast.Location = new System.Drawing.Point(270, 52);
            this.btnAddCast.Name = "btnAddCast";
            this.btnAddCast.Size = new System.Drawing.Size(24, 43);
            this.btnAddCast.TabIndex = 14;
            this.btnAddCast.Text = "+";
            this.btnAddCast.UseVisualStyleBackColor = true;
            this.btnAddCast.Click += new System.EventHandler(this.btnAddCast_Click);
            // 
            // btnAddGenre
            // 
            this.btnAddGenre.Location = new System.Drawing.Point(270, 96);
            this.btnAddGenre.Name = "btnAddGenre";
            this.btnAddGenre.Size = new System.Drawing.Size(24, 22);
            this.btnAddGenre.TabIndex = 15;
            this.btnAddGenre.Text = "+";
            this.btnAddGenre.UseVisualStyleBackColor = true;
            this.btnAddGenre.Click += new System.EventHandler(this.btnAddGenre_Click);
            // 
            // NewMovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 181);
            this.Controls.Add(this.btnAddGenre);
            this.Controls.Add(this.btnAddCast);
            this.Controls.Add(this.btnHelp2);
            this.Controls.Add(this.btnHelp1);
            this.Controls.Add(this.txtReleaseDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.txtActors);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.txtMovieName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewMovieForm";
            this.Text = "Nový Film";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.TextBox txtActors;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReleaseDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHelp1;
        private System.Windows.Forms.Button btnHelp2;
        private System.Windows.Forms.Button btnAddCast;
        private System.Windows.Forms.Button btnAddGenre;
    }
}