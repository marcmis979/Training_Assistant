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
        public DbSet<ExerciseMusclePart> ExerciseMuscleParts { get; set; }
        public DbSet<TrainingExercise> TrainingExercises { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingPlanTraing> TrainingPlanTraings { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration of fields 

            modelBuilder.Entity<MusclePart>()
                .HasKey(mp=> mp.Id);

            modelBuilder.Entity<ExerciseMusclePart>()
                .HasKey(em=> new {em.ExerciseId, em.MusclePartId});

            modelBuilder.Entity<Exercise>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<TrainingExercise>()
                .HasKey(te => new { te.TrainingId, te.ExerciseId });

            modelBuilder.Entity<Training>()
                .HasKey(t=>t.Id);

            modelBuilder.Entity<TrainingPlanTraing>()
                .HasKey(tpt => new { tpt.TrainingPlanId, tpt.TrainingId });

            modelBuilder.Entity<TrainingPlan>()
                .HasKey(tp => new { tp.Id });

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            //Entity relationships configuration
            modelBuilder.Entity<ExerciseMusclePart>()
                .HasOne(em => em.Exercise)
                .WithMany(e => e.ExercisesMuscleParts)
                .HasForeignKey(em => em.ExerciseId);
            modelBuilder.Entity<ExerciseMusclePart>()
                .HasOne(em => em.MusclePart)
                .WithMany(mp => mp.ExercisesMuscleParts)
                .HasForeignKey(em => em.MusclePartId);

            modelBuilder.Entity<TrainingExercise>()
                .HasOne(te=>te.Training)
                .WithMany(e=>e.TrainingExercises)
                .HasForeignKey(te => te.TrainingId);
            modelBuilder.Entity<TrainingExercise>()
                .HasOne(t => t.Exercise)
                .WithMany(te => te.TrainingExercises)
                .HasForeignKey(t => t.ExerciseId);

            modelBuilder.Entity<TrainingPlanTraing>()
                .HasOne(tpt => tpt.TrainingPlan)
                .WithMany(t => t.TrainingPlanTraings)
                .HasForeignKey(tpt => tpt.TrainingPlanId);
            modelBuilder.Entity<TrainingPlanTraing>()
                .HasOne(t => t.Training)
                .WithMany(tpt => tpt.TrainingPlanTraings)
                .HasForeignKey(t => t.TrainingId);

            modelBuilder.Entity<TrainingPlan>()
                .HasOne(u => u.User)
                .WithOne(tp => tp.TrainingPlan)
                .HasForeignKey<User>(u=>u.Id);

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
            modelBuilder.Entity<Training>().HasData(
                new Training { Id = 1, Name = "Endurance training"},
                new Training { Id = 2, Name = "Acrobatic training" },
                new Training { Id = 3, Name = "Tabata training" }
            );
            modelBuilder.Entity<TrainingPlan>().HasData(
                new TrainingPlan { Id = 1, Name = "Weight loss"},
                new TrainingPlan { Id = 2, Name = "Mass gain"},
                new TrainingPlan { Id = 3, Name = "Ninja warrior"}
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Rafał", Surname="Hońca",Sex=false, Age=22, Email="xDD", Password="xyz" },
                new User { Id = 2, Name = "Marcin", Surname = "Misiuna", Sex = true, Age = 22, Email = "xDD", Password = "xyz" },
                new User { Id = 3, Name = "Mateusz" ,Surname="Bachowski", Sex = false, Age = 33, Email = "xDD", Password = "xyz" }
            );

            modelBuilder.Entity<ExerciseMusclePart>().HasData(
                new ExerciseMusclePart { ExerciseId = 1, MusclePartId = 1 },
                new ExerciseMusclePart { ExerciseId = 1, MusclePartId = 3 },
                new ExerciseMusclePart { ExerciseId = 2, MusclePartId = 2 },
                new ExerciseMusclePart { ExerciseId = 2, MusclePartId = 3 },
                new ExerciseMusclePart { ExerciseId = 3, MusclePartId = 3 }
            );

            modelBuilder.Entity<TrainingExercise>().HasData(
                new TrainingExercise { TrainingId = 1, ExerciseId = 1 },
                new TrainingExercise { TrainingId = 1, ExerciseId = 3 },
                new TrainingExercise { TrainingId = 2, ExerciseId = 2 },
                new TrainingExercise { TrainingId = 2, ExerciseId = 3 },
                new TrainingExercise { TrainingId = 3, ExerciseId = 3 }
            );

            modelBuilder.Entity<TrainingPlanTraing>().HasData(
                new TrainingPlanTraing { TrainingPlanId = 1, TrainingId = 1 },
                new TrainingPlanTraing { TrainingPlanId = 1, TrainingId = 3 },
                new TrainingPlanTraing { TrainingPlanId = 2, TrainingId = 2 },
                new TrainingPlanTraing { TrainingPlanId = 2, TrainingId = 3 },
                new TrainingPlanTraing { TrainingPlanId = 3, TrainingId = 3 }
            );
        }
    }
}