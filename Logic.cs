using H3_EFCORE_SQLITE.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_EFCORE_SQLITE {

    public class Logic {


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

    }
}
