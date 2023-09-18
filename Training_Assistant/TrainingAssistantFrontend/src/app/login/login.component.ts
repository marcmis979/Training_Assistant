import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  wrongInputs: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router
  ) {}

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
        this.userService.setLoggedInUser(response.user);
        this.router.navigate(['/training']); // Przekieruj na odpowiedni widok po zalogowaniu
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
