
namespace Vista
{
    partial class FrmReactivar
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
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnReactivarEmpleado = new System.Windows.Forms.Button();
            this.btnReactivarCliente = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblIngreseDni = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDni.Location = new System.Drawing.Point(377, 27);
            this.txtDni.MaxLength = 8;
            this.txtDni.Name = "txtDni";
            this.txtDni.PlaceholderText = "Ej.: 12345678";
            this.txtDni.Size = new System.Drawing.Size(338, 38);
            this.txtDni.TabIndex = 0;
            // 
            // btnReactivarEmpleado
            // 
            this.btnReactivarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.btnReactivarEmpleado.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnReactivarEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReactivarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnReactivarEmpleado.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnReactivarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReactivarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReactivarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReactivarEmpleado.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReactivarEmpleado.Location = new System.Drawing.Point(560, 116);
            this.btnReactivarEmpleado.Name = "btnReactivarEmpleado";
            this.btnReactivarEmpleado.Size = new System.Drawing.Size(155, 74);
            this.btnReactivarEmpleado.TabIndex = 1;
            this.btnReactivarEmpleado.Text = "Reactivar empleado";
            this.btnReactivarEmpleado.UseVisualStyleBackColor = false;
            this.btnReactivarEmpleado.Click += new System.EventHandler(this.btnReactivarEmpleado_Click);
            // 
            // btnReactivarCliente
            // 
            this.btnReactivarCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnReactivarCliente.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnReactivarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReactivarCliente.FlatAppearance.BorderSize = 0;
            this.btnReactivarCliente.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnReactivarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReactivarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReactivarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReactivarCliente.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReactivarCliente.Location = new System.Drawing.Point(557, 116);
            this.btnReactivarCliente.Name = "btnReactivarCliente";
            this.btnReactivarCliente.Size = new System.Drawing.Size(158, 74);
            this.btnReactivarCliente.TabIndex = 2;
            this.btnReactivarCliente.Text = "Reactivar cliente";
            this.btnReactivarCliente.UseVisualStyleBackColor = false;
            this.btnReactivarCliente.Click += new System.EventHandler(this.btnReactivarCliente_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::Vista.Properties.Resources.Boton9;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrar.Location = new System.Drawing.Point(12, 116);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(138, 74);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Atras";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblIngreseDni
            // 
            this.lblIngreseDni.BackColor = System.Drawing.Color.Transparent;
            this.lblIngreseDni.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIngreseDni.Location = new System.Drawing.Point(12, 29);
            this.lblIngreseDni.Name = "lblIngreseDni";
            this.lblIngreseDni.Size = new System.Drawing.Size(338, 38);
            this.lblIngreseDni.TabIndex = 4;
            // 
            // FrmReactivar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoApp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(746, 200);
            this.Controls.Add(this.lblIngreseDni);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnReactivarCliente);
            this.Controls.Add(this.btnReactivarEmpleado);
            this.Controls.Add(this.txtDni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReactivar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReactivar";
            this.Load += new System.EventHandler(this.FrmReactivar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnReactivarEmpleado;
        private System.Windows.Forms.Button btnReactivarCliente;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblIngreseDni;
    }
}