import { Component } from '@angular/core';
import { Exercise } from './model/exercise';
import { ExerciseResponse } from './model/exercise-response';
import { Type } from './model/type.enum';
import { ExerciseService } from '../exercise.service';

@Component({
  selector: 'app-exercise',
  templateUrl: './exercise.component.html',
  styleUrls: ['./exercise.component.css']
})
export class ExerciseComponent {
  exercise?: Exercise;
  exerciseResponse:ExerciseResponse={
    name: '',
    burnedKcal: 0,
    time: 0,
    type:Type.aerobic
  }
  exerciseTypes = Object.keys(Type).filter((type) => isNaN(Number(type)));
  searchId!: number; // Pole do wprowadzania ID do wyszukiwania

  constructor(private exerciseService: ExerciseService) { }

  ngOnInit(): void {
    this.searchId = 1; // Domyślne ID do wyszukiwania
    this.loadExercise(); // Wywołujemy metodę pobierającą MusclePart
  }

  private loadExercise(): void {
    this.exerciseService.getExercise(this.searchId).subscribe((data) => {
      this.exercise = data;
    });
  }

  searchExercise(): void {
    this.loadExercise(); // Wywołujemy metodę pobierającą MusclePart po ID
  }

  // Metoda do dodawania MusclePart
  addExercise(): void {
    this.exerciseService.addExercise(this.exerciseResponse).subscribe(() => {
      // Po dodaniu MusclePart odśwież listę lub wykonaj inne działania
      this.loadExercise();
      // Zresetuj dane nowego MusclePart
      this.exerciseResponse = {
        name: '',
        burnedKcal: 0,
        time: 0,
        type:Type.aerobic
      };
    });
  }
  // Metoda do usuwania ćwiczenia
  deleteExercise(id: number): void {
    this.exerciseService.deleteExercise(id).subscribe(() => {
      // Po usunięciu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadExercise();
    });
  }

  // Metoda do aktualizacji ćwiczenia
  updateExercise(id: number, updatedExercise: ExerciseResponse): void {
    this.exerciseService.updateExercise(id, updatedExercise).subscribe(() => {
      // Po zaktualizowaniu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadExercise();
    });
  }
}
