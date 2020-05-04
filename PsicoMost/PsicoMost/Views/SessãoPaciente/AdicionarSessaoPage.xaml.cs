using Android.Widget;
using PsicoMost.BLL;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views.SessãoPaciente
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdicionarSessaoPage : ContentPage
	{
		public AdicionarSessaoPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#ff7400");
        }

        private void RoundedButton_Clicked_Cadastrar(object sender, EventArgs e)
        {
            Sessao sessao = new Sessao();
           
            txtValorSessao.Text = "80,00";
            
            sessao.RegistroPaciente = txtRegistroPaciente.Text;
            sessao.DescricaoSessao = txtDescricaoS.Text;
            sessao.SituacaoSessao = txtSituacao.Text;
            sessao.DataSessao = txtDtSessao.Text;
            sessao.HoraSessao = txtHoraSessao.Text;
            sessao.ValorSessao = decimal.Parse(txtValorSessao.Text.ToString());
            sessao.ValorMulta = decimal.Parse("0,00");
            sessao.ValorJuros = decimal.Parse("0,00");
            sessao.Duracao = txtDuracao.Text;
            sessao.Falta = "PRESENTE";
            sessao.ObsFalta = "-";
            sessao.Assunto = "Informe um Assunto.";

            if (txtRegistroPaciente.Text == null && txtDescricaoS.Text == null && txtSituacao.Text == null && txtDtSessao.Text == null && txtDuracao.Text == null && txtHoraSessao.Text == null)
            {
                Toast.MakeText(Android.App.Application.Context, "Por favor, preencha os campos!", ToastLength.Long).Show();

            }
            else
            {
                SessaoBLL sessaoBLL = new SessaoBLL();
                if (sessaoBLL.Incluir(sessao))
                {
                    Toast.MakeText(Android.App.Application.Context, "Sessão do paciente registrada com sucesso!", ToastLength.Long).Show();
                    Navigation.PushAsync(new ConsultaSessaoPage());

                }
                else
                {
                    Toast.MakeText(Android.App.Application.Context, "Houve um problema ao registrar a sessão, verifique os campos e tente novamente.", ToastLength.Long).Show();

                    txtRegistroPaciente.Text = string.Empty;
                    txtDescricaoS.Text = string.Empty;
                    txtSituacao.Text = string.Empty;
                    txtValorJuros.Text = string.Empty;
                    txtValorMulta.Text = string.Empty;
                    txtDtSessao.Text = string.Empty;
                    txtHoraSessao.Text = string.Empty;
                    txtValorSessao.Text = string.Empty;
                    txtDuracao.Text = string.Empty;

                }

            }
        }
    }
}