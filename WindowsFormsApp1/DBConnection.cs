using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class DBConnection
    {
        public string DBCon(String qry)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Project\WindowsFormsApp1\DatabaseCP.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "Operation Performed Successfully!";
            }

            catch(SqlException se)
            {
                return "Operation Failed - Error " + se;
            }

            finally
            {
                con.Close();
            }
        }
    }
}
