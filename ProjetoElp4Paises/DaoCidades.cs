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
                mSql = "insert into cidades (Cidade, DDD, datCad, ultAlt, id_estado) values (@estado, @ddd, @datcad, @ultalt, @idEstado)";

            }
            else
            {
                mSql = "update cidades set cidade = @cidade, ddd = @ddd, datcad = @datcad, ultalt = @ultalt, id_estado = @idEstado where id = @codigo";
            }
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                cmd.Parameters.AddWithValue("@estado", aCidade.Cidade);
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
            return "";
        }

        public override List<Cidades> Listar()
        {
            return null;
        }

        public override Object CarregaObj(int chave)
        {
            return null;
        }

        public override List<Cidades> Pesquisar(string chave)
        {
            return null;
        }
    }
}
