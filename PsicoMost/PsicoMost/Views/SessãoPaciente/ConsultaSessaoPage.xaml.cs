using Android.Widget;
using PsicoMost.BLL;
using PsicoMost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views.SessãoPaciente
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaSessaoPage : ContentPage
	{

        public string rp;
        public string rs;
        public string crp = PsicoMost.Utils.Settings.CRP;


        public ConsultaSessaoPage ()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#ff7400");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#009688");
        }

        private void GridSessao_Tap(object sender, DevExpress.XamarinForms.DataGrid.DataGridGestureEventArgs e)
        {
    
            Sessao sessao = new Sessao();
            sessao.RegistroPaciente = gridSessao.GetCellDisplayText(e.RowHandle, "Nº.P");
            sessao.RegistroSessao = gridSessao.GetCellDisplayText(e.RowHandle, "Nº.S");

            PsicoMost.Utils.Settings.Registro = sessao.RegistroPaciente;
            PsicoMost.Utils.Settings.RegistroS = sessao.RegistroSessao;

            Navigation.PushAsync(new DetalhesSessaoPage());
        }

        private void ToolbarItem_Clicked_Adicionar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdicionarSessaoPage());
        }

        private async void OnAlertYesNoClicked()
        {

            PsicoMost.Utils.Settings.Registro = rp;
            PsicoMost.Utils.Settings.RegistroS = rs;

            bool resp = await DisplayAlert("Atenção", "Deseja realmente excluir a sessão?", "Confirmar", "Cancelar");

            if (resp == true)
            {
                SessaoBLL sessaoBLL = new SessaoBLL();
                if (sessaoBLL.ExcluirSessao(rs, rp, crp))
                {
                   
                    Toast.MakeText(Android.App.Application.Context, "Sessão excluida com sucesso!", ToastLength.Long).Show();
                    await Navigation.PushAsync(new ConsultaSessaoPage());
                }
                else
                {
                    Toast.MakeText(Android.App.Application.Context, "Houve um erro ao excluir a sessão!", ToastLength.Long).Show();
                }
            }
            else
            {
                await Navigation.PushAsync(new ConsultaSessaoPage());
            }


        }

        private void SwipeItem_Tap_Edit(object sender, DevExpress.XamarinForms.DataGrid.SwipeItemTapEventArgs e)
        {
            if (e.Item != null)
            {
                Paciente paciente = new Paciente();
                Sessao sessao = new Sessao();
                paciente.CRP = crp;
                sessao.RegistroPaciente = gridSessao.GetCellDisplayText(e.RowHandle, "Nº.P");
                sessao.RegistroSessao = gridSessao.GetCellDisplayText(e.RowHandle, "Nº.S");

                PsicoMost.Utils.Settings.Registro = sessao.RegistroPaciente;
                PsicoMost.Utils.Settings.RegistroS = sessao.RegistroSessao;
                
                Navigation.PushAsync(new EditarSessaoPage());
            }
        }

        private void SwipeItem_Tap_Delete(object sender, DevExpress.XamarinForms.DataGrid.SwipeItemTapEventArgs e)
        {
            if (e.Item != null)
            {
                Sessao sessao = new Sessao();
                sessao.RegistroPaciente = gridSessao.GetCellDisplayText(e.RowHandle, "Nº.P");
                sessao.RegistroSessao = gridSessao.GetCellDisplayText(e.RowHandle, "Nº.S");

                PsicoMost.Utils.Settings.CRP = crp;
                PsicoMost.Utils.Settings.Registro = sessao.RegistroPaciente;
                PsicoMost.Utils.Settings.RegistroS = sessao.RegistroSessao;

                OnAlertYesNoClicked();
            }
        }

        private void ToolbarItem_Clicked_Lembrete(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EnviarLembreteSessaoPage());
        }
    }
}