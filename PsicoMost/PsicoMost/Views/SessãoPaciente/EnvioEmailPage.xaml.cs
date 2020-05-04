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
    public partial class EnvioEmailPage : ContentPage
    {
        public EnvioEmailPage()
        {
            InitializeComponent();
        }

        //LEMBRETE DA SESSÃO
        public bool enviarLembrete(string NomeRemetente, string NomeDestinatario, string EmailRemetente, string EmailDestinatario, string Assunto, string Descricao, string valor, string data, string hora, string duracao)
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress(EmailRemetente, NomeRemetente);


                // Destinatario seta no metodo abaixo
                //Constroi o MailMessage
                _mailMessage.To.Add(EmailDestinatario);
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Subject = Assunto;
                _mailMessage.Body = "<span> Olá, </span>" +
                 "<span style=font-weight:bold;>" + NomeDestinatario + "." + "</span>" +
                 "<br>" +
                 "<span>" + "Segue as informações sobre a sua consulta com o(a) Psicólogo(a), " + NomeRemetente + "." + "</span>" +
                    "<br>" +
                    "<br>" +
                    "<span>" + "Descrição: " + Descricao + "</span>" +
                    "<br>" +
                    "<span>" + "Data da Sessão: " + data + "</span>" +
                    "<br>" +
                    "<span>" + "Horário da Sessão: " + hora + "</span>" +
                    "<br>" +
                    "<span>" + "Valor da Sessão: " + valor + "</span>" +
                    "<br>" +
                    "<span>" + "Duração da Sessão: " + duracao + "</span>" +
                    " <br>" +
                    " <br>" +
                     " <br>" +
                        "<span> Att, </span>" +
                        "<br>" +
                        "<span>" + "Psicólogo(a): " + NomeRemetente + "</span>" +
                        "<br>" +
                        "<span >" + " Email: " + EmailRemetente + " :) " + "</span>";



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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage n = ((NavigationPage)Application.Current.MainPage);
            n.BarBackgroundColor = Color.FromHex("#ff7400");
        }


        private void RoundedButton_Clicked_Enviar(object sender, EventArgs e)
        {

            Paciente pacientesModel = new Paciente();
            pacientesModel.Nome = txtNomePaciente.Text;
            pacientesModel.Email = txtEmailPaciente.Text;
            pacientesModel.NomePsicologoResponsavel = txtNomePsicologo.Text;
            pacientesModel.EmailPsicologo = txtEmailPsicologo.Text;

            Sessao sessaoModel = new Sessao();
            sessaoModel.Assunto = txtAssunto.Text;
            sessaoModel.Duracao = txtDuracao.Text;
            sessaoModel.DataSessao = txtDtSessao.Text;
            sessaoModel.HoraSessao = txtHoraSessao.Text;
            sessaoModel.DescricaoSessao = txtDescricaoS.Text;
            sessaoModel.ValorSessao = decimal.Parse(txtValorSessao.Text.ToString());

            string nomeR = txtNomePsicologo.Text;
            string emailR = txtEmailPsicologo.Text;
            string nomeD = txtNomePaciente.Text;
            string emailD = txtEmailPaciente.Text;
            string assunto = txtAssunto.Text;
            string duracao = txtDuracao.Text;
            string descricaoSessao = txtDescricaoS.Text;
            string ValorSessao = txtValorSessao.Text;
            string HoraSessao = txtHoraSessao.Text;
            string dataSessao = txtDtSessao.Text;


            SessaoBLL sessaoBLL = new SessaoBLL();
            if(!string.IsNullOrEmpty(nomeR) && !string.IsNullOrEmpty(emailR) && !string.IsNullOrEmpty(nomeD) && !string.IsNullOrEmpty(emailD)
                     && !string.IsNullOrEmpty(assunto) && !string.IsNullOrEmpty(duracao) &&
                    !string.IsNullOrEmpty(descricaoSessao) && !string.IsNullOrEmpty(ValorSessao) && !string.IsNullOrEmpty(HoraSessao) &&
                    !string.IsNullOrEmpty(dataSessao))
            {
                if (sessaoBLL.DadosEnvioLembrete(sessaoModel, pacientesModel))
                {

                    if (enviarLembrete(nomeR, nomeD, emailR, emailD, assunto, descricaoSessao, ValorSessao, HoraSessao, dataSessao, duracao))
                    {
                        Toast.MakeText(Android.App.Application.Context, "Email enviado com sucesso!", ToastLength.Long).Show();
                        Navigation.PushAsync(new ConsultaSessaoPage());
                    }
                    else
                    {
                        Toast.MakeText(Android.App.Application.Context, "Erro ao enviar email, verifique se o email é valido!", ToastLength.Long).Show();
                    }

                }
                else
                {
                    Toast.MakeText(Android.App.Application.Context, "Erro, contate o suporte para mais detalhes.", ToastLength.Long).Show();

                }
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, "Por favor, preencha os campos para o envio do lembrete.", ToastLength.Long).Show();

            }

        }
    }
}