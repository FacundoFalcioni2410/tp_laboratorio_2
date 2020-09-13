namespace MiCalculadora
{
    partial class FormCalculadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalculadora));
            this.BtnOperar = new System.Windows.Forms.Button();
            this.comboOperador = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.BtnDecimalABinario = new System.Windows.Forms.Button();
            this.BtnBinarioADecimal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnOperar
            // 
            this.BtnOperar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnOperar.Location = new System.Drawing.Point(96, 198);
            this.BtnOperar.Name = "BtnOperar";
            this.BtnOperar.Size = new System.Drawing.Size(168, 71);
            this.BtnOperar.TabIndex = 4;
            this.BtnOperar.Text = "Operar";
            this.BtnOperar.UseVisualStyleBackColor = false;
            this.BtnOperar.Click += new System.EventHandler(this.BtnOperar_Click);
            // 
            // comboOperador
            // 
            this.comboOperador.BackColor = System.Drawing.Color.White;
            this.comboOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboOperador.FormattingEnabled = true;
            this.comboOperador.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.comboOperador.Location = new System.Drawing.Point(327, 122);
            this.comboOperador.Name = "comboOperador";
            this.comboOperador.Size = new System.Drawing.Size(164, 28);
            this.comboOperador.TabIndex = 1;
            this.comboOperador.Text = "Operador";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(96, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 26);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(551, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(168, 26);
            this.textBox2.TabIndex = 2;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnLimpiar.Location = new System.Drawing.Point(327, 198);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(168, 71);
            this.BtnLimpiar.TabIndex = 5;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnCerrar.Location = new System.Drawing.Point(551, 198);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(168, 71);
            this.BtnCerrar.TabIndex = 6;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // BtnDecimalABinario
            // 
            this.BtnDecimalABinario.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnDecimalABinario.Location = new System.Drawing.Point(96, 293);
            this.BtnDecimalABinario.Name = "BtnDecimalABinario";
            this.BtnDecimalABinario.Size = new System.Drawing.Size(285, 71);
            this.BtnDecimalABinario.TabIndex = 7;
            this.BtnDecimalABinario.Text = "Convertir a binario";
            this.BtnDecimalABinario.UseVisualStyleBackColor = false;
            this.BtnDecimalABinario.Click += new System.EventHandler(this.BtnDecimalABinario_Click);
            // 
            // BtnBinarioADecimal
            // 
            this.BtnBinarioADecimal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnBinarioADecimal.Location = new System.Drawing.Point(434, 293);
            this.BtnBinarioADecimal.Name = "BtnBinarioADecimal";
            this.BtnBinarioADecimal.Size = new System.Drawing.Size(285, 71);
            this.BtnBinarioADecimal.TabIndex = 8;
            this.BtnBinarioADecimal.Text = "Convertir a decimal";
            this.BtnBinarioADecimal.UseVisualStyleBackColor = false;
            this.BtnBinarioADecimal.Click += new System.EventHandler(this.BtnBinarioADecimal_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(623, 66);
            this.label1.TabIndex = 3;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnBinarioADecimal);
            this.Controls.Add(this.BtnDecimalABinario);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboOperador);
            this.Controls.Add(this.BtnOperar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Facundo Falcioni Division 2°A";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOperar;
        private System.Windows.Forms.ComboBox comboOperador;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Button BtnDecimalABinario;
        private System.Windows.Forms.Button BtnBinarioADecimal;
        private System.Windows.Forms.Label label1;
    }
}

