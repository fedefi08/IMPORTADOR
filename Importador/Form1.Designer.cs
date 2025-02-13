namespace Importador
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnClientes = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnVendedores = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnClientes
            // 
            this.BtnClientes.Location = new System.Drawing.Point(14, 111);
            this.BtnClientes.Name = "BtnClientes";
            this.BtnClientes.Size = new System.Drawing.Size(292, 59);
            this.BtnClientes.TabIndex = 0;
            this.BtnClientes.Text = "Clientes";
            this.BtnClientes.UseVisualStyleBackColor = true;
            this.BtnClientes.Click += new System.EventHandler(this.BtnClientes_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(292, 58);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 259);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(292, 65);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnVendedores
            // 
            this.btnVendedores.Location = new System.Drawing.Point(12, 37);
            this.btnVendedores.Name = "btnVendedores";
            this.btnVendedores.Size = new System.Drawing.Size(292, 58);
            this.btnVendedores.TabIndex = 3;
            this.btnVendedores.Text = "Transportes";
            this.btnVendedores.UseVisualStyleBackColor = true;
            this.btnVendedores.Click += new System.EventHandler(this.btnVendedores_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(318, 347);
            this.Controls.Add(this.btnVendedores);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnClientes);
            this.Name = "FrmPrincipal";
            this.Text = "Importador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnClientes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnVendedores;
    }
}

