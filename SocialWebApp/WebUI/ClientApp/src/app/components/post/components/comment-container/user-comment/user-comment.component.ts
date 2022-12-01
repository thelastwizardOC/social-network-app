import { Component, Input, OnInit } from '@angular/core';
import { IUser } from '../../../../../interface/user';
import {AbstractControl, FormControl, Validators} from '@angular/forms';
import { environment } from '../../../../../../environments/environment';
import { TuiSizeM, TuiSizeS } from '@taiga-ui/core';

@Component({
  selector: 'app-user-comment',
  templateUrl: './user-comment.component.html',
  styleUrls: ['./user-comment.component.scss']
})
export class UserCommentComponent implements OnInit {
  @Input() userInfo!: IUser;
  mockImage: string = environment.mockImg;
  size: TuiSizeM | TuiSizeS = `m`;
  commentValue = new FormControl(``, [commentValidator]);

  constructor() {}

  ngOnInit(): void {}

  onPressEnter() {
    if(this.commentValue.value?.trim() === ""){
      this.commentValue.setErrors({other:"Comment has no value"})
    }
    console.log('Comment', this.commentValue.value);
  }
}

export function commentValidator(field: AbstractControl): Validators | null {
  if (!field.value) return null;
  if (field.value.split(' ').length > 100) return { other: `The maximum length of your comment is 100 words. Please try again.` };
  return null;
}
