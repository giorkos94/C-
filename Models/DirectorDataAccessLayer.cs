using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.SqlClient;

namespace Csharp
{  
    public class DirectorDataAccessLayer  
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
                    customer.Department = rdr["Department"].ToString();  
                    customer.CID = Convert.ToInt32(rdr["CID"]); 
                    customer.Calls = rdr["Calls"].ToString();  
                    
                    lstcustomer.Add(customer);  
                }  
                con.Close();  
            }  
            return lstcustomer;  
        }  
        //To Add new employee record    
        public void AddCustomer(Customer customer)  
        {  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("spAddCustomer", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@Name", customer.Name);  
                cmd.Parameters.AddWithValue("@CID", customer.CID);  
                cmd.Parameters.AddWithValue("@Department", customer.Department);  
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
                cmd.Parameters.AddWithValue("@CusClsId", customer.CustomerCallsId);  
                cmd.Parameters.AddWithValue("@Name", customer.Name);  
                cmd.Parameters.AddWithValue("@CID", customer.CID);  
                cmd.Parameters.AddWithValue("@Department", customer.Department);  
                cmd.Parameters.AddWithValue("@Calls", customer.Calls);                  
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
       public void AddCall(int? id)  
        {    
            Customer customer = new Customer();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand("spAddCustomer", con);
                SqlCommand cmd = new SqlCommand("spAddCalls",con);                                
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@Calls",customer.Calls);

                cmd1.Parameters.AddWithValue("@Name", customer.Name);  
                cmd1.Parameters.AddWithValue("@CID", customer.CID);  
                cmd1.Parameters.AddWithValue("@Department", customer.Department);
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();   
            }
        }
        //Get the details of a particular customer  
        public Customer GetCustomerData(int? id)  
        {  
            Customer customer = new Customer();  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                string sqlQuery = "SELECT * FROM tblCustomer, tblCustomerCalls WHERE CustomerID= " + id;  
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
        //To Delete the record on a particular Customer          
        public void DeleteCustomer(int? id)  
        {  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);  
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@CusId", id);
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close();  
            }  
        }  
    }  
}