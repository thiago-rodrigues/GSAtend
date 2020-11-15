using GSAtend.CamadaDB;
using GSAtend.CamadaNegocio;
using Sirb.Documents.BR.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GSAtend
{
    public partial class frmAtendimentos : Form
    {
        private PacienteDB pacienteDB = new PacienteDB();
        private Paciente paciente = new Paciente();
        private Atendimento atendimento = new Atendimento();
        private AtendimentoDB atendimentoDB = new AtendimentoDB();

        public frmAtendimentos()
        {
            InitializeComponent();
        }

        private void txtcpf_Leave(object sender, EventArgs e)
        {
            if (!Cpf.IsValid(txtcpf.Text) && (txtcpf.Text != "   .   .   -"))
            {
                txtcpf.Text = "";
                MessageBox.Show("CPF Inválido!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcpf.Focus();
            }
            else
            {
                List<Paciente> pacientes = pacienteDB.GetPacientesByCPF(Cpf.RemoveMask(txtcpf.Text));
                if (pacientes.Count > 0)
                {
                    txtnome.Text = pacientes[0].Nome;
                    atendimentoDB.PreencheGrid(dgAtendimentos, Cpf.RemoveMask(txtcpf.Text));                    
                }
                else if (txtcpf.Text != ("   .   .   -"))
                {
                    txtcpf.Text = "";
                    txtnome.Text = "";
                    MessageBox.Show("Paciente não cadastrado!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcpf.Focus();
                }
            }
        }        
    }
}
