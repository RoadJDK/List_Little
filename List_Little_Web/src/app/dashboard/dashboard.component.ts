import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Auth0Client } from '@auth0/auth0-spa-js';
import { lastValueFrom, take } from 'rxjs';
import { PersonService } from 'src/shared/person.service';
import { Person } from '../models/person';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  personSearch?: string;
  offset = 10;

  personList: Person[] = []
  filteredPersonList: Person[] = [];
  options: string[] = []
  filteredOptions: string[] = [];

  constructor(public auth: AuthService, private readonly personService: PersonService) { }

  async ngOnInit(): Promise<void> {
    this.personList = await lastValueFrom(this.personService.getAll().pipe(take(1)))
    this.personList.map(p => {
      p.imagePath = `../../assets/images/person_${p.number}.jpeg`
    })
    this.personList.sort((a, b) => {
      if (a.number < b.number) return -1;
      if (a.number > b.number) return 1;
      return 0;
    });

    this.filteredPersonList = this.personList;
    this.options = this.personList.map(person => person.firstName + ' ' + person.lastName)
    this.filteredOptions = this.options
  }

  onChange(value: string): void {
    let searchWords = value.toLowerCase().split(' ');

    this.filteredPersonList = this.personList.filter(option => {
      let fullName = (option.firstName + ' ' + option.lastName).toLowerCase()

      return searchWords.every(word => fullName.indexOf(word) !== -1)
    })
    this.filteredOptions = this.options.filter(option => option.toLowerCase().indexOf(value.toLowerCase()) !== -1 || option.toLowerCase().indexOf(value.toLowerCase()) !== -1)
  }

  logout() {
    this.auth.logout({returnTo: 'https://localhost:7075/'})
  }
}