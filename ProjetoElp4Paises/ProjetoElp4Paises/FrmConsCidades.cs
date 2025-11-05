using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class FrmConsCidades : ProjetoElp4Paises.frmConsultas
    {
        frmCadCidades oFrmCadCidades;
        Cidades aCidade;
        CtrlCidades aCtrlCidades;
        public FrmConsCidades()
        {
            InitializeComponent();
        }

        protected override void Pesquisar()
        {
            if (txtCodigo.Text != string.Empty)
            {
                ListV.Items.Clear();
                foreach (var aCidade in aCtrlCidades.Pesquisar(txtCodigo.Text).Cast<Cidades>().ToList())
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(aCidade.Codigo));
                    item.SubItems.Add(aCidade.Cidade);
                    item.SubItems.Add(aCidade.DDD);
                    item.SubItems.Add(aCidade.OEstado.Codigo.ToString());
                    item.SubItems.Add(aCidade.OEstado.Estado);
                    ListV.Items.Add(item);
                }
            }
            else
            {
                this.CarregaLv();
            }
        }

        protected override void Incluir()
        {
            oFrmCadCidades.LimpaTxt();
            oFrmCadCidades.ConhecaObjeto(aCidade, aCtrlCidades);
            oFrmCadCidades.ShowDialog();
            this.CarregaLv();
        }

        protected override void Excluir()
        {
            int chave = Convert.ToInt32(ListV.SelectedItems[0].SubItems[0].Text);
            aCidade = (Cidades)aCtrlCidades.CarregaObj(chave);
            string aux;
            oFrmCadCidades.ConhecaObjeto(aCidade, aCtrlCidades);
            oFrmCadCidades.LimpaTxt();
            oFrmCadCidades.CarregaTxt();
            oFrmCadCidades.BloquearTxt();
            aux = oFrmCadCidades.btnSalvar.Text;
            oFrmCadCidades.btnSalvar.Text = "Excluir";
            oFrmCadCidades.ShowDialog();
            oFrmCadCidades.DesbloquearTxt();
            oFrmCadCidades.btnSalvar.Text = aux;
            this.CarregaLv();
        }

        protected override void Alterar()
        {
            int chave = Convert.ToInt32(ListV.SelectedItems[0].SubItems[0].Text);
            aCidade = (Cidades)aCtrlCidades.CarregaObj(chave);
            oFrmCadCidades.ConhecaObjeto(aCidade, aCtrlCidades);
            oFrmCadCidades.LimpaTxt();
            oFrmCadCidades.CarregaTxt();
            oFrmCadCidades.ShowDialog();
            this.CarregaLv();
        }

        protected override void CarregaLv()
        {
            ListV.Items.Clear();
            foreach(var aCidade in aCtrlCidades.TodasCidades())
            {
                ListViewItem item = new ListViewItem(Convert.ToString(aCidade.Codigo));
                item.SubItems.Add(aCidade.Cidade);
                item.SubItems.Add(aCidade.DDD);
                item.SubItems.Add(aCidade.OEstado.Codigo.ToString());
                item.SubItems.Add(aCidade.OEstado.Estado);
                ListV.Items.Add(item);
            }
        }

        public override void setFrmCadastro(object obj)
        {
            if (obj != null)
            {
                oFrmCadCidades = (frmCadCidades)obj;
            }
        }

        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if (obj != null)
                aCidade = (Cidades)obj;
            if (ctrl != null)
                aCtrlCidades = (CtrlCidades)ctrl;
        }

    }
}
