import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MusclePartComponent } from './muscle-part/muscle-part.component';
import { ExerciseComponent } from './exercise/exercise.component';

const routes: Routes = [
  {path:'muscle-part',component: MusclePartComponent},
  {path:'exercise',component: ExerciseComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
