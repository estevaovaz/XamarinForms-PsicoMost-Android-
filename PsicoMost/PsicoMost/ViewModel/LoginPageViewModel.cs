using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PsicoMost.ViewModel
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string crp;

        public string CRP
        {
            get
            {
                return crp;
            }
            set
            {
                crp = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CRP"));
                PsicoMost.Utils.Settings.CRP = value;
            }
        }

        private string senha;

        public string Senha
        {
            get
            {
                return senha;
            }
            set
            {
                senha = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Senha"));
                PsicoMost.Utils.Settings.Senha = value;
            }
        }

        private string nome;

        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nome"));
                PsicoMost.Utils.Settings.Nome = value;
            }
        }

        private string email;

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                PsicoMost.Utils.Settings.Email = value;
            }
        }

        private string registro;

        public string RegistroPaciente
        {
            get
            {
                return registro;
            }
            set
            {
                registro = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RegistroPaciente"));
                PsicoMost.Utils.Settings.Registro = value;
            }
        }

        private string registroS;

        public string RegistroSessao
        {
            get
            {
                return registroS;
            }
            set
            {
                registro = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RegistroSessao"));
                PsicoMost.Utils.Settings.RegistroS = value;
            }
        }

        private string registroA;

        public string RegistroAnamnese
        {
            get
            {
                return registroS;
            }
            set
            {
                registro = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RegistroAnamnese"));
                PsicoMost.Utils.Settings.RegistroA = value;
            }
        }

        public LoginPageViewModel()
        {
            CRP = PsicoMost.Utils.Settings.CRP;
            Senha = PsicoMost.Utils.Settings.Senha;
            Email = PsicoMost.Utils.Settings.Email;
            Nome = PsicoMost.Utils.Settings.Nome;
            RegistroPaciente = PsicoMost.Utils.Settings.Registro;
            RegistroSessao = PsicoMost.Utils.Settings.RegistroS;
            RegistroAnamnese = PsicoMost.Utils.Settings.RegistroA;
        }

    }
}
