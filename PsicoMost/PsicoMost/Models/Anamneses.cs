using System;
using System.Collections.Generic;
using System.Text;

namespace PsicoMost.Models
{
    public class Anamneses
    {
        public string RegistroAnamnese { get; set; }
        
        public string RegistroPaciente { get; set; }
        public string QueixaPrincipal { get; set; }
        public string EvolucaoQueixa { get; set; }
        public string ComoComecou { get; set; }
        public string RepentinoOuGradual { get; set; }
        public string Sintomas { get; set; }
        public string Transformacao { get; set; }
        public string QueixasCognitivas { get; set; }
        public string QueixasAfetivoEmocionais { get; set; }
        public string HabitosRotinas { get; set; }
        public string VidaSocial { get; set; }
        public string ComoEstaASaude { get; set; }
        public string AntecedentesFamiliares { get; set; }
        public string HistoriaFamiliar { get; set; }
        public string Tratamento { get; set; }
        public bool IntSensorial { get; set; }
        public bool Percepcao { get; set; }
        public bool Atencao { get; set; }
        public bool Memoria { get; set; }
        public bool Volicao { get; set; }
        public bool Afeto { get; set; }
        public bool Humor { get; set; }
        public bool Ansiedade { get; set; }
        public bool Medo { get; set; }
        public bool Culpa { get; set; }
        public bool Raiva { get; set; }
        public bool Psicomotricidade { get; set; }
        public bool Normal { get; set; }
        public bool Lento { get; set; }
        public bool Agitado { get; set; }
        public bool Luto { get; set; }
        public bool Desanimo { get; set; }
    }
}
