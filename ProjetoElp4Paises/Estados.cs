using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class Estados : Pai
    {
        protected string estado;
        protected string uf;
        protected Paises oPais;

        public Estados() : base()
        {
            estado = string.Empty;
            uf = string.Empty;
            oPais = new Paises();
        }

        public Estados(int codigo, DateTime datcad, DateTime ultalt, string estado, string uf, Paises oPais) : base(codigo, datcad, ultalt)
        {
            this.estado = estado;
            this.uf = uf;
            this.oPais = oPais;
        }

        public string Estado
        {
            get => estado;
            set => estado = value;
        }

        public string UF
        {
            get => uf;
            set => uf = value;
        }

        public Paises OPais
        {
            get => oPais;
            set => oPais = value;
        }

        public Estados Clone()
        {
            return new Estados(this.codigo, this.datcad, this.ultalt, this.estado, this.uf, this.oPais.Clone());
        }
    }
}
