﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JarvisEF.Repository.Infrastructure
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Retrieve a single item by it's primary key or return null if not found
        /// </summary>
        /// <param name="primaryKey">Prmary key to find</param>
        /// <returns>TEntity</returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> whereCondition);

        /// <summary>
        /// Returns all the rows for type TEntity
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Returns all the rows for type TEntity on basis of filter condition
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> whereCondition);

        /// <summary>
        /// Inserts the data into the table
        /// </summary>
        /// <param name="entity">The entity to insert</param>
        /// <param name="userId">The user performing the insert</param>
        /// <returns></returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Updates this entity in the database using it's primary key
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <param name="userId">The user performing the update</param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates all the passed entities in the database 
        /// </summary>
        /// <param name="entities">Entities to update</param>
        void UpdateAll(IList<TEntity> entities);

        /// <summary>
        /// Deletes this entry fro the database
        /// ** WARNING - Most items should be marked inactive and Updated, not deleted
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <param name="userId">The user Id who deleted the entity</param>
        /// <returns></returns>
        void Delete(Expression<Func<TEntity, bool>> whereCondition);

        /// <summary>
        /// Does this item exist by it's primary key
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<TEntity, bool>> whereCondition);
    }
}
