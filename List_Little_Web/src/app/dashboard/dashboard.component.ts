import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Auth0Client } from '@auth0/auth0-spa-js';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  personSearch?: string;
  offset = 10;

  options = ["John", "Eva", "Justin", "Timo", "Lukas", "Aline", "Adrian"];
  filteredOptions: string[] = [];

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
    this.filteredOptions = this.options;
  }

  onChange(value: string): void {
    this.filteredOptions = this.options.filter(option => option.toLowerCase().indexOf(value.toLowerCase()) !== -1);
  }

  logout() {
    this.auth.logout()
  }
}