using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("1 - Arabaları göster.");
            Console.WriteLine("2 - Araba ekle.");
            Console.WriteLine("3 - Araba güncelle.");
            Console.WriteLine("4 - Şu arabayı getir.");
            Console.WriteLine("5 - Araba sil.");
            Console.Write("İşlem seçiniz: ");
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == 1)
            {
                CarsDataShow();
            }
            if (answer == 2)
            {
                CarAdd();
            }
            if (answer == 3)
            {
                CarUptade();

            }
            if (answer == 4)
            {
                CarGetById();
            }
            if (answer == 5)
            {
                CarDelete();

            }

        }
        #region Function
        private static void CarUptade()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car();

            Console.Write("Güncellemek istediğiniz ürünün id sini giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sırasıyla markasını, rengini, yılını, günlük ücreitini ve isteğe bağlı olarak da açıklamayı giriniz");

            car.Id = id;
            car.BrandId = Convert.ToInt32(Console.ReadLine());
            car.ColorId = Convert.ToInt32(Console.ReadLine());
            car.ModelYear = Convert.ToInt32(Console.ReadLine());
            car.DailyPrice = Convert.ToInt32(Console.ReadLine());
            car.Description = Console.ReadLine();

            var result = carManager.Update(car);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.Write("Silmek istediğiniz ürünün id sini giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = carManager.Delete(id);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.Write("Görüntülemek istediğiniz ürünün id sini giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = carManager.GetById(id);
            if (result.Success == true)
            {
                Console.WriteLine(result.Data.BrandId + "/" + result.Data.ColorId + "/" + result.Data.ModelYear +
                    " / " + result.Data.DailyPrice + " / " + result.Data.Description + " / ");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarAdd()
        {
            Car car = new Car();
            Console.WriteLine("Sırasıyla markasını, rengini, yılını, günlük ücreitini ve isteğe bağlı olarak da açıklamayı giriniz");
            car.BrandId = Convert.ToInt32(Console.ReadLine());
            car.ColorId = Convert.ToInt32(Console.ReadLine());
            car.ModelYear = Convert.ToInt32(Console.ReadLine());
            car.DailyPrice = Convert.ToInt32(Console.ReadLine());
            car.Description = Console.ReadLine();

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(car);
            Console.WriteLine(result.Message);
        }

        private static void CarsDataShow()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.BrandId+" / "+item.DailyPrice+" / "+ item.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        #endregion 
    }
}
