
using PsicoMost.ConexaoBancoSQL;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PsicoMost.DAL
{
   public  class UsuarioDAL
    {
        private conexao conexao;

        public UsuarioDAL()
        {
            conexao = new conexao(@"Data Source=PsicoMost.mssql.somee.com;Initial Catalog=PsicoMost;User ID=estevaovaz_SQLLogin_1;Password=lwz2he32tm");
        }

        public SqlDataReader LogarUsuario(Usuario usuario)
        {
            StringBuilder query = null;
            SqlCommand ocmd = null;

            try
            {
                query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("  [ID], ");
                query.Append("  [Nome Completo], ");
                query.Append("  imgPsicologo, ");
                query.Append("  [CRP], ");
                query.Append("  [Email], ");
                query.Append("  [Senha], ");
                query.Append("  [Ativo], ");
                query.Append("  [Usuario] ");               
                query.Append(" FROM [UsuarioPsi] ");
                query.Append(" WHERE [CRP] = @CRP ");
                query.Append(" AND [Senha]  = @Senha ");
                
                ocmd = new SqlCommand(query.ToString());
                ocmd.Parameters.Add("@CRP", SqlDbType.VarChar).Value = usuario.CRP;
                ocmd.Parameters.Add("@Senha", SqlDbType.VarChar).Value = usuario.Senha;


                return conexao.RetornarDataReader(ocmd);
            }
            catch (Exception ex)
            {
                throw new Exception("* UsuarioDAL.LogarUsuario(Usuario)\n" + "<br>" + ex.Message);
            }
            finally
            {
                if (query != null)
                    query = null;

                if (ocmd != null)
                    ocmd.Dispose();
            }
        }

        public DataTable VerificarCRP(Usuario usuario)
        {
            StringBuilder query = null;
            SqlCommand ocmd = null;

            try
            {
                query = new StringBuilder();
                query.Append("SELECT ");
                //query.Append("  [ID], ");
                query.Append("  [Nome Completo] as Nome, ");
                query.Append("  [CRP], ");
                query.Append("  [Email], ");
                query.Append("  [Senha], ");
                query.Append("  [Ativo] ");
                //query.Append("  [Usuario] ");
                query.Append("FROM [UsuarioPsi] ");
                query.Append("WHERE [CRP] = @CRP ");
                
                ocmd = new SqlCommand(query.ToString());
                ocmd.Parameters.Add("@CRP", SqlDbType.VarChar).Value = usuario.CRP;
               

                return conexao.RetornarDataTable(ocmd);
            }
            catch (Exception ex)
            {
                throw new Exception("* UsuarioDAL.LogarUsuario(Usuario)\n" + "<br>" + ex.Message);
            }
            finally
            {
                if (query != null)
                    query = null;

                if (ocmd != null)
                    ocmd.Dispose();
            }
        }

        public DataTable ListarPsiMenu()
        {
            StringBuilder sql = null;
            SqlCommand ocmd = null;
            DataTable dt = null;

            try
            {
                sql = new StringBuilder();
                sql.Append(" SELECT [Nome Completo] AS Nome, [Senha], [Email], [CRP] ");
                sql.Append(" FROM [UsuarioPsi]  ");

                ocmd = new SqlCommand(sql.ToString());
               // ocmd.Parameters.Add("@CRP", SqlDbType.VarChar).Value = usuario.CRP;

                dt = conexao.RetornarDataTable(ocmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (ocmd != null)
                    ocmd.Dispose();
                sql = null;
            }

            return dt;
        }

        public DataTable ListarPsiMenu(string crp)
        {
            StringBuilder sql = null;
            SqlCommand ocmd = null;
            DataTable dt = null;

            try
            {
                sql = new StringBuilder();
                sql.Append(" SELECT [Nome Completo] AS Nome, [Senha], [Email], [CRP] ");
                sql.Append(" FROM [UsuarioPsi] WHERE CRP = @CRP ");

                ocmd = new SqlCommand(sql.ToString());
                ocmd.Parameters.Add("@CRP", SqlDbType.VarChar).Value = crp;

                dt = conexao.RetornarDataTable(ocmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (ocmd != null)
                    ocmd.Dispose();
                sql = null;
            }

            return dt;
        }

        public bool EditarPsicologo(Usuario usuario)
        {

            SqlConnection oConexao = null;
            StringBuilder sql = null;
            SqlCommand ocmd = null;

            try
            {
                using (oConexao = new SqlConnection("Data Source = PsicoMost.mssql.somee.com; Initial Catalog = PsicoMost; User ID = estevaovaz_SQLLogin_1; Password = lwz2he32tm"))
                {
                    oConexao.Open();

                    sql = new StringBuilder();

                    sql.Append("UPDATE [UsuarioPsi] SET [Nome Completo] = @nome, ");
                    sql.Append(" Senha = @senha, Email = @email");                   
                    sql.Append(" WHERE CRP = @CRP ");

                    ocmd = new SqlCommand(sql.ToString(), oConexao);

                    ocmd.Parameters.AddWithValue("@nome", usuario.Nome);
                    ocmd.Parameters.AddWithValue("@senha", usuario.Senha);
                    ocmd.Parameters.AddWithValue("@email", usuario.Email);
                    ocmd.Parameters.AddWithValue("@CRP", usuario.CRP);
                    //ocmd.Parameters.AddWithValue("@CRP", crp);
                
                    ocmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString().ToUpper());
            }
            finally
            {
                if (sql != null)
                    sql = null;

                if (ocmd != null)
                    ocmd.Dispose();
            }
        }



    }
}
