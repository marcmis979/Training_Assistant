import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { UserResponse } from '../user/model/user-response';
import { User } from '../user/model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5014/UserApi';
  private loggedInUserSubject = new BehaviorSubject<UserResponse | undefined>(undefined);
  loggedInUser = this.loggedInUserSubject.asObservable();
  isLoggedIn = false;
  
  private userUpdatedSubject = new BehaviorSubject<boolean>(false);
  userUpdated = this.userUpdatedSubject.asObservable();

  constructor(private http: HttpClient) {
    const token = localStorage.getItem('authToken');
    if (token) {
      this.setLoggedInUserFromToken(token);
    }
  }
  notifyUserUpdated() {
    this.userUpdatedSubject.next(true);
  }
  setLoggedInUser(user: UserResponse) {
    this.loggedInUserSubject.next(user);
    this.isLoggedIn = true;
  }

  setLoggedInUserFromToken(token: string) {
    const user = this.decodeJwtToken(token);
    if (user) {
      this.setLoggedInUser(user);
    }
  }

  decodeJwtToken(token: string): UserResponse | null {
    return null; 
  }

  login(login: string, password: string): Observable<{ token: string, user: UserResponse }> {
    const loginRequest = { Login: login, Password: password };
    return this.http.post<{ token: string, user: UserResponse }>(`${this.apiUrl}/login`, loginRequest).pipe(
      tap(response => {
        this.setLoggedInUser(response.user);
        localStorage.setItem('authToken', response.token);
      })
    );
  }

  logout() {
    localStorage.removeItem('authToken');
    this.loggedInUserSubject.next(undefined);
  }

  getUserById(id: number): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/GetUserById/${id}`);
  }
  getByEmail(email: string): Observable<UserResponse> {
    return this.http.get<UserResponse>(`${this.apiUrl}/GetUserByEmail/${email}`);
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
  addTrainingPlanToUser(updatedUser:User, userId: number,trainingPlanId: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/addTrainingPlanToUser/${userId}/${trainingPlanId}`, updatedUser);
  }
  removeTrainingPlanFromUser(updatedUser:User, userId: number,trainingPlanId: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/removeTrainingPlanFromUser/${userId}/${trainingPlanId}`, updatedUser);
  }
}

