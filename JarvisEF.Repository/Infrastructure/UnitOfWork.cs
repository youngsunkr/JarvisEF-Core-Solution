using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisEF.Repository.Infrastructure
{
    /// <summary>
    /// https://technotipstutorial.blogspot.com/2018/05/part-58-repository-pattern-5-setup.html
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MVCTutorialEntitiesContainer _dbContext;

        public UnitOfWork()
        {
            _dbContext = new MVCTutorialEntitiesContainer();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
