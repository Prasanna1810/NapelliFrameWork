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
        public DataTable UserLogin(UserRegisterVO rVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select user_id, email_id from user_register where email_id = @email and password = @pwd";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@email", rVO.Email_id);
                cmd.Parameters.AddWithValue("@pwd", rVO.Password);
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

                string query = "select email_id, mobile_number, password from user_register where email_id = @email or mobile_number = @mnum";
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
                string query = "insert into personal_edu_details(user_id, sur_name, full_name, gender, date_birth, age, place_birth, birth_time, birth_name, marital_status, height, star, padam, rasi, caste_id, city, physical_status, mother_tongue, country, state, complexion, paternal_gotram, maternal_gotram, sub_cast_id, religion, qualification, college) " +
                    "values(@uid, @sname, @fname, @gen, @dob, @age, @pob, @bt, @bn, @ms, @hit, @star, @pad, @rasi, @cid, @city, @pgy, @mtou, @con, @sta, @com, @pg, @mg, @scid, @reg, @qua, @col)";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", perEduVO.UserId);
                cmd.Parameters.AddWithValue("@sname", perEduVO.SurName);
                cmd.Parameters.AddWithValue("@fname", perEduVO.FullName);
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
                string query = "insert into image(user_id, profile_pic, image1, image2, image3, image4, image5) values(@uid, @name, @img1, @img2, @img3, @img4, @img5)";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", iVO.UserId);
                cmd.Parameters.AddWithValue("@name", iVO.ProfilePic);
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
        public DataTable GetCities(int stat_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_cities where state_id = @sid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@sid", stat_id);
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

                string query = "select * from master_designation";
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
        public DataTable GetStates(int coun_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_states where country_id = @cid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@cid", coun_id);
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
        public DataTable GetSubCast(int scaste_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from master_sub_caste where caste_id = @scid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@scid", scaste_id);
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
        public DataTable GetPackage()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select package_id, pack_name from package";
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
        public DataTable GetPackageDetails(int pack_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from package where package_id = @pid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@pid", pack_id);
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
        public DataTable GetPackCoupCalculation(int pack_id, string coupCode)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "select p.pack_price, c.coupon_offer, c.coupon_validfrom, c.coupon_validto from package p inner join cupons c on c.coupon_code = @ccode and p.package_id = @pid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@pid", pack_id);
                cmd.Parameters.AddWithValue("@ccode", coupCode);
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
        public DataTable GetFamilyDetails(int user_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "SELECT * FROM family_details where user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", user_id);
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
        public DataTable GetPersonalEducationalDetails(int user_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select ped.sur_name, ped.full_name, ped.gender, ped.date_birth, ped.age, ped.place_birth, ped.birth_time, ped.birth_name, ped.marital_status, ped.height, ms.star_name, ped.padam, mr.rasi, mc.caste, cit.name as city, ped.physical_status, ml.language_name, con.name as country, st.name as state, msc.subcast_name as sub_caste, reg.religion_name, mq.quali_name as qualification, ped.complexion, ped. paternal_gotram, ped.maternal_gotram, ped.college from personal_edu_details ped inner join master_star ms on ms.star_id = ped.star inner join master_rasi mr on ped.rasi = mr.rasi_id inner join master_caste mc on ped.caste_id = mc.caste_id inner join master_cities cit on ped.city = cit.city_id inner join master_language ml on ped.mother_tongue = ml.lang_id inner join master_countries con on ped.country = con.coun_id inner join master_states st on ped.state = st.state_id inner join master_sub_caste msc on ped.sub_cast_id = msc.sub_caste_id inner join master_religion reg on ped.religion = reg.relig_id inner join master_qualification mq on ped.qualification = mq.quli_id where ped.user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", user_id);
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
        public DataTable GetProfessionalDetails(int user_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select pd.employee_type, md.designation_name, pd.company_name, pd.salary_annum, pd.income from professional_details pd inner join master_designation md on pd.designation = md.desi_id and pd.user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", user_id);
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
        public DataTable GetPartnerPreferencesDetails(int user_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select pp.job_type, mq.quali_name, pp.age_from, pp.age_to, pp.height_from, pp.height_to, pp.family_type, pp.physical_status, pp.requirements, pp.complexion, cu.name as country_name, ms.name as state_name, mc.name as city_name from partner_preference pp inner join master_qualification mq on pp.qualification_id = mq.quli_id inner join master_countries cu on pp.country_id = cu.coun_id inner join master_states ms on pp.state_id = ms.state_id inner join master_cities mc on pp.city_id = mc.city_id and pp.user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", user_id);
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
        public DataTable GetImages(int user_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "SELECT * FROM image where user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", user_id);
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
        public DataTable GetPackageCuponsDetails(int user_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select cupon_code, p.pack_name, p.covered, p.coupon from package_cupons pc inner join package p on pc.pack_id = p.package_id where pc.user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", user_id);
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
        public string UpdateFamily(FamilyVO fVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "update family_details set father_name = @fname, mother_name = @mname, brother = @bro, sister = @sis, family_type = @ftype where user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@fname", fVO.FatherName);
                cmd.Parameters.AddWithValue("@mname", fVO.MotherName);
                cmd.Parameters.AddWithValue("@bro", fVO.Brother);
                cmd.Parameters.AddWithValue("@sis", fVO.Sister);
                cmd.Parameters.AddWithValue("@ftype", fVO.FamilyType);
                cmd.Parameters.AddWithValue("@uid", fVO.UserId);
                Int32 row = cmd.ExecuteNonQuery();
                if (row > 0)
                    return "Updated";
                else
                    return "Not Updated";
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
        public string UpdateProfessional(ProfessionalVo pVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "update professional_details set employee_type = @etype, designation = @deg, company_name = @cname, salary_annum = @spanum, income = @income where user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@etype", pVO.EmployeeType);
                cmd.Parameters.AddWithValue("@deg", pVO.Designation);
                cmd.Parameters.AddWithValue("@cname", pVO.CompanyName);
                cmd.Parameters.AddWithValue("@spanum", pVO.SalaryPerAnnum);
                cmd.Parameters.AddWithValue("@income", pVO.Income);
                cmd.Parameters.AddWithValue("@uid", pVO.UserId);
                Int32 row = cmd.ExecuteNonQuery();
                if (row > 0)
                    return "Updated";
                else
                    return "Not Updated";
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
        public string UpdatePartnerPreference(PartnerPrefVO ppVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "update partner_preference set job_type = @jtype, qualification_id = @qalf, age_from = @agef, age_to = @aget, height_from = @higf, height_to = @higt, family_type = @ftype, country_id = @cid, physical_status = @psts, state_id = @sid, requirements = @req, city_id = @cityid, complexion = @com where user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@jtype", ppVO.JobType);
                cmd.Parameters.AddWithValue("@qalf", ppVO.QualificationId);
                cmd.Parameters.AddWithValue("@agef", ppVO.AgeForm);
                cmd.Parameters.AddWithValue("@aget", ppVO.AgeTo);
                cmd.Parameters.AddWithValue("@higf", ppVO.HeightFrom);
                cmd.Parameters.AddWithValue("@higt", ppVO.HeightTo);
                cmd.Parameters.AddWithValue("@ftype", ppVO.FamiltType);
                cmd.Parameters.AddWithValue("@cid", ppVO.CountryId);
                cmd.Parameters.AddWithValue("@psts", ppVO.PhysicalStatus);
                cmd.Parameters.AddWithValue("@sid", ppVO.StateId);
                cmd.Parameters.AddWithValue("@req", ppVO.Requirements);
                cmd.Parameters.AddWithValue("@cityid", ppVO.CityId);
                cmd.Parameters.AddWithValue("@com", ppVO.Complexion);
                cmd.Parameters.AddWithValue("@uid", ppVO.UserId);
                Int32 row = cmd.ExecuteNonQuery();
                if (row > 0)
                    return "Updated";
                else
                    return "Not Updated";
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
        public string UpdatePersonalEdu(PersonalEduVO peVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "update personal_edu_details set sur_name = @sname, full_name = @fname, gender = @gen, date_birth = @dob, age = @age, place_birth = @pob, sub_cast_id = @scid, birth_time = @btime, birth_name = @bname, marital_status = @msts, height = @hit, star = @star, padam = @padam, rasi = @rasi, caste_id = @cid, city = @city, physical_status = @psts, mother_tongue = @mtng, country = @con, state = @sta, complexion = @com, paternal_gotram = @pgot, maternal_gotram = @mgot, religion = @reg, qualification = @qlf, college = @clz where user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@sname", peVO.SurName);
                cmd.Parameters.AddWithValue("@fname", peVO.FullName);
                cmd.Parameters.AddWithValue("@gen", peVO.Gender);
                cmd.Parameters.AddWithValue("@dob", peVO.DateOfBirth);
                cmd.Parameters.AddWithValue("@age", peVO.Age);
                cmd.Parameters.AddWithValue("@pob", peVO.PlaceOfBirth);
                cmd.Parameters.AddWithValue("@scid", peVO.SubCastId);
                cmd.Parameters.AddWithValue("@btime", peVO.BirthTime);
                cmd.Parameters.AddWithValue("@bname", peVO.BirthName);
                cmd.Parameters.AddWithValue("@msts", peVO.MaritalStatus);
                cmd.Parameters.AddWithValue("@hit", peVO.Height);
                cmd.Parameters.AddWithValue("@star", peVO.Star);
                cmd.Parameters.AddWithValue("@padam", peVO.Padam);
                cmd.Parameters.AddWithValue("@rasi", peVO.Rasi);
                cmd.Parameters.AddWithValue("@cid", peVO.CasteId);
                cmd.Parameters.AddWithValue("@city", peVO.City);
                cmd.Parameters.AddWithValue("@psts", peVO.PhysicalStatus);
                cmd.Parameters.AddWithValue("@mtng", peVO.MotherTounge);
                cmd.Parameters.AddWithValue("@con", peVO.Country);
                cmd.Parameters.AddWithValue("@sta", peVO.State);
                cmd.Parameters.AddWithValue("@com", peVO.Complexion);
                cmd.Parameters.AddWithValue("@pgot", peVO.PaternalGotram);
                cmd.Parameters.AddWithValue("@mgot", peVO.MaternalGotram);
                cmd.Parameters.AddWithValue("@reg", peVO.Religion);
                cmd.Parameters.AddWithValue("@qlf", peVO.Qualification);
                cmd.Parameters.AddWithValue("@clz", peVO.College);
                cmd.Parameters.AddWithValue("@uid", peVO.UserId);
                Int32 row = cmd.ExecuteNonQuery();
                if (row > 0)
                    return "Updated";
                else
                    return "Not Updated";
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
        public string UpdateImage(ImageVO iVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                string query = "update image set profile_pic = @pname, image1 = @i1, image2 = @i2, image3 = @i3, image4 = @i4, image5 = @i5 where user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@pname", iVO.ProfilePic);
                cmd.Parameters.AddWithValue("@i1", iVO.Image1);
                cmd.Parameters.AddWithValue("@i2", iVO.Image2);
                cmd.Parameters.AddWithValue("@i3", iVO.Image3);
                cmd.Parameters.AddWithValue("@i4", iVO.Image4);
                cmd.Parameters.AddWithValue("@i5", iVO.Image5);
                cmd.Parameters.AddWithValue("@uid", iVO.UserId);
                Int32 row = cmd.ExecuteNonQuery();
                if (row > 0)
                    return "Updated";
                else
                    return "Not Updated";
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
        public DataTable ViewProfile(int user_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select f.father_name, f.mother_name, f.brother, f.sister, f.family_type, pd.employee_type, md.designation_name, pd.company_name, pd.salary_annum, pd.income, pp.job_type, mq.quali_name, pp.age_from, pp.age_to, pp.height_from, pp.height_to, pp.family_type, pp.physical_status, pp.requirements, pp.complexion, cu.name as country_name, ms.name as state_name, cit1.name as city_name, ped.sur_name, ped.full_name, ped.gender, ped.date_birth, ped.age, ped.place_birth, ped.birth_time, ped.birth_name, ped.marital_status, ped.height, str.star_name, ped.padam, mr.rasi, mc.caste, cit.name as city, ped.physical_status, ml.language_name, con.name as country, st.name as state, msc.subcast_name as sub_caste, reg.religion_name, mq1.quali_name as qualification, ped.complexion, ped. paternal_gotram, ped.maternal_gotram, ped.college from family_details f, professional_details pd inner join master_designation md on pd.designation = md.desi_id, partner_preference pp inner join master_qualification mq on pp.qualification_id = mq.quli_id inner join master_countries cu on pp.country_id = cu.coun_id inner join master_states ms on pp.state_id = ms.state_id inner join master_cities cit1 on pp.city_id = cit1.city_id, personal_edu_details ped inner join master_star str on str.star_id = ped.star inner join master_rasi mr on ped.rasi = mr.rasi_id inner join master_caste mc on ped.caste_id = mc.caste_id inner join master_cities cit on ped.city = cit.city_id inner join master_language ml on ped.mother_tongue = ml.lang_id inner join master_countries con on ped.country = con.coun_id inner join master_states st on ped.state = st.state_id inner join master_sub_caste msc on ped.sub_cast_id = msc.sub_caste_id inner join master_religion reg on ped.religion = reg.relig_id inner join master_qualification mq1 on ped.qualification = mq1.quli_id where f.user_id = @uid and pd.user_id = @uid and ped.user_id = @uid and pp.user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", user_id);
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
        public DataTable GetPersonalEducationalEdit(int user_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from personal_edu_details where user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", user_id);
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
        public DataTable GetProfessionalEdit(int user_id)

        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from professional_details where user_id = @uid";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", user_id);
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
        public DataTable GetPartnerPreferencesEdit(int user_id)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select * from partner_preference where user_id = @uid"; 
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uid", user_id);
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
