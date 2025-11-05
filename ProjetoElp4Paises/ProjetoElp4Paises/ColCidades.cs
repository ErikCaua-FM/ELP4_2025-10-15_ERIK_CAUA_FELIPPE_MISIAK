using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class ColCidades:Colecoes<Cidades>
    {
        public Cidades BuscaPorDDD(string ddd)
        {
            foreach(var cidade in aLista)
            {
                if (cidade.DDD.Equals(ddd, StringComparison.OrdinalIgnoreCase))
                {
                    return cidade;
                }
            }
            return null;
        }
    }
}
