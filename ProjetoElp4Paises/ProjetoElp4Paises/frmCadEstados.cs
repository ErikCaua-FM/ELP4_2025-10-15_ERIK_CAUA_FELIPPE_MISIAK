using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class frmCadEstados : ProjetoElp4Paises.frmCadastros
    {
        Estados oEstado;
        CtrlEstados aCtrlEstados;
        FrmConsPaises oFrmConsPaises;
        public frmCadEstados()
        {
            InitializeComponent();
        }

        public override void Salvar()
        {
            //if (MessageDlg("Confirma (S/N)") == "S")
            {
                oEstado.Codigo = Convert.ToInt32(txtCodigo.Text);
                oEstado.Estado = txtEstado.Text;
                oEstado.UF = txtUF.Text;
                oEstado.OPais.Pais = txtPais.Text;
                oEstado.OPais.Codigo = Convert.ToInt32(txtCodigoPais.Text);
                if(this.btnSalvar.Text == "&Salvar")
                    MessageBox.Show(aCtrlEstados.Salvar(oEstado.Clone()));
                else if(this.btnSalvar.Text == "Excluir")
                    MessageBox.Show(aCtrlEstados.Excluir(oEstado.Clone()));
            }
        }

        public override void CarregaTxt()
        {
            this.txtCodigo.Text = Convert.ToString(oEstado.Codigo);
            this.txtEstado.Text = oEstado.Estado;
            this.txtUF.Text = oEstado.UF;
            this.txtPais.Text = oEstado.OPais.Pais;
            this.txtCodigoPais.Text = Convert.ToString(oEstado.OPais.Codigo);
        }

        public override void LimpaTxt()
        {
            this.txtCodigo.Text = "0";
            this.txtEstado.Clear();
            this.txtUF.Clear();
            this.txtPais.Clear();
            this.txtCodigoPais.Text = "0";
        }

        public override void BloquearTxt()
        {
            this.txtCodigo.Enabled = false;
            this.txtCodigoPais.Enabled = false;
            this.txtEstado.Enabled = false;
            this.txtUF.Enabled = false;
            this.txtPais.Enabled = false;
            this.btnBuscar.Enabled = false;
        }

        public override void DesbloquearTxt()
        {
            this.btnBuscar.Enabled = true;
            this.txtCodigo.Enabled = true;
            this.txtCodigoPais.Enabled = true;
            this.txtEstado.Enabled = true;
            this.txtUF.Enabled = true;
            this.txtPais.Enabled = true;
        }

        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if (obj != null)
                oEstado = (Estados)obj;
            if (ctrl != null)
                aCtrlEstados = (CtrlEstados)ctrl;
        }

        public void setFrmConsPaises(object obj)
        {
            if (obj != null)
            {
                oFrmConsPaises = (FrmConsPaises)obj;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string obtnSair = oFrmConsPaises.btnSair.Text;
            oFrmConsPaises.btnSair.Text = "Selecionar";
            oFrmConsPaises.ConhecaObjeto(oEstado.OPais, aCtrlEstados.ACtrlPaises);
            oFrmConsPaises.ShowDialog();
            this.txtCodigoPais.Text = Convert.ToString(oEstado.OPais.Codigo);
            this.txtPais.Text = oEstado.OPais.Pais.ToString();
            oFrmConsPaises.btnSair.Text = obtnSair;
        }
    }
}
