﻿namespace Principal
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "DialogoCarga";
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.Location = new System.Drawing.Point(31, 12);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(78, 23);
            this.btnCargarArchivo.TabIndex = 0;
            this.btnCargarArchivo.Text = "Cargar Archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Enabled = false;
            this.txtRutaArchivo.Location = new System.Drawing.Point(31, 52);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(1036, 20);
            this.txtRutaArchivo.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1036, 330);
            this.dataGridView1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 444);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.btnCargarArchivo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

