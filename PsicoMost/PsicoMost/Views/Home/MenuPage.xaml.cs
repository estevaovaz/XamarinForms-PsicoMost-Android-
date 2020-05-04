using Android.Widget;
using PsicoMost.BLL;
using PsicoMost.Models;
using PsicoMost.Views.Anamnese;
using PsicoMost.Views.SessãoPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            
        }

        private void RoundedButton_Clicked_Anamnese(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultaAnamnesePage());
        }

        private  void RoundedButton_Clicked_Psicologo(object sender, EventArgs e)
        {        
                Navigation.PushAsync(new DadosPsicologoPage());               
        }

        private void RoundedButton_Clicked_Paciente(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultaPacientePage());
        }

        private void RoundedButton_Clicked_Sessao(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultaSessaoPage());
        }

        private void ToolbarItem_Clicked_Logout(object sender, EventArgs e)
        {
            Utils.Settings.CRP = string.Empty;
            Utils.Settings.Senha = string.Empty;

            Navigation.PushAsync(new LoginPage());
        }
    }
}