import { Component } from '@angular/core';
import { UserResponse } from './model/user-response';
import { User } from './model/user';
import { UserService } from '../services/user.service';
import { TrainingPlan } from '../training-plan/model/training-plan';
import { TrainingPlanService } from '../services/training-plan.service';

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
    surname: '',
    sex: false,
    age: 0,
    height: 0,
    weight: 0,
    targetWeight: 0,
    tempo: 0,
    password: '',
    email: '',
    isAdmin: false,
    token: ''
  };
  editMode = false;
  editedUserId: number | null = null;
  assignMode = false;
  selectedUser: User | null = null;
  selectedTrainingPlan: TrainingPlan | null = null;
  selectedTrainingPlanToRemove: TrainingPlan | null = null;
  trainingPlans: TrainingPlan[] = [];
  availableTrainingPlans: TrainingPlan[] = [];

  constructor(
    private userService: UserService,
    private trainingPlanService: TrainingPlanService 
  ) {}

  ngOnInit(): void {
    this.loadUsers();
    this.loadTrainingPlans();
  }

  private loadUsers(): void {
    this.userService.getUsers().subscribe((data) => {
      this.users = data;
    });
  }

  private loadTrainingPlans(): void {
    const userTrainingPlanIds: number[] = [];
  
    this.users.forEach((user) => {
      if (user.trainingPlan && user.trainingPlan.id) {
        userTrainingPlanIds.push(user.trainingPlan.id);
      }
    });
  
    this.trainingPlanService.getTrainingPlans().subscribe((data) => {
      this.availableTrainingPlans = data.filter((trainingPlan) => {
        return !userTrainingPlanIds.includes(trainingPlan.id);
      });
  
      this.trainingPlans = data;
    });
  }
  

  addUser(): void {
    this.userService.addUser(this.userResponse).subscribe(() => {
      this.loadUsers();
      this.userResponse = {
        id: 0,
        name: '',
        surname: '',
        sex: false,
        age: 0,
        height: 0,
        weight: 0,
        targetWeight: 0,
        tempo: 0,
        password: '',
        email: '',
        isAdmin: false,
        token: '',
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
  assignTrainingPlan(userId: number): void {
    const selectedUser = this.users.find((user) => user.id === userId);
    if (selectedUser) {
      this.availableTrainingPlans = this.trainingPlans.filter((trainingPlan) => {
        return !selectedUser.trainingPlan || selectedUser.trainingPlan.id !== trainingPlan.id;
      });
  
      this.selectedUser = selectedUser;
      this.assignMode = true;
    } else {
      this.assignMode = false;
    }
  }
  

  assignSelectedTrainingPlan(): void {
    if (this.selectedTrainingPlan && this.selectedUser) {
      this.userService.addTrainingPlanToUser(this.selectedUser, this.selectedUser.id, this.selectedTrainingPlan.id).subscribe(() => {
        this.loadTrainingPlans();
        this.assignMode = false;
      });
    }
  }
  
  removeSelectedTrainingPlan(): void {
    if (this.selectedUser) {
      this.userService.removeTrainingPlanFromUser(this.selectedUser, this.selectedUser.id, this.selectedUser.trainingPlan.id).subscribe(() => {
        this.loadTrainingPlans();
        this.assignMode = false;
      });
    }
  }

  cancelAssignMode(): void {
    this.assignMode = false;
    this.selectedTrainingPlan = null;
  }
}
