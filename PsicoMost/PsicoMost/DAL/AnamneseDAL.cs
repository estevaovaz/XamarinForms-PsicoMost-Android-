using PsicoMost.ConexaoBancoSQL;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PsicoMost.DAL
{
    public class AnamneseDAL
    {
        private conexao conexao;

        public AnamneseDAL()
        {
            conexao = new conexao(@"Data Source=PsicoMost.mssql.somee.com;Initial Catalog=PsicoMost;User ID=estevaovaz_SQLLogin_1;Password=lwz2he32tm");
        }

        public DataTable ListarAnamnese(string crp)
        {
            StringBuilder sql = null;
            SqlCommand ocmd = null;

            try
            {
                sql = new StringBuilder();
                ocmd = new SqlCommand();

                sql.Append(@"
                
                          SELECT
                            A.RegistroAnamnese AS 'Nº.A', P.RegistroPaciente AS 'Nº.P',
                            P.Nome, P.Sobrenome AS 'Sobr.', A.QueixaPrincipal AS 'Queixa.P'	                       
	                        FROM Anamnese A
	                        INNER JOIN Paciente P ON A.RegistroPaciente = P.RegistroPaciente
                            WHERE P.CRP = @CRP
	                        ORDER BY P.Nome, P.RegistroPaciente  
                        
                                ");

                ocmd.CommandText = sql.ToString();
                ocmd.Parameters.Add("@CRP", SqlDbType.VarChar).Value = crp;

                return conexao.RetornarDataTable(ocmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar relátorio." + ex.Message.ToString().ToUpper());
            }
            finally
            {
                if (ocmd != null)
                    ocmd.Dispose();
                sql = null;
            }
        }

        public bool AtualizarAnamnese(Anamneses anamneseNovo, string ra, string crp)
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
                    sql.Append(@"
                            UPDATE A 
                                SET                             
                                A.QueixaPrincipal = @QueixaPrincipal, A.ComoComecou = @ComoComecou, A.RepentinoOuGradual = @RepentinoOuGradual,
                                A.Sintomas = @Sintomas, A.Transformacao = @Transformacao, A.QueixasCognitivas = @QueixasCognitivas, A.QueixasAfetivoEmocionais = @QueixasAfetivoEmocionais, 
                                A.HabitosRotinas = @HabitosRotinas, A.VidaSocial = @VidaSocial, A.ComoEstaASaude = @ComoEstaASaude, A.AntecedentesFamiliares = @AntecedentesFamiliares, A.HistoriaFamiliar = @HistoriaFamiliar,
	                            A.Tratamento = @Tratamento, A.IntSensorial = @IntSensorial, A.Percepcao = @Percepcao, A.Atencao = @Atencao, A.Memoria = @Memoria, 
                                A.Volicao = @Volicao, A.Afeto = @Afeto, A.Humor = @Humor, 
                                A.Ansiedade = @Ansiedade, A.Medo = @Medo, A.Culpa = @Culpa,
							    A.Raiva = @Raiva, A.Psicomotricidade = @Psicomotricidade, A.Normal = @Normal, 
                                A.Lento = @Lento, A.Agitado = @Agitado, A.Luto = @Luto, A.Desanimo = @Desanimo
                                FROM ANAMNESE A
                                INNER JOIN Paciente P ON A.RegistroPaciente = P.RegistroPaciente                                
                                WHERE A.RegistroAnamnese = @RegistroAnamnese AND P.CRP = @CRP
        

                               ");


                    ocmd = new SqlCommand(sql.ToString(), oConexao);
                    ocmd.Parameters.AddWithValue("@QueixaPrincipal", anamneseNovo.QueixaPrincipal);
                    ocmd.Parameters.AddWithValue("@ComoComecou", anamneseNovo.ComoComecou);
                    ocmd.Parameters.AddWithValue("@RepentinoOuGradual", anamneseNovo.RepentinoOuGradual);
                    ocmd.Parameters.AddWithValue("@Sintomas", anamneseNovo.Sintomas);
                    ocmd.Parameters.AddWithValue("@Transformacao", anamneseNovo.Transformacao);
                    ocmd.Parameters.AddWithValue("@QueixasCognitivas", anamneseNovo.QueixasCognitivas);
                    ocmd.Parameters.AddWithValue("@QueixasAfetivoEmocionais", anamneseNovo.QueixasAfetivoEmocionais);
                    ocmd.Parameters.AddWithValue("@HabitosRotinas", anamneseNovo.HabitosRotinas);
                    ocmd.Parameters.AddWithValue("@VidaSocial", anamneseNovo.VidaSocial);
                    ocmd.Parameters.AddWithValue("@ComoEstaASaude", anamneseNovo.ComoEstaASaude);
                    ocmd.Parameters.AddWithValue("@AntecedentesFamiliares", anamneseNovo.AntecedentesFamiliares);
                    ocmd.Parameters.AddWithValue("@Tratamento", anamneseNovo.Tratamento);
                    ocmd.Parameters.AddWithValue("@HistoriaFamiliar", anamneseNovo.HistoriaFamiliar);
                    ocmd.Parameters.AddWithValue("@IntSensorial", anamneseNovo.IntSensorial);
                    ocmd.Parameters.AddWithValue("@Percepcao", anamneseNovo.Percepcao);
                    ocmd.Parameters.AddWithValue("@Atencao", anamneseNovo.Atencao);
                    ocmd.Parameters.AddWithValue("@Memoria", anamneseNovo.Memoria);
                    ocmd.Parameters.AddWithValue("@Volicao", anamneseNovo.Volicao);
                    ocmd.Parameters.AddWithValue("@Afeto", anamneseNovo.Afeto);
                    ocmd.Parameters.AddWithValue("@Humor", anamneseNovo.Humor);
                    ocmd.Parameters.AddWithValue("@Ansiedade", anamneseNovo.Ansiedade);
                    ocmd.Parameters.AddWithValue("@Medo", anamneseNovo.Medo);
                    ocmd.Parameters.AddWithValue("@Raiva", anamneseNovo.Raiva);
                    ocmd.Parameters.AddWithValue("@Psicomotricidade", anamneseNovo.Psicomotricidade);
                    ocmd.Parameters.AddWithValue("@Culpa", anamneseNovo.Culpa);
                    ocmd.Parameters.AddWithValue("@Normal", anamneseNovo.Normal);
                    ocmd.Parameters.AddWithValue("@Lento", anamneseNovo.Lento);
                    ocmd.Parameters.AddWithValue("@Agitado", anamneseNovo.Agitado);
                    ocmd.Parameters.AddWithValue("@Luto", anamneseNovo.Luto);
                    ocmd.Parameters.AddWithValue("@Desanimo", anamneseNovo.Desanimo);
                    ocmd.Parameters.AddWithValue("@RegistroAnamnese", ra);
                    ocmd.Parameters.AddWithValue("@CRP", crp);
                    

                    ocmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("* AnamneseDAL.AtualizarAnamnese(anamneseNovo, anamneseOLD)" + "<br>" + ex.Message.ToString());
            }
            finally
            {
                if (sql != null)
                    sql = null;

                if (ocmd != null)
                    ocmd.Dispose();
            }
        }

        public Anamneses ListarDadosCadastrais(string RegistroAnamnese, string RegistroPacientes)
        {
            Anamneses anamnese = null;

            SqlDataReader dr = null;
            StringBuilder sql = null;
            SqlCommand cmd = null;
           
            try
            {
                sql = new StringBuilder();
                cmd = new SqlCommand();               
                sql.Append(@"
                          SELECT A.RegistroAnamnese,  
	                        A.QueixaPrincipal, A.EvolucaoQueixa, A.ComoComecou, A.RepentinoOuGradual, A.Sintomas, 
	                        A.Transformacao, A.QueixasCognitivas, A.QueixasAfetivoEmocionais, A.HabitosRotinas, A.VidaSocial,
	                        A.ComoEstaASaude, A.AntecedentesFamiliares, A.HistoriaFamiliar,
	                        A.Tratamento, A.IntSensorial, A.Percepcao, A.Atencao, A.Memoria, 
                            A.Volicao, A.Afeto, A.Humor, 
                            A.Ansiedade, A.Medo, A.Culpa,
							A.Raiva, A.Psicomotricidade, A.Normal, A.Lento, A.Agitado, A.Luto, A.Desanimo
	                        FROM Anamnese A                                
	                        INNER JOIN Paciente P ON A.RegistroPaciente = P.RegistroPaciente
                            WHERE A.RegistroAnamnese = @registroAnamnese
                            AND P.RegistroPaciente = @registroPaciente                                      
                                ");
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@registroAnamnese", string.IsNullOrEmpty(RegistroAnamnese) ? (object)DBNull.Value : RegistroAnamnese);
                cmd.Parameters.AddWithValue("@registroPaciente", string.IsNullOrEmpty(RegistroPacientes) ? (object)DBNull.Value : RegistroPacientes);


                using (dr = conexao.RetornarDataReader(cmd))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        anamnese = new Anamneses();


                        anamnese.RegistroAnamnese = RegistroAnamnese;
                        anamnese.RegistroPaciente = RegistroPacientes;

                        //Dados da Anamnese
                        anamnese.RegistroAnamnese = dr["RegistroAnamnese"].ToString().ToUpper();
                        anamnese.QueixaPrincipal = dr["QueixaPrincipal"].ToString().ToUpper();
                        anamnese.EvolucaoQueixa = dr["EvolucaoQueixa"].ToString().ToUpper();
                        anamnese.ComoComecou = dr["ComoComecou"].ToString().ToUpper();
                        anamnese.RepentinoOuGradual = dr["RepentinoOuGradual"].ToString().ToUpper();
                        anamnese.Sintomas = dr["Sintomas"].ToString().ToUpper();
                        anamnese.Transformacao = dr["Transformacao"].ToString().ToUpper();
                        anamnese.QueixasCognitivas = dr["QueixasCognitivas"].ToString().ToUpper();
                        anamnese.QueixasAfetivoEmocionais = dr["QueixasAfetivoEmocionais"].ToString().ToUpper();
                        anamnese.HabitosRotinas = dr["HabitosRotinas"].ToString().ToUpper();
                        anamnese.VidaSocial = dr["VidaSocial"].ToString().ToUpper();
                        anamnese.ComoEstaASaude = dr["ComoEstaASaude"].ToString().ToUpper();
                        anamnese.AntecedentesFamiliares = dr["AntecedentesFamiliares"].ToString().ToUpper();
                        anamnese.HistoriaFamiliar = dr["HistoriaFamiliar"].ToString().ToUpper();
                        anamnese.Tratamento = dr["Tratamento"].ToString().ToUpper();
                        anamnese.IntSensorial = bool.Parse(dr["IntSensorial"].ToString());
                        anamnese.Percepcao = bool.Parse(dr["Percepcao"].ToString());
                        anamnese.Atencao = bool.Parse(dr["Atencao"].ToString());
                        anamnese.Memoria = bool.Parse(dr["Memoria"].ToString());
                        anamnese.Volicao = bool.Parse(dr["Volicao"].ToString());
                        anamnese.Afeto = bool.Parse(dr["Afeto"].ToString());
                        anamnese.Humor = bool.Parse(dr["Humor"].ToString());
                        anamnese.Ansiedade = bool.Parse(dr["Ansiedade"].ToString());
                        anamnese.Medo = bool.Parse(dr["Medo"].ToString());
                        anamnese.Culpa = bool.Parse(dr["Culpa"].ToString());
                        anamnese.Raiva = bool.Parse(dr["Raiva"].ToString());
                        anamnese.Psicomotricidade = bool.Parse(dr["Psicomotricidade"].ToString());
                        anamnese.Normal = bool.Parse(dr["Normal"].ToString());
                        anamnese.Lento = bool.Parse(dr["Lento"].ToString());
                        anamnese.Agitado = bool.Parse(dr["Agitado"].ToString());
                        anamnese.Luto = bool.Parse(dr["Luto"].ToString());
                        anamnese.Desanimo = bool.Parse(dr["Desanimo"].ToString());
                        dr = null;

                    }
                }

                return anamnese;
            }
            catch (Exception ex)
            {
                throw new Exception("* AnamneseDAL.ListarDadosCadastrais(string,string)" + "<br>" + ex.Message.ToString());
            }
            finally
            {
                sql = null;
                cmd = null;
                conexao = null;
            }
        }

        public bool ExcluirAnamnese(string ra, string rp, string crp)
        {
            StringBuilder sql = null;
            SqlCommand ocmd = null;
            bool status = false;

            try
            {
                sql = new StringBuilder();

                sql.Append(@" DELETE A FROM Anamnese A INNER JOIN Paciente P ON A.RegistroPaciente = P.RegistroPaciente " +
                    " WHERE A.RegistroAnamnese = @registroanamnese " +
                    " AND A.RegistroPaciente = @registroPaciente AND P.CRP = @CRP"
                                    );

                ocmd = new SqlCommand(sql.ToString());
                ocmd.Parameters.AddWithValue("@registroanamnese", ra);
                ocmd.Parameters.AddWithValue("@RegistroPaciente", rp);
                ocmd.Parameters.AddWithValue("@CRP", crp);

                conexao.ExecutarComando(ocmd);
                status = true;
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

            return status;
        }

        public bool Incluir(Anamneses anamnese)
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
                          INSERT INTO Anamnese (
                            RegistroPaciente,
                            QueixaPrincipal, ComoComecou, RepentinoOuGradual, Sintomas,
                            Transformacao, QueixasCognitivas, QueixasAfetivoEmocionais, HabitosRotinas, VidaSocial,
                            ComoEstaASaude, AntecedentesFamiliares, HistoriaFamiliar,
                            Tratamento, IntSensorial, Percepcao, Atencao, Memoria, Volicao, Afeto, Humor, Ansiedade, Medo, Culpa,
                            Raiva, Psicomotricidade, Normal, Lento, Agitado, Luto, Desanimo

                            ) VALUES(
                            @RegistroPaciente,
                            @QueixaPrincipal,  @ComoComecou, @RepentinoOuGradual, @Sintomas,
                            @Transformacao, @QueixasCognitivas, @QueixasAfetivoEmocionais, @HabitosRotinas, @VidaSocial,
                            @ComoEstaASaude, @AntecedentesFamiliares, @HistoriaFamiliar,
                            @Tratamento, @IntSensorial, @Percepcao, @Atencao, @Memoria, @Volicao, @Afeto, @Humor, @Ansiedade, @Medo, @Culpa,
                            @Raiva, @Psicomotricidade, @Normal, @Lento, @Agitado, @Luto, @Desanimo )  
                                                                                                        ");

                    command = new SqlCommand(query.ToString(), oConexao);
                    command.Parameters.Add("@RegistroPaciente", SqlDbType.VarChar).Value = anamnese.RegistroPaciente;
                    command.Parameters.Add("@QueixaPrincipal", SqlDbType.VarChar).Value = anamnese.QueixaPrincipal;
                    command.Parameters.Add("@ComoComecou", SqlDbType.VarChar).Value = anamnese.ComoComecou;
                    command.Parameters.Add("@RepentinoOuGradual", SqlDbType.VarChar).Value = anamnese.RepentinoOuGradual;
                    command.Parameters.Add("@Sintomas", SqlDbType.VarChar).Value = anamnese.Sintomas;
                    command.Parameters.Add("@Transformacao", SqlDbType.VarChar).Value = anamnese.Transformacao;
                    command.Parameters.Add("@QueixasCognitivas", SqlDbType.VarChar).Value = anamnese.QueixasCognitivas;
                    command.Parameters.Add("@QueixasAfetivoEmocionais", SqlDbType.VarChar).Value = anamnese.QueixasAfetivoEmocionais;
                    command.Parameters.Add("@HabitosRotinas", SqlDbType.VarChar).Value = anamnese.HabitosRotinas;
                    command.Parameters.Add("@VidaSocial", SqlDbType.VarChar).Value = anamnese.VidaSocial;
                    command.Parameters.Add("@ComoEstaASaude", SqlDbType.VarChar).Value = anamnese.ComoEstaASaude;
                    command.Parameters.Add("@AntecedentesFamiliares", SqlDbType.VarChar).Value = anamnese.AntecedentesFamiliares;
                    command.Parameters.Add("@HistoriaFamiliar", SqlDbType.VarChar).Value = anamnese.HistoriaFamiliar;
                    command.Parameters.Add("@Tratamento", SqlDbType.VarChar).Value = anamnese.Tratamento;
                    command.Parameters.Add("@IntSensorial", SqlDbType.VarChar).Value = anamnese.IntSensorial;
                    command.Parameters.Add("@Percepcao", SqlDbType.VarChar).Value = anamnese.Percepcao;
                    command.Parameters.Add("@Atencao", SqlDbType.VarChar).Value = anamnese.Atencao;
                    command.Parameters.Add("@Memoria", SqlDbType.VarChar).Value = anamnese.Memoria;
                    command.Parameters.Add("@Volicao", SqlDbType.VarChar).Value = anamnese.Volicao;
                    command.Parameters.Add("@Afeto", SqlDbType.VarChar).Value = anamnese.Afeto;
                    command.Parameters.Add("@Humor", SqlDbType.VarChar).Value = anamnese.Humor;
                    command.Parameters.Add("@Ansiedade", SqlDbType.VarChar).Value = anamnese.Ansiedade;
                    command.Parameters.Add("@Medo", SqlDbType.VarChar).Value = anamnese.Medo;
                    command.Parameters.Add("@Culpa", SqlDbType.VarChar).Value = anamnese.Culpa;
                    command.Parameters.Add("@Raiva", SqlDbType.VarChar).Value = anamnese.Raiva;
                    command.Parameters.Add("@Psicomotricidade", SqlDbType.VarChar).Value = anamnese.Psicomotricidade;
                    command.Parameters.Add("@Normal", SqlDbType.VarChar).Value = anamnese.Normal;
                    command.Parameters.Add("@Lento", SqlDbType.VarChar).Value = anamnese.Lento;
                    command.Parameters.Add("@Agitado", SqlDbType.VarChar).Value = anamnese.Agitado;
                    command.Parameters.Add("@Luto", SqlDbType.VarChar).Value = anamnese.Luto;
                    command.Parameters.Add("@Desanimo", SqlDbType.VarChar).Value = anamnese.Desanimo;

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("* AnamneseDAL.Incluir(Anamnese)\n" + "<br>" + ex.Message);
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
