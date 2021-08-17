using MongoDB.DataAccess.Repository;
using MongoDB.Entities.Concrete;

namespace MongoDB.DataAccess.Abstract
{
    public  interface ICityDAL : IRepository<City>
    {
    }
}
