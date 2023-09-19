import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { Observable, Subscription } from "rxjs";
import { UserResponse } from '../user/model/user-response';

@Component({
  selector: 'app-baner',
  templateUrl: './baner.component.html',
  styleUrls: ['./baner.component.css']
})
export class BanerComponent {
  private loggedInUserSubscription: Subscription;
  user?: UserResponse;
  isLoggedIn: boolean = this.userService.isLoggedIn;

  constructor(
    private userService: UserService,
    private router: Router
  ) {
    this.loggedInUserSubscription = this.userService.loggedInUser.subscribe(user => {
      this.user = user;
      this.isLoggedIn = !!user;
      console.log(this.user);
    });
  }

  logout() {
    this.userService.logout();
    this.router.navigate(['/login']); 
  }
}
