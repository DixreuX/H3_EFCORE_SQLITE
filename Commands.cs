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

            Console.WriteLine("\n Printing all tasks and todo's... \n");
            Thread.Sleep(1000);

            using var db = new ProjectManagerContext();

            var tasks = db.Tasks.Include(task => task.Todos);

            foreach (var task in tasks) {

                Console.WriteLine($"\n Task: {task.Name}");

                foreach (var todo in task.Todos) {

                    Console.WriteLine($" -  {todo.Name}");
                }
            }

            Console.WriteLine("\n");
        }

        public void PrintIncompleteTasksAndTodos() {

            Console.WriteLine("\n Finding tasks with incompleted todo's... \n");
            Thread.Sleep(1000);

            using var db = new ProjectManagerContext();

            var tasks = db.Tasks.Include(task => task.Todos.Where(x => x.IsComplete == false)); 


            Thread.Sleep(1000);

            foreach (var task in tasks) {

                Console.WriteLine($"\n Task: {task.Name}");

                foreach (var todo in task.Todos) {

                    string isCompleted = todo.IsComplete == true ? "Yes" : "No";

                    Console.WriteLine($" -  {todo.Name} | Is Completed: {isCompleted}");
                }
            }

            Console.WriteLine("\n");
        }

        public void PrintTeamCurrentTask()
        {
            Console.WriteLine("\n Printing each team's current task... \n");
            Thread.Sleep(1000);

            using var db = new ProjectManagerContext();

            var teamsAndTasks = db.Teams.Include(team => team.Tasks).ThenInclude(task => task.Todos).ToList();
            
            

            Thread.Sleep(1000);

            foreach (var team in teamsAndTasks) {

                Console.WriteLine($"\n Team: {team.Name}");

                foreach (var task in team.Tasks)
                {
                    Console.WriteLine($"\n Task name: {task}");
                }                
            }
        } 
    }
}
