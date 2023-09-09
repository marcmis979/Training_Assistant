import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MusclePart } from './muscle-part/model/muscle-part';
import { MusclePartResponse } from './muscle-part/model/muscle-part-response';

@Injectable({
  providedIn: 'root'
})
export class MusclePartService {

  private apiUrl = 'http://localhost:5014/MusclePartApi';

  constructor(private http: HttpClient) { }

  getMusclePart(id: number): Observable<MusclePart> {
    return this.http.get<MusclePart>(`${this.apiUrl}/getMusclePart/${id}`);
  }
  addMusclePart(musclePart: MusclePartResponse): Observable<MusclePartResponse> {
    return this.http.post<MusclePart>(`${this.apiUrl}/addMusclePart`, musclePart);
  }

  updateMusclePart(id: number, updatedMusclePart: MusclePartResponse): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/updateMusclePart/${id}`, updatedMusclePart);
  }
}
