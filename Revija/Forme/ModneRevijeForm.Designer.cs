
namespace Revija.Forme
{
    partial class ModneRevijeForm
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
            this.listaRevije = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbxModneRevije = new System.Windows.Forms.GroupBox();
            this.gbxInfModnaRevija = new System.Windows.Forms.GroupBox();
            this.btnIzmeniReviju = new System.Windows.Forms.Button();
            this.btnObrisiReviju = new System.Windows.Forms.Button();
            this.btnDodajReviju = new System.Windows.Forms.Button();
            this.gbxManekeni = new System.Windows.Forms.GroupBox();
            this.btnManekeni = new System.Windows.Forms.Button();
            this.gbxKreatori = new System.Windows.Forms.GroupBox();
            this.btnModniKreatori = new System.Windows.Forms.Button();
            this.gbxVip = new System.Windows.Forms.GroupBox();
            this.btnVip = new System.Windows.Forms.Button();
            this.gbxModneRevije.SuspendLayout();
            this.gbxInfModnaRevija.SuspendLayout();
            this.gbxManekeni.SuspendLayout();
            this.gbxKreatori.SuspendLayout();
            this.gbxVip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaRevije
            // 
            this.listaRevije.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listaRevije.FullRowSelect = true;
            this.listaRevije.GridLines = true;
            this.listaRevije.HideSelection = false;
            this.listaRevije.Location = new System.Drawing.Point(6, 19);
            this.listaRevije.Name = "listaRevije";
            this.listaRevije.Size = new System.Drawing.Size(468, 439);
            this.listaRevije.TabIndex = 0;
            this.listaRevije.UseCompatibleStateImageBehavior = false;
            this.listaRevije.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Redni broj revije";
            this.columnHeader1.Width = 92;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Naziv";
            this.columnHeader2.Width = 43;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mesto odrzavanja";
            this.columnHeader3.Width = 101;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Datum i vreme odrzavanja";
            this.columnHeader4.Width = 143;
            // 
            // gbxModneRevije
            // 
            this.gbxModneRevije.Controls.Add(this.listaRevije);
            this.gbxModneRevije.Location = new System.Drawing.Point(12, 28);
            this.gbxModneRevije.Name = "gbxModneRevije";
            this.gbxModneRevije.Size = new System.Drawing.Size(495, 467);
            this.gbxModneRevije.TabIndex = 1;
            this.gbxModneRevije.TabStop = false;
            this.gbxModneRevije.Text = "Modne revije";
            // 
            // gbxInfModnaRevija
            // 
            this.gbxInfModnaRevija.Controls.Add(this.btnIzmeniReviju);
            this.gbxInfModnaRevija.Controls.Add(this.btnObrisiReviju);
            this.gbxInfModnaRevija.Controls.Add(this.btnDodajReviju);
            this.gbxInfModnaRevija.Location = new System.Drawing.Point(567, 26);
            this.gbxInfModnaRevija.Name = "gbxInfModnaRevija";
            this.gbxInfModnaRevija.Size = new System.Drawing.Size(201, 150);
            this.gbxInfModnaRevija.TabIndex = 2;
            this.gbxInfModnaRevija.TabStop = false;
            this.gbxInfModnaRevija.Text = "Info Modna Revija";
            // 
            // btnIzmeniReviju
            // 
            this.btnIzmeniReviju.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnIzmeniReviju.Location = new System.Drawing.Point(24, 108);
            this.btnIzmeniReviju.Name = "btnIzmeniReviju";
            this.btnIzmeniReviju.Size = new System.Drawing.Size(153, 25);
            this.btnIzmeniReviju.TabIndex = 2;
            this.btnIzmeniReviju.Text = "Izmeni reviju";
            this.btnIzmeniReviju.UseVisualStyleBackColor = false;
            this.btnIzmeniReviju.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnObrisiReviju
            // 
            this.btnObrisiReviju.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnObrisiReviju.Location = new System.Drawing.Point(24, 63);
            this.btnObrisiReviju.Name = "btnObrisiReviju";
            this.btnObrisiReviju.Size = new System.Drawing.Size(153, 25);
            this.btnObrisiReviju.TabIndex = 1;
            this.btnObrisiReviju.Text = "Obrisi reviju";
            this.btnObrisiReviju.UseVisualStyleBackColor = false;
            this.btnObrisiReviju.Click += new System.EventHandler(this.btnObrisiReviju_Click);
            // 
            // btnDodajReviju
            // 
            this.btnDodajReviju.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDodajReviju.Location = new System.Drawing.Point(24, 21);
            this.btnDodajReviju.Name = "btnDodajReviju";
            this.btnDodajReviju.Size = new System.Drawing.Size(153, 25);
            this.btnDodajReviju.TabIndex = 0;
            this.btnDodajReviju.Text = "Dodaj reviju";
            this.btnDodajReviju.UseVisualStyleBackColor = false;
            this.btnDodajReviju.Click += new System.EventHandler(this.btnDodajReviju_Click);
            // 
            // gbxManekeni
            // 
            this.gbxManekeni.Controls.Add(this.btnManekeni);
            this.gbxManekeni.Location = new System.Drawing.Point(568, 198);
            this.gbxManekeni.Name = "gbxManekeni";
            this.gbxManekeni.Size = new System.Drawing.Size(200, 78);
            this.gbxManekeni.TabIndex = 3;
            this.gbxManekeni.TabStop = false;
            this.gbxManekeni.Text = "Manekeni";
            // 
            // btnManekeni
            // 
            this.btnManekeni.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnManekeni.Location = new System.Drawing.Point(24, 27);
            this.btnManekeni.Name = "btnManekeni";
            this.btnManekeni.Size = new System.Drawing.Size(153, 25);
            this.btnManekeni.TabIndex = 3;
            this.btnManekeni.Text = "Manekeni";
            this.btnManekeni.UseVisualStyleBackColor = false;
            this.btnManekeni.Click += new System.EventHandler(this.btnManekeni_Click);
            // 
            // gbxKreatori
            // 
            this.gbxKreatori.Controls.Add(this.btnModniKreatori);
            this.gbxKreatori.Location = new System.Drawing.Point(567, 296);
            this.gbxKreatori.Name = "gbxKreatori";
            this.gbxKreatori.Size = new System.Drawing.Size(201, 81);
            this.gbxKreatori.TabIndex = 4;
            this.gbxKreatori.TabStop = false;
            this.gbxKreatori.Text = "ModniKreatori";
            // 
            // btnModniKreatori
            // 
            this.btnModniKreatori.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnModniKreatori.Location = new System.Drawing.Point(24, 28);
            this.btnModniKreatori.Name = "btnModniKreatori";
            this.btnModniKreatori.Size = new System.Drawing.Size(153, 25);
            this.btnModniKreatori.TabIndex = 3;
            this.btnModniKreatori.Text = "Modni kreatori";
            this.btnModniKreatori.UseVisualStyleBackColor = false;
            this.btnModniKreatori.Click += new System.EventHandler(this.btnModniKreatori_Click);
            // 
            // gbxVip
            // 
            this.gbxVip.Controls.Add(this.btnVip);
            this.gbxVip.Location = new System.Drawing.Point(567, 403);
            this.gbxVip.Name = "gbxVip";
            this.gbxVip.Size = new System.Drawing.Size(201, 83);
            this.gbxVip.TabIndex = 5;
            this.gbxVip.TabStop = false;
            this.gbxVip.Text = "VIP";
            // 
            // btnVip
            // 
            this.btnVip.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnVip.Location = new System.Drawing.Point(24, 29);
            this.btnVip.Name = "btnVip";
            this.btnVip.Size = new System.Drawing.Size(153, 25);
            this.btnVip.TabIndex = 3;
            this.btnVip.Text = "VIP";
            this.btnVip.UseVisualStyleBackColor = false;
            this.btnVip.Click += new System.EventHandler(this.btnVip_Click);
            // 
            // ModneRevijeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.gbxVip);
            this.Controls.Add(this.gbxKreatori);
            this.Controls.Add(this.gbxManekeni);
            this.Controls.Add(this.gbxInfModnaRevija);
            this.Controls.Add(this.gbxModneRevije);
            this.Name = "ModneRevijeForm";
            this.Text = "ModneRevijeForm";
            this.Load += new System.EventHandler(this.ModneRevijeForm_Load);
            this.gbxModneRevije.ResumeLayout(false);
            this.gbxInfModnaRevija.ResumeLayout(false);
            this.gbxManekeni.ResumeLayout(false);
            this.gbxKreatori.ResumeLayout(false);
            this.gbxVip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listaRevije;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox gbxModneRevije;
        private System.Windows.Forms.GroupBox gbxInfModnaRevija;
        private System.Windows.Forms.Button btnIzmeniReviju;
        private System.Windows.Forms.Button btnObrisiReviju;
        private System.Windows.Forms.Button btnDodajReviju;
        private System.Windows.Forms.GroupBox gbxManekeni;
        private System.Windows.Forms.GroupBox gbxKreatori;
        private System.Windows.Forms.GroupBox gbxVip;
        private System.Windows.Forms.Button btnManekeni;
        private System.Windows.Forms.Button btnModniKreatori;
        private System.Windows.Forms.Button btnVip;
    }
}