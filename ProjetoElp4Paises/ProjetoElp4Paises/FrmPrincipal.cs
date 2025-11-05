using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoElp4Paises
{
    public partial class FrmPrincipal : Form
    {

        Interfaces aInter = new Interfaces();
        Paises oPais = new Paises();
        Estados oEstado = new Estados();
        Cidades aCidade = new Cidades();
        CtrlCidades aCtrlCidades = new CtrlCidades();
        CtrlPaises aCtrlPaises = new CtrlPaises();
        CtrlEstados aCtrlEstados = new CtrlEstados();
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void paísesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.PecaPaises(oPais, aCtrlPaises);
        }

        private void estadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.PecaEstados(oEstado, aCtrlEstados);
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.PecaCidades(aCidade, aCtrlCidades);
        }
    }
}
