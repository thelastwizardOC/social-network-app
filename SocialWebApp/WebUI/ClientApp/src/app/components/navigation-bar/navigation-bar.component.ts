import { UserService } from './../../services/user.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ChangeDetectionStrategy, Component, ElementRef, Inject, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { TuiDialogService, TuiHostedDropdownComponent } from '@taiga-ui/core';
import { debounce } from 'lodash';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
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
    // this.onSearchInputChange = debounce(this.onSearchInputChange, 500);
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

    console.log(this.isLoadingSearch);
  }

  showDialog(): void {
    this.isDialogOpened = true;
  }

  logout() {
    localStorage.removeItem('jwt');
    localStorage.removeItem('refreshToken');
    this.route.navigate(['auth/login']);
  }

  onSearchInputChange() {
    this.isLoadingSearch = true;
    console.log(this.isLoadingSearch);
    var value: string = this.input.nativeElement.value;
    if (value.length != 0) {
      this.userService.searchUser(this.userId, value).subscribe({
        next: res => {
          console.log('Hi', res);
          console.log(this.isLoadingSearch);
        },
        error: err => {
          console.log(err);
        },
        complete: () => {
          console.log('complete' + this.isLoadingSearch);
          this.isLoadingSearch = false;
        }
      });
    }
  }

  onToggleDropdownSearch() {
    this.isDropDownSearchVisible = true;
  }
}
