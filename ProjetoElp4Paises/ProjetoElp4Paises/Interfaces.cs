using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class Interfaces
    {
        FrmConsPaises oFrmConsPaises;
        frmConsEstados oFrmConsEstados;
        FrmConsCidades oFrmConsCidades;
        frmCadPaises oFrmCadPaises;
        frmCadEstados oFrmCadEstados;
        frmCadCidades oFrmCadCidades;

        public Interfaces()
        {
            oFrmConsPaises = new FrmConsPaises();
            oFrmConsEstados = new frmConsEstados();
            oFrmConsCidades = new FrmConsCidades();

            oFrmCadPaises = new frmCadPaises();
            oFrmCadEstados = new frmCadEstados();
            oFrmCadCidades = new frmCadCidades();

            oFrmConsPaises.setFrmCadastro(oFrmCadPaises);
            oFrmConsEstados.setFrmCadastro(oFrmCadEstados);
            oFrmConsCidades.setFrmCadastro(oFrmCadCidades);

            oFrmCadEstados.setFrmConsPaises(oFrmConsPaises);
            oFrmCadCidades.setFrmConsEstados(oFrmConsEstados);
        }

        public void PecaPaises(object obj, object ctrl)
        {
            oFrmConsPaises.ConhecaObjeto(obj, ctrl);
            oFrmConsPaises.ShowDialog();
        }

        public void PecaEstados(object obj, object ctrl)
        {
            oFrmConsEstados.ConhecaObjeto(obj, ctrl);
            oFrmConsEstados.ShowDialog();
        }

        public void PecaCidades(object obj, object ctrl)
        {
            oFrmConsCidades.ConhecaObjeto(obj, ctrl);
            oFrmConsCidades.ShowDialog();
        }
    }
}
