using System;
using System.Collections.Generic;
using System.Text;

namespace NapelliVO
{
    public class FamilyVO
    {
        public int user_id { get; set; }
        public string father_name { get; set; }
        public string mother_name { get; set; }
        public int brother { get; set; }
        public int sister { get; set; }
        public string family_type { get; set; }

        //public string family_type { get; set; }
        //public int UserId { get; set; }
        //public String FatherName { get; set; }
        //public string MotherName { get; set; }
        //public int Brother { get; set; }
        //public int Sister { get; set; }
        //public string FamilyType { get; set; }
    }
}
