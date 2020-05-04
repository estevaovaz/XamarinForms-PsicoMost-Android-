using PsicoMost.ConexaoBancoSQL;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PsicoMost.DAL
{
    public class PacienteDAL
    {
        private conexao conexao;

        public PacienteDAL()
        {
            conexao = new conexao(@"Data Source=PsicoMost.mssql.somee.com;Initial Catalog=PsicoMost;User ID=estevaovaz_SQLLogin_1;Password=lwz2he32tm");
        }

        public DataTable ListarTodosPaciente(string crp)
        {
            StringBuilder sql = null;
            SqlCommand ocmd = null;
            DataTable dt = null;

            try
            {
                sql = new StringBuilder();
                sql.Append("SET DATEFORMAT DMY ");
                sql.Append(" SELECT ");
                sql.Append(" Nome, RegistroPaciente As Registro, Sobrenome, CPF, ");
                sql.Append(" CONVERT(VARCHAR(10), [Dt Nascimento], 103) AS Nasc, Sexo, EstadoCivil as UFCiv, Email, EmailPsicologo As EmailPsi, Nacionalidade AS Nac, Naturalidade As Nat, Bairro, Rua,");
                sql.Append(" Cep, Cidade as Cid, DDDResidencial AS DDDRes, DDDCelular AS DDDCel, Celular as Cel, Situacao AS Sit ");
                sql.Append(" FROM Paciente ");
                sql.Append(" WHERE CRP = @CRP");

                ocmd = new SqlCommand(sql.ToString());
                ocmd.Parameters.Add("@CRP", SqlDbType.VarChar).Value = crp;
                //ocmd.Parameters.Add("@RP", SqlDbType.VarChar).Value = rp;
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

        public DataTable ListarPaciente(string crp)
        {
            StringBuilder sql = null;
            SqlCommand ocmd = null;
            DataTable dt = null;

            try
            {
                sql = new StringBuilder();
                sql.Append("SET DATEFORMAT DMY ");
                sql.Append(" SELECT ");
                sql.Append(" Nome, RegistroPaciente As Registro, Sobrenome, CPF ");
                //sql.Append(" CONVERT(VARCHAR(10), [Dt Nascimento], 103) AS Nasc, Sexo, EstadoCivil as UFCiv, Email, EmailPsicologo As EmailPsi, Nacionalidade AS Nac, Naturalidade As Nat, Bairro, Rua,");
                //sql.Append(" Cep, Cidade as Cid, DDDResidencial AS DDDRes, DDDCelular AS DDDCel, Celular as Cel, Situacao AS Sit ");
                sql.Append(" FROM Paciente ");
                sql.Append(" WHERE CRP = @CRP ORDER BY Nome ");

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

        public bool EditarPaciente(Paciente pacienteNovo, string rp, string crp)
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

                    sql.Append("UPDATE Paciente SET Nome = @nome, Sobrenome = @sobrenome, ");
                    sql.Append("Estado = @estado, CPF = @cpf, Idade = @idade, ");
                    sql.Append("Sexo = @sexo, [Dt Nascimento] = @dtnascimento, ");
                    sql.Append("EstadoCivil = @EstadoCivil, Nacionalidade = @nacionalidade, Naturalidade = @naturalidade, ");
                    sql.Append("Email = @email, Bairro = @bairro, Rua = @rua, ");
                    sql.Append("Cep = @cep,  Cidade = @cidade, DDDResidencial = @dddResidencial, ");
                    sql.Append("DDDCelular = @dddCelular, Celular = @celular, Situacao = @Situacao ");
                    sql.Append(" WHERE  RegistroPaciente = @rP AND CRP = @CRP ");

                    ocmd = new SqlCommand(sql.ToString(), oConexao);
                    ocmd.Parameters.AddWithValue("@nome", pacienteNovo.Nome);
                    ocmd.Parameters.AddWithValue("@sobrenome", pacienteNovo.Sobrenome);
                    ocmd.Parameters.AddWithValue("@estado", pacienteNovo.Estado);
                    ocmd.Parameters.AddWithValue("@cpf", pacienteNovo.CPF);
                    ocmd.Parameters.AddWithValue("@idade", pacienteNovo.Idade);
                    ocmd.Parameters.AddWithValue("@telresidencial", pacienteNovo.TelResidencial);
                    ocmd.Parameters.AddWithValue("@sexo", pacienteNovo.Sexo);
                    ocmd.Parameters.AddWithValue("@dtnascimento", pacienteNovo.DtNascimento);
                    ocmd.Parameters.AddWithValue("@EstadoCivil", pacienteNovo.EstadoCivil);
                    ocmd.Parameters.AddWithValue("@nacionalidade", pacienteNovo.Nacionalidade);
                    ocmd.Parameters.AddWithValue("@naturalidade", pacienteNovo.Naturalidade);
                    ocmd.Parameters.AddWithValue("@email", pacienteNovo.Email);
                    ocmd.Parameters.AddWithValue("@bairro", pacienteNovo.Bairro);
                    ocmd.Parameters.AddWithValue("@rua", pacienteNovo.Rua);
                    ocmd.Parameters.AddWithValue("@cep", pacienteNovo.Cep);
                    ocmd.Parameters.AddWithValue("@cidade", pacienteNovo.Cidade);
                    ocmd.Parameters.AddWithValue("@dddResidencial", pacienteNovo.DDDResidencial);
                    ocmd.Parameters.AddWithValue("@dddCelular", pacienteNovo.DDDCelular);
                    ocmd.Parameters.AddWithValue("@celular", pacienteNovo.Celular);
                    ocmd.Parameters.AddWithValue("@Situacao", pacienteNovo.Situacao);
                    ocmd.Parameters.AddWithValue("@rP", rp);
                    ocmd.Parameters.AddWithValue("@CRP", crp);

                    ocmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message.ToString());
            }
            finally
            {
                if (sql != null)
                    sql = null;

                if (ocmd != null)
                    ocmd.Dispose();
            }
        }


        public Paciente ListarDadosCadastrais(string rp, string CRP)
        {
            Paciente pacientes = null;

            SqlDataReader dr = null;
            StringBuilder sql = null;
            SqlCommand cmd = null;
            //BancoSQL bd = null;

            try
            {
                sql = new StringBuilder();
                cmd = new SqlCommand();
                //conexao = new BancoSQL(FuncoesSQL.StringConexao("PACIENTES"));
                sql.Append("SET DATEFORMAT DMY ");
                sql.Append(" SELECT RegistroPaciente, Nome, Sobrenome, [CPF], [Idade], [Tel Residencial], Estado, ");
                sql.Append(" CONVERT(VARCHAR(10), [Dt Nascimento], 103) AS DatNascimento, [Sexo], EstadoCivil, Email, Nacionalidade, Naturalidade, Bairro, Rua, ");
                sql.Append(" Cep, Cidade, DDDResidencial, [DDDCelular], Celular, Situacao ");
                sql.Append(" FROM [Paciente] ");
                sql.Append("WHERE RegistroPaciente = @rp AND CRP = @CRP ");
               
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@rp", string.IsNullOrEmpty(rp) ? (object)DBNull.Value : rp);
                cmd.Parameters.AddWithValue("@CRP", string.IsNullOrEmpty(CRP) ? (object)DBNull.Value : CRP);
                
                using (dr = conexao.RetornarDataReader(cmd))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        pacientes = new Paciente();
                        pacientes.CRP = CRP;
                        pacientes.Registro = rp;
                        
                        //Dados Pessoais
                        pacientes.Registro = dr["RegistroPaciente"].ToString().ToUpper();
                        pacientes.Nome = dr["Nome"].ToString().ToUpper();
                        pacientes.Sobrenome = dr["Sobrenome"].ToString().ToUpper();
                        pacientes.CPF = dr["CPF"].ToString().ToUpper();
                        pacientes.Idade = dr["Idade"].ToString();
                        pacientes.DtNascimento = dr["DatNascimento"].ToString().ToUpper();
                        pacientes.Sexo = dr["Sexo"].ToString();
                        pacientes.EstadoCivil = dr["EstadoCivil"].ToString().ToUpper();
                        pacientes.Email = dr["Email"].ToString();
                        pacientes.Nacionalidade = dr["Nacionalidade"].ToString().ToUpper();
                        pacientes.Naturalidade = dr["Naturalidade"].ToString().ToUpper();
                        pacientes.Situacao = dr["Situacao"].ToString().ToUpper();

                        //ENDERECO

                        pacientes.Bairro = dr["Bairro"].ToString().ToUpper();
                        pacientes.Rua = dr["Rua"].ToString().ToUpper();
                        pacientes.Estado = dr["Estado"].ToString().ToUpper();
                        pacientes.Cep = dr["Cep"].ToString().ToUpper();
                        pacientes.Cidade = dr["Cidade"].ToString().ToUpper();

                        //Telefones
                        pacientes.DDDResidencial = dr["DDDResidencial"].ToString();
                        pacientes.DDDCelular = dr["DDDCelular"].ToString();
                        pacientes.TelResidencial = dr["Tel Residencial"].ToString().ToUpper();
                        pacientes.Celular = dr["Celular"].ToString().ToUpper();

                        dr = null;

                    }
                }

                return pacientes;
            }
            catch (Exception ex)
            {
                throw new Exception("* PacientesDAL.ListarDadosCadastrais(string,string)" + "<br>" + ex.Message.ToString());
            }
            finally
            {
                sql = null;
                cmd = null;
                conexao = null;
            }
        }

        public bool Incluir(Paciente pacientes)
        {
            SqlConnection oConexao = null;           
            StringBuilder query = null;
            SqlCommand command = null;
            try
            {
                using (oConexao = new SqlConnection("Data Source = PsicoMost.mssql.somee.com; Initial Catalog = PsicoMost; User ID = estevaovaz_SQLLogin_1; Password = lwz2he32tm"))
                {
                    oConexao.Open();

                    query = new StringBuilder();
                    query.Append("INSERT INTO [Paciente]( ");
                    query.Append("	[NomePsicologoResponsavel], ");
                    query.Append("	[CRP], ");
                    query.Append("	[Nome], ");
                    query.Append("	[Sobrenome], ");
                    query.Append("  [CPF], ");
                    query.Append("  [Idade], ");
                    query.Append("  [Tel Residencial], ");
                    query.Append("  [Estado], ");
                    query.Append("	[Dt Nascimento], ");
                    query.Append("	[Sexo], ");
                    query.Append("  [EstadoCivil], ");
                    query.Append("  [Nacionalidade], ");
                    query.Append("  [Naturalidade], ");
                    query.Append("  [Email], ");
                    query.Append("  [EmailPsicologo], ");
                    query.Append("	[Bairro], ");
                    query.Append("	[Rua], ");
                    query.Append("  [Cep], ");
                    query.Append("  [Cidade], ");
                    query.Append("  [DDDResidencial], ");
                    query.Append("  [DDDCelular], ");
                    query.Append("  [Celular], ");
                    query.Append("  [Situacao] ");
                    query.Append(")VALUES( ");
                    query.Append("	@NomePsi, ");
                    query.Append("	@CRP, ");
                    query.Append("	@Nome, ");
                    query.Append("	@Sobrenome, ");
                    query.Append("	@CPF, ");
                    query.Append("	@Idade, ");
                    query.Append("	@Residencial, ");
                    query.Append("	@Estado, ");
                    query.Append("	@DtNascimento, ");
                    query.Append("	@Sexo, ");
                    query.Append("	@EstadoCivil, ");
                    query.Append("	@Nacionalidade, ");
                    query.Append("	@Naturalidade, ");
                    query.Append("	@Email,");
                    query.Append("	@EmailPsicologo,");
                    query.Append("	@Bairro, ");
                    query.Append("	@Rua, ");
                    query.Append("	@Cep, ");
                    query.Append("	@Cidade, ");
                    query.Append("	@DDDResidencial, ");
                    query.Append("	@DDDCelular, ");
                    query.Append("	@Celular, ");
                    query.Append("	@Situacao ");
                    query.Append("	) ");

                    command = new SqlCommand(query.ToString(), oConexao);
                    command.Parameters.Add("@NomePsi", SqlDbType.VarChar).Value = pacientes.NomePsicologoResponsavel;
                    command.Parameters.Add("@CRP", SqlDbType.VarChar).Value = pacientes.CRP;
                    command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = pacientes.Nome;
                    command.Parameters.Add("@Sobrenome", SqlDbType.VarChar).Value = pacientes.Sobrenome;
                    command.Parameters.Add("@CPF", SqlDbType.VarChar).Value = pacientes.CPF;
                    command.Parameters.Add("@Idade", SqlDbType.VarChar).Value = pacientes.Idade;
                    command.Parameters.Add("@Residencial", SqlDbType.VarChar).Value = pacientes.TelResidencial;
                    command.Parameters.Add("@Estado", SqlDbType.VarChar).Value = pacientes.Estado;
                    command.Parameters.Add("@DtNascimento", SqlDbType.VarChar).Value = pacientes.DtNascimento;
                    command.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = pacientes.Sexo;
                    command.Parameters.Add("@EstadoCivil", SqlDbType.VarChar).Value = pacientes.EstadoCivil;
                    command.Parameters.Add("@Nacionalidade", SqlDbType.VarChar).Value = pacientes.Nacionalidade;
                    command.Parameters.Add("@Naturalidade", SqlDbType.VarChar).Value = pacientes.Naturalidade;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = pacientes.Email;
                    command.Parameters.Add("@EmailPsicologo", SqlDbType.VarChar).Value = pacientes.EmailPsicologo;
                    command.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = pacientes.Bairro;
                    command.Parameters.Add("@Rua", SqlDbType.VarChar).Value = pacientes.Rua;
                    command.Parameters.Add("@Cep", SqlDbType.VarChar).Value = pacientes.Cep;
                    command.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = pacientes.Cidade;
                    command.Parameters.Add("@DDDResidencial", SqlDbType.Char).Value = pacientes.DDDResidencial;
                    command.Parameters.Add("@DDDCelular", SqlDbType.Char).Value = pacientes.DDDCelular;
                    command.Parameters.Add("@Celular", SqlDbType.VarChar).Value = pacientes.Celular;
                    command.Parameters.Add("@Situacao", SqlDbType.VarChar).Value = pacientes.Situacao;

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


        public bool ExcluirRegistro(string rp, string crp)
        {
            StringBuilder sql = null;
            SqlCommand ocmd = null;
            bool status = false;

            try
            {
                sql = new StringBuilder();

                sql.Append("DELETE  " +
                    "FROM [Paciente]  " +
                    "WHERE [RegistroPaciente] = @registro " +
                    "AND [CRP] = @CRP ");
                    

                ocmd = new SqlCommand(sql.ToString());
                ocmd.Parameters.AddWithValue("@registro", rp);                
                ocmd.Parameters.AddWithValue("@CRP", crp);
               
                conexao.ExecutarComando(ocmd);
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception("* PacientesDAL.ExcluirRegistro(pacientes)" + "<br>" + ex.Message.ToString());
            }
            finally
            {
                if (ocmd != null)
                    ocmd.Dispose();
                sql = null;
            }

            return status;
        }

    }
}
