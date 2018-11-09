using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Models.Login
{
    public class Login : BaseEntity
    {
        //[JsonProperty("로긴아뒤")]
        public string strUserID { get; set; }

        //[JsonProperty("Password")]
        public string strUserPW { get; set; }


        //[IgnoreDataMember]
        public DateTime dtExpired { get; set; }
    }
}
