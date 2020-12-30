using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Models.Profile;
using TravellersDiary.Models.Schedule;

namespace TravellersDiary.Handlers.Schedule
{
    public class ScheduleHandler
    {
        Context dbContext = new Context();
        public List<ScheduleModel> GetSchedules(int VAC_ID)
        {
            List<ScheduleModel> retList = new List<ScheduleModel>();

            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM \"VacationInfo\".fnc_get_daily_schedules(@VAC_ID)";
            command.Parameters.AddWithValue("@VAC_ID", VAC_ID);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                retList.Add(new ScheduleModel()
                {
                    PK_SCHEDULE_ID=Convert.ToInt32(rdr["daily_schedule_id"]),
                    DT_DATE = (DateTime)rdr["dt_date"]

                });
            }

            conn.Close();

            return retList;

        }

        public List<TicketedActivityModel> Get_Ticketed_Actions(int SCHEDULE_ID)
        {
            List<TicketedActivityModel> RetList = new List<TicketedActivityModel>();

            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM \"VacationInfo\".fnc_get_ticketed_actions(@daily_schedule_id);";
            command.Parameters.AddWithValue("@daily_schedule_id", SCHEDULE_ID);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();
            
            while (rdr.Read())
            {
                TicketedActivityModel temp = new TicketedActivityModel();
                
                if(DBNull.Value!= rdr["COMPANY_ID"])
                    temp.COMPANY_ID = Convert.ToInt32(rdr["COMPANY_ID"]);
                temp.ACTIVITY_ID = Convert.ToInt32(rdr["ACTIVITY_ID"]);
                temp.TICKET_DETAILS = rdr["TICKET_DETAILS"].ToString();
                if (DBNull.Value != rdr["COST_OF"])
                    temp.COST_OF = Convert.ToDouble(rdr["COST_OF"]);
                temp.ACT_TITLE = rdr["ACT_TITLE"].ToString();
                temp.ACT_DETAILS = rdr["ACT_DETAILS"].ToString();
                temp.ACT_START_TIME = rdr["ACT_START_TIME"].ToString();
                temp.ACT_FNISH_TIME = rdr["ACT_FNISH_TIME"].ToString();


                RetList.Add(temp);
            }

            conn.Close();


            return RetList;
        }

        public List<MealActivityModel> Get_Meal_Actions(int SCHEDULE_ID)
        {
            List<MealActivityModel> RetList = new List<MealActivityModel>();

            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM \"VacationInfo\".fnc_get_meal_action(@daily_schedule_id);";
            command.Parameters.AddWithValue("@daily_schedule_id", SCHEDULE_ID);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                MealActivityModel temp = new MealActivityModel();
                temp.MEAL_NAME = rdr["MEAL_NAME"].ToString();
                if (DBNull.Value != rdr["RATING"])
                    temp.RATING = (int)rdr["RATING"];
                if (DBNull.Value != rdr["COST_OF"])
                    temp.COST_OF = Convert.ToInt32(rdr["COST_OF"]);
                temp.ACT_TITLE = rdr["ACT_TITLE"].ToString();
                temp.ACT_DETAILS = rdr["ACT_DETAILS"].ToString();
                temp.ACT_START_TIME = (string)rdr["ACT_START_TIME"];
                temp.ACT_FNISH_TIME = (string)rdr["ACT_FNISH_TIME"];
                if (DBNull.Value != rdr["COMPANY_ID"])
                    temp.COMPANY_ID = Convert.ToInt32(rdr["COMPANY_ID"]);
                temp.ACTIVITY_ID = Convert.ToInt32(rdr["ACTIVITY_ID"]);




                RetList.Add(temp);
            }

            conn.Close();


            return RetList;
        }

        public List<Accommodation> Get_Accommodation(int Vacation_id)
        {
            List<Accommodation> RetList = new List<Accommodation>();

            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM \"VacationInfo\".GET_ACCOMMODATION(@P_VACATION);";
            command.Parameters.AddWithValue("@P_VACATION", Vacation_id);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                Accommodation temp = new Accommodation();
                temp.PK_ACCOMMODATION_ID = Convert.ToInt32(rdr["PK_ACCOMMODATION_ID"]);
                temp.VACATION_ID = Convert.ToInt32(rdr["VACATION_ID"]);
                temp.COMPANY_ID = Convert.ToInt32(rdr["COMPANY_ID"]);
                temp.TXT_ADDRESS = rdr["TXT_ADDRESS"].ToString();
                temp.MNY_COSTOFACC = Convert.ToInt32(rdr["MNY_COSTOFACC"]);
                temp.CH_ACC_TYPE = (string)rdr["CH_ACC_TYPE"];
                RetList.Add(temp);
            }

            conn.Close();


            return RetList;
        }

        public List<Rented> Get_Rented(int Vacation_id)
        {
            List<Rented> RetList = new List<Rented>();

            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM \"VacationInfo\".GET_RENTED(@P_VACATION);";
            command.Parameters.AddWithValue("@P_VACATION", Vacation_id);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                Rented temp = new Rented();
                temp.PK_RENTED_ID = Convert.ToInt32(rdr["PK_RENTED_ID"]);
                temp.VACATION_ID = Convert.ToInt32(rdr["VACATION_ID"]);
                temp.COMPANY_ID = Convert.ToInt32(rdr["COMPANY_ID"]);
                temp.TXT_OBJECT = rdr["TXT_OBJECT"].ToString();
                temp.MNY_COSTOFRENT = Convert.ToInt32(rdr["MNY_COSTOFRENT"]);
                RetList.Add(temp);
            }

            conn.Close();


            return RetList;
        }

        public List<Following> GetFollowingList(int id)
        {
            List<Following> List = new List<Following>();
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from \"VacationInfo\".fnc_get_following_trav(@p_int_trav_id)";
            command.Parameters.AddWithValue("@p_int_trav_id", id);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                Following model = new Following();
                model.PK_TRAVELLER_ID = Convert.ToInt32(rdr["PK_TRAVELLER_ID"]);
                model.CH_TAG_NAME = (string)rdr["CH_TAG_NAME"];

                List.Add(model);
            }

            conn.Close();
            return List;
        }

        public List<Following> GetVacOwner(int id)
        {
            List<Following> List = new List<Following>();
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from \"VacationInfo\".prc_get_vac_with(@p_vacation_id)";
            command.Parameters.AddWithValue("@p_vacation_id", id);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                Following model = new Following();
                model.PK_TRAVELLER_ID = Convert.ToInt32(rdr["PK_TRAVELLER_ID"]);
                model.CH_TAG_NAME = (string)rdr["CH_TAG_NAME"];

                List.Add(model);
            }

            conn.Close();
            return List;
        }

        public void CreateSchedule(CreateScheduleModel model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);

            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "call \"VacationInfo\".prc_create_daily_schedule(@VACATION_ID,@DT_DATE)";
            comm.Parameters.AddWithValue("@VACATION_ID", model.VACATION_ID);
            comm.Parameters.AddWithValue("@DT_DATE", model.DT_DATE);
            conn.Open();
            comm.ExecuteScalar();
            conn.Close();

        }

        public void CreateTicketedAct(CreateTicketedAct model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);

            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "call \"VacationInfo\".prc_create_ticketed_act(@p_base_schedule_id," +
                                                            "@p_ch_title," +
                                                            "@p_txt_act_details," +
                                                            "@p_tm_fnish_time," +
                                                            "@p_tm_start_time," +
                                                            "@p_traveller_id," +
                                                            "@p_company_id," +
                                                            "@p_cost_of," +
                                                            "@p_txt_ticket_details)";
            comm.Parameters.AddWithValue("@p_base_schedule_id", model.BASE_SCHEDULE_ID);
            comm.Parameters.AddWithValue("@p_ch_title", model.CH_TITLE);
            comm.Parameters.AddWithValue("@p_txt_act_details", model.TXT_ACT_DETAILS);
            comm.Parameters.AddWithValue("@p_tm_fnish_time", model.TM_FNISH_TIME);
            comm.Parameters.AddWithValue("@p_tm_start_time", model.TM_START_TIME);
            comm.Parameters.AddWithValue("@p_traveller_id", model.TRAVELLER_ID);
            comm.Parameters.AddWithValue("@p_company_id", model.COMPANY_ID);
            comm.Parameters.AddWithValue("@p_cost_of", model.MNY_COST_OF);
            comm.Parameters.AddWithValue("@p_txt_ticket_details", model.TXT_TICKET_DETAILS);
            conn.Open();
            comm.ExecuteScalar();
            conn.Close();
        }


        public void CreateMealAct(CreateMealAct model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);

            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "call \"VacationInfo\".prc_create_meal_act(@p_base_schedule_id," +
                                                            "@p_ch_title," +
                                                            "@p_txt_act_details," +
                                                            "@p_tm_fnish_time," +
                                                            "@p_tm_start_time," +
                                                            "@p_traveller_id," +
                                                            "@p_company_id," +
                                                            "@p_cost_of," +
                                                            "@p_int_rating," +
                                                            "@p_txt_meal_name)";
            comm.Parameters.AddWithValue("@p_base_schedule_id", model.BASE_SCHEDULE_ID);
            comm.Parameters.AddWithValue("@p_ch_title", model.CH_TITLE);
            comm.Parameters.AddWithValue("@p_txt_act_details", model.TXT_ACT_DETAILS);
            comm.Parameters.AddWithValue("@p_tm_fnish_time", model.TM_FNISH_TIME);
            comm.Parameters.AddWithValue("@p_tm_start_time", model.TM_START_TIME);
            comm.Parameters.AddWithValue("@p_traveller_id", model.TRAVELLER_ID);
            comm.Parameters.AddWithValue("@p_company_id", model.COMPANY_ID);
            comm.Parameters.AddWithValue("@p_cost_of", model.MNY_COST_OF);
            comm.Parameters.AddWithValue("@p_int_rating", model.INT_RATING);
            comm.Parameters.AddWithValue("@p_txt_meal_name", model.TXT_MEAL_NAME);
            conn.Open();
            comm.ExecuteScalar();
            conn.Close();

        }

        public void CreateAccommodation(CreateAccommodation model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);

            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "call \"VacationInfo\".prc_create_accommodation(@p_txt_address," +
                                                            "@p_vacation_id," +
                                                            "@p_company_id," +
                                                            "@p_mny_costofacc," +
                                                            "@p_ch_acc_type)";
            comm.Parameters.AddWithValue("@p_txt_address", model.TXT_ADDRESS);
            comm.Parameters.AddWithValue("@p_vacation_id", model.VACATION_ID);
            comm.Parameters.AddWithValue("@p_company_id", model.COMPANY_ID);
            comm.Parameters.AddWithValue("@p_mny_costofacc", model.MNY_COSTOFACC);
            comm.Parameters.AddWithValue("@p_ch_acc_type", model.CH_ACC_TYPE);
            conn.Open();
            comm.ExecuteScalar();
            conn.Close();

        }

        public void CreateRented(CreateRented model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);

            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "call \"VacationInfo\".prc_create_rented(@p_txt_object," +
                                                            "@p_vacation_id," +
                                                            "@p_company_id," +
                                                            "@p_mny_costofrent)";
            comm.Parameters.AddWithValue("@p_txt_object", model.TXT_OBJECT);
            comm.Parameters.AddWithValue("@p_vacation_id", model.VACATION_ID);
            comm.Parameters.AddWithValue("@p_company_id", model.COMPANY_ID);
            comm.Parameters.AddWithValue("@p_mny_costofrent", model.MNY_COSTOFRENT);
            conn.Open();
            comm.ExecuteScalar();
            conn.Close();

        }

        public void AddFriendToVac(AddFriendToVac model)
        {
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);

            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "call \"VacationInfo\".prc_add_vac_with(@p_vacation_id,@p_traveller_id)";
            comm.Parameters.AddWithValue("@p_vacation_id", model.VACATION_ID);
            comm.Parameters.AddWithValue("@p_traveller_id", model.TRAVELLER_ID);
            conn.Open();
            comm.ExecuteScalar();
            conn.Close();

        }
    }
}