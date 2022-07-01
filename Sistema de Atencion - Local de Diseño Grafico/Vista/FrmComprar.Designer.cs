
namespace Vista
{
    partial class FrmComprar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComprar));
            this.dgvListaProductos = new System.Windows.Forms.DataGridView();
            this.nUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnCargarALaLista = new System.Windows.Forms.Button();
            this.dgvListaCarrito = new System.Windows.Forms.DataGridView();
            this.btnBorrarDelCarrito = new System.Windows.Forms.Button();
            this.gBoxTamanio = new System.Windows.Forms.GroupBox();
            this.rBtnGrande = new System.Windows.Forms.RadioButton();
            this.rBtnChico = new System.Windows.Forms.RadioButton();
            this.rBtnMediano = new System.Windows.Forms.RadioButton();
            this.gBoxColor = new System.Windows.Forms.GroupBox();
            this.rBtnColor = new System.Windows.Forms.RadioButton();
            this.rBtnSinColor = new System.Windows.Forms.RadioButton();
            this.txtDetallesProducto = new System.Windows.Forms.TextBox();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCarrito)).BeginInit();
            this.gBoxTamanio.SuspendLayout();
            this.gBoxColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListaProductos
            // 
            this.dgvListaProductos.AllowUserToAddRows = false;
            this.dgvListaProductos.AllowUserToDeleteRows = false;
            this.dgvListaProductos.AllowUserToResizeColumns = false;
            this.dgvListaProductos.AllowUserToResizeRows = false;
            this.dgvListaProductos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaProductos.Location = new System.Drawing.Point(11, 16);
            this.dgvListaProductos.MultiSelect = false;
            this.dgvListaProductos.Name = "dgvListaProductos";
            this.dgvListaProductos.ReadOnly = true;
            this.dgvListaProductos.RowHeadersVisible = false;
            this.dgvListaProductos.RowHeadersWidth = 51;
            this.dgvListaProductos.RowTemplate.Height = 29;
            this.dgvListaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaProductos.Size = new System.Drawing.Size(1090, 188);
            this.dgvListaProductos.TabIndex = 100;
            this.dgvListaProductos.TabStop = false;
            this.dgvListaProductos.SelectionChanged += new System.EventHandler(this.dgvListaProductos_SelectionChanged);
            // 
            // nUpDownCantidad
            // 
            this.nUpDownCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nUpDownCantidad.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nUpDownCantidad.Location = new System.Drawing.Point(1017, 221);
            this.nUpDownCantidad.Name = "nUpDownCantidad";
            this.nUpDownCantidad.Size = new System.Drawing.Size(80, 34);
            this.nUpDownCantidad.TabIndex = 4;
            // 
            // btnCargarALaLista
            // 
            this.btnCargarALaLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarALaLista.BackColor = System.Drawing.Color.Transparent;
            this.btnCargarALaLista.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnCargarALaLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargarALaLista.FlatAppearance.BorderSize = 0;
            this.btnCargarALaLista.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCargarALaLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCargarALaLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCargarALaLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarALaLista.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCargarALaLista.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCargarALaLista.Location = new System.Drawing.Point(1121, 211);
            this.btnCargarALaLista.Name = "btnCargarALaLista";
            this.btnCargarALaLista.Size = new System.Drawing.Size(200, 88);
            this.btnCargarALaLista.TabIndex = 6;
            this.btnCargarALaLista.Text = "Cargar Al Carrito";
            this.btnCargarALaLista.UseVisualStyleBackColor = false;
            this.btnCargarALaLista.Click += new System.EventHandler(this.btnCargarALaLista_Click);
            // 
            // dgvListaCarrito
            // 
            this.dgvListaCarrito.AllowUserToAddRows = false;
            this.dgvListaCarrito.AllowUserToDeleteRows = false;
            this.dgvListaCarrito.AllowUserToResizeColumns = false;
            this.dgvListaCarrito.AllowUserToResizeRows = false;
            this.dgvListaCarrito.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaCarrito.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListaCarrito.Location = new System.Drawing.Point(11, 321);
            this.dgvListaCarrito.MultiSelect = false;
            this.dgvListaCarrito.Name = "dgvListaCarrito";
            this.dgvListaCarrito.ReadOnly = true;
            this.dgvListaCarrito.RowHeadersVisible = false;
            this.dgvListaCarrito.RowHeadersWidth = 51;
            this.dgvListaCarrito.RowTemplate.Height = 29;
            this.dgvListaCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaCarrito.Size = new System.Drawing.Size(1310, 361);
            this.dgvListaCarrito.TabIndex = 101;
            this.dgvListaCarrito.TabStop = false;
            // 
            // btnBorrarDelCarrito
            // 
            this.btnBorrarDelCarrito.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrarDelCarrito.BackgroundImage = global::Vista.Properties.Resources.Boton1;
            this.btnBorrarDelCarrito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBorrarDelCarrito.FlatAppearance.BorderSize = 0;
            this.btnBorrarDelCarrito.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnBorrarDelCarrito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBorrarDelCarrito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBorrarDelCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarDelCarrito.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBorrarDelCarrito.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBorrarDelCarrito.Location = new System.Drawing.Point(204, 702);
            this.btnBorrarDelCarrito.Name = "btnBorrarDelCarrito";
            this.btnBorrarDelCarrito.Size = new System.Drawing.Size(293, 59);
            this.btnBorrarDelCarrito.TabIndex = 8;
            this.btnBorrarDelCarrito.Text = "Borrar item del carrito";
            this.btnBorrarDelCarrito.UseVisualStyleBackColor = false;
            this.btnBorrarDelCarrito.Click += new System.EventHandler(this.btnBorrarDelCarrito_Click);
            // 
            // gBoxTamanio
            // 
            this.gBoxTamanio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxTamanio.BackColor = System.Drawing.Color.Transparent;
            this.gBoxTamanio.BackgroundImage = global::Vista.Properties.Resources.Boton8;
            this.gBoxTamanio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gBoxTamanio.Controls.Add(this.rBtnGrande);
            this.gBoxTamanio.Controls.Add(this.rBtnChico);
            this.gBoxTamanio.Controls.Add(this.rBtnMediano);
            this.gBoxTamanio.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gBoxTamanio.Location = new System.Drawing.Point(1122, 16);
            this.gBoxTamanio.Name = "gBoxTamanio";
            this.gBoxTamanio.Size = new System.Drawing.Size(199, 171);
            this.gBoxTamanio.TabIndex = 0;
            this.gBoxTamanio.TabStop = false;
            this.gBoxTamanio.Text = "Tamaño";
            // 
            // rBtnGrande
            // 
            this.rBtnGrande.AutoSize = true;
            this.rBtnGrande.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rBtnGrande.Location = new System.Drawing.Point(35, 116);
            this.rBtnGrande.Name = "rBtnGrande";
            this.rBtnGrande.Size = new System.Drawing.Size(118, 33);
            this.rBtnGrande.TabIndex = 3;
            this.rBtnGrande.TabStop = true;
            this.rBtnGrande.Text = "Grande";
            this.rBtnGrande.UseVisualStyleBackColor = true;
            // 
            // rBtnChico
            // 
            this.rBtnChico.AutoSize = true;
            this.rBtnChico.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rBtnChico.Location = new System.Drawing.Point(35, 32);
            this.rBtnChico.Name = "rBtnChico";
            this.rBtnChico.Size = new System.Drawing.Size(101, 33);
            this.rBtnChico.TabIndex = 1;
            this.rBtnChico.TabStop = true;
            this.rBtnChico.Text = "Chico";
            this.rBtnChico.UseVisualStyleBackColor = true;
            // 
            // rBtnMediano
            // 
            this.rBtnMediano.AutoSize = true;
            this.rBtnMediano.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rBtnMediano.Location = new System.Drawing.Point(35, 75);
            this.rBtnMediano.Name = "rBtnMediano";
            this.rBtnMediano.Size = new System.Drawing.Size(133, 33);
            this.rBtnMediano.TabIndex = 2;
            this.rBtnMediano.TabStop = true;
            this.rBtnMediano.Text = "Mediano";
            this.rBtnMediano.UseVisualStyleBackColor = true;
            // 
            // gBoxColor
            // 
            this.gBoxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxColor.BackColor = System.Drawing.Color.Transparent;
            this.gBoxColor.BackgroundImage = global::Vista.Properties.Resources.Boton8;
            this.gBoxColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gBoxColor.Controls.Add(this.rBtnColor);
            this.gBoxColor.Controls.Add(this.rBtnSinColor);
            this.gBoxColor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gBoxColor.Location = new System.Drawing.Point(1122, 16);
            this.gBoxColor.Name = "gBoxColor";
            this.gBoxColor.Size = new System.Drawing.Size(200, 133);
            this.gBoxColor.TabIndex = 0;
            this.gBoxColor.TabStop = false;
            this.gBoxColor.Text = "Color";
            // 
            // rBtnColor
            // 
            this.rBtnColor.AutoSize = true;
            this.rBtnColor.BackColor = System.Drawing.Color.Transparent;
            this.rBtnColor.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rBtnColor.Location = new System.Drawing.Point(35, 79);
            this.rBtnColor.Name = "rBtnColor";
            this.rBtnColor.Size = new System.Drawing.Size(151, 33);
            this.rBtnColor.TabIndex = 1;
            this.rBtnColor.TabStop = true;
            this.rBtnColor.Text = "Con Color";
            this.rBtnColor.UseVisualStyleBackColor = false;
            // 
            // rBtnSinColor
            // 
            this.rBtnSinColor.AutoSize = true;
            this.rBtnSinColor.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rBtnSinColor.Location = new System.Drawing.Point(35, 37);
            this.rBtnSinColor.Name = "rBtnSinColor";
            this.rBtnSinColor.Size = new System.Drawing.Size(142, 33);
            this.rBtnSinColor.TabIndex = 0;
            this.rBtnSinColor.TabStop = true;
            this.rBtnSinColor.Text = "Sin Color";
            this.rBtnSinColor.UseVisualStyleBackColor = true;
            // 
            // txtDetallesProducto
            // 
            this.txtDetallesProducto.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDetallesProducto.Location = new System.Drawing.Point(11, 265);
            this.txtDetallesProducto.MaxLength = 250;
            this.txtDetallesProducto.Name = "txtDetallesProducto";
            this.txtDetallesProducto.PlaceholderText = "Opcional: Añada detalles del producto seleccionado";
            this.txtDetallesProducto.Size = new System.Drawing.Size(1090, 34);
            this.txtDetallesProducto.TabIndex = 5;
            // 
            // lblDetalles
            // 
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.BackColor = System.Drawing.Color.Transparent;
            this.lblDetalles.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDetalles.Location = new System.Drawing.Point(11, 221);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(129, 32);
            this.lblDetalles.TabIndex = 8;
            this.lblDetalles.Text = "Detalles:";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSiguiente.BackColor = System.Drawing.Color.Transparent;
            this.btnSiguiente.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSiguiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSiguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSiguiente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSiguiente.Location = new System.Drawing.Point(1156, 702);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(165, 59);
            this.btnSiguiente.TabIndex = 7;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(528, 702);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(606, 59);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCantidad.Location = new System.Drawing.Point(869, 223);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(142, 32);
            this.lblCantidad.TabIndex = 11;
            this.lblCantidad.Text = "Cantidad:";
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
            this.btnCancelar.Location = new System.Drawing.Point(12, 702);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(165, 59);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Atras";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmComprar
            // 
            this.AcceptButton = this.btnSiguiente;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoApp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1338, 784);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.gBoxTamanio);
            this.Controls.Add(this.gBoxColor);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.txtDetallesProducto);
            this.Controls.Add(this.btnBorrarDelCarrito);
            this.Controls.Add(this.dgvListaCarrito);
            this.Controls.Add(this.btnCargarALaLista);
            this.Controls.Add(this.nUpDownCantidad);
            this.Controls.Add(this.dgvListaProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmComprar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmComprar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCarrito)).EndInit();
            this.gBoxTamanio.ResumeLayout(false);
            this.gBoxTamanio.PerformLayout();
            this.gBoxColor.ResumeLayout(false);
            this.gBoxColor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaProductos;
        private System.Windows.Forms.NumericUpDown nUpDownCantidad;
        private System.Windows.Forms.Button btnCargarALaLista;
        private System.Windows.Forms.DataGridView dgvListaCarrito;
        private System.Windows.Forms.Button btnBorrarDelCarrito;
        private System.Windows.Forms.GroupBox gBoxTamanio;
        private System.Windows.Forms.RadioButton rBtnGrande;
        private System.Windows.Forms.RadioButton rBtnChico;
        private System.Windows.Forms.RadioButton rBtnMediano;
        private System.Windows.Forms.GroupBox gBoxColor;
        private System.Windows.Forms.RadioButton rBtnColor;
        private System.Windows.Forms.RadioButton rBtnSinColor;
        private System.Windows.Forms.TextBox txtDetallesProducto;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnCancelar;
    }
}