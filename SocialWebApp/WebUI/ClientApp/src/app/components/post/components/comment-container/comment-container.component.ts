import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { IUser } from '../../../../interface/user';

@Component({
  selector: 'app-comment-container',
  templateUrl: './comment-container.component.html',
  styleUrls: ['./comment-container.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class CommentContainerComponent implements OnInit {
  @Input() userInfo!: IUser;

  constructor() {}

  ngOnInit(): void {}
}
