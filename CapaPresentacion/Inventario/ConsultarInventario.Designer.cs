namespace CapaPresentacion.Inventario
{
    partial class ConsultarInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarInventario));
            this.InventariodataGridView = new System.Windows.Forms.DataGridView();
            this.InventariocomboBox = new System.Windows.Forms.ComboBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.InventariotextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InventariodataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
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
            this.InventariodataGridView.Location = new System.Drawing.Point(103, 161);
            this.InventariodataGridView.Name = "InventariodataGridView";
            this.InventariodataGridView.ReadOnly = true;
            this.InventariodataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InventariodataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.InventariodataGridView.Size = new System.Drawing.Size(1087, 399);
            this.InventariodataGridView.StandardTab = true;
            this.InventariodataGridView.TabIndex = 17;
            this.InventariodataGridView.TabStop = false;
            // 
            // InventariocomboBox
            // 
            this.InventariocomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InventariocomboBox.FormattingEnabled = true;
            this.InventariocomboBox.Location = new System.Drawing.Point(839, 81);
            this.InventariocomboBox.Name = "InventariocomboBox";
            this.InventariocomboBox.Size = new System.Drawing.Size(200, 21);
            this.InventariocomboBox.TabIndex = 16;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1268, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 15;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // InventariotextBox
            // 
            this.InventariotextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InventariotextBox.Location = new System.Drawing.Point(207, 82);
            this.InventariotextBox.Name = "InventariotextBox";
            this.InventariotextBox.Size = new System.Drawing.Size(613, 20);
            this.InventariotextBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(461, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "CONSULTAR INVENTARIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.Location = new System.Drawing.Point(554, 123);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(108, 22);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ConsultarInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(200)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(1300, 600);
            this.Controls.Add(this.InventariodataGridView);
            this.Controls.Add(this.InventariocomboBox);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.InventariotextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsultarInventario";
            this.Text = "ConsultarInventario";
            this.Load += new System.EventHandler(this.ConsultarInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InventariodataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView InventariodataGridView;
        private System.Windows.Forms.ComboBox InventariocomboBox;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.TextBox InventariotextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
    }
}