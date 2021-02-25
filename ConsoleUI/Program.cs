using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICarDal carDal = new EfCarDal();
            //var item = carDal.GetById(5);
            ////foreach (var item in carDal.GetById(5))
            ////{
            //    Console.WriteLine("Id:{0} , Model Year: {1} , Description: {2}",item.Id,item.ModelYear,item.Description);
            ////}

            //GetCarsByBrandIdServiceTest();
            //CarAddTest();

            //EfCarDal carDal = new EfCarDal();
            //Console.WriteLine("------------------------------------- GET BY ID -------------------------------------------------------");
            //var result = carDal.GetById(c => c.Id == 1);
            //Console.WriteLine("Id:{0} , BrandId:{3}, ColorId:{4}, Model Year: {1} , Description: {2}", result.Id, result.ModelYear, result.Description, result.BrandId, result.ColorId);


            //var addedCar = new Car
            //{
            //    BrandId = 5,
            //    ColorId = 5,
            //    DailyPrice = 150,
            //    ModelYear = 2004,
            //    Description = "On numara Araç"
            //};


            //carDal.Add(addedCar);

            //carDal.Update(new Car
            //{
            //    Id = carDal.GetAll().Count,
            //    BrandId = 1,
            //    ColorId = 1,
            //    DailyPrice = 500,
            //    Description = "Güncellendi",
            //    ModelYear = 2021
            //});
            //carDal.Delete(new Car
            //{
            //    Id = carDal.GetAll().Count,
            //    BrandId = 1,
            //    ColorId = 1,
            //    DailyPrice = 500,
            //    Description = "Güncellendi",
            //    ModelYear = 2021
            //});

            //Console.WriteLine("---------------------------------- TÜM ARAÇ KAYITLARI -------------------------------------------------");
            //var result2 = carDal.GetAll();
            //foreach (var item in result2)
            //{
            //    Console.WriteLine("Id:{0} , BrandId:{3}, ColorId:{4}, Model Year: {1} , Description: {2}", item.Id, item.ModelYear, item.Description, item.BrandId, item.ColorId);
            //}

            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine("Id:{0} , BrandId:{3}, ColorId:{4}, Model Year: {1} , Description: {2}", item.Id, item.ModelYear, item.Description, item.BrandId, item.ColorId);
            //}

            //CarManager carManager = new CarManager(new EfCarDal());

            //var result = carManager.GetCarDetails();
            //foreach (var item in result.Data)
            //{
            //    Console.WriteLine(item.BrandName);
            //}
            //Console.WriteLine("{0} / {1} / {2}", result.Data, result.Success, result.Message);


            /*
             * Brand Test
             */
            //BrandTest();
            //ColorTest();
            //CustomerTest();
            //UserTest();


            //int year = int.Parse(Console.ReadLine());
            //int month = int.Parse(Console.ReadLine());
            //int day = int.Parse(Console.ReadLine());

            //RentalTest(new DateTime(year,month,day));


            //CarManager car = new CarManager(new EfCarDal());
            //var result = car.GetCarsByBrandName("Mercedes");
            //foreach (var item in result.Data)
            //{
            //    Console.WriteLine("BrandName: {0}  ColorName: {1}  DailyPrice: {2}  " +
            //                      "Description: {3}  ModelYear: {4}", item.BrandName,item.ColorName,item.DailyPrice,item.Description,item.ModelYear);
            //}
            //Console.WriteLine("\n\n");
            //Console.WriteLine(result.Message);







        }

        private static void RentalTest(Rental rental)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var rentals = rentalManager.GetRentals();
            //foreach (var item in rentals.Data)
            //{
            //    Console.WriteLine("{0} / {1} / {2} / {3} / {4}", item.Id, item.CarId, item.CustomerID, item.RentDate, item.ReturnDate);
            //}
            //rentalManager.Add(rental);
            //var rentals = rentalManager.GetRentals();
            //foreach (var item in rentals.Data)
            //{
            //    Console.WriteLine("{0} / {1} / {2} / {3} / {4}", item.Id, item.CarId, item.CustomerID, item.RentDate.Ticks, item.ReturnDate);
            //}
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }
        private static void RentalTest(DateTime date)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var rentals = rentalManager.GetRentals();
            //foreach (var item in rentals.Data)
            //{
            //    Console.WriteLine("{0} / {1} / {2} / {3} / {4}", item.Id, item.CarId, item.CustomerID, item.RentDate, item.ReturnDate);
            //}
            //rentalManager.Add(rental);
            //var rentals = rentalManager.GetRentals();
            //foreach (var item in rentals.Data)
            //{
            //    Console.WriteLine("{0} / {1} / {2} / {3} / {4}", item.Id, item.CarId, item.CustomerID, item.RentDate.Ticks, item.ReturnDate);
            //}
            var result = rentalManager.GetRentalsByRentDate(date);
            Console.WriteLine(result.Message);
            foreach (var item in result.Data)
            {
                Console.WriteLine("{0} / {1} / {2}",item.CarId,item.CustomerID,item.RentDate);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var users = userManager.GetUsers();
            foreach (var item in users.Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / {4}", item.Id, item.FirstName, item.LastName, item.Email, item.Password);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customers = customerManager.GetCustomers();
            foreach (var item in customers.Data)
            {
                Console.WriteLine("{0} / {1} / {2}", item.Id, item.UserId, item.CompanyName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var colors = colorManager.GetColors();
            foreach (var item in colors.Data)
            {
                Console.WriteLine("{0} / {1}", item.Id, item.Name);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brands = brandManager.GetBrands();
            foreach (var item in brands.Data)
            {
                Console.WriteLine("{0} / {1}", item.Id, item.Name);
            }
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 8, ColorId = 8, DailyPrice = 0, ModelYear = 2015, Description = "İyi Araç" });
        }

        private static void GetCarsByBrandIdServiceTest()
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var item in carManager.GetCarsByBrandId(3))
            //{
            //    Console.WriteLine("Id:{0} , BrandId:{3}, ColorId:{4}, Model Year: {1} , Description: {2}", item.Id, item.ModelYear, item.Description, item.BrandId, item.ColorId);
            //}
        }
    }
}
