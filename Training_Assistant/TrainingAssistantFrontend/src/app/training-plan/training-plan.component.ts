import { Component } from '@angular/core';
import { TrainingPlanResponse } from './model/training-plan-response';
import { TrainingPlan } from './model/training-plan';
import { TrainingPlanService } from '../training-plan.service';

@Component({
  selector: 'app-training-plan',
  templateUrl: './training-plan.component.html',
  styleUrls: ['./training-plan.component.css']
})
export class TrainingPlanComponent {
  trainingPlans: TrainingPlan[] = []; // Tablica przechowująca ćwiczenia
  trainingPlanResponse: TrainingPlanResponse = {
    name: '',
  };
  editMode = false; // Tryb edycji
  editedTrainingPlanId: number | null = null; // ID edytowanego ćwiczenia

  constructor(private trainingPlanService: TrainingPlanService) {}

  ngOnInit(): void {
    this.loadTrainingPlanss(); // Wywołujemy metodę pobierającą wszystkie ćwiczenia
  }

  private loadTrainingPlanss(): void {
    this.trainingPlanService.getTrainingPlans().subscribe((data) => {
      this.trainingPlans = data;
    });
  }

  searchTrainingPlan(): void {
    this.loadTrainingPlanss(); // Wywołujemy metodę pobierającą wszystkie ćwiczenia
  }

  // Metoda do dodawania ćwiczenia
  addTrainingPlan(): void {
    this.trainingPlanService.addTrainingPlan(this.trainingPlanResponse).subscribe(() => {
      // Po dodaniu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadTrainingPlanss();
      // Zresetuj dane nowego ćwiczenia
      this.trainingPlanResponse = {
        name: '',
      };
    });
  }

  // Metoda do rozpoczęcia edycji
  startEdit(id: number): void {
    this.editedTrainingPlanId = id;
    this.editMode = true;
  }

  // Metoda do zakończenia edycji
  finishEdit(): void {
    this.editedTrainingPlanId = null;
    this.editMode = false;
  }

  // Metoda do aktualizacji ćwiczenia
  updateTrainingPlan(id: number, updatedTrainingPlan: TrainingPlan): void {
    this.trainingPlanService.updateTrainingPlan(id, updatedTrainingPlan).subscribe(() => {
      // Po zaktualizowaniu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadTrainingPlanss();
      this.finishEdit();
    });
  }

  // Metoda do usuwania ćwiczenia
  deleteTrainingPlan(id: number): void {
    this.trainingPlanService.deleteTrainingPlan(id).subscribe(() => {
      // Po usunięciu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadTrainingPlanss();
    });
  }
}
