using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Models.Home;

namespace TravellersDiary.Handlers.Home
{
    public class HomeHandler
    {
        Context dbContext = new Context();
        public void CreateVacation(CreateVacationBadge model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "call \"VacationInfo\".prc_create_vac(@P_CH_TITLE,@P_INT_BUDGET,@P_TXT_INFO,@P_TRAVVELLER_ID)";
            command.Parameters.AddWithValue("@P_TRAVVELLER_ID", model.TRAVVELLER_ID);
            command.Parameters.AddWithValue("@P_CH_TITLE", model.CH_TITLE);
            command.Parameters.AddWithValue("@P_INT_BUDGET", model.INT_BUDGET);
            command.Parameters.AddWithValue("@P_TXT_INFO", model.TXT_INFO);
            conn.Open();
            command.ExecuteScalar();
            conn.Close();

        }

        public List<VacationBadge> ListVacation()
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            List<VacationBadge> List = new List<VacationBadge>();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM \"VacationInfo\".fnc_list_vac()";
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();




            while (rdr.Read())
            {
                VacationBadge badge = new VacationBadge();
                badge.PK_VACATION_ID = Convert.ToInt32(rdr["PK_VACATION_ID"]);
                badge.MNY_BUDGET = Convert.ToInt32(rdr["MNY_BUDGET"]);
                badge.MNY_COSTOFVAC = Convert.ToInt32(rdr["MNY_COSTOFVAC"]);
                badge.CH_TAG_NAME = (string)rdr["CH_TAG_NAME"];
                badge.CH_TITLE = (string)rdr["CH_TITLE"];
                badge.TXT_INFO = (string)rdr["TXT_INFO"];
                badge.DT_CREATION = (DateTime)rdr["DT_CREATION"];
                badge.PK_TRAVELLER_ID = Convert.ToInt32(rdr["PK_TRAVELLER_ID"]);
                List.Add(badge);
            }

            conn.Close();
            return List;
        }

        public int LikeStatus(LikeModel model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            List<VacationBadge> List = new List<VacationBadge>();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * from \"VacationInfo\".FNC_SW_Rate(@p_travller_id,@p_vacation_id)";
            command.Parameters.AddWithValue("@p_travller_id", model.TRAVELLER_ID);
            command.Parameters.AddWithValue("@p_vacation_id", model.VACATION_ID);
            conn.Open();
            int retVal = (int)command.ExecuteScalar();
            conn.Close();
            return retVal;
        }

        public void RateVac(LikeModel model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL  \"VacationInfo\".prc_rate(@p_traveller_id,@p_vacation_id,@p_sw_type)";
            command.Parameters.AddWithValue("@p_traveller_id", model.TRAVELLER_ID);
            command.Parameters.AddWithValue("@p_vacation_id", model.VACATION_ID);
            command.Parameters.AddWithValue("@p_sw_type", model.SW_TYPE);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

        }

        public void ClearRate(LikeModel model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL \"VacationInfo\".prc_clear_rate(@p_traveller_id,@p_vacation_id)";
            command.Parameters.AddWithValue("@p_traveller_id", model.TRAVELLER_ID);
            command.Parameters.AddWithValue("@p_vacation_id", model.VACATION_ID);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

        }

        public List<VacationBadge> SearchResults(string Word)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            List<VacationBadge> List = new List<VacationBadge>();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM \"VacationInfo\".fnc_search_vac(@p_word)";
            command.Parameters.AddWithValue("@p_word", Word);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();




            while (rdr.Read())
            {
                VacationBadge badge = new VacationBadge();
                badge.PK_VACATION_ID = Convert.ToInt32(rdr["PK_VACATION_ID"]);
                badge.MNY_BUDGET = Convert.ToInt32(rdr["MNY_BUDGET"]);
                badge.MNY_COSTOFVAC = Convert.ToInt32(rdr["MNY_COSTOFVAC"]);
                badge.CH_TAG_NAME = (string)rdr["CH_TAG_NAME"];
                badge.CH_TITLE = (string)rdr["CH_TITLE"];
                badge.TXT_INFO = (string)rdr["TXT_INFO"];
                badge.DT_CREATION = (DateTime)rdr["DT_CREATION"];
                badge.PK_TRAVELLER_ID = Convert.ToInt32(rdr["PK_TRAVELLER_ID"]);
                List.Add(badge);
            }

            conn.Close();
            return List;
        }
    }
}