using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace DapperMVC.Models
{
    public class CustomerDB
    {
        //public string Connectionstring = @"Data Source=DotNetJalps\SQLExpress;Initial Catalog=CodeBase;Integrated Security=True";
        public string Connectionstring = 
                    @"Data Source=.\sqlexpress;Initial Catalog=DapperMVC;Integrated Security=True";

        public IEnumerable<Customer> GetCustomers()
        {
            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
            {
                sqlConnection.Open();
                var customer = sqlConnection.Query<Customer>("Select * from Customer");
                return customer;

            }
        }

    }
}