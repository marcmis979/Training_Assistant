using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.DataAccess
{
    public class TrainingAssistantContext : DbContext
    {
        //Conection string 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TrainingAssistant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        //Setting database entities
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MusclePart> MuscleParts { get; set; }
        public DbSet<ExerciseMusclePart> ExerciseMuscleParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration of fields 
            modelBuilder.Entity<Exercise>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<MusclePart>()
                .HasKey(m=> m.Id);

            modelBuilder.Entity<ExerciseMusclePart>()
                .HasKey(em=> new {em.ExercisesId, em.MusclePartsId});

            //Entity relationships configuration
            modelBuilder.Entity<ExerciseMusclePart>()
                .HasOne(em => em.Exercise)
                .WithMany(e => e.ExercisesMuscleParts)
                .HasForeignKey(em => em.ExercisesId);

            modelBuilder.Entity<ExerciseMusclePart>()
                .HasOne(em => em.MusclePart)
                .WithMany(m => m.ExercisesMuscleParts)
                .HasForeignKey(em => em.MusclePartsId);

            //Adding data to entities
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { Id = 1, Name = "Bench press"},
                new Exercise { Id = 2, Name = "Squat"},
                new Exercise { Id = 3, Name = "Deadlift"}
            );
            modelBuilder.Entity<MusclePart>().HasData(
                new MusclePart { Id = 1, Name = "Chest" },
                new MusclePart { Id = 2, Name = "Legs" },
                new MusclePart { Id = 3, Name = "Back" }
            );

            modelBuilder.Entity<ExerciseMusclePart>().HasData(
                new ExerciseMusclePart { ExercisesId = 1, MusclePartsId = 1 },
                new ExerciseMusclePart { ExercisesId = 1, MusclePartsId = 3 },
                new ExerciseMusclePart { ExercisesId = 2, MusclePartsId = 2 },
                new ExerciseMusclePart { ExercisesId = 2, MusclePartsId = 3 },
                new ExerciseMusclePart { ExercisesId = 3, MusclePartsId = 3 }
            );



        }
    }
}