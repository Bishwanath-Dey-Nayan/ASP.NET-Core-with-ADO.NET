using CoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.DAL
{
    public class CustomerDataAccess_Layer
    {
        string connectionString = "Data Source=LAPTOP-IJQFK7R5\\NAYANSQL;Initial Catalog=CoreMvcDB;Persist Security Info=True;User ID=sa;password=1234";
        //string connectionString = "server=LAPTOP-IJQFK7R5\\NAYANSQL; database=CoreMvcDB;Trusted_Connection=True;";

        public IEnumerable<Customer> GetAllCustomer()
        {
            List<Customer> lstCustomer = new List<Customer>();
            using(SqlConnection con = new SqlConnection(connectionString) )
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    Customer customer = new Customer();
                    customer.ID = Convert.ToInt32(sdr["CustomerId"]);
                    customer.Name = sdr["Name"].ToString();
                    customer.Address = sdr["Address"].ToString();
                    customer.City = sdr["City"].ToString();
                    customer.Country = sdr["Country"].ToString();
                    customer.Gender = sdr["Gender"].ToString();
                    customer.Mobile = sdr["MobileNO"].ToString();
                    customer.Email = sdr["MailId"].ToString();

                    lstCustomer.Add(customer);
                }
                con.Close();
            }
            return lstCustomer;
        }

        /// <summary>
        /// Add New Customer
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddCustomer",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@Gender", customer.Gender);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@MobileNO", customer.Mobile);
                cmd.Parameters.AddWithValue("@MailId", customer.Email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
