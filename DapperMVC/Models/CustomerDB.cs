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

        public string Create(Customer customerEntity)
        {
            try
            {
                using(System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
                {
                    sqlConnection.Open();
                    string sqlQuery =
                        "INSERT INTO [dbo].[Customer]([FirstName],[LastName],[Address],[City]) VALUES (@FirstName, @LastName, @Address, @City)";
                    sqlConnection.Execute(sqlQuery,
                                          new
                                              {
                                                  customerEntity.FirstName,
                                                  customerEntity.LastName,
                                                  customerEntity.Address,
                                                  customerEntity.City,
                                              });
                    sqlConnection.Close();
                }
                return "Created";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}