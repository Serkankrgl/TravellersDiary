using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Web;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Models.Home;
using TravellersDiary.Models.Profile;

namespace TravellersDiary.Handlers.Profile
{
    public class ProfileHandler
    {

        Context dbContext = new Context();
        public List<VacationBadge> GetVacationById(int TRAVELLER_ID)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from \"VacationInfo\".GET_TRAVELLERS_VACS(@p_int_creater)";
            command.Parameters.AddWithValue("@p_int_creater", TRAVELLER_ID);
            List<VacationBadge> List = new List<VacationBadge>();
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


        public bool IsFollowing(Follow model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from \"UserInfo\".FNC_SW_FOLLOWING(@p_travller_id,@p_follower_id)";
            command.Parameters.AddWithValue("@p_travller_id", model.TRAVELLER_ID);
            command.Parameters.AddWithValue("@p_follower_id", model.FOLLOWER_ID);
            conn.Open();
            bool retVal =  (bool)command.ExecuteScalar();


            conn.Close();
            return retVal;
        }
        public void Follow(Follow model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL \"UserInfo\".prc_follow(@p_travller_id,@p_follower_id)";
            command.Parameters.AddWithValue("@p_travller_id", model.TRAVELLER_ID);
            command.Parameters.AddWithValue("@p_follower_id", model.FOLLOWER_ID);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void UnFollow(Follow model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL \"UserInfo\".prc_unfollow(@p_travller_id,@p_follower_id)";
            command.Parameters.AddWithValue("@p_travller_id", model.TRAVELLER_ID);
            command.Parameters.AddWithValue("@p_follower_id", model.FOLLOWER_ID);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void CreateAchivment(CreateAchivment model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL \"UserInfo\".prc_create_achivment(@p_traveller_id,@p_ch_ach_name,@p_dt_date)";
            command.Parameters.AddWithValue("@p_traveller_id", model.TRAVELLER_ID);
            command.Parameters.AddWithValue("@p_ch_ach_name", model.CH_ACH_NAME);
            command.Parameters.AddWithValue("@p_dt_date", model.DT_DATE);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public List<AchivmentModel> GetAchivments(int TRAVELLER_ID)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from \"UserInfo\".FNC_GET_ACHIVMENTS(@P_TRAVELLER_ID)";
            command.Parameters.AddWithValue("@P_TRAVELLER_ID", TRAVELLER_ID);
            List<AchivmentModel> List = new List<AchivmentModel>();
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                AchivmentModel model = new AchivmentModel();
                model.PK_ACHIVMENT_ID = Convert.ToInt32(rdr["PK_ACHIVMENT_ID"]);
                model.CH_ACH_NAME = (string)rdr["CH_ACH_NAME"];
                model.DT_DATE = (DateTime)rdr["DT_DATE"];
                model.TRAVELLER_ID = Convert.ToInt32(rdr["TRAVELLER_ID"]);
      
                List.Add(model);
            }
            conn.Close();
            return List;
        }

        public void EditProfile(EditProfile model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL \"UserInfo\".prc_upd_profile(@p_txt_about,@p_traveller_id)";
            command.Parameters.AddWithValue("@p_traveller_id", model.PK_TRAVELLER_ID);
            command.Parameters.AddWithValue("@p_txt_about", model.TXT_ABOUT);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }

}