
namespace Vista
{
    partial class FrmAltaProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAltaProducto));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gBoxTipoDeProducto = new System.Windows.Forms.GroupBox();
            this.rBtnDisenio = new System.Windows.Forms.RadioButton();
            this.rBtnImpresion = new System.Windows.Forms.RadioButton();
            this.rTxtBoxDescripcion = new System.Windows.Forms.RichTextBox();
            this.lblSignoMoneda = new System.Windows.Forms.Label();
            this.gBoxTipoDeProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BackgroundImage = global::Vista.Properties.Resources.Boton9;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(12, 479);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(155, 54);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Atras";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPrecio.Location = new System.Drawing.Point(243, 294);
            this.txtPrecio.MaxLength = 10;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.PlaceholderText = "Ej.: 1234,5678";
            this.txtPrecio.Size = new System.Drawing.Size(378, 38);
            this.txtPrecio.TabIndex = 2;
            // 
            // lblPrecio
            // 
            this.lblPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecio.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrecio.Location = new System.Drawing.Point(12, 297);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(179, 38);
            this.lblPrecio.TabIndex = 22;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescripcion.Location = new System.Drawing.Point(12, 56);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(214, 38);
            this.lblDescripcion.TabIndex = 16;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAceptar.Location = new System.Drawing.Point(466, 479);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(155, 54);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombre.Location = new System.Drawing.Point(243, 9);
            this.txtNombre.MaxLength = 32;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Ingrese nombre";
            this.txtNombre.Size = new System.Drawing.Size(378, 38);
            this.txtNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(12, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(214, 38);
            this.lblNombre.TabIndex = 13;
            this.lblNombre.Text = "Nombre:";
            // 
            // gBoxTipoDeProducto
            // 
            this.gBoxTipoDeProducto.BackColor = System.Drawing.Color.Transparent;
            this.gBoxTipoDeProducto.BackgroundImage = global::Vista.Properties.Resources.Boton8;
            this.gBoxTipoDeProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gBoxTipoDeProducto.Controls.Add(this.rBtnDisenio);
            this.gBoxTipoDeProducto.Controls.Add(this.rBtnImpresion);
            this.gBoxTipoDeProducto.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gBoxTipoDeProducto.Location = new System.Drawing.Point(12, 348);
            this.gBoxTipoDeProducto.Name = "gBoxTipoDeProducto";
            this.gBoxTipoDeProducto.Size = new System.Drawing.Size(482, 112);
            this.gBoxTipoDeProducto.TabIndex = 25;
            this.gBoxTipoDeProducto.TabStop = false;
            this.gBoxTipoDeProducto.Text = "Tipo de Producto";
            // 
            // rBtnDisenio
            // 
            this.rBtnDisenio.AutoSize = true;
            this.rBtnDisenio.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rBtnDisenio.Location = new System.Drawing.Point(59, 49);
            this.rBtnDisenio.Name = "rBtnDisenio";
            this.rBtnDisenio.Size = new System.Drawing.Size(127, 36);
            this.rBtnDisenio.TabIndex = 3;
            this.rBtnDisenio.TabStop = true;
            this.rBtnDisenio.Text = "Diseño";
            this.rBtnDisenio.UseVisualStyleBackColor = true;
            // 
            // rBtnImpresion
            // 
            this.rBtnImpresion.AutoSize = true;
            this.rBtnImpresion.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rBtnImpresion.Location = new System.Drawing.Point(242, 49);
            this.rBtnImpresion.Name = "rBtnImpresion";
            this.rBtnImpresion.Size = new System.Drawing.Size(169, 36);
            this.rBtnImpresion.TabIndex = 4;
            this.rBtnImpresion.TabStop = true;
            this.rBtnImpresion.Text = "Impresion";
            this.rBtnImpresion.UseVisualStyleBackColor = true;
            // 
            // rTxtBoxDescripcion
            // 
            this.rTxtBoxDescripcion.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rTxtBoxDescripcion.Location = new System.Drawing.Point(243, 58);
            this.rTxtBoxDescripcion.MaxLength = 300;
            this.rTxtBoxDescripcion.Name = "rTxtBoxDescripcion";
            this.rTxtBoxDescripcion.Size = new System.Drawing.Size(378, 230);
            this.rTxtBoxDescripcion.TabIndex = 1;
            this.rTxtBoxDescripcion.Text = "";
            // 
            // lblSignoMoneda
            // 
            this.lblSignoMoneda.BackColor = System.Drawing.Color.Transparent;
            this.lblSignoMoneda.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSignoMoneda.Location = new System.Drawing.Point(208, 297);
            this.lblSignoMoneda.Name = "lblSignoMoneda";
            this.lblSignoMoneda.Size = new System.Drawing.Size(29, 38);
            this.lblSignoMoneda.TabIndex = 27;
            this.lblSignoMoneda.Text = "$";
            // 
            // FrmAltaProducto
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoApp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(643, 545);
            this.Controls.Add(this.lblSignoMoneda);
            this.Controls.Add(this.rTxtBoxDescripcion);
            this.Controls.Add(this.gBoxTipoDeProducto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAltaProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAltaProducto_Load);
            this.gBoxTipoDeProducto.ResumeLayout(false);
            this.gBoxTipoDeProducto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox gBoxTipoDeProducto;
        private System.Windows.Forms.RadioButton rBtnDisenio;
        private System.Windows.Forms.RadioButton rBtnImpresion;
        private System.Windows.Forms.RichTextBox rTxtBoxDescripcion;
        private System.Windows.Forms.Label lblSignoMoneda;
    }
}