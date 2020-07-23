using autopark.Models;
using System;
using System.Linq;

namespace autopark.Data
{
    public class AppDbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
        context.Database.EnsureCreated();

        if (context.Cars.Any())
        {
            return;
        }

        var cars = new Car[]
        {
        new Car
            {
             Brand = "Renault", Model = "Logan",ReleaseDate = DateTime.Parse("1998-03-11"),CarNumber = "е817нв",RegDate = DateTime.Parse("2019-10-10")
            },
        new Car
            {
            Brand = "Москвич", Model = "2141",ReleaseDate = DateTime.Parse("1997-02-10"),CarNumber = "а324кв",RegDate = DateTime.Parse("2018-05-05")
            },
        new Car
            {
            Brand = "ВАЗ", Model = "21099",ReleaseDate = DateTime.Parse("1993-05-05"),CarNumber = "р902ун",RegDate = DateTime.Parse("2019-10-10")
            },
        new Car
            {
            Brand = "ЛАДА", Model = "Калина",ReleaseDate = DateTime.Parse("2019-10-02"),CarNumber = "о402кн",RegDate = DateTime.Parse("2019-10-10")
            },
        new Car
            {
            Brand = "Hyundai",Model = "Solaris",ReleaseDate = DateTime.Parse("2012-03-11"),CarNumber = "л552пв",RegDate = DateTime.Parse("2019-10-10")
            },
        new Car
            {
            Brand = "DAEWOO", Model = "Matiz",ReleaseDate = DateTime.Parse("2019-03-11"),CarNumber = "м606тч",RegDate = DateTime.Parse("2019-10-10")
            }
        };

        foreach (Car c in cars)
        {
            context.Cars.Add(c);
        }
            context.SaveChanges();

        if (context.Inspections.Any())
        {
            return;
        }

        var inspections = new Inspection[]
        {
        new Inspection
            {
            CarId = 1,InspNote = "Замечания отсутствуют",InspDate = DateTime.Parse("2019-11-10")
            },
        new Inspection
            {
            CarId = 2,InspNote = "Замечания отсутствуют",InspDate = DateTime.Parse("2019-10-05")
            },
        new Inspection
            {
            CarId = 3,InspNote = "Замечания отсутствуют",InspDate = DateTime.Parse("2019-11-05")
            }
        };
        foreach (Inspection n in inspections)
        {
            context.Inspections.Add(n);
        }
        context.SaveChanges();
        }
    }
}
