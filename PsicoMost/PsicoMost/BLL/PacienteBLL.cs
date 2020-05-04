using PsicoMost.DAL;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PsicoMost.BLL
{
    public class PacienteBLL
    {
        private PacienteDAL pacientes = null;

        public DataTable dataTableCollection { get; set; }
        
        public string crp = PsicoMost.Utils.Settings.CRP;

        public PacienteBLL()
        {
            pacientes = new PacienteDAL();
            dataTableCollection = ListarPaciente(crp);
            
        }

        public bool Incluir(Paciente pacientes)
        {
            PacienteDAL _PacientesDAL = null;
            try
            {
                _PacientesDAL = new PacienteDAL();
                return _PacientesDAL.Incluir(pacientes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EditarPaciente(Paciente Paciente, string rp, string crp)
        {
            PacienteDAL PacienteDAL = null;
            try
            {
                PacienteDAL = new PacienteDAL();
                return PacienteDAL.EditarPaciente(Paciente, rp, crp);
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }

        }

        public DataTable ListarPaciente(string crp)
        {
            return pacientes.ListarPaciente(crp);
        }

        public Paciente ListarDadosCadastrais(string rp, string CRP)
        {
            Paciente pacienteModel = null;
            try
            {
                pacientes = new PacienteDAL();

                pacienteModel = pacientes.ListarDadosCadastrais(rp, CRP);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                pacientes = null;
            }
            return pacienteModel;
        }

        public DataTable ListarTodosPaciente(string crp)
        {
            return pacientes.ListarTodosPaciente(crp);
        }

        public bool ExcluirRegistro(string rp, string crp)
        {
            PacienteDAL _PacientesDAL = null;
            try
            {
                _PacientesDAL = new PacienteDAL();
                return _PacientesDAL.ExcluirRegistro(rp, crp);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
