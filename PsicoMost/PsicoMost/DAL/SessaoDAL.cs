using PsicoMost.ConexaoBancoSQL;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PsicoMost.DAL
{
    public class SessaoDAL
    {
        private conexao conexao;

        public SessaoDAL()
        {
            conexao = new conexao(@"Data Source=PsicoMost.mssql.somee.com;Initial Catalog=PsicoMost;User ID=estevaovaz_SQLLogin_1;Password=lwz2he32tm");
        }

        public DataTable ListarSessao(string crp)
        {
            StringBuilder sql = null;
            SqlCommand ocmd = null;
            DataTable dt = null;

            try
            {
                sql = new StringBuilder();
                sql.Append("SET DATEFORMAT DMY ");
                sql.Append(@"
                          SELECT 
                          P.Nome, S.RegistroSessao AS 'Nº.S', P.RegistroPaciente AS 'Nº.P', S.DescricaoSessao AS 'Desc',
                          CONVERT(varchar(10), S.DataSessao, 103) AS Data 
		                  FROM [SessaoPaciente] S
		                  INNER JOIN [Paciente] P ON S.RegistroPaciente = P.RegistroPaciente
                          WHERE P.CRP = @CRP
		                  ORDER BY P.Nome
                           
                                                                 ");
                ocmd = new SqlCommand(sql.ToString());
                ocmd.Parameters.Add("@CRP", SqlDbType.VarChar).Value = crp;

                dt = conexao.RetornarDataTable(ocmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString().ToUpper());
            }
            finally
            {
                if (ocmd != null)
                    ocmd.Dispose();
                sql = null;
            }

            return dt;
        }

        public Sessao ListarDadosCadastrais(string RegistroSessao, string RegistroPaciente)
        {
            Sessao sessao = null;

            SqlDataReader dr = null;
            StringBuilder sql = null;
            SqlCommand cmd = null;
           

            try
            {
                sql = new StringBuilder();
                cmd = new SqlCommand();
                
                sql.Append("SET DATEFORMAT DMY ");
                sql.Append(@"
                          SELECT S.RegistroSessao, P.Nome, P.Sobrenome, P.RegistroPaciente, S.DescricaoSessao, 
                          S.SituacaoSessao, CONVERT(varchar(10), S.DataSessao, 103) AS DataSessao, CONVERT(varchar(5), S.HoraSessao, 108) AS HoraSessao, S.ValorSessao, S.ValorMulta,
		                  S.ValorJuros, S.Duracao, S.Falta, S.OBSFalta
		                  FROM SessaoPaciente S
		                  INNER JOIN Paciente P ON S.RegistroPaciente = P.RegistroPaciente                        
		                  WHERE S.RegistroSessao = @registroSessao
                            AND P.RegistroPaciente = @registroPaciente   
                           
                                                                 ");
                
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@registroSessao", string.IsNullOrEmpty(RegistroSessao) ? (object)DBNull.Value : RegistroSessao);
                cmd.Parameters.AddWithValue("@registroPaciente", string.IsNullOrEmpty(RegistroPaciente) ? (object)DBNull.Value : RegistroPaciente);


                using (dr = conexao.RetornarDataReader(cmd))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        sessao = new Sessao();
                        sessao.RegistroSessao = RegistroSessao;
                        sessao.RegistroPaciente = RegistroPaciente;


                        sessao.RegistroSessao = dr["RegistroSessao"].ToString().ToUpper();
                        // sessao.RegistroPaciente = dr["RegistroPaciente"].ToString().ToUpper();
                        sessao.Nome = dr["Nome"].ToString().ToUpper();
                        sessao.Sobrenome = dr["Sobrenome"].ToString().ToUpper();
                        sessao.DescricaoSessao = dr["DescricaoSessao"].ToString().ToUpper();
                        sessao.SituacaoSessao = dr["SituacaoSessao"].ToString().ToUpper();
                        sessao.DataSessao = dr["DataSessao"].ToString().ToUpper();
                        sessao.HoraSessao = dr["HoraSessao"].ToString().ToUpper();
                        sessao.ValorSessao = decimal.Parse(dr["ValorSessao"].ToString());
                        sessao.ValorMulta = decimal.Parse(dr["ValorMulta"].ToString());
                        sessao.ValorJuros = decimal.Parse(dr["ValorJuros"].ToString());
                        sessao.Duracao = dr["Duracao"].ToString().ToUpper();
                        sessao.Falta = dr["Falta"].ToString().ToUpper();
                        sessao.ObsFalta = dr["OBSFalta"].ToString().ToUpper();

                        dr = null;

                    }
                }

                return sessao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                sql = null;
                cmd = null;
                conexao = null;
            }
        }

        public bool Incluir(Sessao sessao)
        {
            SqlConnection oConexao = null;
            StringBuilder query = null;
            SqlCommand command = null;
            try
            {
                using (oConexao = new SqlConnection("Data Source=PsicoMost.mssql.somee.com;Initial Catalog=PsicoMost;User ID=estevaovaz_SQLLogin_1;Password=lwz2he32tm"))
                {
                    oConexao.Open();

          
                    query = new StringBuilder();
                    query.Append("INSERT INTO [SessaoPaciente]( ");
                    query.Append("	[RegistroPaciente], ");
                    query.Append("	[DescricaoSessao], ");
                    query.Append("  [SituacaoSessao], ");
                    query.Append("  [DataSessao], ");
                    query.Append("	[HoraSessao], ");
                    query.Append("  [ValorSessao], ");
                    query.Append("  [ValorMulta], ");
                    query.Append("	[ValorJuros], ");
                    query.Append("	[Duracao], ");
                    query.Append("	[Falta], ");
                    query.Append("	[OBSFalta] ");
                    query.Append(")VALUES( ");
                    query.Append("	@registroPaciente, ");
                    query.Append("	@descricaoSessao, ");
                    query.Append("	@situacaoSessao, ");
                    query.Append("	@dataSessao, ");
                    query.Append("	@hora, ");
                    query.Append("	@vSessao, ");
                    query.Append("	@vMulta, ");
                    query.Append("	@vJuros, ");
                    query.Append("	@Duracao, ");
                    query.Append("	@Falta, ");
                    query.Append("	@ObsFalta ");
                    query.Append("	) ");

                    command = new SqlCommand(query.ToString(), oConexao);
                    command.Parameters.Add("@registroPaciente", SqlDbType.VarChar).Value = sessao.RegistroPaciente;
                    command.Parameters.Add("@descricaoSessao", SqlDbType.VarChar).Value = sessao.DescricaoSessao;
                    command.Parameters.Add("@situacaoSessao", SqlDbType.VarChar).Value = sessao.SituacaoSessao;
                    command.Parameters.Add("@dataSessao", SqlDbType.VarChar).Value = sessao.DataSessao;
                    command.Parameters.Add("@hora", SqlDbType.VarChar).Value = sessao.HoraSessao;
                    command.Parameters.Add("@vSessao", SqlDbType.Money).Value = sessao.ValorSessao;
                    command.Parameters.Add("@vMulta", SqlDbType.Money).Value = sessao.ValorMulta;
                    command.Parameters.Add("@vJuros", SqlDbType.Money).Value = sessao.ValorJuros;
                    command.Parameters.Add("@Duracao", SqlDbType.VarChar).Value = sessao.Duracao;
                    command.Parameters.Add("@Falta", SqlDbType.VarChar).Value = sessao.Falta;
                    command.Parameters.Add("@OBSFalta", SqlDbType.VarChar).Value = sessao.ObsFalta;
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString().ToUpper());
            }
            finally
            {
                if (query != null)
                    query = null;

                if (command != null)
                    command.Dispose();


            }
        }

        public bool AtualizarSessao(Sessao sessao, string rs, string crp)
        {

            SqlConnection oConexao = null;
            StringBuilder sql = null;
            SqlCommand ocmd = null;

            try
            {
                using (oConexao = new SqlConnection("Data Source=PsicoMost.mssql.somee.com;Initial Catalog=PsicoMost;User ID=estevaovaz_SQLLogin_1;Password=lwz2he32tm"))
                {
                    oConexao.Open();

                    sql = new StringBuilder();

                    sql.Append("UPDATE S SET  S.DescricaoSessao = @descricaoSessao, ");
                    sql.Append(" S.SituacaoSessao = @situacaoSessao, S.DataSessao = @dataSessao, S.HoraSessao = @horaSessao, S.ValorSessao = @vSessao, ");
                    sql.Append(" S.ValorMulta = @vMulta, S.ValorJuros = @vJuros, S.Duracao = @duracao, S.Falta = @falta, S.OBSFalta = @obsfalta ");
                    sql.Append(" FROM SessaoPaciente S  ");
                    sql.Append(" INNER JOIN Paciente P ON S.RegistroPaciente = P.RegistroPaciente ");
                    sql.Append(" WHERE S.RegistroSessao = @RS AND P.CRP = @CRP ");

                    ocmd = new SqlCommand(sql.ToString(), oConexao);

                    ocmd.Parameters.AddWithValue("@descricaoSessao", sessao.DescricaoSessao);
                    ocmd.Parameters.AddWithValue("@situacaoSessao", sessao.SituacaoSessao);
                    ocmd.Parameters.AddWithValue("@dataSessao", sessao.DataSessao);
                    ocmd.Parameters.AddWithValue("@horaSessao", sessao.HoraSessao);
                    ocmd.Parameters.AddWithValue("@vSessao", sessao.ValorSessao);
                    ocmd.Parameters.AddWithValue("@vMulta", sessao.ValorMulta);
                    ocmd.Parameters.AddWithValue("@vJuros", sessao.ValorJuros);
                    ocmd.Parameters.AddWithValue("@duracao", sessao.Duracao);
                    ocmd.Parameters.AddWithValue("@falta", sessao.Falta);
                    ocmd.Parameters.AddWithValue("@obsfalta", sessao.ObsFalta);                   
                    ocmd.Parameters.AddWithValue("@CRP", crp);
                    ocmd.Parameters.AddWithValue("@RS", rs);

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

        public bool ExcluirSessao(string rs, string RP, string CRP)
        {
            StringBuilder sql = null;
            SqlCommand ocmd = null;
            bool status = false;

            try
            {
                sql = new StringBuilder();

                sql.Append(" DELETE S FROM SessaoPaciente S INNER JOIN Paciente P ON S.RegistroPaciente = P.RegistroPaciente " +
                    " WHERE S.RegistroSessao = @registrosessao " +
                    "AND S.RegistroPaciente = @registroPaciente AND P.CRP = @CRP ");

                ocmd = new SqlCommand(sql.ToString());
                ocmd.Parameters.AddWithValue("@registrosessao", rs);
                ocmd.Parameters.AddWithValue("@registroPaciente", RP);
                ocmd.Parameters.AddWithValue("@CRP", CRP);

                conexao.ExecutarComando(ocmd);
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (ocmd != null)
                    ocmd.Dispose();
                sql = null;
            }

            return status;
        }

        public bool DadosEnvioLembrete(Sessao sessao, Paciente pacientes)
        {
            SqlConnection oConexao = null;
            StringBuilder query = null;
            SqlCommand command = null;
            try
            {
                using (oConexao = new SqlConnection("Data Source=PsicoMost.mssql.somee.com;Initial Catalog=PsicoMost;User ID=estevaovaz_SQLLogin_1;Password=lwz2he32tm"))
                {
                    oConexao.Open();


                    query = new StringBuilder();
                    query.Append(@"
                                   SELECT P.NomePsicologoResponsavel, P.EmailPsicologo, P.Nome, P.Email, S.Assunto, CONVERT(varchar(5), S.HoraSessao, 108) AS HoraSessao, S.ValorSessao, 
                                    S.DescricaoSessao, CONVERT(varchar(10), S.DataSessao, 103) AS DataSessao, S.Duracao
                                    FROM SessaoPaciente S
                                    INNER JOIN Paciente P ON S.RegistroPaciente = P.RegistroPaciente 
                                    WHERE P.NomePsicologoResponsavel = @nomeRemetente AND P.EmailPsicologo = @emailRemetente AND 
                                    P.Nome = @nomeDes AND  P.Email = @emailDes AND S.Assunto = @assunto AND  S.HoraSessao = @horaSessao
                                    AND S.ValorSessao = @valor AND  S.DescricaoSessao = @desc AND S.DataSessao = @data AND  S.Duracao = @duracao
                                                                                                                        ");
                    command = new SqlCommand(query.ToString(), oConexao);
                    command.Parameters.Add("@nomeRemetente", SqlDbType.VarChar).Value = pacientes.NomePsicologoResponsavel;
                    command.Parameters.Add("@emailRemetente", SqlDbType.VarChar).Value = pacientes.EmailPsicologo;
                    command.Parameters.Add("@nomeDes", SqlDbType.VarChar).Value = pacientes.Nome;
                    command.Parameters.Add("@emailDes", SqlDbType.VarChar).Value = pacientes.Email;
                    command.Parameters.Add("@Assunto", SqlDbType.VarChar).Value = sessao.Assunto;
                    command.Parameters.Add("@horaSessao", SqlDbType.VarChar).Value = sessao.HoraSessao;
                    command.Parameters.Add("@data", SqlDbType.VarChar).Value = sessao.DataSessao;
                    command.Parameters.Add("@valor", SqlDbType.VarChar).Value = sessao.ValorSessao;
                    command.Parameters.Add("@duracao", SqlDbType.VarChar).Value = sessao.Duracao;
                    command.Parameters.Add("@desc", SqlDbType.VarChar).Value = sessao.DescricaoSessao;

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                if (query != null)
                    query = null;

                if (command != null)
                    command.Dispose();

            }
        }


    }
}
