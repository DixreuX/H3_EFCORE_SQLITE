using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace H3_EFCORE_SQLITE.Data.Contexts {

    public class ProjectManagerContext : DbContext {

        //string sqliteDbpath = "C:\\Users\\Danny\\OneDrive\\Dokumenter\\Special Projects\\H3_EFCORE_SQLITE\\Data\\Database\\";
        string sqliteDbPath = "C:\\Users\\Bruger 1\\Source\\Repos\\DixreuX\\H3_EFCORE_SQLITE\\Data\\Database\\";
        public string SqliteDbpath { get => sqliteDbPath; set => sqliteDbPath = value; }


        public DbSet<Todo> Todos { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<TeamWorker> TeamWorkers { get; set; }


        public string DbPath { get; }
        

        public ProjectManagerContext() {

            DbPath = System.IO.Path.Join(sqliteDbPath, "ProjectManager.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<TeamWorker>().HasKey(p => new { p.TeamId, p.WorkerId });
            modelBuilder.Entity<Task>().HasKey(p => new { p.TaskId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Todo {

        public int TodoId { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }
    }

    public class Task {

        public int TaskId { get; set; }

        public string Name { get; set; }

        public List<Todo> Todos { get; set; }
    }

    public class Team {

        public int TeamId { get; set; }

        public string Name { get; set; }

        public List<Worker> Workers { get; set; }

        public Task CurrentTask { get; set; }

        public List<Task> Tasks { get; set; }
    }

    public class Worker {

        public int WorkerId { get; set; }

        public string Name { get; set; }

        public List<Team> Teams { get; set; }
      
        public Todo CurrentTodo { get; set; }

        public List<Todo> Todos { get; set; }
    }

    public class TeamWorker {

        public int TeamId { get; set; }

        public int WorkerId { get; set; }
    }
}
