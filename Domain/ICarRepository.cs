using Domain;
using System.Collections.Generic;

namespace DataAccess
{
    public interface ICarRepository
    {
        bool Delete(int id);
        Car GetById(int id);
        List<Car> GetCarsList();
        bool Insert(Car domainEntity);
        bool UpsertCar(Car domainEntity);
    }
}