using Android.Widget;
using DevExpress.XamarinForms.DataGrid;
using PsicoMost.BLL;
using PsicoMost.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DadosPsicologoPage : ContentPage
    {

        public DadosPsicologoPage()
        {
            InitializeComponent();        
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromRgb(156, 39, 176);
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#009688");
        }

        private void GridPsicologo_Tap(object sender, DataGridGestureEventArgs e)
        {
          
            if (e.Item != null)
            {               
                Usuario usuario = new Usuario();
                usuario.Nome = gridPsicologo.GetCellDisplayText(e.RowHandle, "Nome");
                usuario.Senha = gridPsicologo.GetCellDisplayText(e.RowHandle, "Senha");
                usuario.Email = gridPsicologo.GetCellDisplayText(e.RowHandle, "Email");
                usuario.CRP = gridPsicologo.GetCellDisplayText(e.RowHandle, "CRP");

                PsicoMost.Utils.Settings.Nome = usuario.Nome;                       
                PsicoMost.Utils.Settings.Senha = usuario.Senha;                       
                PsicoMost.Utils.Settings.CRP = usuario.CRP;                       
                PsicoMost.Utils.Settings.Email = usuario.Email; 
                
                Navigation.PushAsync(new EditarPsicologoPage());
                   
            }
        }
      
    }
}