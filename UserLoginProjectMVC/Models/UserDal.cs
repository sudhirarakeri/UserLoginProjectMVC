using System;
using System.Data.SqlClient;

namespace UserLoginProjectMVC.Models
{
    public class UserDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public UserDal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public int Save(User u)
        {
            string str = "insert into Users values(@name,@email,@password,@roleid)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", u.Name);
            cmd.Parameters.AddWithValue("@email", u.Email);
            cmd.Parameters.AddWithValue("@password", u.Password);
            cmd.Parameters.AddWithValue("@roleid", u.RoleId);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int Search(string user,string pass)
        {
            User u = new User();
            string str = "select * from Users where FullName=@user and Password=@pass";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
                return 1;
            con.Close();
            return 0;
        }
    }
}
