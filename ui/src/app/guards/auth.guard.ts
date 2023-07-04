import { Injectable, inject } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router,
  RouterStateSnapshot,
} from '@angular/router';

@Injectable()
export class PermissionsService {
  constructor(public router: Router) {}

  canActivate(): boolean {
    const token = localStorage.getItem('accessToken');
    if (token) {
      return true;
    } else {
      
      console.log("girdi");
      console.log("Router",this.router);
      if (this.router) {
        this.router.navigate(['/sign-in']);
      }
      return false;
    }
  }
}

export const authGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  return inject(PermissionsService).canActivate();
};
