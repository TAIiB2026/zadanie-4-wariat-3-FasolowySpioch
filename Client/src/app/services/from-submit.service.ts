import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormSubmitInterface } from '../interfaces/form-submit.interface';

@Injectable({
  providedIn: 'root'
})
export class FormSubmitService implements FormSubmitInterface {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'http://localhost:5106/api/filmy';

  Post(nazwa: string, cena: number, data: Date): Observable<boolean> {
    const body = {
      tytul: nazwa,
      cena: cena,
      dataPremiery: data.toISOString()
    };
    return this.http.post<boolean>(this.apiUrl, body);
  }

  Put(id: number, nazwa: string, cena: number, data: Date): Observable<boolean> {
    const body = {
      id: id,
      tytul: nazwa,
      cena: cena,
      dataPremiery: data.toISOString()
    };
    return this.http.put<boolean>(`${this.apiUrl}/${id}`, body);
  }

  Delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
}