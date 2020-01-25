using EventManagment.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventManagment.Areas.Admin.Repository
{
    public class CityRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add  
        public bool Add(City obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Sp_City_Insert", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CityName", obj.CityName);
            com.Parameters.AddWithValue("@StateId", obj.StateId);

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
        public List<City> GetAll()
        {
            connection();
            List<City> countryList = new List<City>();


            SqlCommand com = new SqlCommand("Sp_City_SelectAll", con);
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

                    new City
                    {
                        CityId = Convert.ToInt32(dr["CityId"]),
                        CityName = Convert.ToString(dr["CityName"]),
                        StateId = Convert.ToInt32(dr["StateId"]),
                    }
                    );
            }
            return countryList;
        }

        //To Update  
        public bool Update(City obj)
        {
            connection();
            SqlCommand com = new SqlCommand("Sp_City_Update", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CityId", obj.CityId);
            com.Parameters.AddWithValue("@CityName", obj.CityName);
            com.Parameters.AddWithValue("@StateId", obj.StateId);

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
            SqlCommand com = new SqlCommand("Sp_City_Delete", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CityId", Id);

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