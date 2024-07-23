
namespace Revija
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnModneRevije = new System.Windows.Forms.Button();
            this.btnModniKreatori = new System.Windows.Forms.Button();
            this.btnManekeni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(127, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(222, 206);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnModneRevije
            // 
            this.btnModneRevije.Location = new System.Drawing.Point(127, 293);
            this.btnModneRevije.Name = "btnModneRevije";
            this.btnModneRevije.Size = new System.Drawing.Size(222, 57);
            this.btnModneRevije.TabIndex = 1;
            this.btnModneRevije.Text = "MODNE REVIJE";
            this.btnModneRevije.UseVisualStyleBackColor = true;
            this.btnModneRevije.Click += new System.EventHandler(this.btnModneRevije_Click);
            // 
            // btnModniKreatori
            // 
            this.btnModniKreatori.Location = new System.Drawing.Point(127, 385);
            this.btnModniKreatori.Name = "btnModniKreatori";
            this.btnModniKreatori.Size = new System.Drawing.Size(222, 57);
            this.btnModniKreatori.TabIndex = 2;
            this.btnModniKreatori.Text = "MODNI KREATORI";
            this.btnModniKreatori.UseVisualStyleBackColor = true;
            this.btnModniKreatori.Click += new System.EventHandler(this.btnModniKreatori_Click);
            // 
            // btnManekeni
            // 
            this.btnManekeni.Location = new System.Drawing.Point(127, 462);
            this.btnManekeni.Name = "btnManekeni";
            this.btnManekeni.Size = new System.Drawing.Size(222, 57);
            this.btnManekeni.TabIndex = 3;
            this.btnManekeni.Text = "MANEKENI";
            this.btnManekeni.UseVisualStyleBackColor = true;
            this.btnManekeni.Click += new System.EventHandler(this.btnManekeni_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(478, 559);
            this.Controls.Add(this.btnManekeni);
            this.Controls.Add(this.btnModniKreatori);
            this.Controls.Add(this.btnModneRevije);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "POCETNA STRANICA";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnModneRevije;
        private System.Windows.Forms.Button btnModniKreatori;
        private System.Windows.Forms.Button btnManekeni;
    }
}

