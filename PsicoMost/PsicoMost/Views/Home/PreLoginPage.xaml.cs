using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views.Home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PreLoginPage : ContentPage
	{
		public PreLoginPage ()
		{
			InitializeComponent ();
           
		}

        private void RoundedButton_Clicked_Login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void RoundedButtonPsicologo_Clicked_Visitante(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisitantePage());
        }
    }
}