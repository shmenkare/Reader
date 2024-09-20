namespace Reader
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsvLista = new System.Windows.Forms.ListView();
            this.dgvDep = new System.Windows.Forms.DataGridView();
            this.dgvInv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).BeginInit();
            this.SuspendLayout();
            // 
            // lsvLista
            // 
            this.lsvLista.Location = new System.Drawing.Point(12, 42);
            this.lsvLista.Name = "lsvLista";
            this.lsvLista.Size = new System.Drawing.Size(881, 301);
            this.lsvLista.TabIndex = 0;
            this.lsvLista.UseCompatibleStateImageBehavior = false;
            // 
            // dgvDep
            // 
            this.dgvDep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDep.Location = new System.Drawing.Point(12, 349);
            this.dgvDep.Name = "dgvDep";
            this.dgvDep.Size = new System.Drawing.Size(432, 188);
            this.dgvDep.TabIndex = 1;
            // 
            // dgvInv
            // 
            this.dgvInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInv.Location = new System.Drawing.Point(461, 349);
            this.dgvInv.Name = "dgvInv";
            this.dgvInv.Size = new System.Drawing.Size(432, 188);
            this.dgvInv.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 556);
            this.Controls.Add(this.dgvInv);
            this.Controls.Add(this.dgvDep);
            this.Controls.Add(this.lsvLista);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvLista;
        private System.Windows.Forms.DataGridView dgvDep;
        private System.Windows.Forms.DataGridView dgvInv;
    }
}

