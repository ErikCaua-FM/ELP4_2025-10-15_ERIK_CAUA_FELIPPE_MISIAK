using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class Cidades : Pai
    {
        protected string cidade;
        protected string ddd;
        protected Estados oEstado;

        public Cidades()
        {
            cidade = string.Empty;
            ddd = string.Empty;
            oEstado = new Estados();
        }

        public Cidades(int codigo, DateTime datcad, DateTime ultalt, string cidade, string ddd, Estados oEstado) : base(codigo, datcad, ultalt)
        {
            this.cidade = cidade;
            this.ddd = ddd;
            this.oEstado = oEstado;
        }

        public string Cidade
        {
            get => cidade;
            set => cidade = value;
        }

        public string DDD
        {
            get => ddd;
            set => ddd = value;
        }

        public Estados OEstado
        {
            get => oEstado;
            set => oEstado = value;
        }

        public Cidades Clone()
        {
            return new Cidades(this.codigo, this.datcad, this.ultalt, this.cidade, this.ddd, this.oEstado.Clone());
        }
    }
}
