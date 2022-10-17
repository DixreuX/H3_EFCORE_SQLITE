﻿// <auto-generated />
using System;
using H3_EFCORE_SQLITE.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace H3_EFCORE_SQLITE.Migrations
{
    [DbContext(typeof(ProjectManagerContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

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

                    b.HasKey("TodoId");

                    b.HasIndex("TasksTaskId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WorkerId");

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

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Todo", b =>
                {
                    b.HasOne("H3_EFCORE_SQLITE.Data.Contexts.Tasks", null)
                        .WithMany("Todos")
                        .HasForeignKey("TasksTaskId");
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
#pragma warning restore 612, 618
        }
    }
}
