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
            Estados oEstado = (Estados)obj;
            string mSql = $"delete from estados where id = @id";
            try
            {
                using (SqlCommand cmd = new SqlCommand(mSql, cnn))
                {
                    cmd.Parameters.AddWithValue("@id", oEstado.Codigo);
                    cmd.ExecuteNonQuery();
                }
                return $"Estado '{oEstado.Estado}' removido com sucesso!";
            }
            catch (Exception ex)
            {
                return $"ERRO: Estado '{oEstado.Estado}' vinculado a um ou mais cidades!";
            }
        }

        public override List<Estados> Listar()
        {
            string mSql = "select * from estados as e inner join paises as p on p.id = e.id_pais order by e.id ";
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<Estados> lista = new List<Estados>();
                while (reader.Read())
                {
                    Paises oPais = new Paises(
                        Convert.ToInt32(reader["id_pais"]),
                        Convert.ToDateTime(reader["datCad"]),
                        Convert.ToDateTime(reader["ultAlt"]),
                        reader["pais"].ToString(),
                        reader["sigla"].ToString(),
                        reader["ddi"].ToString(),
                        reader["moeda"].ToString()
                    );

                    Estados oEstado = new Estados(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToDateTime(reader["datCad"]),
                        Convert.ToDateTime(reader["ultAlt"]),
                        reader["Estado"].ToString(),
                        reader["UF"].ToString(),
                        oPais
                    );
                    lista.Add(oEstado);
                }
                reader.Close();
                return lista;
            }
        }

        public override Object CarregaObj(int chave)
        {
            string mSql = $"select * from estados as e inner join paises as p on p.id = e.id_pais where e.id = {chave} ";
            Estados oEstado = null;
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Paises oPais = new Paises(
                        Convert.ToInt32(reader["id_pais"]),
                        Convert.ToDateTime(reader["datCad"]),
                        Convert.ToDateTime(reader["ultAlt"]),
                        reader["pais"].ToString(),
                        reader["sigla"].ToString(),
                        reader["ddi"].ToString(),
                        reader["moeda"].ToString()
                    );

                    oEstado = new Estados(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToDateTime(reader["datCad"]),
                        Convert.ToDateTime(reader["ultAlt"]),
                        reader["Estado"].ToString(),
                        reader["UF"].ToString(),
                        oPais
                    );
                }
                reader.Close();
            }
            return oEstado;
        }

        public override List<Estados> Pesquisar(string chave)
        {
            string mSql = $"select * from estados as e inner join paises as p on p.id = e.id_pais where e.estado like '%{chave}%' or e.uf like '%{chave}%' or e.id like '%{chave}%' or e.id_pais like '%{chave}%' or p.pais like '%{chave}%'";
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<Estados> lista = new List<Estados>();
                while (reader.Read())
                {
                    Paises oPais = new Paises(
                        Convert.ToInt32(reader["id_pais"]),
                        Convert.ToDateTime(reader["datCad"]),
                        Convert.ToDateTime(reader["ultAlt"]),
                        reader["pais"].ToString(),
                        reader["sigla"].ToString(),
                        reader["ddi"].ToString(),
                        reader["moeda"].ToString()
                    );

                    Estados oEstado = new Estados(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToDateTime(reader["datCad"]),
                        Convert.ToDateTime(reader["ultAlt"]),
                        reader["Estado"].ToString(),
                        reader["UF"].ToString(),
                        oPais
                    );
                    //if(oEstado.Estado.Contains(chave) || oEstado.UF == chave || oEstado.OPais.Pais.Contains(chave))
                        lista.Add(oEstado);
                }
                reader.Close();
                return lista;
            }
        }
    }
}
