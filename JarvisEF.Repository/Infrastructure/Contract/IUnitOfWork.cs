﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JarvisEF.Repository.Infrastructure
{
    /// <summary>
    /// https://technotipstutorial.blogspot.com/2018/05/part-57-repository-pattern-4-adding.html
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Return the database reference for this UOW
        /// </summary>
        DbContext Db { get; }

        int Complete();



        IMemberRepository Member { get; }
    }
}
