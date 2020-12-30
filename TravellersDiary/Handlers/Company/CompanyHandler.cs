using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Models.Company;

namespace TravellersDiary.Handlers.Company
{
    public class CompanyHandler
    {
        Context dbContext = new Context();
        public void CreateCompany(CreateCompany model)
        {

            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "CALL \"VacationInfo\".prc_create_company(@p_ch_company_name," +
                                                                            "@p_int_quality," +
                                                                            "@p_tm_closing_time," +
                                                                            "@p_tm_opening_time," +
                                                                            "@p_txt_comp_description," +
                                                                            "@p_txt_comp_site)";
            command.Parameters.AddWithValue("@p_ch_company_name", model.CH_COMP_NAME);
            command.Parameters.AddWithValue("@p_int_quality", model.INT_QUALITY);
            command.Parameters.AddWithValue("@p_tm_closing_time", model.TM_CLOSING_TIME);
            command.Parameters.AddWithValue("@p_tm_opening_time", model.TM_OPENING_TIME);
            command.Parameters.AddWithValue("@p_txt_comp_description", model.TXT_COMP_DESCRIPTION);
            command.Parameters.AddWithValue("@p_txt_comp_site", model.TXT_COMP_SITE);
            conn.Open();
            command.ExecuteNonQuery();

            conn.Close();
        }
        public CompanyModel GetCompany(int COMPANY_ID)
        {

            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * from \"VacationInfo\".FNC_GET_COMPANY(@P_COMPANY_ID)";
            command.Parameters.AddWithValue("@P_COMPANY_ID", COMPANY_ID);
            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();
            CompanyModel model = new CompanyModel();
            while (rdr.Read())
            {
                
                model.PK_COMPANY_ID = Convert.ToInt32(rdr["PK_COMPANY_ID"]);
                model.CH_COMP_NAME = (string)rdr["CH_COMP_NAME"];
                model.INT_QUALITY = Convert.ToInt32(rdr["INT_QUALITY"]);
                model.TM_CLOSING_TIME = (string)rdr["TM_CLOSING_TIME"];
                model.TM_OPENING_TIME = (string)rdr["TM_OPENING_TIME"];
                if (rdr["TXT_COMP_DESCRIPTION"] != DBNull.Value)
                    model.TXT_COMP_DESCRIPTION = (string)rdr["TXT_COMP_DESCRIPTION"];
                model.TXT_COMP_SITE = (string)rdr["TXT_COMP_SITE"];
                
            }
            conn.Close();
            return model;
        }

        public List<CompanyModel> GetCompanyList()
        {
            List<CompanyModel> List = new List<CompanyModel>();
            NpgsqlConnection conn = new NpgsqlConnection(dbContext.ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from \"VacationInfo\".\"COMPANY\" order by \"PK_COMPANY_ID\" DESC";

            conn.Open();
            NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                CompanyModel model = new CompanyModel();
                model.PK_COMPANY_ID = Convert.ToInt32(rdr["PK_COMPANY_ID"]);
                model.CH_COMP_NAME = (string)rdr["CH_COMP_NAME"];
                model.INT_QUALITY = Convert.ToInt32(rdr["INT_QUALITY"]);
                model.TM_CLOSING_TIME = (string)rdr["TM_CLOSING_TIME"];
                model.TM_OPENING_TIME = (string)rdr["TM_OPENING_TIME"];
                if(rdr["TXT_COMP_DESCRIPTION"]!=DBNull.Value)
                model.TXT_COMP_DESCRIPTION = (string)rdr["TXT_COMP_DESCRIPTION"];
                model.TXT_COMP_SITE = (string)rdr["TXT_COMP_SITE"];
                List.Add(model);
            }

            conn.Close();
            return List;
        }
    }
}