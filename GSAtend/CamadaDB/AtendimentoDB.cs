using Dapper;
using GSAtend.CamadaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GSAtend.CamadaDB
{
    public class AtendimentoDB : IAtendimento
    {
        public void Add(Atendimento atendimento)
        {
            List<Atendimento> atendimentos = GetAtendimentosByID(atendimento.Id);
            if (atendimentos.Count == 0)
            {
                string sql = "Insert into Atendimentos " +
                               "(DataAtendimento, Descricao , CPF) " +
                               "values (@DataAtendimento, @Descricao, @CPF) ";
                try
                {
                    using (IDbConnection db = Conection.getConexao())
                    {
                        var affectedRows = db.Execute(sql, new
                        {
                            DataAtendimento = atendimento.DataAtendimento,
                            Descricao = atendimento.DescricaoAtendimento,
                            CPF = atendimento.Paciente.CPF
                        }); 
                    }
                    MessageBox.Show("Registro Inserido com sucesso!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar Inserir Atendimento!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Update(atendimento);
            }
        }

        public void Delete(Atendimento atendimento)
        {
            string sql = "Delete Atendimentos " +
                         "Where Id=@IdAtend ;";
            try
            {
                using (IDbConnection db = Conection.getConexao())
                {
                    db.Execute(sql, new { IdAtend = atendimento.Id });
                }
                MessageBox.Show("Registro Apagado com sucesso!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar apagar Atendimento!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
           

        public List<Atendimento> GetAtendimentosByCPF(string CPF)
        {
            string sql = "Select * From Atendimentos where CPF=@pacienteCPF ";
            List<Atendimento> atendimento = new List<Atendimento>();
            try
            {
                using (IDbConnection db = Conection.getConexao())
                {
                    return atendimento = db.Query<Atendimento>(sql, new { pacienteCPF = CPF }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar retornar Atendimentos!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return atendimento;
        }

        public List<Atendimento> GetAtendimentosByID(int Id)
        {
            string sql = "Select * From Atendimentos where Id=@IdAtend ";
            List<Atendimento> atendimentos = new List<Atendimento>();
            try
            {
                using (IDbConnection db = Conection.getConexao())
                {
                    return atendimentos = db.Query<Atendimento>(sql, new {IdAtend = Id}).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar retornar Atendimento!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return atendimentos;
        }

        public void PreencheGrid(DataGridView dataGrid, string cpf)
        {
            string sql = "Select * From Atendimentos where CPF=@pacienteCPF ";
            List<Atendimento> atendimento = new List<Atendimento>();
            try
            {
                using (IDbConnection db = Conection.getConexao())
                {
                    dataGrid.Rows.Clear();
                    var datareader = db.ExecuteReader(sql, new {pacienteCPF = cpf});
                    while (datareader.Read())
                    {
                        string[] MyArray = new string[3];
                        MyArray[0] = datareader.GetInt32(datareader.GetOrdinal("Id")).ToString();                        
                        MyArray[1] = datareader.GetDateTime(datareader.GetOrdinal("DataAtendimento")).ToShortDateString();
                        MyArray[2] = datareader.GetString(datareader.GetOrdinal("Descricao"));

                        dataGrid.Rows.Add();
                        dataGrid.Rows[dataGrid.RowCount - 1].SetValues(MyArray);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar retornar Atendimentos!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        public void Update(Atendimento atendimento)
        {
            string sql = "Update Atendimentos " +
                            "Set DataAtendimento=@DataAtendimento, Descricao=@Descricao, CPF=@CPF " +
                         "Where Id=@Id ;";
            try
            {
                using (IDbConnection db = Conection.getConexao())
                {
                    var affectedRows = db.Execute(sql, new
                    {
                        DataAtendimento = atendimento.DataAtendimento,
                        Descricao = atendimento.DescricaoAtendimento,
                        CPF = atendimento.Paciente.CPF,
                        Id = atendimento.Id
                    });
                }
                MessageBox.Show("Registro Atualizado com sucesso!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar Atualizar Paciente!\n" + ex, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
