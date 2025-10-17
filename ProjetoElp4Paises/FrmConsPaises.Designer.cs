namespace ProjetoElp4Paises
{
    partial class FrmConsPaises
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
            this.colPais = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSigla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDDI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMoeda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ListV
            // 
            this.ListV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPais,
            this.colSigla,
            this.colDDI,
            this.colMoeda});
            // 
            // colPais
            // 
            this.colPais.Text = "País";
            this.colPais.Width = 200;
            // 
            // colSigla
            // 
            this.colSigla.Text = "Sigla";
            // 
            // colDDI
            // 
            this.colDDI.Text = "DDI";
            // 
            // colMoeda
            // 
            this.colMoeda.Text = "Moeda";
            // 
            // FrmConsPaises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FrmConsPaises";
            this.Text = "Consulta de Países";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colPais;
        private System.Windows.Forms.ColumnHeader colSigla;
        private System.Windows.Forms.ColumnHeader colDDI;
        private System.Windows.Forms.ColumnHeader colMoeda;
    }
}
