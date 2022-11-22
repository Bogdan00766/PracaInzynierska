import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  public isAuthenticated(): boolean {
    var cookie = document.cookie.match(/^(.*;)?\s*GUID\s*=\s*[^;]+(.*)?$/);
    if (cookie != null) return true;
    else return false;
  }

  
}
