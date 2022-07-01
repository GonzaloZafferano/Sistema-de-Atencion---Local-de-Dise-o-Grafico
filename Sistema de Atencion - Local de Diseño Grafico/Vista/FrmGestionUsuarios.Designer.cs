
namespace Vista
{
    partial class FrmGestionUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionUsuarios));
            this.btnModificacionUsuario = new System.Windows.Forms.Button();
            this.btnAltaUsuario = new System.Windows.Forms.Button();
            this.btnBajaUsuario = new System.Windows.Forms.Button();
            this.dgwListaUsuarios = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAsignarNuevoJefe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificacionUsuario
            // 
            this.btnModificacionUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificacionUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnModificacionUsuario.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnModificacionUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificacionUsuario.FlatAppearance.BorderSize = 0;
            this.btnModificacionUsuario.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnModificacionUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnModificacionUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnModificacionUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificacionUsuario.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModificacionUsuario.Location = new System.Drawing.Point(560, 248);
            this.btnModificacionUsuario.Name = "btnModificacionUsuario";
            this.btnModificacionUsuario.Size = new System.Drawing.Size(226, 61);
            this.btnModificacionUsuario.TabIndex = 2;
            this.btnModificacionUsuario.Text = "Modificar Usuario";
            this.btnModificacionUsuario.UseVisualStyleBackColor = false;
            this.btnModificacionUsuario.Click += new System.EventHandler(this.btnModificacionUsuario_Click);
            // 
            // btnAltaUsuario
            // 
            this.btnAltaUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAltaUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnAltaUsuario.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnAltaUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAltaUsuario.FlatAppearance.BorderSize = 0;
            this.btnAltaUsuario.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAltaUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAltaUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAltaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaUsuario.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAltaUsuario.Location = new System.Drawing.Point(1204, 248);
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.Size = new System.Drawing.Size(165, 61);
            this.btnAltaUsuario.TabIndex = 3;
            this.btnAltaUsuario.Text = "Alta Usuario";
            this.btnAltaUsuario.UseVisualStyleBackColor = false;
            this.btnAltaUsuario.Click += new System.EventHandler(this.btnAltaUsuario_Click);
            // 
            // btnBajaUsuario
            // 
            this.btnBajaUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnBajaUsuario.BackgroundImage = global::Vista.Properties.Resources.Boton1;
            this.btnBajaUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBajaUsuario.FlatAppearance.BorderSize = 0;
            this.btnBajaUsuario.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnBajaUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBajaUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBajaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajaUsuario.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBajaUsuario.Location = new System.Drawing.Point(222, 248);
            this.btnBajaUsuario.Name = "btnBajaUsuario";
            this.btnBajaUsuario.Size = new System.Drawing.Size(180, 61);
            this.btnBajaUsuario.TabIndex = 1;
            this.btnBajaUsuario.Text = "Baja Usuario";
            this.btnBajaUsuario.UseVisualStyleBackColor = false;
            this.btnBajaUsuario.Click += new System.EventHandler(this.btnBajaUsuario_Click);
            // 
            // dgwListaUsuarios
            // 
            this.dgwListaUsuarios.AllowUserToAddRows = false;
            this.dgwListaUsuarios.AllowUserToDeleteRows = false;
            this.dgwListaUsuarios.AllowUserToResizeColumns = false;
            this.dgwListaUsuarios.AllowUserToResizeRows = false;
            this.dgwListaUsuarios.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwListaUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwListaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwListaUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwListaUsuarios.Location = new System.Drawing.Point(9, 12);
            this.dgwListaUsuarios.MultiSelect = false;
            this.dgwListaUsuarios.Name = "dgwListaUsuarios";
            this.dgwListaUsuarios.ReadOnly = true;
            this.dgwListaUsuarios.RowHeadersVisible = false;
            this.dgwListaUsuarios.RowHeadersWidth = 51;
            this.dgwListaUsuarios.RowTemplate.Height = 29;
            this.dgwListaUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwListaUsuarios.Size = new System.Drawing.Size(1360, 221);
            this.dgwListaUsuarios.TabIndex = 19;
            this.dgwListaUsuarios.TabStop = false;
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
            this.btnCancelar.Location = new System.Drawing.Point(9, 248);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 61);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Atras";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAsignarNuevoJefe
            // 
            this.btnAsignarNuevoJefe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarNuevoJefe.BackColor = System.Drawing.Color.Transparent;
            this.btnAsignarNuevoJefe.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnAsignarNuevoJefe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAsignarNuevoJefe.FlatAppearance.BorderSize = 0;
            this.btnAsignarNuevoJefe.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAsignarNuevoJefe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAsignarNuevoJefe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAsignarNuevoJefe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarNuevoJefe.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAsignarNuevoJefe.Location = new System.Drawing.Point(900, 248);
            this.btnAsignarNuevoJefe.Name = "btnAsignarNuevoJefe";
            this.btnAsignarNuevoJefe.Size = new System.Drawing.Size(244, 61);
            this.btnAsignarNuevoJefe.TabIndex = 20;
            this.btnAsignarNuevoJefe.Text = "Asignar Nuevo Jefe";
            this.btnAsignarNuevoJefe.UseVisualStyleBackColor = false;
            this.btnAsignarNuevoJefe.Click += new System.EventHandler(this.btnAsignarNuevoJefe_Click);
            // 
            // FrmGestionUsuarios
            // 
            this.AcceptButton = this.btnAltaUsuario;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoApp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1381, 319);
            this.Controls.Add(this.btnAsignarNuevoJefe);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgwListaUsuarios);
            this.Controls.Add(this.btnBajaUsuario);
            this.Controls.Add(this.btnModificacionUsuario);
            this.Controls.Add(this.btnAltaUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGestionUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GestionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwListaUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModificacionUsuario;
        private System.Windows.Forms.Button btnAltaUsuario;
        private System.Windows.Forms.Button btnBajaUsuario;
        private System.Windows.Forms.DataGridView dgwListaUsuarios;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAsignarNuevoJefe;
    }
}