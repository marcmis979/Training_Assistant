import { Component, OnInit } from '@angular/core';
import { MusclePartService } from '../services/muscle-part.service';
import { MusclePart } from './model/muscle-part';
import { MusclePartResponse } from './model/muscle-part-response';
import { UserResponse } from '../user/model/user-response';
import { UserService } from '../services/user.service';
import { Subscription } from 'rxjs';

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
  editMode = false;
  editedMusclePartId: number | null = null;

  private loggedInUserSubscription: Subscription;
  user?: UserResponse;
  isLoggedIn: boolean = this.userService.isLoggedIn;
  router: any;

  constructor(private musclePartService: MusclePartService, private userService: UserService) {
    this.loggedInUserSubscription = this.userService.loggedInUser.subscribe(user => {
      this.user = user;
      this.isLoggedIn = !!user;
    });
  }

  ngOnInit(): void {
    this.loadMuscleParts();
    console.log(this.user);
    this.userService.loggedInUser.subscribe(user => {
      this.user = user!; 
      this.userService.userUpdated.subscribe();
    });
    
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
