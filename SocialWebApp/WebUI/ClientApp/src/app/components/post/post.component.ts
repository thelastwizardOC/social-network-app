import { Component, Input, OnInit } from '@angular/core';
import { IPersonalPost } from 'src/app/interface/personal-post';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent {
  @Input()
  post!: IPersonalPost;

  mockImg: string = environment.mockImg;
  constructor() {}
}
