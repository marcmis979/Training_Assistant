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
  muscleParts: MusclePart[] = [];
  musclePartResponse: MusclePartResponse = {
    name: ''
  };
  searchId!: number;
  editMode = false;
  editedMusclePartId: number | null = null;

  constructor(private musclePartService: MusclePartService) {}

  ngOnInit(): void {
    this.searchId = 1;
    this.loadMuscleParts();
  }

  private loadMuscleParts(): void {
    this.musclePartService.getMuscleParts().subscribe((data) => {
      this.muscleParts = data;
    });
  }

  searchMusclePart(): void {
    this.loadMuscleParts();
  }

  addMusclePart(): void {
    this.musclePartService.addMusclePart(this.musclePartResponse).subscribe(() => {
      this.loadMuscleParts();
      this.musclePartResponse = {
        name: ''
      };
    });
  }

  deleteMusclePart(id: number): void {
    this.musclePartService.deleteMusclePart(id).subscribe(() => {
      this.loadMuscleParts();
    });
  }

  startEdit(id: number): void {
    this.editedMusclePartId = id;
    this.editMode = true;
  }

  finishEdit(): void {
    this.editedMusclePartId = null;
    this.editMode = false;
  }

  updateMusclePart(id: number, name: string): void {
    const updatedMusclePart: MusclePart = { id, name };
    this.musclePartService.updateMusclePart(id, updatedMusclePart).subscribe(() => {
      this.loadMuscleParts();
      this.finishEdit();
    });
  }
}
