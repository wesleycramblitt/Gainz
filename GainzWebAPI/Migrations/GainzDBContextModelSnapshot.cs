﻿// <auto-generated />
using System;
using GainzWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GainzWebAPI.Migrations
{
    [DbContext(typeof(GainzDBContext))]
    partial class GainzDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GainzWebAPI.Models.Day", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsRest");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("GainzWebAPI.Models.DayMuscle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DayID");

                    b.Property<int?>("MuscleID");

                    b.HasKey("ID");

                    b.HasIndex("DayID");

                    b.HasIndex("MuscleID");

                    b.ToTable("DayMuscles");
                });

            modelBuilder.Entity("GainzWebAPI.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExerciseType");

                    b.Property<bool>("IsCompound");

                    b.Property<string>("Name");

                    b.HasKey("ExerciseID");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GainzWebAPI.Models.ExerciseMuscle", b =>
                {
                    b.Property<int>("ExerciseMuscleID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExerciseID");

                    b.Property<int>("MuscleID");

                    b.Property<int>("percentInvolvement");

                    b.HasKey("ExerciseMuscleID");

                    b.HasIndex("ExerciseID");

                    b.HasIndex("MuscleID");

                    b.ToTable("ExerciseMuscles");
                });

            modelBuilder.Entity("GainzWebAPI.Models.Muscle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Size");

                    b.HasKey("ID");

                    b.ToTable("Muscles");
                });

            modelBuilder.Entity("GainzWebAPI.Models.Split", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Frequency");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Splits");
                });

            modelBuilder.Entity("GainzWebAPI.Models.SplitDay", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DayID");

                    b.Property<int>("SplitID");

                    b.HasKey("ID");

                    b.HasIndex("DayID");

                    b.HasIndex("SplitID");

                    b.ToTable("SplitDays");
                });

            modelBuilder.Entity("GainzWebAPI.Models.DayMuscle", b =>
                {
                    b.HasOne("GainzWebAPI.Models.Day")
                        .WithMany("DaysMuscles")
                        .HasForeignKey("DayID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GainzWebAPI.Models.Muscle", "Muscle")
                        .WithMany()
                        .HasForeignKey("MuscleID");
                });

            modelBuilder.Entity("GainzWebAPI.Models.ExerciseMuscle", b =>
                {
                    b.HasOne("GainzWebAPI.Models.Exercise")
                        .WithMany("ExerciseMuscles")
                        .HasForeignKey("ExerciseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GainzWebAPI.Models.Muscle", "Muscle")
                        .WithMany()
                        .HasForeignKey("MuscleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GainzWebAPI.Models.SplitDay", b =>
                {
                    b.HasOne("GainzWebAPI.Models.Day", "Day")
                        .WithMany()
                        .HasForeignKey("DayID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GainzWebAPI.Models.Split")
                        .WithMany("SplitDays")
                        .HasForeignKey("SplitID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
