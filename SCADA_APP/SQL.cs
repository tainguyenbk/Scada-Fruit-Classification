using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SCADA_APP
{
    public class SQL
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.SQLPath);
        public DataTable dt_alarm = new DataTable();
        public DataTable dt_data = new DataTable();
        public DataTable dt_boxdata = new DataTable();
        public bool SQL_Connected = false;
        protected SQL()
        {

        }
        private static SQL _instance;
        public static SQL Instance()
        {
            if (_instance == null)
            {
                _instance = new SQL();
            }
            return _instance;
        }
        public void TestConnection()
        {
            try
            {
                con.Open();
                SQL_Connected = true;
                con.Close();
            }
            catch
            {
                SQL_Connected = false;
            }
        }
        public void Connect()
        {
            SQL_Connected = true;
        }
        public void Disconnect()
        {
            SQL_Connected = false;
        }


        public void Insert_Alarm()
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "INSERT INTO ALARM(TimeDate, Working, Alarm) " +
                    "VALUES(@TimeDate, @Working, @Alarm)";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.AddWithValue("TimeDate", DateTime.Now);
                    com.Parameters.AddWithValue("Working", PLCRead.Instance().Light_Start);
                    com.Parameters.AddWithValue("Alarm", 0);
                    com.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void Show_Alarm()
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "SELECT *FROM ALARM";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt_alarm);
                }
                con.Close();
            }
        }

        public void Delete_Alarm()
        {
            if (SQL_Connected)
            {
                string sqlDelete = "DELETE FROM ALARM ";
                using (SqlCommand com = new SqlCommand(sqlDelete, con))
                {
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    dt_alarm.Clear();
                    da.Fill(dt_alarm);
                }
            }
        }
        public void Query_Alarm(DateTime StartDate, DateTime EndDate)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "SELECT * from ALARM where convert(date, TimeDate) between @StartDate and @EndDate";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.AddWithValue("StartDate", StartDate);
                    com.Parameters.AddWithValue("EndDate", EndDate);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    dt_alarm.Clear();
                    da.Fill(dt_alarm);
                }
                con.Close();
            }
        }
        public void Query_Alarm_Date(DateTime StartDate)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "SELECT * from ALARM where convert(date, TimeDate) between @StartDate and @StartDate";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.AddWithValue("StartDate", StartDate);
                    //com.Parameters.AddWithValue("EndDate", EndDate);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    dt_alarm.Clear();
                    da.Fill(dt_alarm);
                }
                con.Close();
            }
        }


        public void Insert_Data()
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "INSERT INTO DATA(TimeDate, Type1, Type2, Type3, Type4, Total)" +
                    "VALUES(@TimeDate, @Type1, @Type2, @Type3, @Type4, @Total)";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.AddWithValue("TimeDate", DateTime.Now);
                    com.Parameters.AddWithValue("Type1", PLCRead.Instance().Quanity_Red);
                    com.Parameters.AddWithValue("Type2", PLCRead.Instance().Quanity_Orange);
                    com.Parameters.AddWithValue("Type3", PLCRead.Instance().Quanity_Green);
                    com.Parameters.AddWithValue("Type4", PLCRead.Instance().Quanity_Error);
                    com.Parameters.AddWithValue("Total", PLCRead.Instance().Quanity_Total);
                    com.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        public void Show_Data()
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "SELECT *FROM DATA";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt_data);
                }
                con.Close();
            }
        }


        public void Delete_Data()
        {
            if (SQL_Connected)
            {
                string sqlDelete = "DELETE FROM DATA ";
                using (SqlCommand com = new SqlCommand(sqlDelete, con))
                {
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    dt_data.Clear();
                    da.Fill(dt_data);
                }
            }
        }


        public void Query_Data(DateTime StartDate, DateTime EndDate)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "SELECT * from DATA where convert(date, TimeDate) between " +
                    "@StartDate and @EndDate";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.AddWithValue("StartDate", StartDate);
                    com.Parameters.AddWithValue("EndDate", EndDate);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    dt_data.Clear();
                    da.Fill(dt_data);
                }
                con.Close();
            }
        }


        public void Query_Data_Date(DateTime StartDate)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "SELECT * from DATA where convert(date, TimeDate) between @StartDate and @StartDate";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.AddWithValue("StartDate", StartDate);
                    //com.Parameters.AddWithValue("EndDate", EndDate);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    dt_data.Clear();
                    da.Fill(dt_data);
                }
                con.Close();
            }
        }

        public void Insert_BoxData()
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "INSERT INTO BOX_DATA(TimeDate, Box1, Box2, Box3, Box4, Total)" +
                    "VALUES(@TimeDate, @Box1, @Box2, @Box3, @Box4, @Total)";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.AddWithValue("TimeDate", DateTime.Now);
                    com.Parameters.AddWithValue("Box1", PLCRead.Instance().Quanity_Box1);
                    com.Parameters.AddWithValue("Box2", PLCRead.Instance().Quanity_Box2);
                    com.Parameters.AddWithValue("Box3", PLCRead.Instance().Quanity_Box3);
                    com.Parameters.AddWithValue("Box4", PLCRead.Instance().Quanity_Box4);
                    com.Parameters.AddWithValue("Total", PLCRead.Instance().Quanity_Box_Total);
                    com.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        public void Show_BoxData()
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "SELECT *FROM BOX_DATA";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt_boxdata);
                }
                con.Close();
            }
        }

        public void Query_BoxData(DateTime StartDate, DateTime EndDate)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "SELECT * from BOX_DATA where convert(date, TimeDate) between @StartDate and @EndDate";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.AddWithValue("StartDate", StartDate);
                    com.Parameters.AddWithValue("EndDate", EndDate);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    dt_boxdata.Clear();
                    da.Fill(dt_boxdata);
                }
                con.Close();
            }
        }
        public void Query_BoxData_Date(DateTime StartDate)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "SELECT * from BOX_DATA where convert(date, TimeDate) between @StartDate and @StartDate";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.AddWithValue("StartDate", StartDate);
                    //com.Parameters.AddWithValue("EndDate", EndDate);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    dt_boxdata.Clear();
                    da.Fill(dt_boxdata);
                }
                con.Close();
            }
        }

        public void Delete_BoxData()
        {
            if (SQL_Connected)
            {
                string sqlDelete = "DELETE FROM BOX_DATA ";
                using (SqlCommand com = new SqlCommand(sqlDelete, con))
                {
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    dt_boxdata.Clear();
                    da.Fill(dt_boxdata);
                }
            }
        }

    }
}
