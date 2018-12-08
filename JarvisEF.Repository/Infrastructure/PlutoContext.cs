using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace JarvisEF.Repository.Infrastructure
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()// : base("DefaultConnection")
        {
            //Configuration.LazyLoadingEnabled = false;
        }

    }
}
