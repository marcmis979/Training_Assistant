import { Component } from '@angular/core';
import { UserResponse } from './model/user-response';
import { User } from './model/user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  users: User[] = []; // Tablica przechowująca ćwiczenia
  userResponse: UserResponse = {
    name: '',
    surname:'',
    sex:false,
    age:0,
    height:0,
    weight:0,
    targetWeight:0,
    tempo:0,
    email:'',
    password:''
  };
  editMode = false; // Tryb edycji
  editedUserId: number | null = null; // ID edytowanego ćwiczenia

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers(); // Wywołujemy metodę pobierającą wszystkie ćwiczenia
  }

  private loadUsers(): void {
    this.userService.getUsers().subscribe((data) => {
      this.users = data;
    });
  }

  searchUser(): void {
    this.loadUsers(); // Wywołujemy metodę pobierającą wszystkie ćwiczenia
  }

  // Metoda do dodawania ćwiczenia
  addUser(): void {
    this.userService.addUser(this.userResponse).subscribe(() => {
      // Po dodaniu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadUsers();
      // Zresetuj dane nowego ćwiczenia
      this.userResponse = {
        name: '',
        surname:'',
        sex:false,
        age:0,
        height:0,
        weight:0,
        targetWeight:0,
        tempo:0,
        email:'',
        password:''
      };
    });
  }

  // Metoda do rozpoczęcia edycji
  startEdit(id: number): void {
    this.editedUserId = id;
    this.editMode = true;
  }

  // Metoda do zakończenia edycji
  finishEdit(): void {
    this.editedUserId = null;
    this.editMode = false;
  }

  // Metoda do aktualizacji ćwiczenia
  updateUser(id: number, updatedUser: User): void {
    this.userService.updateUser(id, updatedUser).subscribe(() => {
      // Po zaktualizowaniu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadUsers();
      this.finishEdit();
    });
  }

  // Metoda do usuwania ćwiczenia
  deleteUser(id: number): void {
    this.userService.deleteUser(id).subscribe(() => {
      // Po usunięciu ćwiczenia odśwież listę lub wykonaj inne działania
      this.loadUsers();
    });
  }
}
