using Business.Concretes;
using Core.Entities.Concretes;
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
            /*UserManager userManager = new UserManager(new EfUserDal());
            User user = new User() { FirstName = "a", LastName = "b", Email = "e", Password = "f" };
            userManager.Add(user);*/
             CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
             
            /*foreach (var customer in customerManager.GetCustomerDetailDtos().Data)
            {
                Console.WriteLine(customer.FirstName);
            }*/
        }

        private static void CarProcess(CarManager carManager)
        {
            
            foreach (var car in carManager.GetCarDetailDtos().Data)
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }
            //CarProcess(carManager);
            /*Car car1 = new Car() {BrandId=1,ColorId=1,Description="AddedCar",DailyPrice=120,ModelYear=2016 };
            carManager.Add(car1);*/

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.DailyPrice);
            }
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
