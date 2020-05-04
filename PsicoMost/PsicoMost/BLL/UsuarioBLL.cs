using PsicoMost.DAL;
using PsicoMost.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PsicoMost.BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAL usuarios = null;

        public DataTable dataTableCollection { get; set; }
        public DataTable dataTableCollectionFoto { get; set; }

        public string crp = PsicoMost.Utils.Settings.CRP;


        public UsuarioBLL()
        {
            usuarios = new UsuarioDAL();
            dataTableCollection = ListarPsiMenu(crp);

        }

        public bool LogarUsuario(Usuario usuario)
        {
            UsuarioDAL _UsuarioDAL = null;
            SqlDataReader dr = null;
            try
            {
                //Regra 1: O usuário deve possuir um CRP.
                if (String.IsNullOrEmpty(usuario.CRP)) return false;
                //Regra 2: O usuário deve possuir uma senha.
                if (String.IsNullOrEmpty(usuario.Senha)) return false;

                _UsuarioDAL = new UsuarioDAL();
                using (dr = _UsuarioDAL.LogarUsuario(usuario))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        usuario.ID = Convert.ToInt32(dr["ID"]);
                        usuario.CRP = dr["CRP"].ToString();
                        usuario.Senha = dr["Senha"].ToString();
                        usuario.Ativo = dr["Ativo"].ToString();

                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("* UsuarioBLL.LogarUsuario(Usuario)\n" + "<br>" + ex.Message);
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }
            }
        }

        public bool EditarPsicologo(Usuario usuario)
        {
            UsuarioDAL usuarioDAL = null;
            try
            {
                usuarioDAL = new UsuarioDAL();
                return usuarioDAL.EditarPsicologo(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("* UsuarioBLL.EditarPsicologo(usuario)\n" + "<br>" + ex.Message);
            }

        }

        public DataTable ListarPsiMenu(string crp)
        {
            return usuarios.ListarPsiMenu(crp);
        }

        public DataTable ListarPsiMenu()
        {
            return usuarios.ListarPsiMenu();
        }

        /*public bool VerificarCRP(Usuario usuario)
        {
            DataTableCollection = null;

            using (DataTableCollection = usuarios.VerificarCRP(usuario))
            {
                if(DataTableCollection != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
        }*/

    }
}

