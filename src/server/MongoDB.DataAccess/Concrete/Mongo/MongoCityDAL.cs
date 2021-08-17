using Microsoft.Extensions.Options;
using MongoDB.DataAccess.Abstract;
using MongoDB.DataAccess.Repository;
using MongoDB.Entities.Concrete;
using MongoDB.Utilities;

namespace MongoDB.DataAccess.Concrete.Mongo
{
    public class MongoCityDAL : MongoDBRepositoryBase<City>, ICityDAL
    {
        public MongoCityDAL(IOptions<MongoSettings> options) : base(options)
        {
        }
    }
}
