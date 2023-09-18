import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private userService: UserService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const token = localStorage.getItem('authToken');

    if (token) {
      // Jeśli istnieje token JWT, użytkownik jest zalogowany
      this.userService.setLoggedInUserFromToken(token); // Aktualizuj stan zalogowania na podstawie tokena
      return true;
    } else {
      // Jeśli nie ma tokenu JWT, przekieruj na stronę logowania
      this.router.navigate(['login']);
      return false;
    }
  }
}
