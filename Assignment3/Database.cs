//using System;
//using System.Data.Entity;
//using System.Linq;

//public class StaffsEntities : DbContext
//{
//    public DbSet<Staff> Staffs { get; set; }
//}

//public class Staff
//{
//    public int staff_id { get; set; }
//    public string first_name { get; set; }
//    public string last_name { get; set; }
//    public string email { get; set; }
//    public string phone { get; set; }
//    public int active { get; set; }
//    public int store_id { get; set; }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        using (var ctx = new StaffsEntities())
//        {
//            bool databaseExists = ctx.Database.Exists();

//            if (!databaseExists)
//            {
//                ctx.Database.Create();
//                InsertData(ctx);
//            }
//            else
//            {
//                Console.WriteLine("Database already exists.");
//            }
//        }
//    }

//    private static void InsertData(StaffsEntities ctx)
//    {
//        var StaffData = new[]
//        {
//            new Staff { first_name = "Fabiola", last_name = "Jackson", email = "fabiola.jackson@bikes.shop", phone = "(831)555-5554", active = 1, store_id = 1 },
//            new Staff { first_name = "Mireya", last_name = "Copeland", email = "mireya.copeland@bikes.shop", phone = "(831)555-5555", active = 1, store_id = 1 },
//            new Staff { first_name = "Genna", last_name = "Serrano", email = "genna.serrano@bikes.shop", phone = "(831)555-5556", active = 1, store_id = 1 },
//            new Staff { first_name = "Virgie", last_name = "Wiggins", email = "virgie.wiggins@bikes.shop", phone = "(831)555-5557", active = 1, store_id = 1 },
//            new Staff { first_name = "Jannette", last_name = "David", email = "jannette.david@bikes.shop", phone = "(516)379-4444", active = 1, store_id = 2 },
//            new Staff { first_name = "Marcelene", last_name = "Boyer", email = "marcelene.boyer@bikes.shop", phone = "(516)379-4445", active = 1, store_id = 2 },
//            new Staff { first_name = "Venita", last_name = "Daniel", email = "venita.daniel@bikes.shop", phone = "(516)379-4446", active = 1, store_id = 2 },
//            new Staff { first_name = "Kali", last_name = "Vargas", email = "kali.vargas@bikes.shop", phone = "(972)530-5555", active = 1, store_id = 3 },
//            new Staff { first_name = "Layla", last_name = "Terrell", email = "layla.terrell@bikes.shop", phone = "(972)530-5556", active = 1, store_id = 3 },
//            new Staff { first_name = "Bernardine", last_name = "Houston", email = "bernardine.houston@bikes.shop", phone = "(972)530-5557", active = 1, store_id = 3 }
//        };        
//        ctx.Staffs.AddRange(StaffData);
//        ctx.SaveChanges();
//    }
//}
