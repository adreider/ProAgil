import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../_models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {
  baseUrl = 'http://localhost:5000/api/evento';


  constructor(private http: HttpClient) { }

  // tslint:disable-next-line: typedef
  GetAllEvento(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseUrl);
  }

  GetEventoByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseUrl}/getByTema/${tema}`);
  }

  GetEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseUrl}/${id}`);
  }

}
