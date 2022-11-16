import {
  ChangeDetectionStrategy,
  Component, Inject,
  OnInit,
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
export class NavigationBarComponent implements OnInit {
  isDialogOpened: boolean = false;

  constructor(private route: Router, @Inject(TuiDialogService) private readonly dialogService: TuiDialogService,) {
  }

  @ViewChild(TuiHostedDropdownComponent)
  component?: TuiHostedDropdownComponent;

  readonly profileItems = [
    {label: 'See Your Profile', link: '/profile/1'},
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
  }

  showDialog(): void {
    this.isDialogOpened = true;
  }

  logout() {
    localStorage.clear();
    this.route.navigate(["auth/login"]);
  }
}
