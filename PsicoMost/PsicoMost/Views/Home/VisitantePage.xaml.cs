using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsicoMost.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VisitantePage : ContentPage
	{
		public VisitantePage ()
		{
			InitializeComponent ();
		}

        public bool SendMail()
        {

            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("sgcppsicologo@gmail.com", "Psico Most");


                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.To.Add("sgcppsicologo@gmail.com");
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Subject = "Solicitacao de Usuario Free Trial ";
                _mailMessage.Body = "<span> Gostaria de um usuario de teste </span>" +
                 "<br>" +
                    "<br>" +                   
                     "<span>" + "Nome do Usuario: " + txtNome.Text + "</span>" +
                     "<br>" +
                     "<br>" +
                    "<span>" + "Email do Usuario: " + txtEmail.Text + "</span>" +
                    "<br>" +
                     " <br>";

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587);

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("sgcppsicologo@gmail.com", "SGCP1141");
                _smtpClient.EnableSsl = true;


                _smtpClient.Send(_mailMessage);

                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro ao enviar email", ex.Message);
                return false;

            }
        }


        private void RoundedButton_Clicked_ENVIAR(object sender, EventArgs e)
        {
            if (ValidarPreenchimento())
            {
                if (SendMail())
                {
                    Toast.MakeText(Android.App.Application.Context, "O suporte irá enviar dados de acesso para seu email.", ToastLength.Long).Show();
                    Navigation.PushAsync(new LoginPage());
                }
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, "Este email é inválido.", ToastLength.Long).Show();
            }

        }

        private bool ValidarPreenchimento()
        {

            if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtNome.Text))
            {
                Toast.MakeText(Android.App.Application.Context, "Por favor preencha os campos.", ToastLength.Long).Show();

                return false;

            }
            else
            {

                return true;
            }

        }
    }
}