﻿namespace CapaPresentacion.Cliente
{
    partial class DarAltaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DarAltaCliente));
            this.ClientedataGridView = new System.Windows.Forms.DataGridView();
            this.ClientecomboBox = new System.Windows.Forms.ComboBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClientedataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientedataGridView
            // 
            this.ClientedataGridView.AllowUserToAddRows = false;
            this.ClientedataGridView.AllowUserToDeleteRows = false;
            this.ClientedataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ClientedataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClientedataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(155)))), ((int)(((byte)(153)))));
            this.ClientedataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientedataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClientedataGridView.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientedataGridView.Location = new System.Drawing.Point(103, 161);
            this.ClientedataGridView.Name = "ClientedataGridView";
            this.ClientedataGridView.ReadOnly = true;
            this.ClientedataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ClientedataGridView.Size = new System.Drawing.Size(1087, 399);
            this.ClientedataGridView.StandardTab = true;
            this.ClientedataGridView.TabIndex = 17;
            this.ClientedataGridView.TabStop = false;
            // 
            // ClientecomboBox
            // 
            this.ClientecomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ClientecomboBox.FormattingEnabled = true;
            this.ClientecomboBox.Location = new System.Drawing.Point(839, 81);
            this.ClientecomboBox.Name = "ClientecomboBox";
            this.ClientecomboBox.Size = new System.Drawing.Size(200, 21);
            this.ClientecomboBox.TabIndex = 16;
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
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.Location = new System.Drawing.Point(207, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(613, 20);
            this.textBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(461, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "DAR DE ALTA A CLIENTE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.Location = new System.Drawing.Point(671, 123);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(108, 22);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(467, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 22);
            this.button1.TabIndex = 19;
            this.button1.Text = "DAR DE ALTA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DarAltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(200)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(1300, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ClientedataGridView);
            this.Controls.Add(this.ClientecomboBox);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DarAltaCliente";
            this.Text = "DarAltaCliente";
            this.Load += new System.EventHandler(this.DarAltaCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClientedataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ClientedataGridView;
        private System.Windows.Forms.ComboBox ClientecomboBox;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button button1;
    }
}