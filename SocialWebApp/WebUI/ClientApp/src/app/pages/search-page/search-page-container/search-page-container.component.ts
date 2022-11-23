import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ISearchUser } from 'src/app/interface/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-search-page-container',
  templateUrl: './search-page-container.component.html',
  styleUrls: ['./search-page-container.component.scss']
})
export class SearchPageContainerComponent implements OnInit {
  constructor(private route: ActivatedRoute, private userService: UserService, private jwtHelper: JwtHelperService) {}
  searchString: string = '';
  userList: ISearchUser[] = [];
  userId!: number;
  hasNextPage: boolean = false;
  isLoading: boolean = false;
  limit: number = 10;
  offset: number = 0;

  ngOnInit(): void {
    this.userId = +this.jwtHelper.decodeToken(localStorage.getItem('jwt') as string).sub;
    this.route.queryParams.subscribe((params: any) => {
      this.searchString = params['searchString'];
      this.onSearchUser();
    });
  }

  onSearchUser() {
    this.isLoading = true;
    this.userService.searchUser(this.userId, this.searchString, this.offset, this.limit).subscribe({
      next: res => {
        this.userList = [...this.userList, ...res.users];
        this.offset += this.limit;
        this.hasNextPage = res.hasNextPage;
      },
      error: err => {
        console.log(err);
      },
      complete: () => {
        this.isLoading = false;
      }
    });
  }
}
