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
	public partial class ConsultaAnamnesePage : ContentPage
	{

        public string rp;
        public string ra;
        public string crp = PsicoMost.Utils.Settings.CRP;

        public ConsultaAnamnesePage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#2196F3");
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#009688");
        }

        private async void OnAlertYesNoClicked()
        {

            PsicoMost.Utils.Settings.Registro = rp;
            PsicoMost.Utils.Settings.RegistroA = ra;

            bool resp = await DisplayAlert("Atenção", "Deseja realmente excluir a anamnese?", "Confirmar", "Cancelar");

            if (resp == true)
            {
                AnamneseBLL anamneseBLL = new AnamneseBLL();
                if (anamneseBLL.ExcluirAnamnese(ra, rp, crp))
                {

                    Toast.MakeText(Android.App.Application.Context, "Anamnese excluida com sucesso!", ToastLength.Long).Show();
                    await Navigation.PushAsync(new ConsultaAnamnesePage());
                }
                else
                {
                    Toast.MakeText(Android.App.Application.Context, "Houve um erro ao excluir a anamnese!", ToastLength.Long).Show();
                }
            }
            else
            {
                await Navigation.PushAsync(new ConsultaAnamnesePage());
            }


        }


        private void GridAnamnese_Tap(object sender, DevExpress.XamarinForms.DataGrid.DataGridGestureEventArgs e)
        {
            Anamneses anamneses = new Anamneses();
            anamneses.RegistroPaciente = gridAnamnese.GetCellDisplayText(e.RowHandle, "Nº.P");
            anamneses.RegistroAnamnese = gridAnamnese.GetCellDisplayText(e.RowHandle, "Nº.A");

            PsicoMost.Utils.Settings.Registro = anamneses.RegistroPaciente;
            PsicoMost.Utils.Settings.RegistroA = anamneses.RegistroAnamnese;
         
            Navigation.PushAsync(new DetalhesAnamnesePage());
        }

        private void SwipeItem_Tap_Edit(object sender, DevExpress.XamarinForms.DataGrid.SwipeItemTapEventArgs e)
        {
            if (e.Item != null)
            {
                Paciente paciente = new Paciente();
                Anamneses anamneses = new Anamneses();
                paciente.CRP = crp;
                anamneses.RegistroPaciente = gridAnamnese.GetCellDisplayText(e.RowHandle, "Nº.P");
                anamneses.RegistroAnamnese = gridAnamnese.GetCellDisplayText(e.RowHandle, "Nº.A");

                PsicoMost.Utils.Settings.Registro = anamneses.RegistroPaciente;
                PsicoMost.Utils.Settings.RegistroA = anamneses.RegistroAnamnese;

                Navigation.PushAsync(new EditarAnamnesePage());
            }
           
        }

        private void SwipeItem_Tap_Delete(object sender, DevExpress.XamarinForms.DataGrid.SwipeItemTapEventArgs e)
        {

            if (e.Item != null)
            {
                Anamneses anamneses = new Anamneses();
                anamneses.RegistroPaciente = gridAnamnese.GetCellDisplayText(e.RowHandle, "Nº.P");
                anamneses.RegistroAnamnese = gridAnamnese.GetCellDisplayText(e.RowHandle, "Nº.A");

                PsicoMost.Utils.Settings.CRP = crp;
                PsicoMost.Utils.Settings.Registro = anamneses.RegistroPaciente;
                PsicoMost.Utils.Settings.RegistroA = anamneses.RegistroAnamnese;

                OnAlertYesNoClicked();
            }
        }

        private void ToolbarItem_Clicked_Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdicionarAnamnesePage());
        }
    }
}