using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GSAtend
{
    public static class Conection
    {
        private static SqlConnection con;              

        public static SqlConnection getConexao()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["GSAtend"].ToString());
            try
            {  
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    return con;
                }
                else
                {
                    return con;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao tentar recuperar conexao!!\n" + e, "Erro de Conexao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
    }
}
