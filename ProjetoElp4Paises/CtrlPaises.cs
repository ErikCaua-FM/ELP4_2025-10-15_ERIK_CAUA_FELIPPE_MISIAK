using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class CtrlPaises:Controller
    {
        protected ColPaises aColPaises;
        protected DaoPaises aDaoPaises;

        public CtrlPaises()
        {
            aColPaises = new ColPaises();
            aDaoPaises = new DaoPaises();
        }

        public override string Salvar(object obj)
        {
            return aDaoPaises.Salvar(obj);
            //base.Salvar(obj);
            /*Paises oPais = (Paises)obj;
            if (oPais.Codigo == 0)
            {
                oPais.Codigo = aColPaises.Tamanho() + 10;
                aColPaises.Inserir(oPais.Clone());
            }
            else
            {
                Paises oPaisProcurado = aColPaises.BuscarPorSigla(oPais.Sigla);

                int indice = aColPaises.Buscar(oPaisProcurado);

                aColPaises.Atualizar(indice, oPais);
            }*/
        }

        public override string Excluir(object obj)
        {
            return aDaoPaises.Excluir(obj);
            // base.Excluir(obj);
            /*Paises oPais = (Paises)obj;

            aColPaises.Remover(oPais);*/
        }

        public List<Paises> TodosPaises()
        {
            return aDaoPaises.Listar();
        }

        public override object CarregaObj(int chave)
        {
            return aDaoPaises.CarregaObj(chave);
        }

        public override List<Object> Pesquisar(string chave)
        {
            return aDaoPaises.Pesquisar(chave).Cast<object>().ToList();
        }
    }
}
