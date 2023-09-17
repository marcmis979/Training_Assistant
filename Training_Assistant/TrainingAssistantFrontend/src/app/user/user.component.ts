import { Component } from '@angular/core';
import { UserResponse } from './model/user-response';
import { User } from './model/user';
import { UserService } from '../services/user.service';
import { TrainingPlan } from '../training-plan/model/training-plan';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  users: User[] = [];
  userResponse: UserResponse = {
    id: 0,
    name: '',
    surname:'',
    sex:false,
    age:0,
    height:0,
    weight:0,
    targetWeight:0,
    tempo:0,
    password:'',
    email:'',
    isAdmin:false
  };
  editMode = false;
  editedUserId: number | null = null;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  private loadUsers(): void {
    this.userService.getUsers().subscribe((data) => {
      this.users = data;
    });
  }

  searchUser(): void {
    this.loadUsers();
  }

  addUser(): void {
    this.userService.addUser(this.userResponse).subscribe(() => {
      this.loadUsers();
      this.userResponse = {
        id: 0,
        name: '',
        surname:'',
        sex:false,
        age:0,
        height:0,
        weight:0,
        targetWeight:0,
        tempo:0,
        password:'',
        email:'',
        isAdmin:false
      };
    });
  }

  startEdit(id: number): void {
    this.editedUserId = id;
    this.editMode = true;
  }

  finishEdit(): void {
    this.editedUserId = null;
    this.editMode = false;
  }

  updateUser(id: number, updatedUser: User): void {
    this.userService.updateUser(id, updatedUser).subscribe(() => {
      this.loadUsers();
      this.finishEdit();
    });
  }

  deleteUser(id: number): void {
    this.userService.deleteUser(id).subscribe(() => {
      this.loadUsers();
    });
  }
}
