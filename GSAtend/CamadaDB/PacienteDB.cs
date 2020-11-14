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
            List<Paciente> pacientes = GetPacientesByCPF(paciente.CPF);
            if (pacientes.Count == 0)
            {
                string sql = "Insert into Pacientes " +
                               "(CPF, Nome, DataNascimento , Sexo) " +
                               "values (@CPF, @Nome, @DataNascimento, @Sexo) ";
                try
                {
                    using (IDbConnection db = Conection.getConexao())
                    {
                        var affectedRows = db.Execute(sql, new
                        {
                            Nome = paciente.Nome,
                            DataNascimento = paciente.DataNascimento,
                            Sexo = paciente.Sexo,
                            CPF = paciente.CPF
                        });
                    }
                    MessageBox.Show("Registro Inserido com sucesso!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar Inserir Paciente!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Update(paciente);
            }
        }

        public void Delete(Paciente paciente)
        {
            string sql = "Delete Pacientes " +                           
                         "Where CPF=@CPF ;";
            try
            {
                using (IDbConnection db = Conection.getConexao())
                {
                    var affectedRows = db.Execute(sql, new {CPF = paciente.CPF});
                }
                MessageBox.Show("Registro Apagado com sucesso!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar Atualizar Paciente!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            string sql = "Select * From Pacientes where CPF=@pacienteCPF ";
            List<Paciente> paciente = new List<Paciente>();
            try
            {
                using (IDbConnection db = Conection.getConexao())
                {
                    return paciente = db.Query<Paciente>(sql, new { pacienteCPF = CPF }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar retornar Pacientes!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return paciente;
        }

        public void Update(Paciente paciente)
        {
            string sql = "Update Pacientes " +
                            "Set Nome=@Nome, DataNascimento=@DataNascimento, Sexo=@Sexo " +
                         "Where CPF=@CPF ;";
            try
            {
                using (IDbConnection db = Conection.getConexao())
                {
                    var affectedRows = db.Execute(sql, new
                    {
                        Nome = paciente.Nome,
                        DataNascimento = paciente.DataNascimento,
                        Sexo = paciente.Sexo,
                        CPF = paciente.CPF
                    });
                }
                MessageBox.Show("Registro Atualizado com sucesso!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar Atualizar Paciente!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PreencheGrid(DataGridView dataGrid)
        {
            string sql = "Select * From Pacientes;";            
            try
            {
                using (IDbConnection db = Conection.getConexao())
                {
                    dataGrid.Rows.Clear();
                    var datareader = db.ExecuteReader(sql);
                    while (datareader.Read())
                    {
                        string[] MyArray = new string[4];
                        MyArray[0] = datareader.GetString(datareader.GetOrdinal("CPF"));
                        MyArray[1] = datareader.GetString(datareader.GetOrdinal("Nome"));
                        MyArray[2] = datareader.GetDateTime(datareader.GetOrdinal("DataNascimento")).ToShortDateString();
                        MyArray[3] = datareader.GetString(datareader.GetOrdinal("Sexo"));

                        dataGrid.Rows.Add();
                        dataGrid.Rows[dataGrid.RowCount - 1].SetValues(MyArray);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar retornar Pacientes!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
