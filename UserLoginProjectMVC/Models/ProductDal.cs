using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UserLoginProjectMVC.Models
{
    public class ProductDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
            string str = "select * from Products";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToDecimal(dr["Price"]);
                    p.Company = dr["Company"].ToString();
                    p.Description = dr["Description"].ToString();
                    list.Add(p);
                }
                con.Close();
                return list;
            }
            else
            {
                con.Close();
                return list;
            }
        }
        public int Save(Product p)
        {
            string str = "insert into Products values(@name,@price,@company,@description)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@price", p.Price);
            cmd.Parameters.AddWithValue("@company", p.Company);
            cmd.Parameters.AddWithValue("@description", p.Description);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Product p)
        {
            string str = "update Products set Name=@name,Price=@price,Company=@company,Description=@description where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@price", p.Price);
            cmd.Parameters.AddWithValue("@company", p.Company);
            cmd.Parameters.AddWithValue("@description", p.Description);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int id)
        {
            string str = "delete from Products where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
