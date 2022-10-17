﻿// <auto-generated />
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
    [Migration("20221017125012_NewDbPathFour")]
    partial class NewDbPathFour
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

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
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

                    b.ToTable("Todo");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Todo", b =>
                {
                    b.HasOne("H3_EFCORE_SQLITE.Data.Contexts.Tasks", null)
                        .WithMany("Todos")
                        .HasForeignKey("TasksTaskId");
                });

            modelBuilder.Entity("H3_EFCORE_SQLITE.Data.Contexts.Tasks", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
