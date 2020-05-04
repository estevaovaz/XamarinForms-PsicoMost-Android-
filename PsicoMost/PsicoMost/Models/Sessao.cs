using System;
using System.Collections.Generic;
using System.Text;

namespace PsicoMost.Models
{
    public class Sessao
    {
        public string IDSessao { get; set; }
        public string RegistroSessao { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DescricaoSessao { get; set; }
        public string SituacaoSessao { get; set; }
        //public int RegistroPaciente { get; set; }
        public string RegistroPaciente { get; set; }
        public string Duracao { get; set; }
        public string Falta { get; set; }
        public string ObsFalta { get; set; }
        public string DataSessao { get; set; }
        public string HoraSessao { get; set; }
        public string Assunto { get; set; }

        public Decimal ValorSessao { get; set; }
        public Decimal ValorMulta { get; set; }
        public Decimal ValorJuros { get; set; }
    }

}
