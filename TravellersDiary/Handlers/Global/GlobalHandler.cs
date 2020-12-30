using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TravellersDiary.Models.Global;
using TravellersDiary.Models.Home;

namespace TravellersDiary.Handlers.Global
{
    public class GlobalHandler
    {
        Context dbContext = new Context();
        public Traveller GetTraveller(string TAG_NAME)
        {
            Traveller model = new Traveller();
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from \"UserInfo\".fnc_get_curruser(@TAG_NAME)";
            command.Parameters.AddWithValue("@TAG_NAME", TAG_NAME);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                model.PK_TRAVELLER_ID = Convert.ToInt32(rdr["PK_TRAVELLER_ID"]);
                model.CH_TAG_NAME = rdr["CH_TAG_NAME"].ToString();
                model.CH_EMAIL = rdr["CH_EMAIL"].ToString();
                model.CH_FIRSTNAME = rdr["CH_FIRSTNAME"].ToString();
                model.CH_LASTNAME = rdr["CH_LASTNAME"].ToString();
                model.TXT_ABOUT = rdr["TXT_ABOUT"].ToString();
                model.DT_CREATION = (DateTime)rdr["DT_CREATION"];
            }
            conn.Close();
            return model;
        }

        public VacationBadge GetVacation(int PK_VACATION_ID)
        {
            VacationBadge model = new VacationBadge();
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from \"VacationInfo\".\"VACATION_BADGE\" where \"PK_VACATION_ID\"= @PK_VACATION_ID";
            command.Parameters.AddWithValue("@PK_VACATION_ID", PK_VACATION_ID);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                model.PK_VACATION_ID = Convert.ToInt32(rdr["PK_VACATION_ID"]);
                model.MNY_BUDGET = Convert.ToInt32(rdr["MNY_BUDGET"]);
                model.MNY_COSTOFVAC = Convert.ToInt32(rdr["MNY_COSTOFVAC"]);
                model.PK_TRAVELLER_ID = Convert.ToInt32(rdr["INT_CREATER"]);
                model.CH_TITLE = (string)rdr["CH_TITLE"];
                model.TXT_INFO = (string)rdr["TXT_INFO"];
                model.DT_CREATION = (DateTime)rdr["DT_CREATION"];
            }
            conn.Close();
            return model;
        }

    }
}