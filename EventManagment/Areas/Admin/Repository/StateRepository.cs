using EventManagment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventManagment.Areas.Admin.Repository
{
    public class StateRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add  
        public bool Add(State obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Sp_State_Insert", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StateName", obj.StateName);
            com.Parameters.AddWithValue("@CountryId", obj.CountryId);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //To view    
        public List<State> GetAll()
        {
            connection();
            List<State> countryList = new List<State>();


            SqlCommand com = new SqlCommand("Sp_State_SelectAll", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                countryList.Add(

                    new State
                    {
                        StateId = Convert.ToInt32(dr["StateId"]),
                        StateName = Convert.ToString(dr["StateName"]),
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                    }
                    );
            }
            return countryList;
        }

        //To Update  
        public bool Update(State obj)
        {
            connection();
            SqlCommand com = new SqlCommand("Sp_State_Update", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@StateId", obj.StateId);
            com.Parameters.AddWithValue("@StateName", obj.StateName);
            com.Parameters.AddWithValue("@CountryId", obj.CountryId);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //To delete     
        public bool Delete(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("Sp_State_Delete", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StateId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}