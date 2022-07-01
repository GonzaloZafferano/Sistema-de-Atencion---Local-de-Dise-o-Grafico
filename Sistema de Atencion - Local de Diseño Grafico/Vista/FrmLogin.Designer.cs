
namespace Vista
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.lblUsuairo = new System.Windows.Forms.Label();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnIngresarAdministrador = new System.Windows.Forms.Button();
            this.btnIngresarUsuario = new System.Windows.Forms.Button();
            this.btnIngresarComoJefe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsuario.Location = new System.Drawing.Point(210, 56);
            this.txtUsuario.MaxLength = 8;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PlaceholderText = "Usuario";
            this.txtUsuario.Size = new System.Drawing.Size(284, 42);
            this.txtUsuario.TabIndex = 0;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassWord.Location = new System.Drawing.Point(210, 124);
            this.txtPassWord.MaxLength = 8;
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.PlaceholderText = "Contraseña";
            this.txtPassWord.Size = new System.Drawing.Size(284, 42);
            this.txtPassWord.TabIndex = 1;
            // 
            // lblUsuairo
            // 
            this.lblUsuairo.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuairo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUsuairo.Location = new System.Drawing.Point(14, 59);
            this.lblUsuairo.Name = "lblUsuairo";
            this.lblUsuairo.Size = new System.Drawing.Size(179, 39);
            this.lblUsuairo.TabIndex = 2;
            this.lblUsuairo.Text = "Usuario:";
            // 
            // lblPassWord
            // 
            this.lblPassWord.BackColor = System.Drawing.Color.Transparent;
            this.lblPassWord.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassWord.Location = new System.Drawing.Point(14, 127);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(179, 39);
            this.lblPassWord.TabIndex = 3;
            this.lblPassWord.Text = "Contraseña:";
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.Transparent;
            this.btnIngresar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIngresar.BackgroundImage")));
            this.btnIngresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIngresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIngresar.ForeColor = System.Drawing.Color.Maroon;
            this.btnIngresar.Location = new System.Drawing.Point(315, 192);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(179, 52);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::Vista.Properties.Resources.Boton9;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrar.ForeColor = System.Drawing.Color.Maroon;
            this.btnCerrar.Location = new System.Drawing.Point(14, 192);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(179, 52);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Salir";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnIngresarAdministrador
            // 
            this.btnIngresarAdministrador.BackColor = System.Drawing.Color.Transparent;
            this.btnIngresarAdministrador.BackgroundImage = global::Vista.Properties.Resources.Boton12;
            this.btnIngresarAdministrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIngresarAdministrador.FlatAppearance.BorderSize = 0;
            this.btnIngresarAdministrador.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarAdministrador.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarAdministrador.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarAdministrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarAdministrador.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIngresarAdministrador.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnIngresarAdministrador.Location = new System.Drawing.Point(588, 95);
            this.btnIngresarAdministrador.Name = "btnIngresarAdministrador";
            this.btnIngresarAdministrador.Size = new System.Drawing.Size(217, 79);
            this.btnIngresarAdministrador.TabIndex = 5;
            this.btnIngresarAdministrador.TabStop = false;
            this.btnIngresarAdministrador.Text = "Administrador";
            this.btnIngresarAdministrador.UseVisualStyleBackColor = false;
            this.btnIngresarAdministrador.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // btnIngresarUsuario
            // 
            this.btnIngresarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnIngresarUsuario.BackgroundImage = global::Vista.Properties.Resources.Boton12;
            this.btnIngresarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIngresarUsuario.FlatAppearance.BorderSize = 0;
            this.btnIngresarUsuario.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarUsuario.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIngresarUsuario.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnIngresarUsuario.Location = new System.Drawing.Point(588, 12);
            this.btnIngresarUsuario.Name = "btnIngresarUsuario";
            this.btnIngresarUsuario.Size = new System.Drawing.Size(217, 78);
            this.btnIngresarUsuario.TabIndex = 6;
            this.btnIngresarUsuario.TabStop = false;
            this.btnIngresarUsuario.Text = "Usuario";
            this.btnIngresarUsuario.UseVisualStyleBackColor = false;
            this.btnIngresarUsuario.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // btnIngresarComoJefe
            // 
            this.btnIngresarComoJefe.BackColor = System.Drawing.Color.Transparent;
            this.btnIngresarComoJefe.BackgroundImage = global::Vista.Properties.Resources.Boton12;
            this.btnIngresarComoJefe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIngresarComoJefe.FlatAppearance.BorderSize = 0;
            this.btnIngresarComoJefe.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarComoJefe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarComoJefe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIngresarComoJefe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarComoJefe.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIngresarComoJefe.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnIngresarComoJefe.Location = new System.Drawing.Point(588, 181);
            this.btnIngresarComoJefe.Name = "btnIngresarComoJefe";
            this.btnIngresarComoJefe.Size = new System.Drawing.Size(217, 78);
            this.btnIngresarComoJefe.TabIndex = 7;
            this.btnIngresarComoJefe.TabStop = false;
            this.btnIngresarComoJefe.Text = "Jefe";
            this.btnIngresarComoJefe.UseVisualStyleBackColor = false;
            this.btnIngresarComoJefe.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(845, 271);
            this.Controls.Add(this.btnIngresarComoJefe);
            this.Controls.Add(this.btnIngresarUsuario);
            this.Controls.Add(this.btnIngresarAdministrador);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.lblUsuairo);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUsuario);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label lblUsuairo;
        private System.Windows.Forms.Label lblPassWord;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnIngresarAdministrador;
        private System.Windows.Forms.Button btnIngresarUsuario;
        private System.Windows.Forms.Button btnIngresarComoJefe;
    }
}

