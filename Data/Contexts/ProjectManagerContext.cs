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

        string sqliteDbpath = "C:\\Users\\Danny\\OneDrive\\Dokumenter\\Special Projects\\H3_EFCORE_SQLITE\\Data\\Database\\";
        public string SqliteDbpath { get => sqliteDbpath; set => sqliteDbpath = value; }


        public DbSet<Todo> Todo { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        public string DbPath { get; }
        

        public ProjectManagerContext() {

            DbPath = System.IO.Path.Join(sqliteDbpath, "ProjectManager.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Todo {

        public int TodoId { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }
    }

    public class Tasks {

        [Key]
        public int TaskId { get; set; }

        public string Name { get; set; }

        public List<Todo> Todos { get; set; }
    }
}
