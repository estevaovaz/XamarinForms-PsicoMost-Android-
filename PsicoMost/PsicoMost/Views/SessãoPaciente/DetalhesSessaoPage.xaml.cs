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
	public partial class DetalhesSessaoPage : ContentPage
	{
        public string sessaoR = Utils.Settings.RegistroS;
        string rp = Utils.Settings.Registro;
        Sessao sessao;

        public DetalhesSessaoPage ()
		{
			InitializeComponent ();
            CarregarDadosPessoais();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#ff7400");
        }

        protected void CarregarDadosPessoais()
        {
            sessao = new Sessao();
            SessaoBLL sessaoBLL = new SessaoBLL();
            sessao = sessaoBLL.ListarDadosCadastrais(sessaoR, rp);

            lblRegistro.Text = sessao.RegistroPaciente;
            lblNome.Text = sessao.Nome;
            lblSobrenome.Text = sessao.Sobrenome;
            lblDescSessao.Text = sessao.DescricaoSessao;
            lblDtSessao.Text = sessao.DataSessao;
            lblHoraS.Text = sessao.HoraSessao;
            lblDuracao.Text = sessao.Duracao;
            lblfrequencia.Text = sessao.Falta;
            lblSituacao.Text = sessao.SituacaoSessao;
            lblObsFalta.Text = sessao.ObsFalta;
            lblValorSessao.Text = sessao.ValorSessao.ToString("N2");
            lblValorMulta.Text = sessao.ValorMulta.ToString("N2");
            lblValorJuros.Text = sessao.ValorJuros.ToString("N2");

        }

    }
}