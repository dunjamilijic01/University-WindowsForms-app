
namespace Revija.Forme
{
    partial class DodajRevijuForm
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
            this.gbxOsnPodRevija = new System.Windows.Forms.GroupBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtMesto = new System.Windows.Forms.TextBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtRbr = new System.Windows.Forms.TextBox();
            this.lblPrvaZaj = new System.Windows.Forms.Label();
            this.chbxPrvaZaj = new System.Windows.Forms.CheckBox();
            this.lblDatVr = new System.Windows.Forms.Label();
            this.lblMestoOdr = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblRbrRevije = new System.Windows.Forms.Label();
            this.gbxOsnPodRevija.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxOsnPodRevija
            // 
            this.gbxOsnPodRevija.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbxOsnPodRevija.Controls.Add(this.btnDodaj);
            this.gbxOsnPodRevija.Controls.Add(this.dateTimePicker1);
            this.gbxOsnPodRevija.Controls.Add(this.txtMesto);
            this.gbxOsnPodRevija.Controls.Add(this.txtNaziv);
            this.gbxOsnPodRevija.Controls.Add(this.txtRbr);
            this.gbxOsnPodRevija.Controls.Add(this.lblPrvaZaj);
            this.gbxOsnPodRevija.Controls.Add(this.chbxPrvaZaj);
            this.gbxOsnPodRevija.Controls.Add(this.lblDatVr);
            this.gbxOsnPodRevija.Controls.Add(this.lblMestoOdr);
            this.gbxOsnPodRevija.Controls.Add(this.lblNaziv);
            this.gbxOsnPodRevija.Controls.Add(this.lblRbrRevije);
            this.gbxOsnPodRevija.Location = new System.Drawing.Point(21, 20);
            this.gbxOsnPodRevija.Name = "gbxOsnPodRevija";
            this.gbxOsnPodRevija.Size = new System.Drawing.Size(330, 223);
            this.gbxOsnPodRevija.TabIndex = 0;
            this.gbxOsnPodRevija.TabStop = false;
            this.gbxOsnPodRevija.Text = "Osnovni podaci o reviji";
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDodaj.Location = new System.Drawing.Point(234, 183);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 10;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(174, 111);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(135, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // txtMesto
            // 
            this.txtMesto.Location = new System.Drawing.Point(183, 80);
            this.txtMesto.Name = "txtMesto";
            this.txtMesto.Size = new System.Drawing.Size(100, 20);
            this.txtMesto.TabIndex = 8;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(183, 54);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(100, 20);
            this.txtNaziv.TabIndex = 7;
            // 
            // txtRbr
            // 
            this.txtRbr.Location = new System.Drawing.Point(183, 28);
            this.txtRbr.Name = "txtRbr";
            this.txtRbr.Size = new System.Drawing.Size(100, 20);
            this.txtRbr.TabIndex = 6;
            // 
            // lblPrvaZaj
            // 
            this.lblPrvaZaj.AutoSize = true;
            this.lblPrvaZaj.Location = new System.Drawing.Point(18, 155);
            this.lblPrvaZaj.Name = "lblPrvaZaj";
            this.lblPrvaZaj.Size = new System.Drawing.Size(111, 13);
            this.lblPrvaZaj.TabIndex = 5;
            this.lblPrvaZaj.Text = "Prva zajednicka revija";
            // 
            // chbxPrvaZaj
            // 
            this.chbxPrvaZaj.AutoSize = true;
            this.chbxPrvaZaj.Location = new System.Drawing.Point(174, 155);
            this.chbxPrvaZaj.Name = "chbxPrvaZaj";
            this.chbxPrvaZaj.Size = new System.Drawing.Size(15, 14);
            this.chbxPrvaZaj.TabIndex = 4;
            this.chbxPrvaZaj.UseVisualStyleBackColor = true;
            // 
            // lblDatVr
            // 
            this.lblDatVr.AutoSize = true;
            this.lblDatVr.Location = new System.Drawing.Point(18, 118);
            this.lblDatVr.Name = "lblDatVr";
            this.lblDatVr.Size = new System.Drawing.Size(130, 13);
            this.lblDatVr.TabIndex = 3;
            this.lblDatVr.Text = "Datum i vreme odrzavanja";
            // 
            // lblMestoOdr
            // 
            this.lblMestoOdr.AutoSize = true;
            this.lblMestoOdr.Location = new System.Drawing.Point(18, 90);
            this.lblMestoOdr.Name = "lblMestoOdr";
            this.lblMestoOdr.Size = new System.Drawing.Size(91, 13);
            this.lblMestoOdr.TabIndex = 2;
            this.lblMestoOdr.Text = "Mesto odrzavanja";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(18, 66);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(34, 13);
            this.lblNaziv.TabIndex = 1;
            this.lblNaziv.Text = "Naziv";
            // 
            // lblRbrRevije
            // 
            this.lblRbrRevije.AutoSize = true;
            this.lblRbrRevije.Location = new System.Drawing.Point(18, 35);
            this.lblRbrRevije.Name = "lblRbrRevije";
            this.lblRbrRevije.Size = new System.Drawing.Size(83, 13);
            this.lblRbrRevije.TabIndex = 0;
            this.lblRbrRevije.Text = "Redni broj revije";
            // 
            // DodajRevijuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(380, 265);
            this.Controls.Add(this.gbxOsnPodRevija);
            this.Name = "DodajRevijuForm";
            this.Text = "DodajRevijuForm";
            this.gbxOsnPodRevija.ResumeLayout(false);
            this.gbxOsnPodRevija.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxOsnPodRevija;
        private System.Windows.Forms.Label lblDatVr;
        private System.Windows.Forms.Label lblMestoOdr;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label lblRbrRevije;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtMesto;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtRbr;
        private System.Windows.Forms.Label lblPrvaZaj;
        private System.Windows.Forms.CheckBox chbxPrvaZaj;
    }
}