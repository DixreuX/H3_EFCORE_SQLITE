// <auto-generated />
using System;
using H3_EFCORE_SQLITE.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace H3_EFCORE_SQLITE.Migrations
{
    [DbContext(typeof(ProjectManagerContext))]
    [Migration("20221019095943_TechCollege2")]
    partial class TechCollege2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Tasks", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TaskId");

                    b.HasIndex("TeamId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentTaskTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.HasIndex("CurrentTaskTaskId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.TeamWorker", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamId", "WorkerId");

                    b.ToTable("TeamWorkers");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Todo", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TasksTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoId");

                    b.HasIndex("TasksTaskId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentTodoTodoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WorkerId");

                    b.HasIndex("CurrentTodoTodoId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("TeamWorker", b =>
                {
                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkersWorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamsTeamId", "WorkersWorkerId");

                    b.HasIndex("WorkersWorkerId");

                    b.ToTable("TeamWorker");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Tasks", b =>
                {
                    b.HasOne("H3_EFCORE_SQLITE.Data.Contexts.Team", null)
                        .WithMany("Tasks")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Team", b =>
                {
                    b.HasOne("H3_EFCORE_SQLITE.Data.Contexts.Tasks", "CurrentTask")
                        .WithMany()
                        .HasForeignKey("CurrentTaskTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentTask");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Todo", b =>
                {
                    b.HasOne("H3_EFCORE_SQLITE.Data.Contexts.Tasks", null)
                        .WithMany("Todos")
                        .HasForeignKey("TasksTaskId");

                    b.HasOne("H3_EFCORE_SQLITE.Data.Contexts.Worker", null)
                        .WithMany("Todos")
                        .HasForeignKey("WorkerId");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Worker", b =>
                {
                    b.HasOne("H3_EFCORE_SQLITE.Data.Contexts.Todo", "CurrentTodo")
                        .WithMany()
                        .HasForeignKey("CurrentTodoTodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentTodo");
                });

            modelBuilder.Entity("TeamWorker", b =>
                {
                    b.HasOne("H3_EFCORE_SQLITE.Data.Contexts.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("H3_EFCORE_SQLITE.Data.Contexts.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersWorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Tasks", b =>
                {
                    b.Navigation("Todos");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Team", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Worker", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
