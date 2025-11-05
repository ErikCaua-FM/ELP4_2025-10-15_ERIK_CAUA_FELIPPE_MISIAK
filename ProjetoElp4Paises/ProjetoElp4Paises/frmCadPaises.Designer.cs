namespace ProjetoElp4Paises
{
    partial class frmCadPaises
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
            this.lblSigla = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblDDI = new System.Windows.Forms.Label();
            this.lblMoeda = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.txtSigla = new System.Windows.Forms.TextBox();
            this.txtMoeda = new System.Windows.Forms.TextBox();
            this.txtDDI = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.TabIndex = 4;
            // 
            // txtCodigo
            // 
            this.txtCodigo.MaxLength = 5;
            this.txtCodigo.TabIndex = 16;
            // 
            // btnSair
            // 
            this.btnSair.TabIndex = 5;
            // 
            // lblSigla
            // 
            this.lblSigla.AutoSize = true;
            this.lblSigla.Location = new System.Drawing.Point(332, 8);
            this.lblSigla.Name = "lblSigla";
            this.lblSigla.Size = new System.Drawing.Size(38, 16);
            this.lblSigla.TabIndex = 10;
            this.lblSigla.Text = "Sigla";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(87, 9);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(34, 16);
            this.lblPais.TabIndex = 11;
            this.lblPais.Text = "País";
            // 
            // lblDDI
            // 
            this.lblDDI.AutoSize = true;
            this.lblDDI.Location = new System.Drawing.Point(427, 8);
            this.lblDDI.Name = "lblDDI";
            this.lblDDI.Size = new System.Drawing.Size(30, 16);
            this.lblDDI.TabIndex = 12;
            this.lblDDI.Text = "DDI";
            // 
            // lblMoeda
            // 
            this.lblMoeda.AutoSize = true;
            this.lblMoeda.Location = new System.Drawing.Point(493, 8);
            this.lblMoeda.Name = "lblMoeda";
            this.lblMoeda.Size = new System.Drawing.Size(50, 16);
            this.lblMoeda.TabIndex = 13;
            this.lblMoeda.Text = "Moeda";
            // 
            // txtPais
            // 
            this.txtPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPais.Location = new System.Drawing.Point(90, 27);
            this.txtPais.MaxLength = 55;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(237, 22);
            this.txtPais.TabIndex = 0;
            // 
            // txtSigla
            // 
            this.txtSigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSigla.Location = new System.Drawing.Point(336, 27);
            this.txtSigla.MaxLength = 5;
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.Size = new System.Drawing.Size(85, 22);
            this.txtSigla.TabIndex = 1;
            // 
            // txtMoeda
            // 
            this.txtMoeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMoeda.Location = new System.Drawing.Point(496, 27);
            this.txtMoeda.MaxLength = 3;
            this.txtMoeda.Name = "txtMoeda";
            this.txtMoeda.Size = new System.Drawing.Size(51, 22);
            this.txtMoeda.TabIndex = 3;
            // 
            // txtDDI
            // 
            this.txtDDI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDDI.Location = new System.Drawing.Point(430, 27);
            this.txtDDI.MaxLength = 5;
            this.txtDDI.Name = "txtDDI";
            this.txtDDI.Size = new System.Drawing.Size(57, 22);
            this.txtDDI.TabIndex = 2;
            this.txtDDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmCadPaises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDDI);
            this.Controls.Add(this.txtMoeda);
            this.Controls.Add(this.txtSigla);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.lblMoeda);
            this.Controls.Add(this.lblDDI);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.lblSigla);
            this.Name = "frmCadPaises";
            this.Text = "Cadastro de Países";
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.btnSalvar, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.lblSigla, 0);
            this.Controls.SetChildIndex(this.lblPais, 0);
            this.Controls.SetChildIndex(this.lblDDI, 0);
            this.Controls.SetChildIndex(this.lblMoeda, 0);
            this.Controls.SetChildIndex(this.txtPais, 0);
            this.Controls.SetChildIndex(this.txtSigla, 0);
            this.Controls.SetChildIndex(this.txtMoeda, 0);
            this.Controls.SetChildIndex(this.txtDDI, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSigla;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblDDI;
        private System.Windows.Forms.Label lblMoeda;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.TextBox txtSigla;
        private System.Windows.Forms.TextBox txtMoeda;
        private System.Windows.Forms.TextBox txtDDI;
    }
}
