using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JarvisEF.Repository.Infrastructure
{
    /// <summary>
    /// Base class for all SQL based service classes
    /// </summary>
    /// <typeparam name="TEntity">The domain object type</typeparam>
    /// <typeparam name="TU">The database object type</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<TEntity>();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> whereCondition)
        {
            var dbResult = dbSet.Where(whereCondition).FirstOrDefault();
            return dbResult;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> whereCondition)
        {
            return dbSet.Where(whereCondition).AsEnumerable();
        }

        public virtual TEntity Insert(TEntity entity)
        {

            dynamic obj = dbSet.Add(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj;

        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            this._unitOfWork.Db.SaveChanges();


        }

        public virtual void UpdateAll(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                dbSet.Attach(entity);
                _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            }
            this._unitOfWork.Db.SaveChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> whereCondition)
        {
            IEnumerable<TEntity> entities = this.GetAll(whereCondition);
            foreach (TEntity entity in entities)
            {
                if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
            this._unitOfWork.Db.SaveChanges();
        }

        //--------------Exra generic methods--------------------------------

        public TEntity SingleOrDefaultOrderBy(Expression<Func<TEntity, bool>> whereCondition, Expression<Func<TEntity, int>> orderBy, string direction)
        {
            if (direction == "ASC")
            {
                return dbSet.Where(whereCondition).OrderBy(orderBy).FirstOrDefault();

            }
            else
            {
                return dbSet.Where(whereCondition).OrderByDescending(orderBy).FirstOrDefault();
            }
        }

        public bool Exists(Expression<Func<TEntity, bool>> whereCondition)
        {
            return dbSet.Any(whereCondition);
        }

        public int Count(Expression<Func<TEntity, bool>> whereCondition)
        {
            return dbSet.Where(whereCondition).Count();
        }

        public IEnumerable<TEntity> GetPagedRecords(Expression<Func<TEntity, bool>> whereCondition, Expression<Func<TEntity, string>> orderBy, int pageNo, int pageSize)
        {
            return (dbSet.Where(whereCondition).OrderBy(orderBy).Skip((pageNo - 1) * pageSize).Take(pageSize)).AsEnumerable();
        }

        //public IEnumerable<TEntity> ExecWithStoreProcedure(string query, params object[] parameters)
        //{
        //    return dbSet.SqlQuery(query, parameters);
        //}
    }
}
