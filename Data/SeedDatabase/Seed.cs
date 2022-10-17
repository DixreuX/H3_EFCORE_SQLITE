using H3_EFCORE_SQLITE.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_EFCORE_SQLITE.Data.SeedDatabase {

    public class Seed {

        public void Database() {

            using var db = new ProjectManagerContext();

            db.Todo.AddRange(

               new Todo {
                   TodoId = 1,
                   Name = "Invite to meeting via Teams",
                   IsComplete = false
               },

              new Todo {
                  TodoId = 2,
                  Name = "Order food and drinks",
                  IsComplete = false
              },

              new Todo {
                  TodoId = 3,
                  Name = "Create agenda",
                  IsComplete = false
              },

              new Todo {
                  TodoId = 4,
                  Name = "Talk to department heads",
                  IsComplete = false
              },

              new Todo {
                  TodoId = 5,
                  Name = "Talk to employees",
                  IsComplete = false
              },

              new Todo {
                  TodoId = 6,
                  Name = "Get list of company hardware",
                  IsComplete = false
              }
           );

            db.SaveChanges();


            var taskList1 = db.Todo.Where(x => x.TodoId <= 3).ToList();
            var taskList2 = db.Todo.Where(x => x.TodoId >= 4).ToList();


            db.Tasks.AddRange(

                new Tasks {

                    Name = "Staff Meeting",
                    Todos = taskList1
                },

                new Tasks {

                    Name = "Review Infrastructure",
                    Todos = taskList2
                }

              );

            db.SaveChanges();
        }
    }
}
