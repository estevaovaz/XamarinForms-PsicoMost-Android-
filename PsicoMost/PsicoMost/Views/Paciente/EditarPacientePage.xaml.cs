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
	public partial class EditarPacientePage : ContentPage
	{
        public string crp = Utils.Settings.CRP;
        string rp = Utils.Settings.Registro;
        Paciente oPacienteModel;

		public EditarPacientePage ()
		{
			InitializeComponent();
            CarregarDadosPessoais();

        }


        protected void CarregarDadosPessoais()
        {
            oPacienteModel = new Paciente();
            PacienteBLL pacientesBLL = new PacienteBLL();
            oPacienteModel = pacientesBLL.ListarDadosCadastrais(rp, crp);

            txtNome.Text = oPacienteModel.Nome;
            txtSobrenome.Text = oPacienteModel.Sobrenome;         
            txtCPF.Text = oPacienteModel.CPF;
            txtIdade.Text = oPacienteModel.Idade;
            pcSexo.SelectedItem = oPacienteModel.Sexo;
            txtDtNascimento.Text = oPacienteModel.DtNascimento;
            pcEstadoCivil.SelectedItem = oPacienteModel.EstadoCivil;
            txtNacionalidade.Text = oPacienteModel.Nacionalidade;
            txtNaturalidade.Text = oPacienteModel.Naturalidade;
            pcSit.SelectedItem = oPacienteModel.Situacao;
            txtEmail.Text = oPacienteModel.Email;

            txtBairro.Text = oPacienteModel.Bairro;
            txtRua.Text = oPacienteModel.Rua;
            txtCep.Text = oPacienteModel.Cep;
            pcEstado.SelectedItem = oPacienteModel.Estado;
            txtCidade.Text = oPacienteModel.Cidade;

            pcDDDResi.SelectedItem = oPacienteModel.DDDResidencial;
            txtResidencial.Text = oPacienteModel.TelResidencial;
            pcDDDCel.SelectedItem = oPacienteModel.DDDCelular;
            txtCelular.Text = oPacienteModel.Celular;

        }


        private void RoundedButton_Clicked_Salvar(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente();            
            paciente.Nome = txtNome.Text;
            paciente.Sobrenome = txtSobrenome.Text;
            paciente.CPF = txtCPF.Text;
            paciente.Idade = txtIdade.Text;
            paciente.Estado = pcEstado.SelectedItem.ToString();
            paciente.DtNascimento = txtDtNascimento.Text;           
            paciente.EstadoCivil = pcEstadoCivil.SelectedItem.ToString();
            paciente.Nacionalidade = txtNacionalidade.Text;
            paciente.Naturalidade = txtNaturalidade.Text;
            paciente.Email = txtEmail.Text;
            paciente.Cidade = txtCidade.Text;
            paciente.Bairro = txtBairro.Text;
            paciente.Rua = txtRua.Text;
            paciente.Cep = txtCep.Text;
            paciente.DDDResidencial = pcDDDResi.SelectedItem.ToString();
            paciente.TelResidencial = txtResidencial.Text;
            paciente.DDDCelular = pcDDDCel.SelectedItem.ToString();
            paciente.Celular = txtCelular.Text;
            paciente.Situacao = pcSit.SelectedItem.ToString();

            PacienteBLL pacienteBLL = new PacienteBLL();
            if (pacienteBLL.EditarPaciente(paciente, rp, crp))
            {
                Toast.MakeText(Android.App.Application.Context, "Dados editados com sucesso!", ToastLength.Long).Show();
                Navigation.PushAsync(new ConsultaPacientePage());
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, "Erro ao editar dados do psicólogo.", ToastLength.Long).Show();               
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