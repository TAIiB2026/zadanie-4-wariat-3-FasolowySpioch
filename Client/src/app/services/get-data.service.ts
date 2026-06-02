import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { GetDataInterface } from '../interfaces/get-data.interface';
import { FilmClass } from '../classes/film.class';

@Injectable({
  providedIn: 'root'
})
export class GetDataService implements GetDataInterface {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'http://localhost:5106/api/filmy';

  Get(): Observable<FilmClass[]> {
    return this.http.get<any[]>(this.apiUrl).pipe(
      map(filmy => filmy.map(f => new FilmClass(f.id, f.tytul, f.cena, new Date(f.dataPremiery))))
    );
  }

  GetByID(id: number): Observable<FilmClass> {
    return this.http.get<any>(`${this.apiUrl}/${id}`).pipe(
      map(f => new FilmClass(f.id, f.tytul, f.cena, new Date(f.dataPremiery)))
    );
  }
}