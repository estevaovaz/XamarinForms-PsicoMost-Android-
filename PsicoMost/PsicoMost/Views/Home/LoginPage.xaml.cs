using Android.Widget;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using PsicoMost.BLL;
using PsicoMost.Models;
using PsicoMost.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
      
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
            txtCRP.Focus();

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecuperarSenhaPage());
        }

     
        public void RoundedButton_Clicked_Login(object sender, EventArgs e)
        {

            if (ValidarLogin())
            {

                Usuario usuario = new Usuario();
                usuario.CRP = txtCRP.Text;
                usuario.Senha = txtSenha.Text;                
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                if (usuarioBLL.LogarUsuario(usuario))
                {
                    if (usuario.Ativo == "NAO")
                    {
                        txtCRP.Text = string.Empty;
                        txtSenha.Text = string.Empty;
                        txtCRP.Focus();
                        Toast.MakeText(Android.App.Application.Context, "Seus dados não estão ativo, consulte o suporte para verificar sua situação.", ToastLength.Long).Show();
                        return;
                    }
                    else
                    {
                        PsicoMost.Utils.Settings.CRP = usuario.CRP;
                        PsicoMost.Utils.Settings.Senha = usuario.Senha;                        
                        Navigation.PushAsync(new MenuPage());
                    }
                }
                else
                {
                    Toast.MakeText(Android.App.Application.Context, "CRP do usuário e/ou senha estão incorretos(s).", ToastLength.Long).Show();

                }

            }
        }

        private bool ValidarLogin()
        {

            if (String.IsNullOrEmpty(txtCRP.Text))
            {
                Toast.MakeText(Android.App.Application.Context, "Digite seu CRP", ToastLength.Long).Show();

                return false;
            }
            else if (String.IsNullOrEmpty(txtSenha.Text))
            {
                Toast.MakeText(Android.App.Application.Context, "Digite sua Senha", ToastLength.Long).Show();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}