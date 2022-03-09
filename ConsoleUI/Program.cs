using Business.Concretes;
using DataAccess.Concretes;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

             foreach (var car in carManager.GetAll())
             {
                 Console.WriteLine(car.Description);
             }
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.DailyPrice);
            }
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.Description);
            }
            /*Car car1 = new Car() {BrandId=1,ColorId=1,Description="AddedCar",DailyPrice=120,ModelYear=2016 };
            carManager.Add(car1);*/
        }
    }
}
