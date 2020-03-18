using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.SqlClient;

namespace Csharp
{  
    public class EmployeeDataAccessLayer  
    {  
        string connectionString = "Integrated Security=False;Persist Security Info=False;Initial Catalog=TestDB;Data Source=pafitis;User ID=SA;Password=GiorkosPafitis1994";  
        //To View all Customer details    
        public IEnumerable<Customer> GetAllCustomer()  
        {  
            List<Customer> lstcustomer = new List<Customer>();  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("spGetAllCustomer", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
                con.Open();  
                SqlDataReader rdr = cmd.ExecuteReader();  
                while (rdr.Read())  
                {  
                    Customer customer = new Customer();  
                    customer.ID = Convert.ToInt32(rdr["CustomerID"]);  
                    customer.Name = rdr["Name"].ToString();  
                    customer.CID = Convert.ToInt32(rdr["CID"]);   
                    customer.Department = rdr["Department"].ToString();  
                    customer.Calls = rdr["Calls"].ToString();  
                    lstcustomer.Add(customer);  
                }  
                con.Close();  
            }  
            return lstcustomer;  
        }  
        public void AddCalls(Customer customer)  
        {  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("spAddCalls", con);  
                cmd.CommandType = CommandType.StoredProcedure;                  
                cmd.Parameters.AddWithValue("@CID", customer.CID);                  
                cmd.Parameters.AddWithValue("@Calls", customer.Calls);  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }
        //To Update the records of a particluar employee  
        public void UpdateCustomer(Customer customer)  
        {  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("spUpdateCustomer", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@CusId", customer.ID);  
                cmd.Parameters.AddWithValue("@Name", customer.Name);                 
                cmd.Parameters.AddWithValue("@Department", customer.Department);
                cmd.Parameters.AddWithValue("@CusclsId", customer.CustomerCallsId);
                cmd.Parameters.AddWithValue("@CID", customer.CID);    
                cmd.Parameters.AddWithValue("@Calls", customer.Calls);  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }
        //Get the details of a particular employee  
        public Customer GetCustomerData(int? id)  
        {  
            Customer customer = new Customer();  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                string sqlQuery = "SELECT TOP 10 * FROM tblCustomer, tblCustomerCalls WHERE CustomerID= " + id;  
                SqlCommand cmd = new SqlCommand(sqlQuery, con);  
                con.Open();  
                SqlDataReader rdr = cmd.ExecuteReader();  
                while (rdr.Read())  
                {  
                    customer.ID = Convert.ToInt32(rdr["CustomerID"]);  
                    customer.Name = rdr["Name"].ToString();  
                    customer.CID = Convert.ToInt32(rdr["CID"]); 
                    customer.Department = rdr["Department"].ToString();  
                    customer.Calls = rdr["Calls"].ToString();  
                }  
            }  
            return customer;  
        }  

         //To Delete the record on a particular customer  
        public void DeleteCustomerCalls(int? id)  
        {  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("spDeleteCustomerCalls", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@CusId", id);
                cmd.Parameters.AddWithValue("@CID", id);
                cmd.Parameters.AddWithValue("@Calls", id);
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }
        
         
    }  
}