using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class InMemoryCarDal :ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1 , DailyPrice= 100, Description = "Mercedes", ModelYear = 2010},
                new Car{Id = 2, BrandId = 2, ColorId = 2 , DailyPrice= 120, Description = "Ford", ModelYear = 2016},
                new Car{Id = 3, BrandId = 3, ColorId = 3 , DailyPrice= 140, Description = "Audi", ModelYear = 2018},
                new Car{Id = 4, BrandId = 4, ColorId = 4 , DailyPrice= 160, Description = "Fiat", ModelYear = 2020},
                new Car{Id = 5, BrandId = 5, ColorId = 5 , DailyPrice= 180, Description = "Opel", ModelYear = 2020}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            Car carToFind = _cars.SingleOrDefault(c=>c.Id == id);
            return carToFind;
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
