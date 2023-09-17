import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../user/model/user';
import { Observable } from 'rxjs';
import { UserResponse } from '../user/model/user-response';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  [x: string]: any;

  private apiUrl = 'http://localhost:14536/UserApi';

  constructor(private http: HttpClient) { }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/getUser/${id}`);
  }
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/getUsers`);
  }
  addUser(user: UserResponse): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/addUser`, user);
  }
  updateUser(id: number, updatedUser: User): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/updateUser/${id}`, updatedUser);
  }
  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/deleteUser/${id}`);
  }
  getBMI(id:number): Observable<number>{
    return this.http.get<number>(`${this.apiUrl}/BMI/${id}`);
  }
}
