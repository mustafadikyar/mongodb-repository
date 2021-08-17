using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Entities;
using MongoDB.Entities.Contexts;
using MongoDB.Utilities;
using MongoDB.Utilities.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDB.DataAccess.Repository
{
    public class MongoDBRepositoryBase<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly MongoDBContext _context;
        private readonly IMongoCollection<T> _collection;

        public MongoDBRepositoryBase(IOptions<MongoSettings> options)
        {
            _context = new(options);
            _collection = _context.GetCollection<T>();
        }

        public GetManyResult<T> GetAll()
        {
            GetManyResult<T> result = new();
            try
            {
                List<T> data = _collection.AsQueryable().ToList();
                if (data != null) result.Result = data;
            }
            catch (System.Exception ex)
            {
                result.Message = $"GetAll {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public async Task<GetManyResult<T>> GetAllAsync()
        {
            GetManyResult<T> result = new();
            try
            {
                List<T> data = await _collection.AsQueryable().ToListAsync();
                if (data != null) result.Result = data;
            }
            catch (System.Exception ex)
            {
                result.Message = $"GetAllAsync {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public GetOneResult<T> DeleteById(string id)
        {
            GetOneResult<T> result = new();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var data = _collection.FindOneAndDelete(filter);
                if (data != null) result.Entity = data;
            }
            catch (Exception ex)
            {
                result.Message = $"DeleteById {ex.Message}";
                result.Success = false;
                result.Entity = null;
                throw;
            }
            return result;
        }

        public async Task<GetOneResult<T>> DeleteByIdAsync(string id)
        {
            GetOneResult<T> result = new();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var data = await _collection.FindOneAndDeleteAsync(filter);
                if (data != null) result.Entity = data;
            }
            catch (Exception ex)
            {
                result.Message = $"DeleteByIdAsync {ex.Message}";
                result.Success = false;
                result.Entity = null;
                throw;
            }
            return result;
        }

        public void DeleteMany(Expression<Func<T, bool>> expression)
        {
            _collection.DeleteMany(expression);
        }

        public async Task DeleteManyAsync(Expression<Func<T, bool>> expression)
        {
            await _collection.DeleteManyAsync(expression);
        }

        public GetOneResult<T> DeleteOne(Expression<Func<T, bool>> expression)
        {
            GetOneResult<T> result = new();
            try
            {
                var deleted = _collection.FindOneAndDelete(expression);
                result.Entity = deleted;
            }
            catch (System.Exception ex)
            {
                result.Message = $"DeleteOne {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

        public async Task<GetOneResult<T>> DeleteOneAsync(Expression<Func<T, bool>> expression)
        {
            GetOneResult<T> result = new();
            try
            {
                var deleted = await _collection.FindOneAndDeleteAsync(expression);
                result.Entity = deleted;
            }
            catch (System.Exception ex)
            {
                result.Message = $"DeleteOneAsync {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

        public GetManyResult<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            GetManyResult<T> result = new();
            try
            {
                List<T> data = _collection.Find(expression).ToList();
                if (data != null) result.Result = data;
            }
            catch (System.Exception ex)
            {
                result.Message = $"FilterBy {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public async Task<GetManyResult<T>> FilterByAsync(Expression<Func<T, bool>> expression)
        {
            GetManyResult<T> result = new();
            try
            {
                List<T> data = await _collection.Find(expression).ToListAsync();
                if (data != null) result.Result = data;
            }
            catch (System.Exception ex)
            {
                result.Message = $"FilterByAsync {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public GetOneResult<T> GetById(string id)
        {
            GetOneResult<T> result = new();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var data = _collection.Find(filter).FirstOrDefault();
                if (data != null) result.Entity = data;
            }
            catch (Exception ex)
            {
                result.Message = $"GetById {ex.Message}";
                result.Success = false;
                result.Entity = null;
                throw;
            }
            return result;
        }

        public async Task<GetOneResult<T>> GetByIdAsync(string id)
        {
            GetOneResult<T> result = new();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var data = await _collection.Find(filter).FirstOrDefaultAsync();
                if (data != null) result.Entity = data;
            }
            catch (Exception ex)
            {
                result.Message = $"GetByIdAsync {ex.Message}";
                result.Success = false;
                result.Entity = null;
                throw;
            }
            return result;
        }

        public GetManyResult<T> InsertMany(ICollection<T> entities)
        {
            GetManyResult<T> result = new();
            try
            {
                _collection.InsertMany(entities);
                result.Result = entities;
            }
            catch (Exception ex)
            {
                result.Message = $"InsertMany {ex.Message}";
                result.Success = false;
                result.Result = null;
                throw;
            }
            return result;
        }

        public async Task<GetManyResult<T>> InsertManyAsync(ICollection<T> entities)
        {
            GetManyResult<T> result = new();
            try
            {
                await _collection.InsertManyAsync(entities);
                result.Result = entities;
            }
            catch (Exception ex)
            {
                result.Message = $"InsertManyAsync {ex.Message}";
                result.Success = false;
                result.Result = null;
                throw;
            }
            return result;
        }

        public GetOneResult<T> InsertOne(T entity)
        {
            GetOneResult<T> result = new();
            try
            {
                _collection.InsertOne(entity);
                result.Entity = entity;
            }
            catch (Exception ex)
            {
                result.Message = $"InsertOne {ex.Message}";
                result.Success = false;
                result.Entity = null;
                throw;
            }
            return result;
        }

        public async Task<GetOneResult<T>> InsertOneAsync(T entity)
        {
            GetOneResult<T> result = new();
            try
            {
                await _collection.InsertOneAsync(entity);
                result.Entity = entity;
            }
            catch (Exception ex)
            {
                result.Message = $"InsertOneAsync {ex.Message}";
                result.Success = false;
                result.Entity = null;
                throw;
            }
            return result;
        }

        public GetOneResult<T> ReplaceOne(T entity, string id)
        {
            GetOneResult<T> result = new();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var updated = _collection.ReplaceOne(filter, entity);
                result.Entity = entity;
            }
            catch (Exception ex)
            {
                result.Message = $"ReplaceOne {ex.Message}";
                result.Success = false;
                result.Entity = null;
                throw;
            }
            return result;
        }

        public async Task<GetOneResult<T>> ReplaceOneAsync(T entity, string id)
        {
            GetOneResult<T> result = new();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var updated = await _collection.ReplaceOneAsync(filter, entity);
                result.Entity = entity;
            }
            catch (Exception ex)
            {
                result.Message = $"ReplaceOneAsync {ex.Message}";
                result.Success = false;
                result.Entity = null;
                throw;
            }
            return result;
        }
    }
}
