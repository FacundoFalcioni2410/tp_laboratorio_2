﻿namespace WindowsForms
{
    partial class FrmDatos
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnGuardarTexto = new System.Windows.Forms.Button();
            this.btnLeerTexto = new System.Windows.Forms.Button();
            this.btnGuardarXml = new System.Windows.Forms.Button();
            this.labelInforma = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(54, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(590, 315);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(675, 314);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 57);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(253, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "HISTORIAL DE VENTAS";
            // 
            // btnAlta
            // 
            this.btnAlta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlta.Location = new System.Drawing.Point(675, 239);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(101, 48);
            this.btnAlta.TabIndex = 3;
            this.btnAlta.Text = "AGREGAR UNA VENTA";
            this.btnAlta.UseVisualStyleBackColor = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnGuardarTexto
            // 
            this.btnGuardarTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnGuardarTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarTexto.Location = new System.Drawing.Point(675, 56);
            this.btnGuardarTexto.Name = "btnGuardarTexto";
            this.btnGuardarTexto.Size = new System.Drawing.Size(101, 41);
            this.btnGuardarTexto.TabIndex = 4;
            this.btnGuardarTexto.Text = "Guardar datos";
            this.btnGuardarTexto.UseVisualStyleBackColor = false;
            this.btnGuardarTexto.Click += new System.EventHandler(this.btnGuardarTexto_Click);
            // 
            // btnLeerTexto
            // 
            this.btnLeerTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnLeerTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeerTexto.Location = new System.Drawing.Point(675, 103);
            this.btnLeerTexto.Name = "btnLeerTexto";
            this.btnLeerTexto.Size = new System.Drawing.Size(101, 47);
            this.btnLeerTexto.TabIndex = 5;
            this.btnLeerTexto.Text = "Leer datos";
            this.btnLeerTexto.UseVisualStyleBackColor = false;
            this.btnLeerTexto.Click += new System.EventHandler(this.btnLeerTexto_Click);
            // 
            // btnGuardarXml
            // 
            this.btnGuardarXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnGuardarXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarXml.Location = new System.Drawing.Point(675, 156);
            this.btnGuardarXml.Name = "btnGuardarXml";
            this.btnGuardarXml.Size = new System.Drawing.Size(101, 47);
            this.btnGuardarXml.TabIndex = 7;
            this.btnGuardarXml.Text = "Guardar archivo xml";
            this.btnGuardarXml.UseVisualStyleBackColor = false;
            this.btnGuardarXml.Click += new System.EventHandler(this.btnGuardarXml_Click);
            // 
            // labelInforma
            // 
            this.labelInforma.Location = new System.Drawing.Point(51, 374);
            this.labelInforma.Name = "labelInforma";
            this.labelInforma.Size = new System.Drawing.Size(265, 57);
            this.labelInforma.TabIndex = 8;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(675, 384);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(101, 47);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // FrmDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.labelInforma);
            this.Controls.Add(this.btnGuardarXml);
            this.Controls.Add(this.btnLeerTexto);
            this.Controls.Add(this.btnGuardarTexto);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FrmDatos";
            this.Text = "VENTAS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDatos_FormClosing);
            this.Load += new System.EventHandler(this.fmrDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnGuardarTexto;
        private System.Windows.Forms.Button btnLeerTexto;
        private System.Windows.Forms.Button btnGuardarXml;
        private System.Windows.Forms.Label labelInforma;
        private System.Windows.Forms.Button btnSalir;
    }
}

