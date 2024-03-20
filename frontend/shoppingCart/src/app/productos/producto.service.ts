import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root',
})
export class ProductoService {
  private http = inject(HttpClient);
  private authService = inject(AuthService);
  private readonly url = environment.apiUrl;

  constructor() {}

  getProducts(): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });

    // const headers = {
    //   Authorization: `Bearer ${this.authService.getToken()}`,
    // };

    return this.http.get<any>(`${this.url}/producto`, { headers });
  }
}
