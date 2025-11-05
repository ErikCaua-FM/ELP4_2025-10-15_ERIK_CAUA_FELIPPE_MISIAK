using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class Paises: Pai
    {
        protected string pais;
        protected string sigla;
        protected string ddi;
        protected string moeda;

        public Paises(): base()
        {
            pais = string.Empty;
            sigla = string.Empty;
            ddi = string.Empty; 
            moeda = string.Empty;
        }
        public Paises(int codigo, DateTime datcad, DateTime ultalt, string pais, string sigla, string ddi, string moeda) : base(codigo, datcad, ultalt)
        {
            this.pais = pais;
            this.sigla = sigla;
            this.ddi = ddi;
            this.moeda = moeda;
        }
        public string Pais
        {
            get => pais;
            set => pais = value;    
        }
        public string Sigla
        { 
            get => sigla;
            set => sigla = value;
        }
        public string Ddi
        { 
            get => ddi;
            set => ddi = value;
        }
        public string Moeda
        { 
            get => moeda;
            set => moeda = value;
        }

        public Paises Clone()
        {
            return new Paises(this.codigo, this.datcad, this.ultalt, this.pais, this.sigla, this.ddi, this.moeda);
        }
    }
}
