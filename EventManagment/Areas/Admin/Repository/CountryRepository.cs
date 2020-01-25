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
    public class CountryRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add  
        public bool Add(Country obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Sp_Country_Insert", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CountryName", obj.CountryName);

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
        public List<Country> GetAll()
        {
            connection();
            List<Country> countryList = new List<Country>();


            SqlCommand com = new SqlCommand("Sp_Country_SelectAll", con);
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

                    new Country
                    {
                        CountryId = Convert.ToInt32(dr["CountryId"]),
                        CountryName = Convert.ToString(dr["CountryName"])
                    }
                    );
            }
            return countryList;
        }

        //To Update  
        public bool Update(Country obj)
        {
            connection();
            SqlCommand com = new SqlCommand("Sp_Country_Update", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CountryId", obj.CountryId);
            com.Parameters.AddWithValue("@CountryName", obj.CountryName);

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
            SqlCommand com = new SqlCommand("Sp_Country_Delete", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CountryId", Id);

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