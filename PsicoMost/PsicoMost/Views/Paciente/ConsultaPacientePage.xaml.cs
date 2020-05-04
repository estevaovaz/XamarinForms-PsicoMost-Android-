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

namespace PsicoMost.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaPacientePage : ContentPage
    {

        public string rp;
        public string crp = PsicoMost.Utils.Settings.CRP;


        public ConsultaPacientePage()
        {
            InitializeComponent();
        }


        private void GridPaciente_Tap(object sender, DevExpress.XamarinForms.DataGrid.DataGridGestureEventArgs e)
        {
            Paciente paciente = new Paciente();
            paciente.Registro = gridPaciente.GetCellDisplayText(e.RowHandle, "Registro");
            PsicoMost.Utils.Settings.Registro = paciente.Registro;

            Navigation.PushAsync(new DetalhesPacientePage());
        }


        private void ToolbarItem_Clicked_Adicionar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdicionarPacientePage());
        }

        private void SwipeItem_Tap_Edit(object sender, DevExpress.XamarinForms.DataGrid.SwipeItemTapEventArgs e)
        {
            if (e.Item != null)
            {
                Paciente paciente = new Paciente();
                paciente.CRP = crp;
                paciente.Registro = gridPaciente.GetCellDisplayText(e.RowHandle, "Registro");

                //PsicoMost.Utils.Settings.CRP = paciente.CRP;
                PsicoMost.Utils.Settings.Registro = paciente.Registro;

                Navigation.PushAsync(new EditarPacientePage());
            }
        }

        private async void OnAlertYesNoClicked()
        {
           
            //PsicoMost.Utils.Settings.CRP = crp;
            PsicoMost.Utils.Settings.Registro = rp;

            bool resp = await DisplayAlert("Atenção", "Deseja realmente excluir o paciente?", "Confirmar", "Cancelar");

            if(resp == true)
            {
                PacienteBLL pacienteBLL = new PacienteBLL();
                if (pacienteBLL.ExcluirRegistro(rp, crp))
                {
                    Toast.MakeText(Android.App.Application.Context, "Paciente excluido com sucesso!", ToastLength.Long).Show();
                    await Navigation.PushAsync(new ConsultaPacientePage());
                }
                else
                {
                    Toast.MakeText(Android.App.Application.Context, "Houve um erro ao excluir o paciente!", ToastLength.Long).Show();
                }
            }
            else
            {
                await Navigation.PushAsync(new ConsultaPacientePage());
            }
            
            
        }

        private void SwipeItem_Tap_Delete(object sender, DevExpress.XamarinForms.DataGrid.SwipeItemTapEventArgs e)
        {
            if (e.Item != null)
            {
 
                rp = gridPaciente.GetCellDisplayText(e.RowHandle, "Registro");

                PsicoMost.Utils.Settings.CRP = crp;
                PsicoMost.Utils.Settings.Registro = rp;

                OnAlertYesNoClicked();
            }
        }
    }
}