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
        public TrainingAssistantContext(DbContextOptions<TrainingAssistantContext>options):base(options) 
        {

        }
        
        //Setting database entities
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MusclePart> MuscleParts { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration of fields 

            modelBuilder.Entity<MusclePart>()
                .HasKey(mp => new { mp.Id });

            modelBuilder.Entity<Exercise>()
                .HasKey(e => new { e.Id });

            modelBuilder.Entity<Training>()
                .HasKey(t => new { t.Id });

            modelBuilder.Entity<TrainingPlan>()
                .HasKey(tp => new { tp.Id });

            modelBuilder.Entity<User>()
                .HasKey(u => new { u.Id });

            modelBuilder.Entity<MusclePart>()
                .HasMany(e => e.Exercises)
                .WithMany(m => m.MuscleParts)
                .UsingEntity(j => j.ToTable("MusclePartExercise"));

            modelBuilder.Entity<Exercise>()
                .HasMany(t => t.Trainings)
                .WithMany(e => e.Exercises)
                .UsingEntity(j => j.ToTable("ExerciseTraining"));

            modelBuilder.Entity<Training>()
                .HasOne(tp => tp.TrainingPlan)
                .WithMany(t => t.Trainings)
                .HasForeignKey(tp => tp.TrainingPlanId);

            modelBuilder.Entity<TrainingPlan>()
                .HasOne(u => u.User)
                .WithOne(tp => tp.TrainingPlan)
                .HasForeignKey<User>(u => u.TrainingPlanId);

            //Adding data to entities

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { Id = 1, Name = "Bench press", BurnedKcal = 10, Time = 5 },
                new Exercise { Id = 2, Name = "Squat", BurnedKcal = 20, Time = 10 },
                new Exercise { Id = 3, Name = "Deadlift", BurnedKcal = 30, Time = 15 }
            );
            modelBuilder.Entity<MusclePart>().HasData(
                new MusclePart { Id = 1, Name = "Chest" },
                new MusclePart { Id = 2, Name = "Legs" },
                new MusclePart { Id = 3, Name = "Back" }
            );
            modelBuilder.Entity<Training>().HasData(
                new Training { Id = 1, Name = "Endurance training"},
                new Training { Id = 2, Name = "Acrobatic training" },
                new Training { Id = 3, Name = "Tabata training" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Rafał", Surname = "Hońca", Sex = false, Age = 22, Email = "admin@gmail.com", Password = "admin", Height = 183, Weight = 65, IsAdmin = true },
                new User { Id = 3, Name = "Mateusz", Surname = "Bachowski", Sex = false, Age = 33, Email = "user@gmail.com", Password = "user", Height = 170, Weight = 45, IsAdmin = false }
            );
            modelBuilder.Entity<TrainingPlan>().HasData(
                new TrainingPlan { Id = 1, Name = "Weight loss"},
                new TrainingPlan { Id = 2, Name = "Mass gain"},
                new TrainingPlan { Id = 3, Name = "Ninja warrior"}
            );
        }
    }
}