import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ISearchUser } from 'src/app/interface/user';

@Component({
  selector: 'app-user-info-card',
  templateUrl: './user-info-card.component.html',
  styleUrls: ['./user-info-card.component.scss']
})
export class UserInfoCardComponent implements OnInit {
  @Input() user!: ISearchUser;

  constructor(private route: Router) {}

  ngOnInit(): void {}

  handleOnButtonPress(user: ISearchUser, relationship: number) {
    if (relationship === 0) {
      this.route.navigate(['profile/' + user.id]);
    }
  }
}
