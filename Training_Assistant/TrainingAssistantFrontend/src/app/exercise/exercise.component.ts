import { Component, OnInit } from '@angular/core';
import { Exercise } from './model/exercise';
import { ExerciseResponse } from './model/exercise-response';
import { Type } from './model/type.enum';
import { ExerciseService } from '../services/exercise.service';
import { MusclePart } from '../muscle-part/model/muscle-part';
import { MusclePartService } from '../services/muscle-part.service';
import { Subscription } from 'rxjs';
import { UserResponse } from '../user/model/user-response';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-exercise',
  templateUrl: './exercise.component.html',
  styleUrls: ['./exercise.component.css']
})
export class ExerciseComponent implements OnInit {
  private loggedInUserSubscription: Subscription;
  user?: UserResponse;
  isLoggedIn: boolean = this.userService.isLoggedIn;

  assignMode = false;
  selectedExercise: Exercise | null = null;
  selectedMusclePart: MusclePart | null = null;
  selectedMusclePartToRemove: MusclePart| null = null;
  availableMuscleParts: MusclePart[] = [];
  exercises: Exercise[] = [];
  exerciseResponse: ExerciseResponse = {
    name: '',
    burnedKcal: 0,
    time: 0,
    type: Type.aerobic,
    muscleParts: []
  };
  editMode = false;
  editedExerciseId: number | null = null;
  muscleParts: MusclePart[] = [];

  constructor(
    private exerciseService: ExerciseService,
    private musclePartService: MusclePartService,
    private userService: UserService
  ) {
    this.loggedInUserSubscription = this.userService.loggedInUser.subscribe(user => {
      this.user = user;
      this.isLoggedIn = !!user;
    });
  }

  ngOnInit(): void {
    this.loadExercises();
    this.loadMuscleParts();
  }

  private loadExercises(): void {
    this.exerciseService.getExercises().subscribe((data) => {
      this.exercises = data;
    });
  }

  private loadMuscleParts(): void {
    this.musclePartService.getMuscleParts().subscribe((data) => {
      this.muscleParts = data;
    });
  }

  addExercise(): void {
    this.exerciseService.addExercise(this.exerciseResponse).subscribe(() => {
      this.loadExercises();
      this.exerciseResponse = {
        name: '',
        burnedKcal: 0,
        time: 0,
        type: Type.aerobic,
        muscleParts: []
      };
    });
  }

  startEdit(id: number): void {
    this.editedExerciseId = id;
    this.editMode = true;
  }

  finishEdit(): void {
    this.editedExerciseId = null;
    this.editMode = false;
  }

  updateExercise(id: number, updatedExercise: Exercise): void {
    this.exerciseService.updateExercise(id, updatedExercise).subscribe(() => {
      this.loadExercises();
      this.finishEdit();
    });
  }

  deleteExercise(id: number): void {
    this.exerciseService.deleteExercise(id).subscribe(() => {
      this.loadExercises();
    });
  }

  assignMusclePart(exerciseId:number): void {
    const selectedExercise = this.exercises.find(exercise => exercise.id === exerciseId);

    if (selectedExercise) {

      this.availableMuscleParts = this.muscleParts.filter(musclePart => {
        return !selectedExercise.muscleParts.some(selectedMusclePart => selectedMusclePart.id === musclePart.id);
      });
      this.selectedExercise = selectedExercise;
      this.assignMode = true;
    } else {
      this.selectedExercise = null;
      this.availableMuscleParts = [];
      this.assignMode=false;
    }
  }
  assignSelectedMusclePart(): void {
    if (this.selectedExercise && this.selectedMusclePart) {
      this.exerciseService.addMusclePartToExercise(this.selectedExercise, this.selectedExercise.id,this.selectedMusclePart.id).subscribe(() => {
      });
      this.loadMuscleParts();
      this.assignMode=false;
    }
  }
  removeSelectedMusclePart(): void {
    if (this.selectedExercise && this.selectedMusclePartToRemove) {
    this.exerciseService.removeMusclePartFromExercise(this.selectedExercise, this.selectedExercise.id,this.selectedMusclePartToRemove.id).subscribe(() => {
    });
  }
  this.loadMuscleParts();
  this.assignMode=false;
    }
  cancelAssignMode(): void{
    this.assignMode=false;
    this.selectedExercise = null;
    this.availableMuscleParts = [];
  }
}
