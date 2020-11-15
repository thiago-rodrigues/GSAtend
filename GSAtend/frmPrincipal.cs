using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSAtend.CamadaDB;
using GSAtend.CamadaNegocio;
using Sirb.Documents.BR.Validation;

namespace GSAtend
{
    public partial class frmPrincipal : Form
    {        
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void mnuPaciente_Click(object sender, EventArgs e)
        {
            frmPacientes formPaciente = new frmPacientes();
            formPaciente.ShowDialog(this);
        }

        private void mnuAtendimento_Click(object sender, EventArgs e)
        {
            frmAtendimentos formAtendimentos = new frmAtendimentos();
            formAtendimentos.ShowDialog(this);
        }        
    }
}
