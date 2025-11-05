using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class ColPaises:Colecoes<Paises>
    {
        public Paises BuscarPorSigla(string sigla)
        {
            foreach (var opais in aLista)
            {
                if (opais.Sigla.Equals(sigla, StringComparison.OrdinalIgnoreCase))
                {
                    return opais;
                }
            }
            return null;
        }
    }
}
