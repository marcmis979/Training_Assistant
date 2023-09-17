import { Component, OnInit } from '@angular/core';
import { MusclePartService } from '../services/muscle-part.service';
import { MusclePart } from './model/muscle-part';
import { MusclePartResponse } from './model/muscle-part-response';

@Component({
  selector: 'app-muscle-part',
  templateUrl: './muscle-part.component.html',
  styleUrls: ['./muscle-part.component.css']
})
export class MusclePartComponent implements OnInit {
  muscleParts: MusclePart[] = []; // Tablica przechowująca MusclePart
  musclePartResponse: MusclePartResponse = {
    name: ''
  };
  searchId!: number; // Pole do wprowadzania ID do wyszukiwania
  editMode = false; // Tryb edycji
  editedMusclePartId: number | null = null; // ID edytowanego MusclePart

  constructor(private musclePartService: MusclePartService) {}

  ngOnInit(): void {
    this.searchId = 1; // Domyślne ID do wyszukiwania
    this.loadMuscleParts(); // Wywołujemy metodę pobierającą wszystkie MusclePart
  }

  private loadMuscleParts(): void {
    this.musclePartService.getMuscleParts().subscribe((data) => {
      this.muscleParts = data;
    });
  }

  searchMusclePart(): void {
    this.loadMuscleParts(); // Wywołujemy metodę pobierającą wszystkie MusclePart
  }

  // Metoda do dodawania MusclePart
  addMusclePart(): void {
    this.musclePartService.addMusclePart(this.musclePartResponse).subscribe(() => {
      // Po dodaniu MusclePart odśwież listę lub wykonaj inne działania
      this.loadMuscleParts();
      // Zresetuj dane nowego MusclePart
      this.musclePartResponse = {
        name: ''
      };
    });
  }

  // Metoda do usuwania MusclePart
  deleteMusclePart(id: number): void {
    this.musclePartService.deleteMusclePart(id).subscribe(() => {
      // Po usunięciu MusclePart odśwież listę lub wykonaj inne działania
      this.loadMuscleParts();
    });
  }

  // Metoda do rozpoczęcia edycji
  startEdit(id: number): void {
    this.editedMusclePartId = id;
    this.editMode = true;
  }

  // Metoda do zakończenia edycji
  finishEdit(): void {
    this.editedMusclePartId = null;
    this.editMode = false;
  }

  // Metoda do aktualizacji MusclePart
  updateMusclePart(id: number, name: string): void {
    const updatedMusclePart: MusclePart = { id,name };
    this.musclePartService.updateMusclePart(id, updatedMusclePart).subscribe(() => {
      // Po aktualizacji MusclePart odśwież listę lub wykonaj inne działania
      this.loadMuscleParts();
      this.finishEdit();
    });
  }
}
