import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

export const guardaGuard: CanActivateFn = (route, state) => {
  const oauthService: AuthService = inject(AuthService);
    if (oauthService.hasAccess() ) {
      return true;
    }
    else{
      oauthService.redirecionaLogin();
      return false;
    }
};


