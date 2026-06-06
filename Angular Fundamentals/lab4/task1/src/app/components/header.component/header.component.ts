import { Component, inject } from "@angular/core";
import { Router, RouterLink, RouterLinkActive } from "@angular/router";

@Component({
  selector: 'app-header',
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  imports: [ RouterLink, RouterLinkActive ]
})
export class HeaderComponent {
  isAuthenticated: boolean = localStorage.getItem('user') !== null || sessionStorage.getItem('user') !== null;

  router: Router = inject(Router);

  logout() {
    localStorage.removeItem('user');
    sessionStorage.removeItem('user');

    this.isAuthenticated = false;

    this.router.navigate(['/home']);
  }
}
