using PsicoMost.DAL;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PsicoMost.BLL
{
    public class AnamneseBLL
    { 
        private AnamneseDAL anamneseDal = null;

        public DataTable dataTableCollection { get; set; }

        public string crp = PsicoMost.Utils.Settings.CRP;

        public AnamneseBLL()
        {
            anamneseDal = new AnamneseDAL();
            dataTableCollection = ListarAnamnese(crp);

        }

        public DataTable ListarAnamnese(string crp)
        {
            return anamneseDal.ListarAnamnese(crp);
        }

        public bool AtualizarAnamnese(Anamneses anamneseNovo, string ra, string crp)
        {
            AnamneseDAL _AnamneseDAL = null;
            try
            {
                _AnamneseDAL = new AnamneseDAL();
                return _AnamneseDAL.AtualizarAnamnese(anamneseNovo, ra, crp);
            }
            catch (Exception ex)
            {
                throw new Exception("* AnamneseBLL.AtualizarAnamnese(AnamneseNovo, AnamneseOLD)\n" + "<br>" + ex.Message);
            }
        }

        public Anamneses ListarDadosCadastrais(string RegistroAnamnese, string RegistroPaciente)
        {
            return anamneseDal.ListarDadosCadastrais(RegistroAnamnese, RegistroPaciente);
        }

        public bool ExcluirAnamnese(string ra, string rp, string crp)
        {
            AnamneseDAL _AnamneseDAL = null;
            try
            {
                _AnamneseDAL = new AnamneseDAL();
                return _AnamneseDAL.ExcluirAnamnese(ra, rp, crp);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString().ToUpper());
            }
        }

        public bool Incluir(Anamneses anamnese)
        {
            return anamneseDal.Incluir(anamnese);
        }

    }
}
