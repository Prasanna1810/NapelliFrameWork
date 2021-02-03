using MySql.Data.MySqlClient;
using NapelliFrameWork;
using NapelliVO;
using System;
using System.Data;
using static NapelliFrameWork.StatusInfo;

namespace NapelliServerFrameWork
{
    public class User
    {
        public StatusInfo status;
        public User(UserInfo uinfo)
        {
            status = new StatusInfo(uinfo);
        }
        public DataTable UserLogin(UserRegisterVO urVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select user_name, password from user_register where user_name = @uname and password = @pwd";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uname", urVO.UserName);
                cmd.Parameters.AddWithValue("@pwd", urVO.Password);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                status.errcode = 1;
                status.errmesg = ex.Message;
                status.rowcount = -1;
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        public string RegisterUser(UserRegisterVO userVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "insert into user_register(user_name, email_id, password, confirm_password, mobile_number, state, city, accept_t_c) values(@fname, @email, @pwd, @conpwd, @mobile, @state, @city,@tc)";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@fname", userVO.UserName);
                cmd.Parameters.AddWithValue("@email", userVO.Email_id);
                cmd.Parameters.AddWithValue("@pwd", userVO.Password);
                cmd.Parameters.AddWithValue("@conpwd", userVO.Confirm_pwd);
                cmd.Parameters.AddWithValue("@mobile", userVO.Mobile_number);
                cmd.Parameters.AddWithValue("@state", userVO.State);
                cmd.Parameters.AddWithValue("@city", userVO.City);
                cmd.Parameters.AddWithValue("@tc", userVO.Accept_TC);
                Int32 row = cmd.ExecuteNonQuery();
                if (row > 0)
                    return "Inserted";
                else
                    return "Not Inserted";
            }
            catch (Exception ex)
            {
                status.errcode = 1;
                status.errmesg = ex.Message;
                status.rowcount = -1;
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}
