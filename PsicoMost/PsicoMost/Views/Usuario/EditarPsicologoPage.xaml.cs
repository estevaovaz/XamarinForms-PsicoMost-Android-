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
	public partial class EditarPsicologoPage : ContentPage
	{
		public EditarPsicologoPage ()
		{
			InitializeComponent();

            txtNome.Text = Utils.Settings.Nome;
            txtSenha.Text = Utils.Settings.Senha;
            txtCRP.Text = Utils.Settings.CRP;
            txtEmail.Text = Utils.Settings.Email;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromRgb(156, 39, 176);
        }

        private void RoundedButton_Clicked_Salvar(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = txtNome.Text;
            usuario.Senha = txtSenha.Text;
            usuario.CRP = txtCRP.Text;
            usuario.Email = txtEmail.Text;

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            if (usuarioBLL.EditarPsicologo(usuario))
            {
                Toast.MakeText(Android.App.Application.Context, "Dados editados com sucesso!", ToastLength.Long).Show();
                Navigation.PushAsync(new DadosPsicologoPage());
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, "Erro ao editar dados do psicólogo.", ToastLength.Long).Show();
                txtNome.Text = string.Empty;
                txtSenha.Text = string.Empty;
                txtCRP.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }

        }
    }
}