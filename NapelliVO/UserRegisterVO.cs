using System;

namespace NapelliVO
{
    public class UserRegisterVO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email_id { get; set; }
        public string Password { get; set; }
        public string Confirm_pwd { get; set; }
        public string Mobile_number { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ProfileFor { get; set; }
    }
}
