import { Component } from '@angular/core';
import {TUI_ARROW} from '@taiga-ui/kit';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';
  readonly arrow = TUI_ARROW;

}
