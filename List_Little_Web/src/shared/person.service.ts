import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from 'src/app/models/person';
import { constants } from 'src/constants';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Person[]> {
    return this.http.get<Person[]>(constants.api.person.url)
  }
}
