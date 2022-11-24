import { Component, ElementRef, Inject, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TuiDialogService, TuiHostedDropdownComponent } from '@taiga-ui/core';
import { debounce, trim } from 'lodash';
import { ISearchUser, ISearchUserResponse } from 'src/app/interface/user';
import { UserService } from './../../services/user.service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit, OnChanges {
  @ViewChild('searchInput') input!: ElementRef;
  isDialogOpened: boolean = false;

  constructor(
    private route: Router,
    private jwtHelper: JwtHelperService,
    @Inject(TuiDialogService) private readonly dialogService: TuiDialogService,
    private userService: UserService
  ) {
    this.onSearchInputChange = debounce(this.onSearchInputChange, 500);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.userId = +this.jwtHelper.decodeToken(localStorage.getItem('jwt') as string).sub;
  }

  @ViewChild(TuiHostedDropdownComponent)
  component?: TuiHostedDropdownComponent;
  userId!: number;

  profileItems = [{ label: 'See Your Profile', link: '/' }, { label: 'Log Out' }];

  isDropDownProfileVisible = false;
  isDropDownSearchVisible = false;
  isOnProfilePage = false;
  isLoadingSearch = false;
  searchUsers: ISearchUser[] = [];

  toggleDropDown(itemIndex: number) {
    if (itemIndex === 1) this.showDialog();
    this.isDropDownProfileVisible = !this.isDropDownProfileVisible;
  }

  ngDoCheck(): void {
    const currentRoute = this.route.url;
    currentRoute.includes('/profile') == true ? (this.isOnProfilePage = true) : (this.isOnProfilePage = false);
  }

  ngOnInit(): void {
    const token = localStorage.getItem('jwt');

    if (token !== null) {
      this.userId = +this.jwtHelper.decodeToken(token as string).sub;
      this.profileItems[0].link = '/profile/' + this.userId;
    }
  }

  showDialog(): void {
    this.isDialogOpened = true;
  }

  logout() {
    localStorage.removeItem('jwt');
    localStorage.removeItem('refreshToken');
    this.route.navigate(['auth/login']);
  }

  onSearch(event: KeyboardEvent) {
    if (this.input.nativeElement.value === '') return;
    if (event.key == 'Enter') {
      this.onSearchEnter();
    } else {
      this.isLoadingSearch = true;
      this.onSearchInputChange();
    }
  }

  onSearchInputChange() {
    var value: string = trim(this.input.nativeElement.value);
    if (value.length != 0) {
      this.userService.searchUser(this.userId, value, 0, 5).subscribe({
        next: (res: ISearchUserResponse) => {
          console.log(res);
          this.searchUsers = res.users;
        },
        error: err => {
          console.log(err);
        },
        complete: () => {
          this.isLoadingSearch = false;
        }
      });
    } else {
      this.searchUsers = [];
      this.isLoadingSearch = false;
    }
  }

  onToggleDropdownSearch() {
    this.isDropDownSearchVisible = true;
  }

  onSearchEnter() {
    this.isDropDownSearchVisible = false;
    this.route.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.route.navigate(['search'], { queryParams: { searchString: trim(this.input.nativeElement.value) } });
    });
  }
}
