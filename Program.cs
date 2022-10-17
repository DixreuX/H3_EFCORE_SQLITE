using H3_EFCORE_SQLITE.Data.Contexts;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;
using H3_EFCORE_SQLITE.Data.SeedDatabase;

namespace H3_EFCORE_SQLITE {

    internal class Program {

        

        static void Main(string[] args) {

            using var db = new ProjectManagerContext();

            Seed seed = new Seed();
            Logic logic = new Logic();


            if (File.Exists(Path.Join(db.SqliteDbpath, "ProjectManager.db"))) {

                Console.WriteLine("\n Database exists... Continuing \n");
            }
            else {

                Console.WriteLine("\n Database does not exist... Creatíng new database\n");
                Thread.Sleep(1000);
                Console.WriteLine(" Database name: ProjectManager.db\n");
                Thread.Sleep(1000);
                Console.WriteLine(" Creating tables...");
                Thread.Sleep(1000);
                Console.WriteLine(" Seeding data...");
                seed.Database();
                Thread.Sleep(1000);
            }
                



            logic.PrintTasksAndTodos();            
          
            

           


            Console.ReadKey();
        }
    }
}