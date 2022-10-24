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
            Commands command = new Commands();


            if (File.Exists(Path.Join(db.SqliteDbpath, "ProjectManager.db"))) {

                Console.WriteLine("\n Database exists... Continuing \n");
                Thread.Sleep(1000);
                //Console.WriteLine("\n Wiping existing data... \n");
                //db.Database.ExecuteSqlRaw("PRAGMA foreign_keys=off");
                //db.Database.ExecuteSqlRaw("DELETE FROM Tasks");
                //db.Database.ExecuteSqlRaw("DELETE FROM Todos");
                //db.Database.ExecuteSqlRaw("DELETE FROM TeamWorkers");
                //db.Database.ExecuteSqlRaw("DELETE FROM TeamWorker");
                //db.Database.ExecuteSqlRaw("DELETE FROM Teams");
                //db.Database.ExecuteSqlRaw("DELETE FROM Workers");
                //db.Database.ExecuteSqlRaw("PRAGMA foreign_keys=on");
                //Thread.Sleep(2000);
                //Console.WriteLine("\n Seeding data... \n");
                //seed.Database();
                Thread.Sleep(1000);
                Console.Clear();
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
                Console.Clear();
            }

            command.PrintTasksAndTodos();
            command.PrintIncompleteTasksAndTodos();
            //command.PrintTeamCurrentTask();

            Console.ReadKey();
        }
    }
}