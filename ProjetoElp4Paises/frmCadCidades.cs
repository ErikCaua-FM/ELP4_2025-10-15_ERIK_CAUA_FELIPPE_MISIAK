using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class frmCadCidades : ProjetoElp4Paises.frmCadastros
    {
        Cidades aCidade;
        CtrlCidades aCtrlCidades;
        frmConsEstados oFrmConsEstados;
        public frmCadCidades()
        {
            InitializeComponent();
        }
        public override void Salvar()
        {
            //if (MessageDlg("Confirma (S/N)") == "S")
            {
                aCidade.Codigo = Convert.ToInt32(txtCodigo.Text);
                aCidade.Cidade = txtCidade.Text;
                aCidade.DDD = txtDDD.Text;
                aCidade.OEstado.Estado = txtEstado.Text;
                aCidade.OEstado.Codigo = Convert.ToInt32(txtCodigoEstado.Text);
                if(this.btnSalvar.Text == "&Salvar")
                    MessageBox.Show(aCtrlCidades.Salvar(aCidade.Clone()));
                else if(this.btnSalvar.Text == "Excluir")
                    MessageBox.Show(aCtrlCidades.Excluir(aCidade.Clone()));
            }
        }
        public override void CarregaTxt()
        {
            this.txtCodigo.Text = Convert.ToString(aCidade.Codigo);
            this.txtCidade.Text = aCidade.Cidade;
            this.txtDDD.Text = aCidade.DDD;
            this.txtEstado.Text = aCidade.OEstado.Estado;
            this.txtCodigoEstado.Text = Convert.ToString(aCidade.OEstado.Codigo);
        }
        public override void LimpaTxt()
        {
            this.txtCodigo.Text = "0";
            this.txtCidade.Clear();
            this.txtDDD.Clear();
            this.txtEstado.Clear();
            this.txtCodigoEstado.Text = "0";
        }
        public override void BloquearTxt()
        {
            this.btnBuscar.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.txtCodigoEstado.Enabled = false;
            this.txtCidade.Enabled = false;
            this.txtDDD.Enabled = false;
            this.txtEstado.Enabled = false;
        }

        public override void DesbloquearTxt()
        {
            this.btnBuscar.Enabled = true;
            this.txtCodigo.Enabled = true;
            this.txtCodigoEstado.Enabled = true;
            this.txtCidade.Enabled = true;
            this.txtDDD.Enabled = true;
            this.txtEstado.Enabled = true;
        }

        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if (obj != null)
                aCidade = (Cidades)obj;
            if (ctrl != null)
                aCtrlCidades = (CtrlCidades)ctrl;
        }

        public void setFrmConsEstados(Object obj)
        {
            if (obj != null)
            {
                oFrmConsEstados = (frmConsEstados)obj;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string obtnSair = oFrmConsEstados.btnSair.Text;
            oFrmConsEstados.btnSair.Text = "Selecionar";
            oFrmConsEstados.ConhecaObjeto(aCidade.OEstado, aCtrlCidades.ACtrlEstados);
            oFrmConsEstados.ShowDialog();
            this.txtCodigoEstado.Text = Convert.ToString(aCidade.OEstado.Codigo);
            this.txtEstado.Text = aCidade.OEstado.Estado.ToString();
            oFrmConsEstados.btnSair.Text = obtnSair;
        }
    }
}
