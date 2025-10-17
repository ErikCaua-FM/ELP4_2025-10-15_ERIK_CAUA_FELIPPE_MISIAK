using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class frmConsEstados : ProjetoElp4Paises.frmConsultas
    {
        frmCadEstados oFrmCadEstados;
        Estados oEstado;
        CtrlEstados aCtrlEstados;
        public frmConsEstados()
        {
            InitializeComponent();       
        }

        protected override void Pesquisar()
        {
        }

        protected override void Incluir()
        {
            oFrmCadEstados.LimpaTxt();
            oFrmCadEstados.ConhecaObjeto(oEstado, aCtrlEstados);
            oFrmCadEstados.ShowDialog();
            this.CarregaLv();
        }

        protected override void Excluir()
        {
            string aux;
            oFrmCadEstados.ConhecaObjeto(oEstado, aCtrlEstados);
            oFrmCadEstados.LimpaTxt();
            oFrmCadEstados.CarregaTxt();
            oFrmCadEstados.BloquearTxt();
            aux = oFrmCadEstados.btnSalvar.Text;
            oFrmCadEstados.btnSalvar.Text = "Excluir";
            oFrmCadEstados.ShowDialog();
            oFrmCadEstados.DesbloquearTxt();
            oFrmCadEstados.btnSalvar.Text = aux;
            this.CarregaLv();
        }

        protected override void Alterar()
        {
            oFrmCadEstados.ConhecaObjeto(oEstado, aCtrlEstados);
            oFrmCadEstados.LimpaTxt();
            oFrmCadEstados.CarregaTxt();
            oFrmCadEstados.ShowDialog();
            this.CarregaLv();
        }

        protected override void CarregaLv()
        {
            ListV.Items.Clear();
            foreach(var oEstado in aCtrlEstados.TodosEstados())
            {
                ListViewItem item = new ListViewItem(Convert.ToString(oEstado.Codigo));
                item.SubItems.Add(oEstado.Estado);
                item.SubItems.Add(oEstado.UF);
                item.SubItems.Add(Convert.ToString(oEstado.OPais.Codigo));
                item.SubItems.Add(oEstado.OPais.Pais);
                ListV.Items.Add(item);
            }
        }

        public override void setFrmCadastro(object obj)
        {
            if (obj != null)
            {
                oFrmCadEstados = (frmCadEstados)obj;
            }
        }

        public override void ConhecaObjeto(object obj, object ctrl)
        {
            if (obj != null)
                oEstado = (Estados)obj;
            if (ctrl != null)
                aCtrlEstados = (CtrlEstados)ctrl;
        }
    }
}
