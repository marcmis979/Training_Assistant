import { Injectable } from '@angular/core';
import { Training } from '../training/model/training';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TrainingResponse } from '../training/model/training-response';

@Injectable({
  providedIn: 'root'
})
export class TrainingService {

  [x: string]: any;

  private apiUrl = 'http://localhost:5014/TrainingApi';

  constructor(private http: HttpClient) { }

  getTraining(id: number): Observable<Training> {
    return this.http.get<Training>(`${this.apiUrl}/getTraining/${id}`);
  }
  getTrainings(): Observable<Training[]> {
    return this.http.get<Training[]>(`${this.apiUrl}/getTrainings`);
  }
  addTraining(training: TrainingResponse): Observable<Training> {
    return this.http.post<Training>(`${this.apiUrl}/addTraining`, training);
  }
  updateTraining(id: number, updatedTraining: Training): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/updateTraining/${id}`, updatedTraining);
  }
  deleteTraining(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/deleteTraining/${id}`);
  }
}
