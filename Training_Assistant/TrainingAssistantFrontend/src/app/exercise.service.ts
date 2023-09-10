import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Exercise } from './exercise/model/exercise';
import { ExerciseResponse } from './exercise/model/exercise-response';
@Injectable({
  providedIn: 'root'
})
export class ExerciseService {
  [x: string]: any;

  private apiUrl = 'http://localhost:5014/ExerciseApi';

  constructor(private http: HttpClient) { }

  getExercise(id: number): Observable<Exercise> {
    return this.http.get<Exercise>(`${this.apiUrl}/getExercise/${id}`);
  }
  getExercises(): Observable<Exercise[]> {
    return this.http.get<Exercise[]>(`${this.apiUrl}/getExercises`);
  }
  addExercise(exercise: ExerciseResponse): Observable<Exercise> {
    return this.http.post<Exercise>(`${this.apiUrl}/addExercise`, exercise);
  }
  updateExercise(id: number, updatedExercise: Exercise): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/updateExercise/${id}`, updatedExercise);
  }
  getBurnedPerHour(id:number): Observable<number>{
    return this.http.get<number>(`${this.apiUrl}/burned/${id}`);
  }
  deleteExercise(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/deleteExercise/${id}`);
  }
}
