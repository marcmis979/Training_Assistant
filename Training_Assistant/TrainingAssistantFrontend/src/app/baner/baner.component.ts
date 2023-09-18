import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-baner',
  templateUrl: './baner.component.html',
  styleUrls: ['./baner.component.css']
})
export class BanerComponent {
  constructor(
    private userService: UserService,
    private router: Router
  ) {}

  logout() {
    this.userService.logout();
    this.router.navigate(['/login']); 
  }
}
