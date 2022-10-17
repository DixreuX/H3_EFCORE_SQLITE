using H3_EFCORE_SQLITE.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace H3_EFCORE_SQLITE {

    public class Commands {


        public void PrintTasksAndTodos() {

            using var db = new ProjectManagerContext();

            var tasks = db.Tasks.Include(task => task.Todos);

            foreach (var task in tasks) {

                Console.WriteLine($"\n Task: {task.Name}");

                foreach (var todo in task.Todos) {

                    Console.WriteLine($" -  {todo.Name}");
                }
            }
        }

        public void PrintIncompleteTasksAndTodos() {

            Console.WriteLine("\n Finding tasks with incompleted todo's \n");
            

            using var db = new ProjectManagerContext();

            //var todos = db.Todo.Where(x => x.IsComplete != true);

            var tasks = db.Tasks.Include(task => task.Todos.Where(x => x.IsComplete == false)); 


            Thread.Sleep(1000);

            foreach (var task in tasks) {

                Console.WriteLine($"\n Task: {task.Name}");

                foreach (var todo in task.Todos) {

                    string isCompleted = todo.IsComplete == true ? "Yes" : "No";

                    Console.WriteLine($" -  {todo.Name} | Is Completed: {isCompleted}");
                }
            }
        }
    }
}
