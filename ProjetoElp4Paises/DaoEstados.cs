using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class DaoEstados:DAO<Estados>
    {
        public override string Salvar(object obj)
        {
            Estados oEstado = (Estados)obj;
            string mSql = "", mOk = "";

            if (oEstado.Codigo == 0)
            {
                mSql = "insert into estados (Estado, UF, datCad, ultAlt, id_pais) values (@estado, @uf, @datcad, @ultalt, @idPais)";

            }
            else
            {
                mSql = "update estados set estado = @estado, uf = @uf,datcad = @datcad, ultalt = @ultalt, id_pais = @idPais where id = @codigo";
            }
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                cmd.Parameters.AddWithValue("@estado", oEstado.Estado);
                cmd.Parameters.AddWithValue("@uf", oEstado.UF);
                cmd.Parameters.AddWithValue("@datcad", oEstado.DatCad);
                cmd.Parameters.AddWithValue("@ultalt", oEstado.UltAlt);
                cmd.Parameters.AddWithValue("@codigo", oEstado.Codigo);
                cmd.Parameters.AddWithValue("@idPais", oEstado.OPais.Codigo);
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

        public override List<Estados> Listar()
        {
            string mSql = "select * from estados as e order by id inner join paises as p on p.id = e.id_pais";
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<Estados> lista = new List<Estados>();
                while (reader.Read())
                {
                    Estados oEstado = new Estados(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToDateTime(reader["datCad"]),
                        Convert.ToDateTime(reader["ultAlt"]),
                        reader["Estado"].ToString(),
                        reader["UF"].ToString(),
                        //reader["id_pais"].ToString()
                    );
                    lista.Add(oEstado);
                }
                reader.Close();
                return lista;
            }
        }

        public override Object CarregaObj(int chave)
        {
            return null;
        }

        public override List<Estados> Pesquisar(string chave)
        {
            return null;
        }
    }
}
