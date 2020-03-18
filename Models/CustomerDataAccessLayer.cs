using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.SqlClient;
using System.Threading.Tasks;  

namespace Csharp
{  
    public class CustomerDataAccessLayer  
    {  
        string connectionString = "Integrated Security=False;Persist Security Info=False;Initial Catalog=TestDB;Data Source=pafitis;User ID=SA;Password=GiorkosPafitis1994";  
        
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
        
        //Get the details of a particular employee  
        public Customer GetCustomerData(int? id)  
        {  
            Customer customer = new Customer();  
            using (SqlConnection con = new SqlConnection(connectionString))  
            {  
                string sqlQuery = "SELECT * FROM tblCustomer WHERE CustomerID= " + id;  
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
         
    }  
}