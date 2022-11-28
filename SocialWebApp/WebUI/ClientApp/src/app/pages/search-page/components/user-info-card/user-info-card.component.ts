import { Component, Input, OnInit } from '@angular/core';
import { ISearchUser } from 'src/app/interface/user';

@Component({
  selector: 'app-user-info-card',
  templateUrl: './user-info-card.component.html',
  styleUrls: ['./user-info-card.component.scss']
})
export class UserInfoCardComponent implements OnInit {
  @Input() user!: ISearchUser;

  constructor() {}

  ngOnInit(): void {}
}
