using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_Management_System
{
   public  class DBhelper1 :IDisposable
    {

        private SqlConnection Connection { get; set; }
        private String ConnectionString = "Data Source=DESKTOP-300DOUA;Initial Catalog=UMS;Integrated Security=True";

        public DBhelper1()
        {
            try
            {
                this.Connection = new SqlConnection(ConnectionString);
                Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// This Function can be used for insert,delete and update.
        /// </summary>
        /// <param name="query">Query</param>
        /// <returns>If success True else False</returns>
        public bool ExecuteQuery(string query)
        {
            try
            {


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.Connection;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// This function works for select queries.
        /// </summary>
        /// <param name="query">string query</param>
        /// <returns>DataTable</returns>
        public DataTable GetRecords(string query)
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.Connection;
            cmd.CommandText = query;

            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);

            return dt;
        }

        public void Dispose()
        {
            if (this.Connection.State != ConnectionState.Closed)
                this.Connection.Close();
        }
    }
}

