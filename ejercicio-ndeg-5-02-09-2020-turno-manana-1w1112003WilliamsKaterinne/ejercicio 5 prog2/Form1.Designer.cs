namespace ejercicio_5_prog2
{
    partial class frmProductos
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
            this.lstNombre = new System.Windows.Forms.ListBox();
            this.lstPrecio = new System.Windows.Forms.ListBox();
            this.lstCantidad = new System.Windows.Forms.ListBox();
            this.lstTotalProducto = new System.Windows.Forms.ListBox();
            this.btnPrecioProducto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstNombre
            // 
            this.lstNombre.FormattingEnabled = true;
            this.lstNombre.ItemHeight = 20;
            this.lstNombre.Location = new System.Drawing.Point(39, 48);
            this.lstNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstNombre.Name = "lstNombre";
            this.lstNombre.Size = new System.Drawing.Size(161, 444);
            this.lstNombre.TabIndex = 0;
            // 
            // lstPrecio
            // 
            this.lstPrecio.FormattingEnabled = true;
            this.lstPrecio.ItemHeight = 20;
            this.lstPrecio.Location = new System.Drawing.Point(226, 48);
            this.lstPrecio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstPrecio.Name = "lstPrecio";
            this.lstPrecio.Size = new System.Drawing.Size(162, 444);
            this.lstPrecio.TabIndex = 0;
            // 
            // lstCantidad
            // 
            this.lstCantidad.FormattingEnabled = true;
            this.lstCantidad.ItemHeight = 20;
            this.lstCantidad.Location = new System.Drawing.Point(409, 48);
            this.lstCantidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstCantidad.Name = "lstCantidad";
            this.lstCantidad.Size = new System.Drawing.Size(170, 444);
            this.lstCantidad.TabIndex = 0;
            // 
            // lstTotalProducto
            // 
            this.lstTotalProducto.FormattingEnabled = true;
            this.lstTotalProducto.ItemHeight = 20;
            this.lstTotalProducto.Location = new System.Drawing.Point(754, 38);
            this.lstTotalProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstTotalProducto.Name = "lstTotalProducto";
            this.lstTotalProducto.Size = new System.Drawing.Size(166, 364);
            this.lstTotalProducto.TabIndex = 0;
            // 
            // btnPrecioProducto
            // 
            this.btnPrecioProducto.Location = new System.Drawing.Point(610, 248);
            this.btnPrecioProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrecioProducto.Name = "btnPrecioProducto";
            this.btnPrecioProducto.Size = new System.Drawing.Size(114, 94);
            this.btnPrecioProducto.TabIndex = 1;
            this.btnPrecioProducto.Text = "Total Producto";
            this.btnPrecioProducto.UseVisualStyleBackColor = true;
            this.btnPrecioProducto.Click += new System.EventHandler(this.btnPrecioProducto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(682, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.AllowDrop = true;
            this.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotal.Location = new System.Drawing.Point(754, 432);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(166, 27);
            this.txtTotal.TabIndex = 3;
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 600);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrecioProducto);
            this.Controls.Add(this.lstTotalProducto);
            this.Controls.Add(this.lstCantidad);
            this.Controls.Add(this.lstPrecio);
            this.Controls.Add(this.lstNombre);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProductos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.frmProductos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstNombre;
        private System.Windows.Forms.ListBox lstPrecio;
        private System.Windows.Forms.ListBox lstCantidad;
        private System.Windows.Forms.ListBox lstTotalProducto;
        private System.Windows.Forms.Button btnPrecioProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotal;
    }
}

