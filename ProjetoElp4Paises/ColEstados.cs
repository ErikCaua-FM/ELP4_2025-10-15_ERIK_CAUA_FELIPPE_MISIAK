using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class ColEstados:Colecoes<Estados>
    {
        public Estados BuscarPorUF(string uf)
        {
            foreach (var oestado in aLista)
            {
                if (oestado.UF.Equals(uf, StringComparison.OrdinalIgnoreCase))
                {
                    return oestado;
                }
            }
            return null;
        }
    }
}
