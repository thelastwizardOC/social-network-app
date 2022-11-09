import {
  ChangeDetectionStrategy,
  Component,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Router } from '@angular/router';
import { TuiHostedDropdownComponent } from '@taiga-ui/core';
import { TUI_ARROW } from '@taiga-ui/kit';
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

  readonly arrow = TUI_ARROW;

  open = false;

  toggleDropDown() {
    this.open = !this.open;
  }

  profileIconColor = 'black';

  ngDoCheck(): void {
    const currentRoute = this.route.url;
    currentRoute == '/personal-wall'
      ? (this.profileIconColor = 'var(--tui-primary-active)')
      : (this.profileIconColor = 'var(--tui-base-09)');
  }

  ngOnInit(): void {}
}
