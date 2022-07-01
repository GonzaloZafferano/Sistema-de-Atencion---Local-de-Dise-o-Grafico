
namespace Vista
{
    partial class FrmGestionProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionProductos));
            this.dgvListaProductos = new System.Windows.Forms.DataGridView();
            this.btnBajaProducto = new System.Windows.Forms.Button();
            this.btnModificacionProducto = new System.Windows.Forms.Button();
            this.btnAltaProducto = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProductos)).BeginInit();
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaProductos.Location = new System.Drawing.Point(13, 13);
            this.dgvListaProductos.MultiSelect = false;
            this.dgvListaProductos.Name = "dgvListaProductos";
            this.dgvListaProductos.ReadOnly = true;
            this.dgvListaProductos.RowHeadersVisible = false;
            this.dgvListaProductos.RowHeadersWidth = 51;
            this.dgvListaProductos.RowTemplate.Height = 29;
            this.dgvListaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaProductos.Size = new System.Drawing.Size(1065, 295);
            this.dgvListaProductos.TabIndex = 0;
            this.dgvListaProductos.TabStop = false;
            // 
            // btnBajaProducto
            // 
            this.btnBajaProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnBajaProducto.BackgroundImage = global::Vista.Properties.Resources.Boton1;
            this.btnBajaProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBajaProducto.FlatAppearance.BorderSize = 0;
            this.btnBajaProducto.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnBajaProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBajaProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBajaProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajaProducto.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBajaProducto.Location = new System.Drawing.Point(237, 326);
            this.btnBajaProducto.Name = "btnBajaProducto";
            this.btnBajaProducto.Size = new System.Drawing.Size(198, 46);
            this.btnBajaProducto.TabIndex = 1;
            this.btnBajaProducto.Text = "Baja Producto";
            this.btnBajaProducto.UseVisualStyleBackColor = false;
            this.btnBajaProducto.Click += new System.EventHandler(this.btnBajaProducto_Click);
            // 
            // btnModificacionProducto
            // 
            this.btnModificacionProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificacionProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnModificacionProducto.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnModificacionProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificacionProducto.FlatAppearance.BorderSize = 0;
            this.btnModificacionProducto.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnModificacionProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnModificacionProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnModificacionProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificacionProducto.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModificacionProducto.Location = new System.Drawing.Point(529, 326);
            this.btnModificacionProducto.Name = "btnModificacionProducto";
            this.btnModificacionProducto.Size = new System.Drawing.Size(250, 46);
            this.btnModificacionProducto.TabIndex = 2;
            this.btnModificacionProducto.Text = "Modificar Producto";
            this.btnModificacionProducto.UseVisualStyleBackColor = false;
            this.btnModificacionProducto.Click += new System.EventHandler(this.btnModificacionProducto_Click);
            // 
            // btnAltaProducto
            // 
            this.btnAltaProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAltaProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnAltaProducto.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnAltaProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAltaProducto.FlatAppearance.BorderSize = 0;
            this.btnAltaProducto.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAltaProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAltaProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAltaProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaProducto.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAltaProducto.Location = new System.Drawing.Point(891, 326);
            this.btnAltaProducto.Name = "btnAltaProducto";
            this.btnAltaProducto.Size = new System.Drawing.Size(187, 46);
            this.btnAltaProducto.TabIndex = 3;
            this.btnAltaProducto.Text = "Alta Producto";
            this.btnAltaProducto.UseVisualStyleBackColor = false;
            this.btnAltaProducto.Click += new System.EventHandler(this.btnAltaProducto_Click);
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
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(12, 326);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 46);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Atras";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmGestionProductos
            // 
            this.AcceptButton = this.btnAltaProducto;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoApp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1099, 384);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAltaProducto);
            this.Controls.Add(this.btnModificacionProducto);
            this.Controls.Add(this.btnBajaProducto);
            this.Controls.Add(this.dgvListaProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGestionProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GestionProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaProductos;
        private System.Windows.Forms.Button btnBajaProducto;
        private System.Windows.Forms.Button btnModificacionProducto;
        private System.Windows.Forms.Button btnAltaProducto;
        private System.Windows.Forms.Button btnCancelar;
    }
}