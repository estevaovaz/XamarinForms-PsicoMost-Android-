using PsicoMost.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PsicoMost.Models
{
    public class Usuario 
    {
       
        public int ID { get; set; }

        public string CRP { get; set; }

        public byte[] imgPsicologo { get; set; }
        
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int CodigoUsuario { get; set; }

        public string Ativo { get; set; }

        public string PrimeiroAcesso { get; set; }

        public string UsuarioPsi { get; set; }
    }
}
