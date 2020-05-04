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

namespace PsicoMost.Views.Anamnese
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdicionarAnamnesePage : ContentPage
	{
		public AdicionarAnamnesePage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#2196F3");
        }

        private void RoundedButton_Clicked_Cadastrar(object sender, EventArgs e)
        {
            Anamneses anamnesesModel = new Anamneses();

            anamnesesModel.RegistroPaciente = txtRegistroPaciente.Text;
            anamnesesModel.QueixaPrincipal = edqQueixaP.Text;
            anamnesesModel.ComoComecou = edComoComecou.Text;
            anamnesesModel.RepentinoOuGradual = edRepGradual.Text;
            anamnesesModel.Transformacao = edTransformacoes.Text;
            anamnesesModel.Sintomas = edSintomas.Text;
            anamnesesModel.QueixasCognitivas = edQueixasCognitivas.Text;
            anamnesesModel.IntSensorial = Convert.ToBoolean(cboIntegridade);
            anamnesesModel.Percepcao = Convert.ToBoolean(cboPercepcao);
            anamnesesModel.Atencao = Convert.ToBoolean(cboAtencao);
            anamnesesModel.Memoria = Convert.ToBoolean(cboMemoria);
            anamnesesModel.QueixasAfetivoEmocionais = edQueixasAfetivosEmocionais.Text;
            anamnesesModel.Volicao = Convert.ToBoolean(cboVolicao);
            anamnesesModel.Afeto = Convert.ToBoolean(cboAfeto);
            anamnesesModel.Humor = Convert.ToBoolean(cboHumor);
            anamnesesModel.Ansiedade = Convert.ToBoolean(cboAnsiedade);
            anamnesesModel.Medo = Convert.ToBoolean(cboMedo);
            anamnesesModel.Culpa = Convert.ToBoolean(cboCulpa);
            anamnesesModel.Raiva = Convert.ToBoolean(cboRaiva);
            anamnesesModel.Psicomotricidade = Convert.ToBoolean(cboPsicomotricidade);
            anamnesesModel.Normal = Convert.ToBoolean(cboNormal);
            anamnesesModel.Lento = Convert.ToBoolean(cboLento);
            anamnesesModel.Agitado = Convert.ToBoolean(cboAgitado);
            anamnesesModel.Luto = Convert.ToBoolean(cboLuto);
            anamnesesModel.Desanimo = Convert.ToBoolean(cboDesanimo);
            anamnesesModel.HabitosRotinas = edHabitosRotinas.Text;
            anamnesesModel.VidaSocial = edVidaSocial.Text;
            anamnesesModel.ComoEstaASaude = edSaude.Text;
            anamnesesModel.AntecedentesFamiliares = edAntecedentesF.Text;
            anamnesesModel.HistoriaFamiliar = edHistoriaF.Text;
            anamnesesModel.Tratamento = edTratamento.Text;

            if (txtRegistroPaciente.Text == null && edqQueixaP.Text == null && edComoComecou.Text == null && edRepGradual.Text == null && edQueixasAfetivosEmocionais.Text == null 
                && edQueixasCognitivas.Text == null && edSaude.Text == null && edSintomas.Text == null &&
                 edTransformacoes.Text == null && edTratamento.Text == null && edVidaSocial.Text == null                
                )
            {
                Toast.MakeText(Android.App.Application.Context, "Por favor, preencha os campos!", ToastLength.Long).Show();

            }
            else
            {
                AnamneseBLL anamneseBLL = new AnamneseBLL();
                if (anamneseBLL.Incluir(anamnesesModel))
                {
                    Toast.MakeText(Android.App.Application.Context, "Anamnese do paciente registrada com sucesso!", ToastLength.Long).Show();
                    Navigation.PushAsync(new ConsultaAnamnesePage());

                }
                else
                {
                    Toast.MakeText(Android.App.Application.Context, "Houve um problema ao registrar a sessão, verifique os campos e tente novamente.", ToastLength.Long).Show();

                    txtRegistroPaciente.Text = string.Empty;
                   
                }

            }
        }
    }
}