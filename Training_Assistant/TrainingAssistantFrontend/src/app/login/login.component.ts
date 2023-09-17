import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  loginForm!: FormGroup;
  wrongInputs: boolean = false;


  constructor(private formBuilder: FormBuilder,
              private userService: UserService,
              private router: Router) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      address: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  onLoginClick(login: string, password: string) {
    this.userService.login(login, password).subscribe(
      response => {
        console.log('Zalogowano:', response);
        this.userService.getByEmail(login).subscribe(
          userResponse => {
            this.userService.setLoggedInUser(userResponse);
            this.userService.isLoggedIn = true;
            console.log("userResponse below" );
            console.log(userResponse);
            console.log(userResponse.isAdmin);
            if (userResponse.isAdmin) {
              this.router.navigate(['/user']);
            } else {
              this.router.navigate(['/trainingPlan']);
            }
          },
          error => {
            console.error('Błąd pobierania użytkownika:', error);
          }
        );
      },
      error => {
        console.error('Błąd logowania:', error);
        this.wrongInputs = true;
        setTimeout(() => {
          this.wrongInputs = false;
        }, 3000);
      }
    );
  }
}
