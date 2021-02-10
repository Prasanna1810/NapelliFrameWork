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

                string query = "select email_id from user_register where email_id = @email and password = @pwd";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@email", urVO.Email_id);
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
        public DataTable CheckMail(string Email_id, string Mobile_number)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select email_id, mobile_number from user_register where email_id = @email or mobile_number = @mnum";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@email", Email_id);
                cmd.Parameters.AddWithValue("@mnum", Mobile_number);
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
                string query = "insert into user_register(user_name, email_id, password, mobile_number, profile_for) values(@uname, @email, @pwd, @mobile, @pfor)";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uname", userVO.UserName);
                cmd.Parameters.AddWithValue("@email", userVO.Email_id);
                cmd.Parameters.AddWithValue("@pwd", userVO.Password);
                cmd.Parameters.AddWithValue("@mobile", userVO.Mobile_number);
                cmd.Parameters.AddWithValue("@pfor", userVO.ProfileFor);
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
        public string FamilyDetails(FamilyVO famVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "insert into family_details(user_id, father_name, mother_name, brother, sister, family_type) values(@uid, @fname, @mname, @bro, @sis, @ftype)";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", famVO.UserId);
                cmd.Parameters.AddWithValue("@fname", famVO.FatherName);
                cmd.Parameters.AddWithValue("@mname", famVO.MotherName);
                cmd.Parameters.AddWithValue("@bro", famVO.Brother);
                cmd.Parameters.AddWithValue("@sis", famVO.Sister);
                cmd.Parameters.AddWithValue("@ftype", famVO.FamilyType);
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
        public string ProfessionalDetails(ProfessionalVo proVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "insert into professional_details(user_id, employee_type, designation, company_name, salary_annum, income) values(@uid, @etype, @deg, @cname, @sal, @inc)";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", proVO.UserId);
                cmd.Parameters.AddWithValue("@etype", proVO.EmployeeType);
                cmd.Parameters.AddWithValue("@deg", proVO.Designation);
                cmd.Parameters.AddWithValue("@cname", proVO.CompanyName);
                cmd.Parameters.AddWithValue("@sal", proVO.SalaryPerAnnum);
                cmd.Parameters.AddWithValue("@inc", proVO.Income);
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
        public string PartnerPreference(PartnerPrefVO parVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "insert into partner_preference" +
                    "(user_id, job_type, qualification_id, age_from, age_to, height_from, height_to, family_type, country_id, physical_status, state_id, requirements, city_id, complexion) " +
                    "values(@uid, @ejtype, @qua, @agef, @aget, @hitf, @hitto, @ftype, @counid, @phys, @sid, @req, @city, @com)";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", parVO.UserId);
                cmd.Parameters.AddWithValue("@ejtype", parVO.JobType);
                cmd.Parameters.AddWithValue("@qua", parVO.QualificationId);
                cmd.Parameters.AddWithValue("@agef", parVO.AgeForm);
                cmd.Parameters.AddWithValue("@aget", parVO.AgeTo);
                cmd.Parameters.AddWithValue("@hitf", parVO.HeightFrom);
                cmd.Parameters.AddWithValue("@hitto", parVO.HeightTo);
                cmd.Parameters.AddWithValue("@ftype", parVO.FamiltType);
                cmd.Parameters.AddWithValue("@counid", parVO.CountryId);
                cmd.Parameters.AddWithValue("@phys", parVO.PhysicalStatus);
                cmd.Parameters.AddWithValue("@sid", parVO.StateId);
                cmd.Parameters.AddWithValue("@req", parVO.Requirements);
                cmd.Parameters.AddWithValue("@city", parVO.CityId);
                cmd.Parameters.AddWithValue("@com", parVO.Complexion);
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
        public string PersonalEducation(PersonalEduVO perEduVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "insert into personal_edu_details(user_id, sur_name, full_name, email_id, mobile_number, gender, date_birth, place_birth, birth_time, birth_name, marital_status, height, star, padam, rasi, caste_id, city, physical_status, mother_tongue, country, state, complexion, paternal_gotram, maternal_gotram, higher_education, sub_cast_id, religion, qualification, college) " +
                    "values(@uid, @sname, @fname, @email, @mnum, @gen, @dob, @age, @pob, @bt, @bn, @ms, @hit, @star, @pad, @rasi, @cid, @city, @pgy, @mtou, @con, @sta, @com, @pg, @mg, @hedu, @scid, @reg, @qua, @col)";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", perEduVO.UserId);
                cmd.Parameters.AddWithValue("@sname", perEduVO.SurName);
                cmd.Parameters.AddWithValue("@fname", perEduVO.FullName);
                cmd.Parameters.AddWithValue("@email", perEduVO.Email_id);
                cmd.Parameters.AddWithValue("@mnum", perEduVO.Mobile_number);
                cmd.Parameters.AddWithValue("@gen", perEduVO.Gender);
                cmd.Parameters.AddWithValue("@dob", perEduVO.DateOfBirth);
                cmd.Parameters.AddWithValue("@age", perEduVO.Age);
                cmd.Parameters.AddWithValue("@pob", perEduVO.PlaceOfBirth);
                cmd.Parameters.AddWithValue("@bt", perEduVO.BirthTime);
                cmd.Parameters.AddWithValue("@bn", perEduVO.BirthName);
                cmd.Parameters.AddWithValue("@ms", perEduVO.MaritalStatus);
                cmd.Parameters.AddWithValue("@hit", perEduVO.Height);
                cmd.Parameters.AddWithValue("@star", perEduVO.Star);
                cmd.Parameters.AddWithValue("@pad", perEduVO.Padam);
                cmd.Parameters.AddWithValue("@rasi", perEduVO.Rasi);
                cmd.Parameters.AddWithValue("@cid", perEduVO.CasteId);
                cmd.Parameters.AddWithValue("@city", perEduVO.City);
                cmd.Parameters.AddWithValue("@pgy", perEduVO.PhysicalStatus);
                cmd.Parameters.AddWithValue("@mtou", perEduVO.MotherTounge);
                cmd.Parameters.AddWithValue("@con", perEduVO.Country);
                cmd.Parameters.AddWithValue("@sta", perEduVO.State);
                cmd.Parameters.AddWithValue("@com", perEduVO.Complexion);
                cmd.Parameters.AddWithValue("@pg", perEduVO.PaternalGotram);
                cmd.Parameters.AddWithValue("@mg", perEduVO.MaternalGotram);
                cmd.Parameters.AddWithValue("@hedu", perEduVO.HigherEducation);
                cmd.Parameters.AddWithValue("@scid", perEduVO.SubCastId);
                cmd.Parameters.AddWithValue("@reg", perEduVO.Religion);
                cmd.Parameters.AddWithValue("@qua", perEduVO.Qualification);
                cmd.Parameters.AddWithValue("@col", perEduVO.College);
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
        public DataTable PackageCupons(int user_id, int package_id, string cupon_code)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "package_cupon";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@package_id", package_id);
                cmd.Parameters.AddWithValue("@cupon_code", cupon_code);
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
        public string InsertImage(ImageVO iVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "insert into image(user_id, name, image1, image2, image3, image4, image5) values(@uid, @name, @img1, @img2, @img3, @img4, @img5)";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", iVO.UserId);
                cmd.Parameters.AddWithValue("@name", iVO.Name);
                cmd.Parameters.AddWithValue("@img1", iVO.Image1);
                cmd.Parameters.AddWithValue("@img2", iVO.Image2);
                cmd.Parameters.AddWithValue("@img3", iVO.Image3);
                cmd.Parameters.AddWithValue("@img4", iVO.Image4);
                cmd.Parameters.AddWithValue("@img5", iVO.Image5);
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
        public DataTable GetCaste()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_caste";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GetCities()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_cities";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GetCountries()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_countries";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GetDesgination()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_desgination";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GetLanguage()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_language";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GetQualification()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_qualification";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GetRasi()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_rasi";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GetReligion()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_religion";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GetStar()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_star";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GetStates()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_states";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GetSubCast()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_sub_caste";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
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
        public DataTable GeneralSearch(string gender, int age_from, int age_to, int religion)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select user_id, age, mq.quali_name from personal_edu_details ped Inner join master_qualification mq on ped.qualification = mq.quli_id where gender = @gen and age between @agef and @aget and religion = @relig";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@gen", gender);
                cmd.Parameters.AddWithValue("@agef", age_from);
                cmd.Parameters.AddWithValue("@aget", age_to);
                cmd.Parameters.AddWithValue("@relig", religion);
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

    }
}
