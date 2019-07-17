namespace CapaPresentacion.Inventario
{
    partial class AgregarInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarInventario));
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.textBoxPUnitario = new System.Windows.Forms.TextBox();
            this.textBoxCantidad = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.InventariodataGridView = new System.Windows.Forms.DataGridView();
            this.errorCantidad = new System.Windows.Forms.Label();
            this.errorPUni = new System.Windows.Forms.Label();
            this.MedidacomboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventariodataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLimpiar.Location = new System.Drawing.Point(1025, 411);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(108, 30);
            this.btnLimpiar.TabIndex = 45;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRegistrar.Location = new System.Drawing.Point(1139, 411);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(108, 30);
            this.btnRegistrar.TabIndex = 44;
            this.btnRegistrar.Text = "REGISTRAR";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // textBoxPUnitario
            // 
            this.textBoxPUnitario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxPUnitario.Location = new System.Drawing.Point(941, 342);
            this.textBoxPUnitario.Name = "textBoxPUnitario";
            this.textBoxPUnitario.Size = new System.Drawing.Size(300, 20);
            this.textBoxPUnitario.TabIndex = 43;
            this.textBoxPUnitario.TextChanged += new System.EventHandler(this.textBoxPUnitario_TextChanged);
            this.textBoxPUnitario.Leave += new System.EventHandler(this.textBoxPUnitario_Leave);
            // 
            // textBoxCantidad
            // 
            this.textBoxCantidad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxCantidad.Location = new System.Drawing.Point(941, 308);
            this.textBoxCantidad.Name = "textBoxCantidad";
            this.textBoxCantidad.Size = new System.Drawing.Size(300, 20);
            this.textBoxCantidad.TabIndex = 42;
            this.textBoxCantidad.TextChanged += new System.EventHandler(this.textBoxCantidad_TextChanged);
            this.textBoxCantidad.Leave += new System.EventHandler(this.textBoxCantidad_Leave);
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxDescripcion.Location = new System.Drawing.Point(941, 240);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(300, 20);
            this.textBoxDescripcion.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(750, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 21);
            this.label6.TabIndex = 39;
            this.label6.Text = "P.Unitario";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(750, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 21);
            this.label5.TabIndex = 38;
            this.label5.Text = "Cantidad";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(750, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 21);
            this.label4.TabIndex = 37;
            this.label4.Text = "Unidad de Medida";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(750, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(750, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "Código ";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1268, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 33;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxCodigo.Location = new System.Drawing.Point(941, 206);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(300, 20);
            this.textBoxCodigo.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(461, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 32);
            this.label1.TabIndex = 31;
            this.label1.Text = "AGREGAR INVENTARIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTotal.Location = new System.Drawing.Point(941, 376);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(300, 20);
            this.textBoxTotal.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(750, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 21);
            this.label7.TabIndex = 47;
            this.label7.Text = "Total";
            // 
            // InventariodataGridView
            // 
            this.InventariodataGridView.AllowUserToAddRows = false;
            this.InventariodataGridView.AllowUserToDeleteRows = false;
            this.InventariodataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InventariodataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InventariodataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(155)))), ((int)(((byte)(153)))));
            this.InventariodataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InventariodataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InventariodataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InventariodataGridView.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.InventariodataGridView.Location = new System.Drawing.Point(25, 87);
            this.InventariodataGridView.Name = "InventariodataGridView";
            this.InventariodataGridView.ReadOnly = true;
            this.InventariodataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.InventariodataGridView.Size = new System.Drawing.Size(667, 431);
            this.InventariodataGridView.StandardTab = true;
            this.InventariodataGridView.TabIndex = 46;
            this.InventariodataGridView.TabStop = false;
            // 
            // errorCantidad
            // 
            this.errorCantidad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.errorCantidad.AutoSize = true;
            this.errorCantidad.ForeColor = System.Drawing.Color.DarkRed;
            this.errorCantidad.Location = new System.Drawing.Point(944, 328);
            this.errorCantidad.Name = "errorCantidad";
            this.errorCantidad.Size = new System.Drawing.Size(107, 13);
            this.errorCantidad.TabIndex = 89;
            this.errorCantidad.Text = "Ingrese solo números";
            this.errorCantidad.Visible = false;
            // 
            // errorPUni
            // 
            this.errorPUni.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.errorPUni.AutoSize = true;
            this.errorPUni.ForeColor = System.Drawing.Color.DarkRed;
            this.errorPUni.Location = new System.Drawing.Point(944, 362);
            this.errorPUni.Name = "errorPUni";
            this.errorPUni.Size = new System.Drawing.Size(120, 13);
            this.errorPUni.TabIndex = 90;
            this.errorPUni.Text = "Ingrese un monto valido";
            this.errorPUni.Visible = false;
            // 
            // MedidacomboBox
            // 
            this.MedidacomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MedidacomboBox.FormattingEnabled = true;
            this.MedidacomboBox.Location = new System.Drawing.Point(941, 273);
            this.MedidacomboBox.Name = "MedidacomboBox";
            this.MedidacomboBox.Size = new System.Drawing.Size(300, 21);
            this.MedidacomboBox.TabIndex = 91;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(1092, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 30);
            this.button1.TabIndex = 96;
            this.button1.Text = "REFRESCAR INVENTARIO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AgregarInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(200)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(1300, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MedidacomboBox);
            this.Controls.Add(this.errorPUni);
            this.Controls.Add(this.errorCantidad);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.textBoxPUnitario);
            this.Controls.Add(this.textBoxCantidad);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InventariodataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AgregarInventario";
            this.Text = "AgregarInventario";
            this.Load += new System.EventHandler(this.AgregarInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventariodataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox textBoxPUnitario;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView InventariodataGridView;
        private System.Windows.Forms.Label errorCantidad;
        private System.Windows.Forms.Label errorPUni;
        private System.Windows.Forms.ComboBox MedidacomboBox;
        private System.Windows.Forms.Button button1;
    }
}