import { Component } from '@angular/core';
import { TrainingPlanResponse } from './model/training-plan-response';
import { TrainingPlan } from './model/training-plan';
import { TrainingPlanService } from '../services/training-plan.service';
import { Training } from '../training/model/training';
import { TrainingService } from '../services/training.service';
import { UserService } from '../services/user.service';
import { Subscription } from 'rxjs';
import { UserResponse } from '../user/model/user-response';
import { User } from '../user/model/user';

@Component({
  selector: 'app-training-plan',
  templateUrl: './training-plan.component.html',
  styleUrls: ['./training-plan.component.css']
})
export class TrainingPlanComponent {
  private loggedInUserSubscription: Subscription;
  user?: UserResponse;
  isLoggedIn: boolean = this.userService.isLoggedIn;
  
  trainingPlans: TrainingPlan[] = [];
  trainingPlanResponse: TrainingPlanResponse = {
    name: '',
  };
  editMode = false;
  editedTrainingPlanId: number | null = null;
  assignMode = false;
  selectedTrainingPlan: TrainingPlan | null = null;
  selectedTraining: Training | null = null;
  selectedTrainingToRemove: Training | null = null;
  availableTrainings: Training[] = [];
  trainings: Training[] = [];

  

  constructor(
    private trainingService: TrainingService,
    private trainingPlanService: TrainingPlanService,
    private userService: UserService 
  ) {
    this.loggedInUserSubscription = this.userService.loggedInUser.subscribe(user => {
      this.user = user;
      this.isLoggedIn = !!user;
    });
  }

  ngOnInit(): void {
    this.loadTrainingPlans();
    this.loadTrainings();
  }

  private loadTrainingPlans(): void {
    this.trainingPlanService.getTrainingPlans().subscribe((data) => {
      this.trainingPlans = data;
    });
  }
  private loadTrainings(): void {
    this.trainingService.getTrainings().subscribe((data) => {
      this.trainings = data;
    });
  }

  addTrainingPlan(): void {
    this.trainingPlanService.addTrainingPlan(this.trainingPlanResponse).subscribe(() => {
      this.loadTrainingPlans();
      this.trainingPlanResponse = {
        name: '',
      };
    });
  }

  startEdit(id: number): void {
    this.editedTrainingPlanId = id;
    this.editMode = true;
  }

  finishEdit(): void {
    this.editedTrainingPlanId = null;
    this.editMode = false;
  }

  updateTrainingPlan(id: number, updatedTrainingPlan: TrainingPlan): void {
    this.trainingPlanService.updateTrainingPlan(id, updatedTrainingPlan).subscribe(() => {
      this.loadTrainingPlans();
      this.finishEdit();
    });
  }

  deleteTrainingPlan(id: number): void {
    this.trainingPlanService.deleteTrainingPlan(id).subscribe(() => {
      this.loadTrainingPlans();
    });
  }
  assignTraining(trainingPlanId: number): void {
    const selectedTrainingPlan = this.trainingPlans.find((trainingPlan) => trainingPlan.id === trainingPlanId);

    if (selectedTrainingPlan) {
      this.availableTrainings = this.trainings.filter((training) => {
        return !selectedTrainingPlan.trainings.some((assignedTraining) => assignedTraining.id === training.id);
      });
      this.selectedTrainingPlan = selectedTrainingPlan;
      this.assignMode = true;
    } else {
      this.selectedTraining = null;
      this.availableTrainings = [];
      this.assignMode = false;
    }
  }

  assignSelectedTraining(): void {
    if (this.selectedTraining && this.selectedTrainingPlan) {
      this.trainingPlanService.addTrainingToTrainingPlan(this.selectedTrainingPlan, this.selectedTrainingPlan.id, this.selectedTraining.id).subscribe(() => {
        this.loadTrainingPlans();
        this.assignMode = false;
      });
    }
  }

  removeSelectedTraining(): void {
    if (this.selectedTrainingToRemove && this.selectedTrainingPlan) {
      this.trainingPlanService.removeTrainingFromTrainingPlan(this.selectedTrainingPlan, this.selectedTrainingPlan.id, this.selectedTrainingToRemove.id).subscribe(() => {
        this.loadTrainingPlans();
        this.assignMode = false;
      });
    }
  }

  cancelAssignMode(): void {
    this.assignMode = false;
    this.selectedTraining = null;
    this.availableTrainings = [];
  }
}
