import { Injectable } from '@angular/core';
import { TrainingPlan } from '../training-plan/model/training-plan';
import { HttpClient } from '@angular/common/http';
import { TrainingPlanResponse } from '../training-plan/model/training-plan-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanService {

  [x: string]: any;

  private apiUrl = 'http://localhost:5014/TrainingPlanApi';

  constructor(private http: HttpClient) { }

  getTrainingPlan(id: number): Observable<TrainingPlan> {
    return this.http.get<TrainingPlan>(`${this.apiUrl}/getTrainingPlan/${id}`);
  }
  getTrainingPlans(): Observable<TrainingPlan[]> {
    return this.http.get<TrainingPlan[]>(`${this.apiUrl}/getTrainingPlans`);
  }
  addTrainingPlan(trainingPlan: TrainingPlanResponse): Observable<TrainingPlan> {
    return this.http.post<TrainingPlan>(`${this.apiUrl}/addTrainingPlan`, trainingPlan);
  }
  updateTrainingPlan(id: number, updatedTrainingPlan: TrainingPlan): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/updateTrainingPlan/${id}`, updatedTrainingPlan);
  }
  deleteTrainingPlan(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/deleteTrainingPlan/${id}`);
  }
}
