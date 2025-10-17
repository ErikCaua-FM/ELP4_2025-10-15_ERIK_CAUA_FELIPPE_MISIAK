using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class DaoPaises:DAO<Paises>
    {
        public override string Salvar(object obj)
        {
            Paises oPais = (Paises)obj;
            string mSql = "", mOk = "";

            if(oPais.Codigo == 0)
            {
                mSql = "insert into paises (Pais, Sigla, DDI, Moeda, datCad, ultAlt) values (@pais, @sigla, @ddi, @moeda, @datcad, @ultalt)";

            }
            else
            {
                mSql = "update paises set pais = @pais, sigla = @sigla, ddi = @ddi, moeda = @moeda, datcad = @datcad, ultalt = @ultalt where id = @codigo";
            }
            using(SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                cmd.Parameters.AddWithValue("@pais", oPais.Pais);
                cmd.Parameters.AddWithValue("@sigla", oPais.Sigla);
                cmd.Parameters.AddWithValue("@ddi", oPais.Ddi);
                cmd.Parameters.AddWithValue("@moeda", oPais.Moeda);
                cmd.Parameters.AddWithValue("@datcad", oPais.DatCad);
                cmd.Parameters.AddWithValue("@ultalt", oPais.UltAlt);
                cmd.Parameters.AddWithValue("@codigo", oPais.Codigo);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT @@IDENTITY";
                mOk = cmd.ExecuteScalar().ToString();
            }
            return mOk;
        }

        public override string Excluir(object obj)
        {
            return "";
        }

        public override List<Paises> Listar()
        {
            string mSql = "select * from paises order by id";
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<Paises> lista = new List<Paises>();
                while (reader.Read())
                {
                    Paises oPais = new Paises(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToDateTime(reader["datCad"]),
                        Convert.ToDateTime(reader["ultAlt"]),
                        reader["Pais"].ToString(),
                        reader["Sigla"].ToString(),
                        reader["DDI"].ToString(),
                        reader["Moeda"].ToString()
                    );
                    lista.Add(oPais);
                }
                reader.Close();
                return lista;
            }
        }

        public override Object CarregaObj(int chave)
        {
            return null;
        }

        public override List<Paises> Pesquisar(string chave)
        {
            return null;
        }
    }
}
