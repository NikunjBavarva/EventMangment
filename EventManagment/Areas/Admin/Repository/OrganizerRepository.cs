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
    public class OrganizerRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add  
        public bool Add(Organizer obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Sp_Organizer_Insert", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@EventName", obj.EventName);
            com.Parameters.AddWithValue("@EventDetails", obj.EventDetails);

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
        public List<Organizer> GetAll()
        {
            connection();
            List<Organizer> OrganizerList = new List<Organizer>();


            SqlCommand com = new SqlCommand("Sp_Organizer_SelectAll", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                OrganizerList.Add(
                    new Organizer
                    {
                        EventId = Convert.ToInt32(dr["EventId"]),
                        Name = Convert.ToString(dr["Name"]),
                        EventName = Convert.ToString(dr["EventName"]),
                        EventDetails = Convert.ToString(dr["EventDetails"])
                    }
                    );
            }
            return OrganizerList;
        }

        //To Update  
        public bool Update(Organizer obj)
        {
            connection();
            SqlCommand com = new SqlCommand("Sp_Organizer_Update", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@EventId", obj.EventId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@EventName", obj.EventName);
            com.Parameters.AddWithValue("@EventDetails", obj.EventDetails);

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
            SqlCommand com = new SqlCommand("Sp_Organizer_Delete", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);

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