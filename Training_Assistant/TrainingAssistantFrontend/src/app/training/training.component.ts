import { Component } from '@angular/core';
import { Training } from './model/training';
import { TrainingResponse } from './model/training-response';
import { TrainingService } from '../services/training.service';
import { Exercise } from '../exercise/model/exercise';
import { ExerciseService } from '../services/exercise.service';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.css']
})
export class TrainingComponent {
  trainings: Training[] = [];
  trainingResponse: TrainingResponse = {
    name: '',
    days: 0,
  };
  editMode = false;
  editedTrainingId: number | null = null;

  assignMode = false;
  selectedTraining: Training | null = null;
  selectedExercise: Exercise | null = null;
  selectedExerciseToRemove: Exercise | null = null;
  availableExercises: Exercise[] = [];
  exercises:Exercise[]=[];

  constructor(
    private trainingService: TrainingService,
    private exerciseService: ExerciseService 
  ) {}

  ngOnInit(): void {
    this.loadTrainings();
    this.loadExercises();
  }

  private loadTrainings(): void {
    this.trainingService.getTrainings().subscribe((data) => {
      this.trainings = data;
    });
  }
  private loadExercises(): void {
    this.exerciseService.getExercises().subscribe((data) => {
      this.exercises = data;
    });
  }

  addTraining(): void {
    this.trainingService.addTraining(this.trainingResponse).subscribe(() => {
      this.loadTrainings();
      this.trainingResponse = {
        name: '',
        days: 0,
      };
    });
  }

  startEdit(id: number): void {
    this.editedTrainingId = id;
    this.editMode = true;
  }

  finishEdit(): void {
    this.editedTrainingId = null;
    this.editMode = false;
  }

  updateTraining(id: number, updatedTraining: Training): void {
    this.trainingService.updateTraining(id, updatedTraining).subscribe(() => {
      this.loadTrainings();
      this.finishEdit();
    });
  }

  deleteTraining(id: number): void {
    this.trainingService.deleteTraining(id).subscribe(() => {
      this.loadTrainings();
    });
  }

  
  assignExercise(trainingId: number): void {
    const selectedTraining = this.trainings.find((training) => training.id === trainingId);

    if (selectedTraining) {
      console.log("test"+this.exercises);
      this.availableExercises = this.exercises.filter((exercise) => {
        return !selectedTraining.exercises.some((assignedExercise) => assignedExercise.id === exercise.id);
      });
      this.selectedTraining = selectedTraining;
      this.assignMode = true;
    } else {
      this.selectedTraining = null;
      this.availableExercises = [];
      this.assignMode = false;
    }
  }

  assignSelectedExercise(): void {
    if (this.selectedTraining && this.selectedExercise) {
      this.trainingService.addExerciseToTraining(this.selectedTraining,this.selectedTraining.id, this.selectedExercise.id).subscribe(() => {
        
        this.loadTrainings();
        this.assignMode = false;
      });
    }
  }

  
  removeSelectedExercise(): void {
    if (this.selectedTraining && this.selectedExerciseToRemove) {
      this.trainingService.removeExerciseFromTraining(this.selectedTraining,this.selectedTraining.id, this.selectedExerciseToRemove.id).subscribe(() => {
        
        this.loadTrainings();
        this.assignMode = false;
      });
    }
  }

  cancelAssignMode(): void {
    this.assignMode = false;
    this.selectedTraining = null;
    this.availableExercises = [];
  }
}