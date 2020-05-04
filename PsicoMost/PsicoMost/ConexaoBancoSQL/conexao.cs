using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PsicoMost.ConexaoBancoSQL
{
    [Serializable]
    public class conexao : IDisposable
    {
        #region Implementando o Método Dispose()
        //Adaptado de URL: http://msdn.microsoft.com/pt-br/library/ms244737(VS.80).aspx
        //Acessado em: 30/09/2008
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~conexao()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                StringConexao = null;
            }
        }
        #endregion

        public string StringConexao;

        public conexao(string strconexao)
        {
            StringConexao = strconexao;
        }

        public SqlDataReader RetornarDataReader(SqlCommand ocmd)
        {
 
            SqlConnection oConexao;

            try
            {
                oConexao = new SqlConnection(StringConexao);
                oConexao.Open();
                ocmd.Connection = oConexao;
                return ocmd.ExecuteReader(CommandBehavior.CloseConnection);
                //return ocmd.ExecuteReader();
            }

            catch (Exception ex)
            {
                throw new Exception("BancoDados.RetornarDatareader(SqlCommand)\\nErro: " + ex.Message.ToString());
            }

        }

        public DataTable RetornarDataTable(SqlCommand ocmd)
        {
            SqlConnection oConexao = null;
            SqlDataAdapter oda = null;
            DataTable odt = null;

            try
            {
                using (oConexao = new SqlConnection(StringConexao))
                {
                    oConexao.Open();

                    ocmd.Connection = oConexao;

                    oda = new SqlDataAdapter();
                    odt = new DataTable();

                    oda.SelectCommand = ocmd;
                    oda.Fill(odt);
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("BancoDados.RetornarDataTable(SqlCommand)\\nSQL Erro: " + sqlex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("BancoDados.RetornarDataTable(SqlCommand)\\nErro: " + ex.Message.ToString());
            }
            finally
            {
                if (oConexao != null && oConexao.State == ConnectionState.Open) oConexao.Close();
                if (oda != null) oda.Dispose();
            }
            return odt;
        }

        public void ExecutarComando(SqlCommand ocmd)
        {

            SqlConnection oConexao = null;
            SqlTransaction oTransacao = null;

            try
            {
                using (oConexao = new SqlConnection(StringConexao))
                {
                    oConexao.Open();

                    using (oTransacao = oConexao.BeginTransaction())
                    {
                        ocmd.Transaction = oTransacao;
                        ocmd.Connection = oConexao;
                        ocmd.ExecuteNonQuery();

                        oTransacao.Commit();
                    }
                }
            }
            catch (SqlException sqlex)
            {
                oTransacao.Rollback();
                throw new Exception("BancoDados.ExecutarComando(SqlCommand)\\nSQL Erro: " + sqlex.Message.ToString());
            }
            catch (Exception ex)
            {
                oTransacao.Rollback();
                throw new Exception("BancoDados.ExecutarComando(SqlCommand)\\nErro: " + ex.Message.ToString());
            }
           
        }


    }
}
