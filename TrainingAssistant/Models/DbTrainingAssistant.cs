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
        }

        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<MusclePart> MuscleParts { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ExerciseMuscle> ExerciseMuscles { get; set; }
        public DbSet<TrainingExcercise> TrainingExcercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseMuscle>().HasKey(em=>new { em.IdExercise, em.IdMusclePart});
            modelBuilder.Entity<TrainingExcercise>().HasKey(em => new { em.IdTraining, em.IdExcercise });
            
            List<MusclePart> muscles = new List<MusclePart>()
            {
                new MusclePart { IdPart = 1, Name = "Chest" },
                new MusclePart { IdPart = 2, Name = "Legs" }
            };
            modelBuilder.Entity<MusclePart>().HasData(muscles);
            
            List<Excercise> excercisesList = new List<Excercise>{
                new Excercise { IdExcercise = 1, Name = "Squat", BurnedKcal = 0.38, Time = 3, Type = TypeEnum.balance },
                new Excercise { IdExcercise = 2, Name = "Push-up", BurnedKcal = 0.29, Time = 2, Type = TypeEnum.strenght }
            };
            modelBuilder.Entity<Excercise>().HasData(excercisesList);

            List<Training> trainingsList = new List<Training>{
                new Training { IdTraining = 1, Name = "Endurance training", Days = 3 },
                new Training { IdTraining = 2, Name = "Acrobatic training", Days = 3 }
            };
            modelBuilder.Entity<Training>().HasData(trainingsList);

            //modelBuilder.Entity<TrainingPlan>().HasData(
            //    new TrainingPlan { IdPlan=1,Name="Plan Marcina",Trainings = trainingsList}
            //    );

            modelBuilder.Entity<ExerciseMuscle>().HasData(
                new ExerciseMuscle { IdExercise=1, IdMusclePart = 2 },
                new ExerciseMuscle { IdExercise = 2, IdMusclePart = 1 }
                );
            modelBuilder.Entity<TrainingExcercise>().HasData(
               new TrainingExcercise { IdTraining = 1, IdExcercise = 2 },
               new TrainingExcercise { IdTraining = 2, IdExcercise = 1 }
               );
        }
    }
}
