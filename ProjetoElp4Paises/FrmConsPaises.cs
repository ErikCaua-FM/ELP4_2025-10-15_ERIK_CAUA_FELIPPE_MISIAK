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
    public partial class FrmConsPaises : ProjetoElp4Paises.frmConsultas
    {
        frmCadPaises oFrmCadPaises;
        Paises oPais;
        CtrlPaises aCtrlPaises;
        public FrmConsPaises()
        {
            InitializeComponent();
        }

        protected override void Sair()
        {
            if (btnSair.Text == "Selecionar")
            {
                int chave = Convert.ToInt32(ListV.SelectedItems[0].SubItems[0].Text);
                oPais = (Paises)aCtrlPaises.CarregaObj(chave);
            }
            base.Sair();
        }
        protected override void Pesquisar()
        {
            this.CarregaLv(txtCodigo.Text);
        }

        protected override void Incluir()
        {
            oFrmCadPaises.LimpaTxt();
            oFrmCadPaises.ConhecaObjeto(oPais, aCtrlPaises);
            oFrmCadPaises.ShowDialog();
            this.CarregaLv("");
        }

        protected override void Excluir()
        {
            int chave = Convert.ToInt32(ListV.SelectedItems[0].SubItems[0].Text);
            oPais = (Paises)aCtrlPaises.CarregaObj(chave);
            string aux;
            oFrmCadPaises.ConhecaObjeto(oPais, aCtrlPaises);
            oFrmCadPaises.LimpaTxt();
            oFrmCadPaises.CarregaTxt();
            oFrmCadPaises.BloquearTxt();
            aux = oFrmCadPaises.btnSalvar.Text;
            oFrmCadPaises.btnSalvar.Text = "Excluir";
            oFrmCadPaises.ShowDialog();
            oFrmCadPaises.DesbloquearTxt();
            oFrmCadPaises.btnSalvar.Text = aux;
            this.CarregaLv("");
        }

        protected override void Alterar()
        {
            int chave = Convert.ToInt32(ListV.SelectedItems[0].SubItems[0].Text);
            oPais = (Paises)aCtrlPaises.CarregaObj(chave);
            oFrmCadPaises.ConhecaObjeto(oPais, aCtrlPaises);
            oFrmCadPaises.LimpaTxt();
            oFrmCadPaises.CarregaTxt();
            oFrmCadPaises.ShowDialog();
            this.CarregaLv("");
        }

        protected override void CarregaLv(string chave)
        {
            if (chave == string.Empty)
            {
                ListV.Items.Clear();
                foreach (var oPais in aCtrlPaises.TodosPaises())
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(oPais.Codigo));
                    item.SubItems.Add(oPais.Pais);
                    item.SubItems.Add(oPais.Sigla);
                    item.SubItems.Add(oPais.Ddi);
                    item.SubItems.Add(oPais.Moeda);
                    item.Tag = oPais;
                    ListV.Items.Add(item);
                }
            }
            else
            {
                ListV.Items.Clear();
                foreach (var oPais in aCtrlPaises.Pesquisar(chave).Cast<Paises>().ToList())
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(oPais.Codigo));
                    item.SubItems.Add(oPais.Pais);
                    item.SubItems.Add(oPais.Sigla);
                    item.SubItems.Add(oPais.Ddi);
                    item.SubItems.Add(oPais.Moeda);
                    ListV.Items.Add(item);
                }
            }
        }
        public override void setFrmCadastro(object obj)
        {
            if (obj != null)
            {
                oFrmCadPaises = (frmCadPaises)obj;
            }
        }

        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if(obj != null)
                oPais = (Paises)obj;
            if(ctrl != null)
                aCtrlPaises = (CtrlPaises)ctrl;
            this.Pesquisar();
        }

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ListV.SelectedItems.Count > 0)
            {
                ListViewItem item = this.ListV.SelectedItems[0];

                // Agora pegamos o país armazenado no Tag
                Paises paisSelecionado = (Paises)item.Tag;

                // Atualiza o objeto oPais passado pelo outro formulário
                oPais.Codigo = paisSelecionado.Codigo;
                oPais.Pais = paisSelecionado.Pais;
                oPais.Sigla = paisSelecionado.Sigla;
                oPais.Ddi = paisSelecionado.Ddi;
                oPais.Moeda = paisSelecionado.Moeda;
            }
        }
    } 
}
