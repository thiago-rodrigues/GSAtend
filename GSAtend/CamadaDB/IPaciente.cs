using GSAtend.CamadaNegocio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSAtend.CamadaDB
{
    interface IPaciente
    {
        public List<Paciente> GetAllPacientes();
        public List<Paciente> GetPacientesByCPF(string CPF);
        public void Add(Paciente paciente);
        public void Update(Paciente paciente);
        public void Delete(Paciente paciente);
        public void PreencheGrid(DataGridView dataGrid);
    }
}
