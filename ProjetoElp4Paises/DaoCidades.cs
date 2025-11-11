using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class DaoCidades:DAO<Cidades>
    {
        public override string Salvar(object obj)
        {
            Cidades aCidade = (Cidades)obj;
            string mSql = "", mOk = "";

            if (aCidade.Codigo == 0)
            {
                mSql = "insert into cidades (Cidade, DDD, datCad, ultAlt, id_estado) values (@cidade, @ddd, @datcad, @ultalt, @idEstado)";

            }
            else
            {
                mSql = "update cidades set cidade = @cidade, ddd = @ddd, datcad = @datcad, ultalt = @ultalt, id_estado = @idEstado where id = @codigo";
            }
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                cmd.Parameters.AddWithValue("@cidade", aCidade.Cidade);
                cmd.Parameters.AddWithValue("@ddd", aCidade.DDD);
                cmd.Parameters.AddWithValue("@datcad", aCidade.DatCad);
                cmd.Parameters.AddWithValue("@ultalt", aCidade.UltAlt);
                cmd.Parameters.AddWithValue("@codigo", aCidade.Codigo);
                cmd.Parameters.AddWithValue("@idEstado", aCidade.OEstado.Codigo);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT @@IDENTITY";
                mOk = cmd.ExecuteScalar().ToString();
            }
            return mOk;
        }

        public override string Excluir(object obj)
        {
            Cidades aCidade = (Cidades)obj;
            string mSql = $"delete from cidades where id = @id";
            try
            {
                using (SqlCommand cmd = new SqlCommand(mSql, cnn))
                {
                    cmd.Parameters.AddWithValue("@id", aCidade.Codigo);
                    cmd.ExecuteNonQuery();
                }
                return $"Cidade '{aCidade.Cidade}' removido com sucesso!";
            }
            catch (Exception ex)
            {
                return $"ERRO: {ex.Message}";
            }
        }

        public override List<Cidades> Listar()
        {
            string mSql = @"
        SELECT 
            c.id AS cidade_id, 
            c.datCad AS cidade_datCad, 
            c.ultAlt AS cidade_ultAlt, 
            c.Cidade, 
            c.ddd,
            e.id AS estado_id, 
            e.datCad AS estado_datCad, 
            e.ultAlt AS estado_ultAlt, 
            e.Estado, 
            e.UF,
            p.id AS pais_id, 
            p.datCad AS pais_datCad, 
            p.ultAlt AS pais_ultAlt, 
            p.pais, 
            p.sigla, 
            p.ddi, 
            p.moeda
        FROM cidades AS c
        INNER JOIN estados AS e ON e.id = c.id_estado
        INNER JOIN paises AS p ON p.id = e.id_pais
        ORDER BY c.id";

            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<Cidades> lista = new List<Cidades>();

                while (reader.Read())
                {
                    Paises oPais = new Paises(
                        Convert.ToInt32(reader["pais_id"]),
                        Convert.ToDateTime(reader["pais_datCad"]),
                        Convert.ToDateTime(reader["pais_ultAlt"]),
                        reader["pais"].ToString(),
                        reader["sigla"].ToString(),
                        reader["ddi"].ToString(),
                        reader["moeda"].ToString()
                    );

                    Estados oEstado = new Estados(
                        Convert.ToInt32(reader["estado_id"]),
                        Convert.ToDateTime(reader["estado_datCad"]),
                        Convert.ToDateTime(reader["estado_ultAlt"]),
                        reader["Estado"].ToString(),
                        reader["UF"].ToString(),
                        oPais
                    );

                    Cidades aCidade = new Cidades(
                        Convert.ToInt32(reader["cidade_id"]),
                        Convert.ToDateTime(reader["cidade_datCad"]),
                        Convert.ToDateTime(reader["cidade_ultAlt"]),
                        reader["Cidade"].ToString(),
                        reader["ddd"].ToString(),
                        oEstado
                    );

                    lista.Add(aCidade);
                }

                reader.Close();
                return lista;
            }
        }

        public override Object CarregaObj(int chave)
        {
            string mSql = $@"SELECT 
            c.id AS cidade_id, 
            c.datCad AS cidade_datCad, 
            c.ultAlt AS cidade_ultAlt, 
            c.Cidade, 
            c.ddd,
            e.id AS estado_id, 
            e.datCad AS estado_datCad, 
            e.ultAlt AS estado_ultAlt, 
            e.Estado, 
            e.UF,
            p.id AS pais_id, 
            p.datCad AS pais_datCad, 
            p.ultAlt AS pais_ultAlt, 
            p.pais, 
            p.sigla, 
            p.ddi, 
            p.moeda
        FROM cidades AS c
        INNER JOIN estados AS e ON e.id = c.id_estado
        INNER JOIN paises AS p ON p.id = e.id_pais
        WHERE c.id = {chave}";
            Cidades aCidade = null;
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Paises oPais = new Paises(
                        Convert.ToInt32(reader["pais_id"]),
                        Convert.ToDateTime(reader["pais_datCad"]),
                        Convert.ToDateTime(reader["pais_ultAlt"]),
                        reader["pais"].ToString(),
                        reader["sigla"].ToString(),
                        reader["ddi"].ToString(),
                        reader["moeda"].ToString()
                    );

                    Estados oEstado = new Estados(
                        Convert.ToInt32(reader["estado_id"]),
                        Convert.ToDateTime(reader["estado_datCad"]),
                        Convert.ToDateTime(reader["estado_ultAlt"]),
                        reader["Estado"].ToString(),
                        reader["UF"].ToString(),
                        oPais
                    );

                    aCidade = new Cidades(
                        Convert.ToInt32(reader["cidade_id"]),
                        Convert.ToDateTime(reader["cidade_datCad"]),
                        Convert.ToDateTime(reader["cidade_ultAlt"]),
                        reader["Cidade"].ToString(),
                        reader["ddd"].ToString(),
                        oEstado
                    );
                }
                reader.Close();
            }
            return aCidade;
        }

        public override List<Cidades> Pesquisar(string chave)
        {
            string mSql = $@"
        SELECT 
            c.id AS cidade_id, 
            c.datCad AS cidade_datCad, 
            c.ultAlt AS cidade_ultAlt, 
            c.Cidade, 
            c.ddd,
            e.id AS estado_id, 
            e.datCad AS estado_datCad, 
            e.ultAlt AS estado_ultAlt, 
            e.Estado, 
            e.UF,
            p.id AS pais_id, 
            p.datCad AS pais_datCad, 
            p.ultAlt AS pais_ultAlt, 
            p.pais, 
            p.sigla, 
            p.ddi, 
            p.moeda
        FROM cidades AS c
        INNER JOIN estados AS e ON e.id = c.id_estado
        INNER JOIN paises AS p ON p.id = e.id_pais
        where c.id like '%{chave}%' or c.cidade like '%{chave}%' or c.ddd like '%{chave}%' or e.id like '%{chave}%' or e.estado like '%{chave}%'";

            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<Cidades> lista = new List<Cidades>();

                while (reader.Read())
                {
                    Paises oPais = new Paises(
                        Convert.ToInt32(reader["pais_id"]),
                        Convert.ToDateTime(reader["pais_datCad"]),
                        Convert.ToDateTime(reader["pais_ultAlt"]),
                        reader["pais"].ToString(),
                        reader["sigla"].ToString(),
                        reader["ddi"].ToString(),
                        reader["moeda"].ToString()
                    );

                    Estados oEstado = new Estados(
                        Convert.ToInt32(reader["estado_id"]),
                        Convert.ToDateTime(reader["estado_datCad"]),
                        Convert.ToDateTime(reader["estado_ultAlt"]),
                        reader["Estado"].ToString(),
                        reader["UF"].ToString(),
                        oPais
                    );

                    Cidades aCidade = new Cidades(
                        Convert.ToInt32(reader["cidade_id"]),
                        Convert.ToDateTime(reader["cidade_datCad"]),
                        Convert.ToDateTime(reader["cidade_ultAlt"]),
                        reader["Cidade"].ToString(),
                        reader["ddd"].ToString(),
                        oEstado
                    );
                    //if(aCidade.Cidade.Contains(chave) || aCidade.DDD == chave || aCidade.OEstado.Estado.Contains(chave))
                        lista.Add(aCidade);
                }

                reader.Close();
                return lista;
            }
        }
    }
}
