using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class CtrlEstados:Controller
    {
        protected ColEstados aColEstados;
        protected CtrlPaises aCtrlPaises;
        protected DaoEstados aDaoEstados;

        public CtrlEstados()
        {
            aColEstados = new ColEstados();
            aDaoEstados = new DaoEstados();
        }

        public CtrlPaises ACtrlPaises
        {
            get => aCtrlPaises;
            set => aCtrlPaises = value;
        }
        public override string Salvar(object obj)
        {
            return aDaoEstados.Salvar(obj);
            //base.Salvar(obj);
            /*Estados oEstado = (Estados)obj;
            if (oEstado.Codigo == 0)
            {
                oEstado.Codigo = aColEstados.Tamanho() + 100;
                aColEstados.Inserir(oEstado.Clone());
            }
            else
            {
                Estados oEstadoProcurado = aColEstados.BuscarPorUF(oEstado.UF);

                int indice = aColEstados.Buscar(oEstadoProcurado);

                aColEstados.Atualizar(indice, oEstado);
            }*/
        }

        public override string Excluir(object obj)
        {
            return aDaoEstados.Excluir(obj);
            //base.Excluir(obj);

            //Estados oEstado = (Estados)obj;

            //aColEstados.Remover(oEstado);
        }

        public List<Estados> TodosEstados()
        {
            return aDaoEstados.Listar();
        }
    }
}
