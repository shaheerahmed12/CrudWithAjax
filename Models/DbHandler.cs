using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using singlePage.Models;

namespace singlePage.Models
{
    public class DbHandler
    {
        Connection connection = new Connection();

        public List<Employee> ListAll() {
            {
                var con = connection.con;
                List<Employee> lst = new List<Employee>();

                using (con)
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("GetAll", con);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new Employee
                        {
                            Id = Convert.ToInt32(rdr["emp_Id"]),
                            FirstName = rdr["emp_firstname"].ToString(),
                            LastName = rdr["emp_lastname"].ToString(),
                            Address = rdr["emp_address"].ToString(),
                          
                        });
                    }

                    return lst;

                }
                
            }
        }

        public int Add(Employee emp)
        {
            int i;
            Connection connection = new Connection();
            var con = connection.con;

            using (con)
            {
                con.Open();
                SqlCommand com = new SqlCommand("Addded", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", "");
                com.Parameters.AddWithValue("@Name", emp.FirstName);
                com.Parameters.AddWithValue("@LastName", emp.LastName);
                com.Parameters.AddWithValue("@Address", emp.Address);
                
                i = com.ExecuteNonQuery();
                
                return i;
            }

        }
        public int Update(Employee emp)
        {
            Connection connection = new Connection();
            var con = connection.con;
            int i;
            using (con)
            {
                con.Open();
                SqlCommand com = new SqlCommand("Updated", con);
                
                com.Parameters.AddWithValue("@Name", emp.FirstName);
                com.Parameters.AddWithValue("@LastName", emp.LastName);
                com.Parameters.AddWithValue("@Address", emp.Address);
                i= com.ExecuteNonQuery();
            }


            return i;


        }
    }
}