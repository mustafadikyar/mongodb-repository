using MongoDB.Entities;
using MongoDB.Utilities.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDB.DataAccess.Repository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        GetManyResult<T> GetAll();
        Task<GetManyResult<T>> GetAllAsync();
        GetManyResult<T> FilterBy(Expression<Func<T, bool>> expression);
        Task<GetManyResult<T>> FilterByAsync(Expression<Func<T, bool>> expression);
        GetOneResult<T> GetById(string id);
        Task<GetOneResult<T>> GetByIdAsync(string id);
        GetOneResult<T> InsertOne(T entity);
        Task<GetOneResult<T>> InsertOneAsync(T entity);
        GetManyResult<T> InsertMany(ICollection<T> entities);
        Task<GetManyResult<T>> InsertManyAsync(ICollection<T> entities);
        GetOneResult<T> ReplaceOne(T entity, string id);
        Task<GetOneResult<T>> ReplaceOneAsync(T entity, string id);
        GetOneResult<T> DeleteOne(Expression<Func<T, bool>> expression);
        Task<GetOneResult<T>> DeleteOneAsync(Expression<Func<T, bool>> expression);
        GetOneResult<T> DeleteById(string id);
        Task<GetOneResult<T>> DeleteByIdAsync(string id);
        void DeleteMany(Expression<Func<T, bool>> expression);
        Task DeleteManyAsync(Expression<Func<T, bool>> expression);
    }
}
