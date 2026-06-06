import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);

  const isLoggedIn = localStorage.getItem('user') !== null || sessionStorage.getItem('user') !== null;

  if (isLoggedIn) {
    return true;
  }

  return router.createUrlTree(['/login']);
};
