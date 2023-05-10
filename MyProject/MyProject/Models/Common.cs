using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MyProject.Models;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class Common
    {
        public static DataTable ExecuteProcedure(string ProcedureName, string[,] Param)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MsSql"].ConnectionString);
            SqlCommand cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Param.Length / 2; i++)
            {
                cmd.Parameters.AddWithValue(Param[i, 0], Param[i, 1]);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable ExecuteProcedure(string ProcedureName)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mssql"].ConnectionString);
            SqlCommand cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}