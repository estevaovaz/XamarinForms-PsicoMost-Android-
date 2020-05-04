using PsicoMost.BLL;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views.Anamnese
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhesAnamnesePage : ContentPage
	{
        public string registroAnamnese = Utils.Settings.RegistroA;
        string rp = Utils.Settings.Registro;
        Anamneses anamneses;

        public DetalhesAnamnesePage ()
		{
			InitializeComponent ();
            CarregarDadosPessoais();
		}


        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#2196F3");
        }

        protected void CarregarDadosPessoais()
        {
            anamneses = new Anamneses();
            AnamneseBLL anamneseBLL = new AnamneseBLL();
            anamneses = anamneseBLL.ListarDadosCadastrais(registroAnamnese, rp);

            lblRegistro.Text = anamneses.RegistroPaciente;
            lblQueixaP.Text = anamneses.QueixaPrincipal;
            lblComocomecou.Text = anamneses.ComoComecou;
            lblRepGradual.Text = anamneses.RepentinoOuGradual;
            lblTransformacoes.Text = anamneses.Transformacao;
            lblSintomas.Text = anamneses.Sintomas;
            lblQueixasCognitivas.Text = anamneses.QueixasCognitivas;            
            lblIntSensorial.Text = anamneses.IntSensorial.ToString();
            lblPercepcao.Text = anamneses.Percepcao.ToString();
            lblAtencao.Text = anamneses.Atencao.ToString();
            lblMemoria.Text = anamneses.Memoria.ToString();
            lblQueixasAfetivosEmocionais.Text = anamneses.QueixasAfetivoEmocionais;
            lblVolicao.Text = anamneses.Volicao.ToString();
            lblAfeto.Text = anamneses.Afeto.ToString();
            lblHumor.Text = anamneses.Humor.ToString();
            lblAnsiedade.Text = anamneses.Ansiedade.ToString();
            lblMedo.Text = anamneses.Medo.ToString();
            lblCulpa.Text = anamneses.Culpa.ToString();
            lblRaiva.Text = anamneses.Raiva.ToString();
            lblPsicomotricidade.Text = anamneses.Psicomotricidade.ToString();
            lblNormal.Text = anamneses.Normal.ToString();
            lbllento.Text = anamneses.Lento.ToString();
            lblAgitado.Text = anamneses.Agitado.ToString();
            lblLuto.Text = anamneses.Luto.ToString();
            lblDesanimo.Text = anamneses.Desanimo.ToString();
            lblhabtios.Text = anamneses.HabitosRotinas;
            lblVidaSocial.Text = anamneses.VidaSocial;
            lblComoestasaude.Text = anamneses.ComoEstaASaude;
            lblAnteceFamiliares.Text = anamneses.AntecedentesFamiliares;
            lblhistoriaFa.Text = anamneses.HistoriaFamiliar;
            lblTratamento.Text = anamneses.Tratamento;

            //adicionando cor aos checkbox  
            #region add cores aos checkbox
            if (anamneses.IntSensorial == true)
            {
                lblIntSensorial.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblIntSensorial.TextColor = Color.Red;               
            }

            if (anamneses.Percepcao == true)
            {
                lblPercepcao.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblPercepcao.TextColor = Color.Red;
            }

            if (anamneses.Atencao == true)
            {
                lblAtencao.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblAtencao.TextColor = Color.Red;
            }

            if (anamneses.Memoria == true)
            {
                lblMemoria.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblMemoria.TextColor = Color.Red;
            }
            if (anamneses.Volicao == true)
            {
                lblVolicao.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblVolicao.TextColor = Color.Red;
            }

            if (anamneses.Afeto == true)
            {
                lblAfeto.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblAfeto.TextColor = Color.Red;
            }

            if (anamneses.Humor == true)
            {
                lblHumor.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblHumor.TextColor = Color.Red;
            }
            if (anamneses.Ansiedade == true)
            {
                lblAnsiedade.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblAnsiedade.TextColor = Color.Red;
            }
            if (anamneses.Medo == true)
            {
                lblMedo.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblMedo.TextColor = Color.Red;
            }

            if (anamneses.Culpa == true)
            {
                lblCulpa.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblCulpa.TextColor = Color.Red;
            }
            if (anamneses.Raiva == true)
            {
                lblRaiva.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblRaiva.TextColor = Color.Red;
            }
            if (anamneses.Psicomotricidade == true)
            {
                lblPsicomotricidade.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblPsicomotricidade.TextColor = Color.Red;
            }

            if (anamneses.Normal == true)
            {
                lblNormal.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblNormal.TextColor = Color.Red;
            }

            if (anamneses.Lento == true)
            {
                lbllento.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lbllento.TextColor = Color.Red;
            }

            if (anamneses.Agitado == true)
            {
                lblAgitado.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblAgitado.TextColor = Color.Red;
            }

            if (anamneses.Luto == true)
            {
                lblLuto.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblLuto.TextColor = Color.Red;
            }


            if (anamneses.Desanimo == true)
            {
                lblDesanimo.TextColor = Color.FromHex("#009688");
            }
            else
            {
                lblDesanimo.TextColor = Color.Red;
            }
            #endregion
        }

    }
}