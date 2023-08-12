using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace singlePage.Models
{
    public class Connection
    {
       
            private static string s = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            public SqlConnection con = new SqlConnection(s);
        
    }
}