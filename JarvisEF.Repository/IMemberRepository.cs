using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JarvisEF.Models;
using JarvisEF.Repository.Infrastructure;

namespace JarvisEF.Repository
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<TEntity> Get<TEntity>(int id);
        Task<TEntity> Delete<TEntity>(int id);
    }
}
