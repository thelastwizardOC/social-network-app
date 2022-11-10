import {
  ChangeDetectionStrategy,
  Component,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Router } from '@angular/router';
import { TuiHostedDropdownComponent } from '@taiga-ui/core';
@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavigationBarComponent implements OnInit {
  constructor(private route: Router) {}

  @ViewChild(TuiHostedDropdownComponent)
  component?: TuiHostedDropdownComponent;

  readonly profileItems = [
    { label: 'See Your Profile', link: '/personal-wall' },
    { label: 'Log Out', link: '/' },
  ];

  isDropDownVisible = false;

  isOnProfilePage = false;

  toggleDropDown() {
    this.isDropDownVisible = !this.isDropDownVisible;
  }

  ngDoCheck(): void {
    const currentRoute = this.route.url;
    currentRoute == '/personal-wall'
      ? (this.isOnProfilePage = true)
      : (this.isOnProfilePage = false);
  }

  ngOnInit(): void {}
}
