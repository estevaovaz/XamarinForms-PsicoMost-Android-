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
	public partial class AdicionarPacientePage : ContentPage
	{
		public AdicionarPacientePage ()
		{
			InitializeComponent();
		}

        private void RoundedButton_Clicked_Salvar(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente();
            paciente.NomePsicologoResponsavel = txtNomePsicologo.Text;
            paciente.CRP = txtCRPpsicologo.Text;
            paciente.Nome = txtNome.Text;
            paciente.Sobrenome = txtSobrenome.Text;
            paciente.CPF = txtCPF.Text;
            paciente.Idade = txtIdade.Text;
            paciente.Estado = pcEstado.SelectedItem.ToString();
            paciente.DtNascimento = txtDtNascimento.Text;
            paciente.Sexo = txtNomePsicologo.Text;
            paciente.EstadoCivil = pcEstadoCivil.SelectedItem.ToString();
            paciente.Nacionalidade = txtNacionalidade.Text;
            paciente.Naturalidade = txtNaturalidade.Text;
            paciente.Email = txtEmail.Text;
            paciente.EmailPsicologo = txtEmailPsicologo.Text;
            paciente.Cidade = txtCidade.Text;
            paciente.Bairro = txtBairro.Text;
            paciente.Rua = txtRua.Text;
            paciente.Cep = txtCep.Text;
            paciente.DDDResidencial = pcDDDResi.SelectedItem.ToString();
            paciente.TelResidencial = txtResidencial.Text;
            paciente.DDDCelular = pcDDDCel.SelectedItem.ToString();
            paciente.Celular = txtCelular.Text;
            paciente.Situacao = "ATIVO(A)";

            PacienteBLL pacienteBLL = new PacienteBLL();
            if (pacienteBLL.Incluir(paciente))
            {
                if (txtNomePsicologo.Text == "" && txtCRPpsicologo.Text == "" && txtNome.Text == "" && txtSobrenome.Text == "" && pcEstado.SelectedItem.ToString() == "" && txtCPF.Text == "" && txtIdade.Text == "")
                {
                    Toast.MakeText(Android.App.Application.Context, "Por favor, preencha os campos!", ToastLength.Long).Show();

                }
                else
                {

                    Toast.MakeText(Android.App.Application.Context, "Paciente registrado com sucesso!", ToastLength.Long).Show();
                    Navigation.PushAsync(new ConsultaPacientePage());
                }
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, "Houve um problema ao registrar o paciente, verifique os campos e tente novamente.", ToastLength.Long).Show();

                txtNomePsicologo.Text = string.Empty;
                txtCRPpsicologo.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtSobrenome.Text = string.Empty;
                txtCPF.Text = string.Empty;
                txtIdade.Text = string.Empty;
                txtResidencial.Text = string.Empty;
                pcEstado.SelectedItem = string.Empty;
                txtDtNascimento.Text = string.Empty;
                pcSexo.SelectedItem = string.Empty;
                pcEstadoCivil.SelectedItem = string.Empty;
                txtNacionalidade.Text = string.Empty;
                txtNaturalidade.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtEmailPsicologo.Text = string.Empty;
                txtBairro.Text = string.Empty;
                txtRua.Text = string.Empty;
                txtCep.Text = string.Empty;
                txtCidade.Text = string.Empty;
                pcDDDResi.SelectedItem = string.Empty;
                pcDDDCel.SelectedItem = string.Empty;
                txtCelular.Text = string.Empty;
            }
        }
       
    }
}