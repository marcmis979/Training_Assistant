import { Component } from '@angular/core';
import { Training } from './model/training';
import { TrainingResponse } from './model/training-response';
import { TrainingService } from '../services/training.service';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.css']
})
export class TrainingComponent {
  trainings: Training[] = []; // Tablica przechowująca ćwiczenia
  trainingResponse: TrainingResponse = {
    name: '',
    days: 0,
  };
  editMode = false; // Tryb edycji
  editedTrainingId: number | null = null; // ID edytowanego ćwiczenia

  constructor(private trainingService: TrainingService) {}

  ngOnInit(): void {
    this.loadTrainings(); // Wywołujemy metodę pobierającą wszystkie ćwiczenia
  }

  private loadTrainings(): void {
    this.trainingService.getTrainings().subscribe((data) => {
      this.trainings = data;
    });
  }

  searchTraining(): void {
    this.loadTrainings(); // Wywołujemy metodę pobierającą wszystkie ćwiczenia
  }

  // Metoda do dodawania ćwiczenia
  addTraining(): void {
    this.trainingService.addTraining(this.trainingResponse).subscribe(() => {
      // Po dodaniu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadTrainings();
      // Zresetuj dane nowego ćwiczenia
      this.trainingResponse = {
        name: '',
        days: 0,
      };
    });
  }

  // Metoda do rozpoczęcia edycji
  startEdit(id: number): void {
    this.editedTrainingId = id;
    this.editMode = true;
  }

  // Metoda do zakończenia edycji
  finishEdit(): void {
    this.editedTrainingId = null;
    this.editMode = false;
  }

  // Metoda do aktualizacji ćwiczenia
  updateTraining(id: number, updatedTraining: Training): void {
    this.trainingService.updateTraining(id, updatedTraining).subscribe(() => {
      // Po zaktualizowaniu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadTrainings();
      this.finishEdit();
    });
  }

  // Metoda do usuwania ćwiczenia
  deleteTraining(id: number): void {
    this.trainingService.deleteTraining(id).subscribe(() => {
      // Po usunięciu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadTrainings();
    });
  }
}
