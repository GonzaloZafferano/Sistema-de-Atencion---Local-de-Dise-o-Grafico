
namespace Vista
{
    partial class FrmTicketsDeCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTicketsDeCompra));
            this.cmbBoxTickets = new System.Windows.Forms.ComboBox();
            this.rTxtTicket = new System.Windows.Forms.RichTextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblSeleccione = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbBoxTickets
            // 
            this.cmbBoxTickets.BackColor = System.Drawing.Color.White;
            this.cmbBoxTickets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxTickets.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbBoxTickets.FormattingEnabled = true;
            this.cmbBoxTickets.Location = new System.Drawing.Point(235, 15);
            this.cmbBoxTickets.Name = "cmbBoxTickets";
            this.cmbBoxTickets.Size = new System.Drawing.Size(386, 27);
            this.cmbBoxTickets.TabIndex = 0;
            this.cmbBoxTickets.SelectedIndexChanged += new System.EventHandler(this.cmbBoxTickets_SelectedIndexChanged);
            // 
            // rTxtTicket
            // 
            this.rTxtTicket.BackColor = System.Drawing.Color.White;
            this.rTxtTicket.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rTxtTicket.Location = new System.Drawing.Point(12, 54);
            this.rTxtTicket.Name = "rTxtTicket";
            this.rTxtTicket.ReadOnly = true;
            this.rTxtTicket.Size = new System.Drawing.Size(609, 384);
            this.rTxtTicket.TabIndex = 1;
            this.rTxtTicket.Text = "";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrar.Location = new System.Drawing.Point(500, 447);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(121, 52);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Aceptar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblSeleccione
            // 
            this.lblSeleccione.AutoSize = true;
            this.lblSeleccione.BackColor = System.Drawing.Color.Transparent;
            this.lblSeleccione.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeleccione.Location = new System.Drawing.Point(12, 15);
            this.lblSeleccione.Name = "lblSeleccione";
            this.lblSeleccione.Size = new System.Drawing.Size(205, 27);
            this.lblSeleccione.TabIndex = 3;
            this.lblSeleccione.Text = "Seleccione Ticket:";
            // 
            // FrmTicketsDeCompra
            // 
            this.AcceptButton = this.btnCerrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoApp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(642, 511);
            this.Controls.Add(this.lblSeleccione);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.rTxtTicket);
            this.Controls.Add(this.cmbBoxTickets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTicketsDeCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmTicketsDeCompra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBoxTickets;
        private System.Windows.Forms.RichTextBox rTxtTicket;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblSeleccione;
    }
}