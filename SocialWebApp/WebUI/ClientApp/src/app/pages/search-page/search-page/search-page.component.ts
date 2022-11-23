import { Component, Input, OnInit } from '@angular/core';
import { ISearchUser } from 'src/app/interface/user';

@Component({
  selector: 'app-search-page',
  templateUrl: './search-page.component.html',
  styleUrls: ['./search-page.component.scss']
})
export class SearchPageComponent implements OnInit {
  @Input() userList!: ISearchUser[];
  @Input() isLoading: boolean = false;

  constructor() {}

  ngOnInit(): void {}
}
