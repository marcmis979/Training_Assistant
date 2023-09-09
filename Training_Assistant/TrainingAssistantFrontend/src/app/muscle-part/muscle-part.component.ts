import { Component, OnInit } from '@angular/core';
import { MusclePartService } from '../muscle-part.service';
import { MusclePart } from './model/muscle-part';
import { MusclePartResponse } from './model/muscle-part-response';

@Component({
  selector: 'app-muscle-part',
  templateUrl: './muscle-part.component.html',
  styleUrls: ['./muscle-part.component.css']
})
export class MusclePartComponent implements OnInit {
  musclePart?: MusclePart;
  musclePartResponse:MusclePartResponse ={
    name: ''
  };
  searchId!: number; // Pole do wprowadzania ID do wyszukiwania

  constructor(private musclePartService: MusclePartService) { }

  ngOnInit(): void {
    this.searchId = 1; // Domyślne ID do wyszukiwania
    this.loadMusclePart(); // Wywołujemy metodę pobierającą MusclePart
  }

  private loadMusclePart(): void {
    this.musclePartService.getMusclePart(this.searchId).subscribe((data) => {
      this.musclePart = data;
    });
  }

  searchMusclePart(): void {
    this.loadMusclePart(); // Wywołujemy metodę pobierającą MusclePart po ID
  }

  // Metoda do dodawania MusclePart
  addMusclePart(): void {
    this.musclePartService.addMusclePart(this.musclePartResponse).subscribe(() => {
      // Po dodaniu MusclePart odśwież listę lub wykonaj inne działania
      this.loadMusclePart();
      // Zresetuj dane nowego MusclePart
      this.musclePartResponse = {
        name: ''
      };
    });
  }
}
