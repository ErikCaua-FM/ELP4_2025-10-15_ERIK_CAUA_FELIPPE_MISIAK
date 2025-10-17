using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class Controller
    {
        public Controller()
        {

        }

        public virtual string Salvar(object obj)
        {
            return "";
        }

        public virtual string Excluir(object obj)
        {
            return "";
        }

        public virtual List<Object> Listar()
        {
            return null;
        }

        public virtual Object CarregaObj(int chave)
        {
            return null;
        }

        public virtual List<Object> Pesquisar(string chave)
        {
            return null;
        }

    }
}
