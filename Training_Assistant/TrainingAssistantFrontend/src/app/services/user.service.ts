import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../user/model/user';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserResponse } from '../user/model/user-response';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  [x: string]: any;

  private apiUrl = 'http://localhost:14536/UserApi';
  loggedUser?: UserResponse;
  isLoggedIn = false;
  private loggedInUserSubject = new BehaviorSubject<UserResponse | undefined>(undefined);
  loggedInUser = this.loggedInUserSubject.asObservable();
  constructor(private http: HttpClient) { }

  setLoggedInUser(user: UserResponse) {
    this.loggedUser = user;
    this.isLoggedIn = true;
    this.loggedInUserSubject.next(user);
  }
  getLoggedInUserObservable(): Observable<UserResponse | undefined> {
    return this.loggedInUser;
  }
  getLoggedInUser() {
    return this.loggedUser;
  }

  login(login: string, password: string): Observable<User> {
    const loginRequest = { Login: login, Password: password };
    //return this.httpClient.post<User>(`${this.baseUrl}/login`, loginRequest);
    return this.http.get<User>(`${this.apiUrl}/getUser/${1}`);
  }

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
