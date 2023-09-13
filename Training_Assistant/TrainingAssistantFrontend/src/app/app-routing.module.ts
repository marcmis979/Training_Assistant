import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MusclePartComponent } from './muscle-part/muscle-part.component';
import { ExerciseComponent } from './exercise/exercise.component';
import { TrainingComponent } from './training/training.component';
import { TrainingPlanComponent } from './training-plan/training-plan.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  {path:'muscle-part',component: MusclePartComponent},
  {path:'exercise',component: ExerciseComponent},
  {path:'training',component: TrainingComponent},
  {path:'trainingPlan',component: TrainingPlanComponent},
  {path:'user',component: UserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
