import { Component, Input, OnInit } from '@angular/core';
import { IUserCommented } from '../../../../../interface/user';
import { communityComment } from '../comment.mock';

@Component({
  selector: 'app-community-comments',
  templateUrl: './community-comments.component.html',
  styleUrls: ['./community-comments.component.scss']
})
export class CommunityCommentsComponent implements OnInit {
  @Input() userCommentList: IUserCommented[] = communityComment;
  expanded: boolean = false;

  constructor() {}

  ngOnInit(): void {}

  onToggleViewMore() {
    this.expanded = !this.expanded;
  }
}
