using PsicoMost.DAL;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PsicoMost.BLL
{
    public class SessaoBLL
    {
        private SessaoDAL sessaoDAL = null;

        public DataTable dataTableCollection { get; set; }

        public string crp = PsicoMost.Utils.Settings.CRP;

        public SessaoBLL()
        {
            sessaoDAL = new SessaoDAL();
            dataTableCollection = ListarSessao(crp);

        }

        public DataTable ListarSessao(string crp)
        {
            return sessaoDAL.ListarSessao(crp);
        }

        public bool DadosEnvioLembrete(Sessao sessao, Paciente pacientes)
        {
            return sessaoDAL.DadosEnvioLembrete(sessao, pacientes);
        }

        public bool ExcluirSessao(string rs, string RP, string crp)
        {
            SessaoDAL _sessaoDAL = null;
            try
            {
                _sessaoDAL = new SessaoDAL();
                return _sessaoDAL.ExcluirSessao(rs, RP, crp);

            }
            catch (Exception ex)
            {
                throw new Exception("* SessaoBLL.ExcluirSessao(Sessao)\n" + "<br>" + ex.Message);
            }
        }

        public bool Incluir(Sessao sessao)
        {
            SessaoDAL _sessaoDAL = null;
            try
            {
                _sessaoDAL = new SessaoDAL();
                return _sessaoDAL.Incluir(sessao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AtualizarSessao(Sessao sessaoNova, string  rs, string crp)
        {
            SessaoDAL _sessaoDAL = null;
            try
            {
                _sessaoDAL = new SessaoDAL();
                return _sessaoDAL.AtualizarSessao(sessaoNova, rs, crp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Sessao ListarDadosCadastrais(string RegistroSessao, string RegistroPaciente)
        {
            Sessao sessaoModel = null;
            try
            {
                sessaoDAL = new SessaoDAL();

               sessaoModel = sessaoDAL.ListarDadosCadastrais(RegistroSessao, RegistroPaciente);

            }
            catch (Exception ex)
            {
                throw new Exception("*SessaoBLL.ListarDadosCadastrais(string, string)" + "<br>" + ex.Message);
            }
            finally
            {
                sessaoDAL = null;
            }
            return sessaoModel;
        }
    }
}
