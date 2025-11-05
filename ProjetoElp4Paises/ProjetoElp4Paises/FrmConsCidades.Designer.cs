namespace ProjetoElp4Paises
{
    partial class FrmConsCidades
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
            this.colCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDDD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCodigoEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ListV
            // 
            this.ListV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCidade,
            this.colDDD,
            this.colCodigoEstado,
            this.colEstado});
            // 
            // colCidade
            // 
            this.colCidade.Text = "Cidade";
            this.colCidade.Width = 200;
            // 
            // colDDD
            // 
            this.colDDD.Text = "DDD";
            // 
            // colCodigoEstado
            // 
            this.colCodigoEstado.Text = "Código Estado";
            this.colCodigoEstado.Width = 110;
            // 
            // colEstado
            // 
            this.colEstado.Text = "Estado";
            this.colEstado.Width = 200;
            // 
            // FrmConsCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FrmConsCidades";
            this.Text = "Consulta de Cidades";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colCidade;
        private System.Windows.Forms.ColumnHeader colDDD;
        private System.Windows.Forms.ColumnHeader colCodigoEstado;
        private System.Windows.Forms.ColumnHeader colEstado;
    }
}
