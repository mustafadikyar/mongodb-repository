using MongoDB.Business.Abstract;
using MongoDB.DataAccess.Abstract;
using MongoDB.Entities.Concrete;
using MongoDB.Utilities.Model;

namespace MongoDB.Business.Concrete.Managers
{
    public class CityManager : ICityService
    {
        private readonly ICityDAL _cityDAL;
        public CityManager(ICityDAL cityDAL) => _cityDAL = cityDAL;

        public GetManyResult<City> GetAllCities() => _cityDAL.GetAll();
        public GetOneResult<City> InsertOne(City model) => _cityDAL.InsertOne(model);

    }
}
