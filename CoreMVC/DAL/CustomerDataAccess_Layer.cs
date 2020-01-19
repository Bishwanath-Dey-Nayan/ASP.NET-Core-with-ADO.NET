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

        /// <summary>
        /// Update information of an employee
        /// </summary>
        /// <param name="customer"></param>
        public void UpdateCustomer(Customer customer)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateCustomer",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", customer.ID);
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

        /// <summary>
        /// Get Specific Details of an Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer object</returns>
        public Customer GetCustomerData(int? id)
        {
            Customer customer = new Customer();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetCustomerByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId",id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    customer.ID = Convert.ToInt32(sdr["CustomerID"]);
                    customer.Name = sdr["Name"].ToString();
                    customer.Address = sdr["Address"].ToString();
                    customer.Gender = sdr["Gender"].ToString();
                    customer.Country = sdr["Country"].ToString();
                    customer.City = sdr["City"].ToString();
                    customer.Mobile = sdr["MobileNO"].ToString();
                    customer.Email = sdr["MailId"].ToString();
                }
            }
            return customer;
        }
    }
}
