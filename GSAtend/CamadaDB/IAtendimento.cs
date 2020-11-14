using GSAtend.CamadaNegocio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GSAtend.CamadaDB
{
    interface IAtendimento
    {
        public List<Atendimento> GetAllPacientes();
        public List<Atendimento> GetAtendimentosByCPF(string CPF);
        public void Add(Atendimento atendimento);
        public void Update(Atendimento atendimento);
        public void Delete(Atendimento atendimento);
        public void PreencheGrid(DataGridView dataGrid);
    }
}
