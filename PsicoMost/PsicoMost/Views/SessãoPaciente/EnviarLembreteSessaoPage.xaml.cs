using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views.SessãoPaciente
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EnviarLembreteSessaoPage : ContentPage
	{
		public EnviarLembreteSessaoPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#ff7400");
        }


        private void RoundedButtonSessao_Clicked_SMS(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EnvioSMSPage());
        }

        private void RoundedButtonSessao_Clicked_EMAIL(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EnvioEmailPage());
        }
    }
}