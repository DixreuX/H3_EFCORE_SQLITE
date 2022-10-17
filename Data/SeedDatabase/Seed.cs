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


            // Add todo's
            db.Todos.AddRange(

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
                  IsComplete = true,
              },
              new Todo {
                  TodoId = 4,
                  Name = "Talk to department heads",
                  IsComplete = false
              },
              new Todo {
                  TodoId = 5,
                  Name = "Talk to employees",
                  IsComplete = true
              },
              new Todo {
                  TodoId = 6,
                  Name = "Get list of company hardware",
                  IsComplete = true
              }
           );

            db.SaveChanges();


            //Add 
            var taskList1 = db.Todos.Where(x => x.TodoId <= 3).ToList();
            var taskList2 = db.Todos.Where(x => x.TodoId >= 4).ToList();

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
       
            // Add teams
            db.Teams.AddRange(

                new Team {

                    TeamId = 1,
                    Name = "Frontend",
                    Workers = db.Workers.Where(x => x.WorkerId <= 3).ToList(),
        },
                new Team {

                    TeamId = 2,
                    Name = "Backend",
                    Workers = db.Workers.Where(x => x.WorkerId >= 4 && x.WorkerId <= 6).ToList()
                },
                new Team {

                    TeamId = 3,
                    Name = "Testers",
                    Workers = db.Workers.Where(x => x.WorkerId >= 7).ToList()
                }

             );

            db.SaveChanges();

            // Add Workers
            db.Workers.AddRange(
                
                new Worker {

                    WorkerId = 1,
                    Name = "Steen Secher",
                    Teams = db.Teams.Where(x => x.TeamId == 1).ToList()

                },
                new Worker {

                    WorkerId = 2,
                    Name = "Ejvind Møller",
                    Teams = db.Teams.Where(x => x.TeamId == 1).ToList()
                },
                new Worker {

                    WorkerId = 3,
                    Name = "Konrad Sommer",
                    Teams = db.Teams.Where(x => x.TeamId == 1).ToList()
                },
                new Worker {

                    WorkerId = 4,
                    Name = "Konrad Sommer",
                    Teams = db.Teams.Where(x => x.TeamId == 2).ToList()
                },
                new Worker {

                    WorkerId = 5,
                    Name = "Sofus Lotus",
                    Teams = db.Teams.Where(x => x.TeamId == 2).ToList()
                },
                new Worker {

                    WorkerId = 6,
                    Name = "Remo Lademann",
                    Teams = db.Teams.Where(x => x.TeamId == 2).ToList()
                },
                new Worker {

                    WorkerId = 7,
                    Name = "Ella Fanth",
                    Teams = db.Teams.Where(x => x.TeamId == 3).ToList()
                },
                new Worker {

                    WorkerId = 8,
                    Name = "Anne Dam",
                    Teams = db.Teams.Where(x => x.TeamId == 3).ToList()
                },
                new Worker {

                    WorkerId = 9,
                    Name = "Steen Secher",
                    Teams = db.Teams.Where(x => x.TeamId == 3).ToList()
                }

            );

            db.SaveChanges();         
        }
    }
}
