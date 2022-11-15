import { Component, EventEmitter, Input, Output } from '@angular/core';
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
  @Input() personalPosts: IPost[] = [];
  @Input() isLoading: boolean = false;
  @Input() uploadedAvatar: any;
  @Output() onScroll = new EventEmitter();
  @Output() onUploadAvatarClick = new EventEmitter();
  @Output() onAvatarUploaded = new EventEmitter();
  @Output() onCoverUploaded = new EventEmitter();

  mockImg: string = environment.mockImg;

  constructor() {}
}
