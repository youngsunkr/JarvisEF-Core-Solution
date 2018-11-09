using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Models.Login
{
    public class Auth_Token : BaseEntity
    {
        public string strHeader { get; set; } = "Bearer";
        public string strToken { get; set; }
    }
}