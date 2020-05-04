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
	public partial class DetalhesPacientePage : ContentPage
	{
        string crp = Utils.Settings.CRP;
        string rp = Utils.Settings.Registro;
        Paciente oPacienteModel;
        

		public DetalhesPacientePage ()
		{
			InitializeComponent();
            CarregarDadosPessoais();
		}


        protected void CarregarDadosPessoais()
        {
             oPacienteModel = new Paciente();           
            PacienteBLL pacientesBLL = new PacienteBLL();
            oPacienteModel = pacientesBLL.ListarDadosCadastrais(rp, crp);

            lblRegistro.Text = oPacienteModel.Registro;
            lblNome.Text = oPacienteModel.Nome;
            lblSobrenome.Text = oPacienteModel.Sobrenome;
            lblSexo.Text = oPacienteModel.Sexo;
            lblDtNascimento.Text = oPacienteModel.DtNascimento;
            lblEstadoCivil.Text = oPacienteModel.EstadoCivil;
            lblNacionalidade.Text = oPacienteModel.Nacionalidade;
            lblNaturalidade.Text = oPacienteModel.Naturalidade;
            lblSituacao.Text = oPacienteModel.Situacao;
            lblEmail.Text = oPacienteModel.Email;

            lblBairro.Text = oPacienteModel.Bairro;
            lblRua.Text = oPacienteModel.Rua;
            lblCep.Text = oPacienteModel.Cep;
            lblUF.Text = oPacienteModel.Estado;
            lblCidade.Text = oPacienteModel.Cidade;

            lblDDDRes.Text = oPacienteModel.DDDResidencial;
            lblTelResi.Text = oPacienteModel.TelResidencial;
            lblDDDCel.Text = oPacienteModel.DDDCelular;
            lblCel.Text = oPacienteModel.Celular;

        }

    }
}