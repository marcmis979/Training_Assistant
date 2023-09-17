import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MusclePartComponent } from './muscle-part/muscle-part.component';
import { ExerciseComponent } from './exercise/exercise.component';
import { TrainingComponent } from './training/training.component';
import { TrainingPlanComponent } from './training-plan/training-plan.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './guard/auth.guard.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent},
  {path:'muscle-part',component: MusclePartComponent, canActivate: [AuthGuard]},
  {path:'exercise',component: ExerciseComponent, canActivate: [AuthGuard]},
  {path:'training',component: TrainingComponent, canActivate: [AuthGuard]},
  {path:'trainingPlan',component: TrainingPlanComponent, canActivate: [AuthGuard]},
  {path:'user',component: UserComponent, canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
