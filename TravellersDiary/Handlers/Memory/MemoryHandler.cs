using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Models.Memory;

namespace TravellersDiary.Handlers.Memory
{
    public class MemoryHandler
    {
        Context dbContext = new Context();
        public List<MemoryModel> GetMemories(int TRAVELLER_ID)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from \"UserInfo\".FNC_GET_MEMORIES(@P_TRAVELLER_ID)";
            command.Parameters.AddWithValue("@P_TRAVELLER_ID", TRAVELLER_ID);
            List<MemoryModel> List = new List<MemoryModel>();
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                MemoryModel model = new MemoryModel();
                model.PK_MEMORIES_ID = Convert.ToInt32(rdr["PK_MEMORIES_ID"]);
                model.TRAVELLER_ID = Convert.ToInt32(rdr["TRAVELLER_ID"]);
                model.TXT_MEMORY = (string)rdr["TXT_MEMORY"];
                model.DT_DATE = (DateTime)rdr["DT_DATE"];
                List.Add(model);
            }
            conn.Close();
            return List;
        }

        public void CreateMemory(CreateMemory model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL \"UserInfo\".prc_create_memory(@p_traveller_id,@p_txt_memory,@p_dt_date)";
            command.Parameters.AddWithValue("@p_traveller_id", model.TRAVELLER_ID);
            command.Parameters.AddWithValue("@p_txt_memory", model.TXT_MEMORY);
            command.Parameters.AddWithValue("@p_dt_date", model.DT_DATE);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteMemory(int MEMORY_ID)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL \"UserInfo\".prc_delete_memory(@p_memory_id)";
            command.Parameters.AddWithValue("@p_memory_id", MEMORY_ID);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}