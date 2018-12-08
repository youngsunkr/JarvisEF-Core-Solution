using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JarvisEF.Models;
using JarvisEF.Repository.Infrastructure;

namespace JarvisEF.Repository
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(PlutoContext context)
            : base(context)
        {
        }


        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext;}
        }

        public Task<TEntity> Delete<TEntity>(int id)
        {
            throw new NotImplementedException();
        }

        public new Task<TEntity> Get<TEntity>(int id)
        {
            throw new NotImplementedException();
        }
    }

}
