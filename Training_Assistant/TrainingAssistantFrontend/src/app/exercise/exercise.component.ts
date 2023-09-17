import { Component, OnInit } from '@angular/core';
import { Exercise } from './model/exercise';
import { ExerciseResponse } from './model/exercise-response';
import { Type } from './model/type.enum';
import { ExerciseService } from '../services/exercise.service';
import { MusclePart } from '../muscle-part/model/muscle-part';
import { MusclePartService } from '../services/muscle-part.service'; // Dodaj import usługi MusclePartService

@Component({
  selector: 'app-exercise',
  templateUrl: './exercise.component.html',
  styleUrls: ['./exercise.component.css']
})
export class ExerciseComponent implements OnInit {
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
  muscleParts: MusclePart[] = []; // Dodaj listę dostępnych muscle party

  constructor(
    private exerciseService: ExerciseService,
    private musclePartService: MusclePartService // Wstrzyknij MusclePartService
  ) {}

  ngOnInit(): void {
    this.loadExercises();
    this.loadMuscleParts(); // Ładuj dostępne muscle party przy inicjalizacji komponentu
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

  searchExercise(): void {
    this.loadExercises();
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

  // Dodaj funkcję do przypisywania muscle party do ćwiczenia
  assignMusclePart(musclePart: MusclePart): void {
    if (this.exerciseResponse.muscleParts.indexOf(musclePart) === -1) {
      this.exerciseResponse.muscleParts.push(musclePart);
    }
  }

  // Dodaj funkcję do usuwania przypisanego muscle party z ćwiczenia
  removeMusclePart(musclePart: MusclePart): void {
    const index = this.exerciseResponse.muscleParts.indexOf(musclePart);
    if (index !== -1) {
      this.exerciseResponse.muscleParts.splice(index, 1);
    }
  }
}
