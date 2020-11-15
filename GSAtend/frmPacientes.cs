using GSAtend.CamadaDB;
using GSAtend.CamadaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sirb.Documents.BR.Validation;

namespace GSAtend
{
    public partial class frmPacientes : Form
    {
        private Paciente paciente = new Paciente();
        private PacienteDB pacienteDB = new PacienteDB();
        public frmPacientes()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((txtcpf.Text != "   .   .   -") && (txtnome.Text != "") && (cbSexo.Text != ""))
            {
                paciente.CPF = Cpf.RemoveMask(txtcpf.Text);
                paciente.Nome = txtnome.Text;
                paciente.DataNascimento = Convert.ToDateTime(dtpdata.Text);
                paciente.Sexo = cbSexo.Text;
                pacienteDB.Add(paciente);
                pacienteDB.PreencheGrid(dgMedicos);
                btnNovo_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Favor preencher todos os campos!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
