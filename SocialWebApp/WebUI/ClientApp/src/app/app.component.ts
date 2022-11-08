import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TUI_ARROW } from '@taiga-ui/kit';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private route: Router) {}
  title = 'ClientApp';

  isNavBarVisible = false;

  ngDoCheck(): void {
    const currentRoute = this.route.url;
    currentRoute == '/login' || currentRoute == '/register' ? (this.isNavBarVisible = false) : (this.isNavBarVisible = true);
  }
  readonly arrow = TUI_ARROW;
}
