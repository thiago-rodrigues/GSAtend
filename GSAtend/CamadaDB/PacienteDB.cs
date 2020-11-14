using Dapper;
using GSAtend.CamadaNegocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSAtend.CamadaDB
{
    public class PacienteDB : IPaciente
    {
        public void Add(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public void Delete(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> GetAllPacientes()
        {
            string sql = "Select * From Pacientes ";
            List<Paciente> paciente = new List<Paciente>();
            try
            {
                using (IDbConnection db = Conection.getConexao())
                {
                    return paciente = db.Query<Paciente>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar retornar lista de pacientes!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return paciente;
        }

        public List<Paciente> GetPacientesByCPF(string CPF)
        {
            throw new NotImplementedException();
        }

        public void Update(Paciente paciente)
        {
            throw new NotImplementedException();
        }
    }
}
