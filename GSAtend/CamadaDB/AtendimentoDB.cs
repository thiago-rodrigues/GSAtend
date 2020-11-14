using Dapper;
using GSAtend.CamadaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
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
                            CPF = atendimento.Paciente
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
            throw new NotImplementedException();
        }

        public List<Atendimento> GetAllPacientes()
        {
            throw new NotImplementedException();
        }

        public List<Atendimento> GetAtendimentosByCPF(string CPF)
        {
            throw new NotImplementedException();
        }

        public List<Atendimento> GetAtendimentosByID(int Id)
        {
            throw new NotImplementedException();
        }

        public void PreencheGrid(DataGridView dataGrid)
        {
            throw new NotImplementedException();
        }

        public void Update(Atendimento atendimento)
        {
            string sql = "Update Atendimentos " +
                            "Set DataAtendimento=@DataNascimento, Descricao=@Descricao, CPF=@CPF " +
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
