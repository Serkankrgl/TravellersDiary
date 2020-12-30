using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Models.Auth;

namespace TravellersDiary.Handlers.Auth
{
    public class AuthHandler
    {
        Context dbContext = new Context();
        public bool Register(RegisterModel model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);

            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT \"UserInfo\".fnc_register(@P_CH_TAG_NAME,@P_CH_EMAIL,@P_CH_PASSWORD,@P_CH_FIRSTNAME,@P_CH_LASTNAME)";
            comm.Parameters.AddWithValue("@P_CH_TAG_NAME", model.CH_Tag_Name);
            comm.Parameters.AddWithValue("@P_CH_EMAIL", model.CH_Email);
            comm.Parameters.AddWithValue("@P_CH_PASSWORD", model.CH_Password);
            comm.Parameters.AddWithValue("@P_CH_FIRSTNAME", model.CH_FirstName);
            comm.Parameters.AddWithValue("@P_CH_LASTNAME", model.CH_LastName);
            conn.Open();
            bool regState = (bool)comm.ExecuteScalar();
            conn.Close();

            return regState;
        }

        public bool Login(LoginModel model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);

            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT \"UserInfo\".fnc_login(@P_CH_TAG_NAME,@P_CH_PASSWORD)";
            comm.Parameters.AddWithValue("@P_CH_TAG_NAME", model.CH_TAG_NAME);
            comm.Parameters.AddWithValue("@P_CH_PASSWORD", model.CH_PASSWORD) ;
            conn.Open();
            bool regState = (bool)comm.ExecuteScalar();
            conn.Close();

            return regState;
        }


    }
}