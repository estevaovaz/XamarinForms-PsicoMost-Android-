using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using PsicoMost.BLL;
using PsicoMost.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views.Anamnese
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarAnamnesePage : ContentPage
    {
        string registroAnamnese = Utils.Settings.RegistroA;
        string registroPaciente = Utils.Settings.Registro;
        string crp = Utils.Settings.CRP;

        Anamneses anamneses;

        public EditarAnamnesePage()
        {
            InitializeComponent();
            CarregarDadosPessoais();
        }

        protected void CarregarDadosPessoais()
        {
            anamneses = new Anamneses();
            AnamneseBLL anamneseBLL = new AnamneseBLL();
            anamneses = anamneseBLL.ListarDadosCadastrais(registroAnamnese, registroPaciente);

            txtRegistroPaciente.Text = anamneses.RegistroPaciente;            
            edqQueixaP.Text = anamneses.QueixaPrincipal;
            edComoComecou.Text = anamneses.ComoComecou;
            edRepGradual.Text = anamneses.RepentinoOuGradual;
            edTransformacoes.Text = anamneses.Transformacao;
            edSintomas.Text = anamneses.Sintomas;
            edQueixasCognitivas.Text = anamneses.QueixasCognitivas;
            cboIntegridade.IsChecked = anamneses.IntSensorial;
            cboPercepcao.IsChecked = anamneses.Percepcao;
            cboAtencao.IsChecked = anamneses.Atencao;
            cboMemoria.IsChecked = anamneses.Memoria;
            edQueixasAfetivosEmocionais.Text = anamneses.QueixasAfetivoEmocionais;
            cboVolicao.IsChecked = anamneses.Volicao;
            cboAfeto.IsChecked = anamneses.Afeto;
            cboHumor.IsChecked = anamneses.Humor;
            cboAnsiedade.IsChecked = anamneses.Ansiedade;
            cboMedo.IsChecked = anamneses.Medo;
            cboCulpa.IsChecked = anamneses.Culpa;
            cboRaiva.IsChecked = anamneses.Raiva;
            cboPsicomotricidade.IsChecked = anamneses.Psicomotricidade;
            cboNormal.IsChecked = anamneses.Normal;
            cboLento.IsChecked = anamneses.Lento;
            cboAgitado.IsChecked = anamneses.Agitado;
            cboLuto.IsChecked = anamneses.Luto;
            cboDesanimo.IsChecked = anamneses.Desanimo;
            edHabitosRotinas.Text = anamneses.HabitosRotinas;
            edVidaSocial.Text = anamneses.VidaSocial;
            edSaude.Text = anamneses.ComoEstaASaude;
            edAntecedentesF.Text = anamneses.AntecedentesFamiliares;
            edHistoriaF.Text = anamneses.HistoriaFamiliar;
            edTratamento.Text = anamneses.Tratamento;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#2196F3");
        }

        private void RoundedButton_Clicked_Salvar(object sender, EventArgs e)
        {
            Anamneses anamnesesModel = new Anamneses();

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

            AnamneseBLL anamneseBLL = new AnamneseBLL();
            if (anamneseBLL.AtualizarAnamnese(anamnesesModel, registroAnamnese, crp))
            {
                Toast.MakeText(Android.App.Application.Context, "Dados editados com sucesso!", ToastLength.Long).Show();
                Navigation.PushAsync(new ConsultaAnamnesePage());
            }
            else
            {
            
                Toast.MakeText(Android.App.Application.Context, "Erro ao editar dados da anamnese.", ToastLength.Long).Show();

            }
        }
    }
}