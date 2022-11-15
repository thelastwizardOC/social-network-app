import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth-layout',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AuthComponent implements OnInit {
  newUser: boolean = true;

  constructor(private route: Router) {}

  ngOnInit(): void {
    const currentRoute = this.route.url;
    currentRoute.includes('/login') ? (this.newUser = true) : (this.newUser = false);
  }
}
