using MongoDB.Entities.Concrete;
using MongoDB.Utilities.Model;

namespace MongoDB.Business.Abstract
{
    public interface ICityService
    {
        GetManyResult<City> GetAllCities();
        GetOneResult<City> InsertOne(City model);
    }
}
