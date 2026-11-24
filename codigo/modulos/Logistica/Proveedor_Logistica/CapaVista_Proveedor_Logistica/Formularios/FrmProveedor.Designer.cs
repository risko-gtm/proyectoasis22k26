namespace CapaVista_Proveedor_Logistica.Formularios
{
    partial class FrmProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProveedor));
            this.LogisticaNavProveedores = new CapaVista_Navegador.Navegador();
            this.LogisticaLblProveedor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogisticaNavProveedores
            // 
            this.LogisticaNavProveedores.Location = new System.Drawing.Point(13, 76);
            this.LogisticaNavProveedores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogisticaNavProveedores.Name = "LogisticaNavProveedores";
            this.LogisticaNavProveedores.Size = new System.Drawing.Size(1078, 90);
            this.LogisticaNavProveedores.TabIndex = 0;
            this.LogisticaNavProveedores.Load += new System.EventHandler(this.LogisticaNavProveedores_Load);
            // 
            // LogisticaLblProveedor
            // 
            this.LogisticaLblProveedor.AutoSize = true;
            this.LogisticaLblProveedor.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblProveedor.ForeColor = System.Drawing.Color.Teal;
            this.LogisticaLblProveedor.Location = new System.Drawing.Point(25, 36);
            this.LogisticaLblProveedor.Name = "LogisticaLblProveedor";
            this.LogisticaLblProveedor.Size = new System.Drawing.Size(301, 25);
            this.LogisticaLblProveedor.TabIndex = 1;
            this.LogisticaLblProveedor.Text = "Mantenimiento de Proveedores";
            // 
            // FrmProveedor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1094, 450);
            this.Controls.Add(this.LogisticaLblProveedor);
            this.Controls.Add(this.LogisticaNavProveedores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5040 - Proveedor de Logistica";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CapaVista_Navegador.Navegador LogisticaNavProveedores;
        private System.Windows.Forms.Label LogisticaLblProveedor;
    }
}