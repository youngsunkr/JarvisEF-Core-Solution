using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JarvisEF.Models;
using JarvisEF.Repository.Infrastructure;

namespace JarvisEF.Repository
{
    public class MemberRepository : IBaseRepository<Member>, IMemberRepository
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Member, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Member, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public Task Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetAll(Expression<Func<Member, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public Member Insert(Member entity)
        {
            throw new NotImplementedException();
        }

        public Member SingleOrDefault(Expression<Func<Member, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public void Update(Member entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateAll(IList<Member> entities)
        {
            throw new NotImplementedException();
        }
    }
}
