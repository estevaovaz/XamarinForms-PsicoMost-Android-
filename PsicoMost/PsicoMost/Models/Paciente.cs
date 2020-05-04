using System;
using System.Collections.Generic;
using System.Text;

namespace PsicoMost.Models
{
    public class Paciente
    {
        public string Registro { get; set; }
        public string Nome { get; set; }
        public string Situacao { get; set; }
        public string NomePsicologoResponsavel { get; set; }
        public string CRP { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string Idade { get; set; }
        public string TelResidencial { get; set; }
        public string Estado { get; set; }

        public string DtNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidade { get; set; }
        public string Naturalidade { get; set; }
        public string Email { get; set; }
        public string EmailPsicologo { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }

        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string DDDResidencial { get; set; }
        public string DDDCelular { get; set; }
        public string Celular { get; set; }

    }
}
