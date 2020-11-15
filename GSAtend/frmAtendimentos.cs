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
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((txtcpf.Text != "   .   .   -") && (txtnome.Text != "") && (txtdescricao.Text != ""))
            {
                atendimento.Id = txtId.Text == "" ? 0 : Convert.ToInt32(txtId.Text);
                atendimento.DataAtendimento = dtData.Value;
                atendimento.DescricaoAtendimento = txtdescricao.Text;
                paciente.CPF = Cpf.RemoveMask(txtcpf.Text);
                paciente.Nome = txtnome.Text;
                atendimento.Paciente = paciente;
                atendimentoDB.Add(atendimento);
                atendimentoDB.PreencheGrid(dgAtendimentos, paciente.CPF);
                txtId.Text = "";
                txtdescricao.Text = "";
            }
            else
            {
                MessageBox.Show("Favor preencher todos os campos!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtcpf.Text = "";
            txtnome.Text = "";
            dtData.Value = DateTime.Today;
            txtId.Text = "";
            txtdescricao.Text = "";
            dgAtendimentos.Rows.Clear();
            txtcpf.Focus();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if ((txtId.Text != "") && txtcpf.Text != "   .   .   -")
            {
                if (MessageBox.Show("Tem certeza que deseja excluir este registro???", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    atendimento.Id = Convert.ToInt32(txtId.Text);
                    atendimentoDB.Delete(atendimento);
                    atendimentoDB.PreencheGrid(dgAtendimentos, Cpf.RemoveMask(txtcpf.Text));
                    txtId.Text = "";
                    txtdescricao.Text = "";
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
