using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TrainingAssistant.Models;

namespace Asystent_Treningowy.Models
{
    internal class DbTrainingAssistant : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = TrainingAssistant; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False\r\n");
            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<MusclePart> MuscleParts { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ExerciseMuscle> ExerciseMuscles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseMuscle>().HasKey(em=>new { em.IdExercise, em.IdMusclePart});
            var muscles = new[]
            {
                new MusclePart { IdPart = 1, Name = "Chest" },
                new MusclePart { IdPart = 2, Name = "Legs" }
            };

            modelBuilder.Entity<MusclePart>().HasData(muscles);

            modelBuilder.Entity<Excercise>().HasData(
                new Excercise { IdExcercise = 1, Name = "Squat", BurnedKcal = 0.38, Time = 3, Type = TypeEnum.balance },
                new Excercise { IdExcercise = 2, Name = "Push-up", BurnedKcal = 0.29, Time = 2, Type = TypeEnum.strenght }
            );
            modelBuilder.Entity<ExerciseMuscle>().HasData(
                new ExerciseMuscle { IdExercise=1, IdMusclePart = 2 },
                new ExerciseMuscle { IdExercise = 2, IdMusclePart = 1 }
                );
        }
    }
}
