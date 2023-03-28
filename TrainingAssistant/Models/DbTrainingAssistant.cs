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
        public DbSet<TrainingExercise> TrainingExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseMuscle>().HasKey(em=>new { em.IdExercise, em.IdMusclePart});
            modelBuilder.Entity<TrainingExercise>().HasKey(me => new { me.IdTrainings, me.IdExcercises });

            modelBuilder.Entity<User>()
                 .HasOne(c => c.TrainingPlan)
                 .WithOne(cr => cr.User)
                 .HasForeignKey<TrainingPlan>(cr => cr.IdPlan)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Training>()
                .HasOne(c => c.Tp)
                .WithMany(cr => cr.Trainingies)
                .HasForeignKey(cr => cr.IdTrainingPlan)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainingExercise>()
                .HasOne<Training>(cr=>cr.training)
                .WithMany(c=>c.TrainingExercise)
                .HasForeignKey(cr=>cr.IdTrainings)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainingExercise>()
               .HasOne<Excercise>(cr => cr.exercise)
               .WithMany(c => c.TrainingExercise)
               .HasForeignKey(cr => cr.IdExcercises)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExerciseMuscle>()
                .HasOne<Excercise>(cr=>cr.excercise)
                .WithMany(c=>c.ExerciseMuscle)
                .HasForeignKey(cr=>cr.IdExercise)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExerciseMuscle>()
                .HasOne<MusclePart>(cr => cr.musclePart)
                .WithMany(c => c.ExerciseMuscle)
                .HasForeignKey(cr => cr.IdMusclePart)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            List<MusclePart> musclePartList = new List<MusclePart>()
            { 
                new MusclePart { IdPart = 1, Name = "Chest" },
                new MusclePart { IdPart = 2, Name = "Legs" }
            };

            modelBuilder.Entity<MusclePart>().HasData(musclePartList);

            List<Excercise> excerciseList = new List<Excercise>()
            {
                new Excercise { IdExcercise = 1, Name = "Squat", BurnedKcal = 0.38, Time = 3, Type = TypeEnum.balance },
                new Excercise { IdExcercise = 2, Name = "Push-up", BurnedKcal = 0.29, Time = 2, Type = TypeEnum.strenght }
            };

            modelBuilder.Entity<Excercise>().HasData(excerciseList);

            //List<Training> trainingList = new List<Training>()
            //{
            //    new Training{ IdTraining = 1,Name="Endurance training",Days=3,IdTrainingPlan=1},
            //    new Training{ IdTraining = 2,Name="Acrobatic training",Days=4,IdTrainingPlan = 1}
            //};

            //modelBuilder.Entity<Training>().HasData(trainingList);

            modelBuilder.Entity<ExerciseMuscle>().HasData(
                new ExerciseMuscle { IdExercise = 1, IdMusclePart = 2 },
                new ExerciseMuscle { IdExercise = 2, IdMusclePart = 1 }
                );
            modelBuilder.Entity<TrainingExercise>().HasData(
               new TrainingExercise { IdTrainings = 1, IdExcercises = 2 },
               new TrainingExercise { IdTrainings = 2, IdExcercises = 1 }
               );
        }
    }
}
