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

        protected override void Pesquisar()
        {
            if (txtCodigo.Text != string.Empty) 
            {
                ListV.Items.Clear();
                foreach (var oPais in aCtrlPaises.Pesquisar(txtCodigo.Text).Cast<Paises>().ToList())
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(oPais.Codigo));
                    item.SubItems.Add(oPais.Pais);
                    item.SubItems.Add(oPais.Sigla);
                    item.SubItems.Add(oPais.Ddi);
                    item.SubItems.Add(oPais.Moeda);
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
            oFrmCadPaises.LimpaTxt();
            oFrmCadPaises.ConhecaObjeto(oPais, aCtrlPaises);
            oFrmCadPaises.ShowDialog();
            this.CarregaLv();
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
            this.CarregaLv();
        }

        protected override void Alterar()
        {
            int chave = Convert.ToInt32(ListV.SelectedItems[0].SubItems[0].Text);
            oPais = (Paises)aCtrlPaises.CarregaObj(chave);
            oFrmCadPaises.ConhecaObjeto(oPais, aCtrlPaises);
            oFrmCadPaises.LimpaTxt();
            oFrmCadPaises.CarregaTxt();
            oFrmCadPaises.ShowDialog();
            this.CarregaLv();
        }

        protected override void CarregaLv()
        {
            ListV.Items.Clear();
            foreach (var oPais in aCtrlPaises.TodosPaises())
            {
                ListViewItem item = new ListViewItem(Convert.ToString(oPais.Codigo));
                item.SubItems.Add(oPais.Pais);
                item.SubItems.Add(oPais.Sigla);
                item.SubItems.Add(oPais.Ddi);
                item.SubItems.Add(oPais.Moeda);
                ListV.Items.Add(item);
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
        }

    } 
}
