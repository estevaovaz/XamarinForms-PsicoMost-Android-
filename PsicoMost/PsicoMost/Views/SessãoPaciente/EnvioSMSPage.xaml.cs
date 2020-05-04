using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views.SessãoPaciente
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnvioSMSPage : ContentPage
    {
        public EnvioSMSPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#ff7400");
        }

        private async void RoundedButtonSessao_Clicked(object sender, EventArgs e)
        {

            if (editMsg.Text == null && txtNumero.Text == null)
            {
                Toast.MakeText(Android.App.Application.Context, "Por favor, preencha os campos!", ToastLength.Long).Show();
                editMsg.Text = string.Empty;
                txtNumero.Text = string.Empty;
            }
            else
            {

                await Sms.ComposeAsync(new SmsMessage(editMsg.Text, txtNumero.Text));
            }
        }
    }
}