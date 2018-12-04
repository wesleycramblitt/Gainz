﻿// <auto-generated />
using System;
using GainzWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GainzWebAPI.Migrations
{
    [DbContext(typeof(GainzDBContext))]
    [Migration("20181104034937_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GainzWebAPI.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseType");

                    b.Property<bool>("IsCompound");

                    b.Property<string>("Name");

                    b.HasKey("ExerciseID");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GainzWebAPI.Models.ExerciseMuscle", b =>
                {
                    b.Property<int>("ExerciseMuscleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseID");

                    b.Property<int?>("muscleID");

                    b.Property<int>("percentInvolvement");

                    b.HasKey("ExerciseMuscleID");

                    b.HasIndex("ExerciseID");

                    b.HasIndex("muscleID");

                    b.ToTable("ExerciseMuscles");
                });

            modelBuilder.Entity("GainzWebAPI.Models.Muscle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsLarge");

                    b.Property<string>("Name");

                    b.Property<int?>("SplitDayID");

                    b.HasKey("ID");

                    b.HasIndex("SplitDayID");

                    b.ToTable("Muscles");
                });

            modelBuilder.Entity("GainzWebAPI.Models.RepScheme", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Intensity");

                    b.Property<int>("RepRange");

                    b.HasKey("ID");

                    b.ToTable("RepSchemes");
                });

            modelBuilder.Entity("GainzWebAPI.Models.RepSchemeSet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Percent1RM");

                    b.Property<int?>("RepSchemeID");

                    b.Property<int>("Reps");

                    b.Property<int>("RestInterval");

                    b.HasKey("ID");

                    b.HasIndex("RepSchemeID");

                    b.ToTable("RepSchemeSet");
                });

            modelBuilder.Entity("GainzWebAPI.Models.Split", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Frequency");

                    b.Property<int>("Intensity");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Splits");
                });

            modelBuilder.Entity("GainzWebAPI.Models.SplitDay", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRest");

                    b.Property<string>("Name");

                    b.Property<int?>("SplitID");

                    b.HasKey("ID");

                    b.HasIndex("SplitID");

                    b.ToTable("SplitDays");
                });

            modelBuilder.Entity("GainzWebAPI.Models.ExerciseMuscle", b =>
                {
                    b.HasOne("GainzWebAPI.Models.Exercise")
                        .WithMany("ExerciseMuscles")
                        .HasForeignKey("ExerciseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GainzWebAPI.Models.Muscle", "muscle")
                        .WithMany()
                        .HasForeignKey("muscleID");
                });

            modelBuilder.Entity("GainzWebAPI.Models.Muscle", b =>
                {
                    b.HasOne("GainzWebAPI.Models.SplitDay")
                        .WithMany("MusclesWorked")
                        .HasForeignKey("SplitDayID");
                });

            modelBuilder.Entity("GainzWebAPI.Models.RepSchemeSet", b =>
                {
                    b.HasOne("GainzWebAPI.Models.RepScheme")
                        .WithMany("RepSchemeSets")
                        .HasForeignKey("RepSchemeID");
                });

            modelBuilder.Entity("GainzWebAPI.Models.SplitDay", b =>
                {
                    b.HasOne("GainzWebAPI.Models.Split")
                        .WithMany("SplitDays")
                        .HasForeignKey("SplitID");
                });
#pragma warning restore 612, 618
        }
    }
}
