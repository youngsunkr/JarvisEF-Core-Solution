using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Models
{
    public class BaseEntity
    {
        //public Int64 Id { get; set; }
        public string RegId { get; set; }
        public string RegIp { get; set; }
        public DateTime RegDate { get; set; }
        public string UpdId { get; set; }
        public string UpdIp { get; set; }
        public DateTime UpdDate { get; set; }

        public bool IsSuccess { get; set; } = false;
    }
}
