import { Component, OnInit } from '@angular/core';
import { Exercise } from './model/exercise';
import { ExerciseResponse } from './model/exercise-response';
import { Type } from './model/type.enum';
import { ExerciseService } from '../exercise.service';
import { MusclePart } from '../muscle-part/model/muscle-part';

@Component({
  selector: 'app-exercise',
  templateUrl: './exercise.component.html',
  styleUrls: ['./exercise.component.css']
})
export class ExerciseComponent implements OnInit {
  exercises: Exercise[] = []; // Tablica przechowująca ćwiczenia
  exerciseResponse: ExerciseResponse = {
    name: '',
    burnedKcal: 0,
    time: 0,
    type: Type.aerobic
  };
  editMode = false; // Tryb edycji
  editedExerciseId: number | null = null; // ID edytowanego ćwiczenia

  constructor(private exerciseService: ExerciseService) {}

  ngOnInit(): void {
    this.loadExercises(); // Wywołujemy metodę pobierającą wszystkie ćwiczenia
  }

  private loadExercises(): void {
    this.exerciseService.getExercises().subscribe((data) => {
      this.exercises = data;
    });
  }

  searchExercise(): void {
    this.loadExercises(); // Wywołujemy metodę pobierającą wszystkie ćwiczenia
  }

  // Metoda do dodawania ćwiczenia
  addExercise(): void {
    this.exerciseService.addExercise(this.exerciseResponse).subscribe(() => {
      // Po dodaniu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadExercises();
      // Zresetuj dane nowego ćwiczenia
      this.exerciseResponse = {
        name: '',
        burnedKcal: 0,
        time: 0,
        type: Type.aerobic
      };
    });
  }

  // Metoda do rozpoczęcia edycji
  startEdit(id: number): void {
    this.editedExerciseId = id;
    this.editMode = true;
  }

  // Metoda do zakończenia edycji
  finishEdit(): void {
    this.editedExerciseId = null;
    this.editMode = false;
  }

  // Metoda do aktualizacji ćwiczenia
  updateExercise(id: number, updatedExercise: Exercise): void {
    this.exerciseService.updateExercise(id, updatedExercise).subscribe(() => {
      // Po zaktualizowaniu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadExercises();
      this.finishEdit();
    });
  }

  // Metoda do usuwania ćwiczenia
  deleteExercise(id: number): void {
    this.exerciseService.deleteExercise(id).subscribe(() => {
      // Po usunięciu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadExercises();
    });
  }
}
