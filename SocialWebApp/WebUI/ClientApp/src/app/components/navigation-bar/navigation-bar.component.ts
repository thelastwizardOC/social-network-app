import { JwtHelperService } from '@auth0/angular-jwt';
import {
  ChangeDetectionStrategy,
  Component, Inject,
  OnChanges,
  OnInit,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import {Router} from '@angular/router';
import {TuiDialogService, TuiHostedDropdownComponent} from '@taiga-ui/core';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavigationBarComponent implements OnInit, OnChanges {
  isDialogOpened: boolean = false;

  constructor(private route: Router, private jwtHelper: JwtHelperService, @Inject(TuiDialogService) private readonly dialogService: TuiDialogService,) {}

  ngOnChanges(changes: SimpleChanges): void {
    this.userId = +this.jwtHelper.decodeToken(localStorage.getItem('jwt') as string).sub;
  }

  @ViewChild(TuiHostedDropdownComponent)
  component?: TuiHostedDropdownComponent;
  userId!: number;

  profileItems = [
    { label: 'See Your Profile', link: '/' },
    {label: 'Log Out', link: '#'},
  ];

  isDropDownVisible = false;

  isOnProfilePage = false;

  toggleDropDown(itemIndex: number) {
    if (itemIndex === 1) this.showDialog();
    this.isDropDownVisible = !this.isDropDownVisible;
  }

  ngDoCheck(): void {
    const currentRoute = this.route.url;
    currentRoute.includes('/profile') == true
      ? (this.isOnProfilePage = true)
      : (this.isOnProfilePage = false);
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
    localStorage.clear();
    this.route.navigate(["auth/login"]);
  }
}
