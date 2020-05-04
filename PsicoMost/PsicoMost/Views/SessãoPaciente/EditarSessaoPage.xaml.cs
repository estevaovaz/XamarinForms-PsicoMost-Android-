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
	public partial class EditarSessaoPage : ContentPage
	{
        string registroSessao = Utils.Settings.RegistroS;
        string registroPaciente = Utils.Settings.Registro;
        string crp = Utils.Settings.CRP;

        Sessao oSessao;

		public EditarSessaoPage ()
		{
			InitializeComponent ();
            CarregarDadosPessoais();
		}


        protected void CarregarDadosPessoais()
        {
            oSessao = new Sessao();
            SessaoBLL sessaoBLL = new SessaoBLL();
            oSessao = sessaoBLL.ListarDadosCadastrais(registroSessao, registroPaciente);

            txtRegistroPaciente.Text = oSessao.RegistroPaciente;
            txtNome.Text = oSessao.Nome;
            txtSobrenome.Text = oSessao.Sobrenome;
            txtDescricaoS.Text = oSessao.DescricaoSessao;
            txtDtSessao.Text = oSessao.DataSessao;
            txtHoraSessao.Text = oSessao.HoraSessao;
            txtDuracao.Text = oSessao.Duracao;
            pcFrequencia.SelectedItem = oSessao.Falta;
            txtSituacao.Text = oSessao.SituacaoSessao;
            obsFalta.Text = oSessao.ObsFalta;
            txtValorSessao.Text = oSessao.ValorSessao.ToString("N2");
            txtValorMulta.Text = oSessao.ValorMulta.ToString("N2");
            txtValorJuros.Text = oSessao.ValorJuros.ToString("N2");

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#ff7400");
        }

        private void RoundedButton_Clicked_Salvar(object sender, EventArgs e)
        {
            Sessao sessaoModel = new Sessao();
            sessaoModel.DescricaoSessao = txtDescricaoS.Text;
            sessaoModel.DataSessao = txtDtSessao.Text;
            sessaoModel.HoraSessao = txtHoraSessao.Text;
            sessaoModel.Duracao = txtDuracao.Text;
            sessaoModel.Falta = pcFrequencia.SelectedItem.ToString();
            sessaoModel.SituacaoSessao = txtSituacao.Text;
            sessaoModel.ObsFalta = obsFalta.Text;
            sessaoModel.ValorSessao = decimal.Parse(txtValorSessao.Text);
            sessaoModel.ValorJuros = decimal.Parse(txtValorJuros.Text);
            sessaoModel.ValorMulta = decimal.Parse(txtValorMulta.Text);


            SessaoBLL sessaoBLL = new SessaoBLL();
            if (sessaoBLL.AtualizarSessao(sessaoModel, registroSessao ,crp))
            {
                Toast.MakeText(Android.App.Application.Context, "Dados editados com sucesso!", ToastLength.Long).Show();
                Navigation.PushAsync(new ConsultaPacientePage());
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, "Erro ao editar dados da sessão.", ToastLength.Long).Show();
                
            }

        }
    }
}