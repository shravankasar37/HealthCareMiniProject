using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareMiniProject
{
    class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr; // Declare ConStr variable

        public Functions()
        {
            ConStr = @"Data Source=SHRAVAN_KASAR\SQLEXPRESS;Initial Catalog=HealthCareDB;Integrated Security=True;Encrypt=False";
            Cmd = new SqlCommand();
            Con = new SqlConnection(ConStr);
            Cmd.Connection = Con;
        }

        public DataTable GetData(String Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, Con); // Initialize SqlDataAdapter with Query and Connection
            sda.Fill(dt);
            return dt;
        }

        public int SetData(String Query)
        {
            int Cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            Cnt = Cmd.ExecuteNonQuery(); // Corrected the variable name to cnt
            Con.Close();
            return Cnt;
        }

    }
}
