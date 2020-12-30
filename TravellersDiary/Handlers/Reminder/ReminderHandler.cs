using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Models.Reminder;

namespace TravellersDiary.Handlers.Reminder
{
    public class ReminderHandler
    {
        Context dbContext = new Context();
        public List<ReminderModel> GetReminders(int TRAVELLER_ID)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from \"UserInfo\".FNC_GET_REMINDER(@P_TRAVELLER_ID)";
            command.Parameters.AddWithValue("@P_TRAVELLER_ID", TRAVELLER_ID);
            List<ReminderModel> List = new List<ReminderModel>();
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                ReminderModel model = new ReminderModel();
                model.PK_REMINDER_ID = Convert.ToInt32(rdr["PK_REMINDER_ID"]);
                model.TRAVELLER_ID = Convert.ToInt32(rdr["TRAVELLER_ID"]);
                model.TXT_MESSAGE = (string)rdr["TXT_MESSAGE"];
                model.DT_DATE = (DateTime)rdr["DT_DATE"];
                List.Add(model);
            }
            conn.Close();
            return List;
        }

        public void CreateReminder(CreateReminder model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL \"UserInfo\".prc_create_reminder(@p_traveller_id,@p_txt_message,@p_dt_date)";
            command.Parameters.AddWithValue("@p_traveller_id", model.TRAVELLER_ID);
            command.Parameters.AddWithValue("@p_txt_message", model.TXT_MESSAGE);
            command.Parameters.AddWithValue("@p_dt_date", model.DT_DATE);
            conn.Open();
             command.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteReminder(int REMINDER_ID)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL \"UserInfo\".prc_delete_reminder(@p_reminder_id)";
            command.Parameters.AddWithValue("@p_reminder_id", REMINDER_ID);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}