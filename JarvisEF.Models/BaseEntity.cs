using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Models
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IPAddress { get; set; }

        public bool IsSuccess { get; set; } = false;
    }
}
