import { Component, Input, OnInit } from '@angular/core';
import { IUserCommented } from '../../../../../interface/user';
import { environment } from '../../../../../../environments/environment';

@Component({
  selector: 'app-community-comments',
  templateUrl: './community-comments.component.html',
  styleUrls: ['./community-comments.component.scss']
})
export class CommunityCommentsComponent implements OnInit {
  @Input() userCommentList!: IUserCommented[];
  expanded: boolean = false;
  mockImg: string = environment.mockImg;

  constructor() {}

  ngOnInit(): void {}

  onToggleViewMore() {
    this.expanded = !this.expanded;
  }

  handleParseDate(date: string): Date {
    return new Date(date);
  }
}
