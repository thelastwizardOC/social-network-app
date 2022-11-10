import {
  Component,
  EventEmitter,
  Input,
  Output,
  ViewEncapsulation,
} from '@angular/core';
import { IPersonalPost } from 'src/app/interface/personal-post';
import { IUser } from 'src/app/interface/user';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-personal',
  templateUrl: './personal.component.html',
  styleUrls: ['./personal.component.scss'],
})
export class PersonalComponent {
  @Input() userNotFound: boolean = false;
  @Input() userInfo: IUser | undefined;
  @Input() activeItemIndex: number = 0;
  @Input() personalPosts: IPersonalPost[] = [];
  @Input() isLoading: boolean = false;
  @Output() onScroll = new EventEmitter();

  mockImg: string = environment.mockImg;

  constructor() {}
}
