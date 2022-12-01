import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IUser } from '../../../../../interface/user';
import { AbstractControl, FormControl, Validators } from '@angular/forms';
import { environment } from '../../../../../../environments/environment';
import { TuiSizeM, TuiSizeS } from '@taiga-ui/core';
import { PostService } from '../../../../../services/post.service';
import { GlobalErrorHandler } from '../../../../../services/error-handler.service';
import { IPost } from '../../../../../interface/post';
import { CurrentPostService } from '../../../current-post.service';

@Component({
  selector: 'app-user-comment',
  templateUrl: './user-comment.component.html',
  styleUrls: ['./user-comment.component.scss']
})
export class UserCommentComponent implements OnInit {
  @Input() userInfo!: IUser;
  @Input() postId!: number;
  @Output() onRefreshPost = new EventEmitter();
  mockImage: string = environment.mockImg;
  size: TuiSizeM | TuiSizeS = `m`;
  commentValue = new FormControl(``, [commentValidator]);
  isSent: boolean = false;

  constructor(private postService: PostService, private currentPostService: CurrentPostService, private errorHandler: GlobalErrorHandler) {}

  ngOnInit(): void {}

  onPostComment() {
    const commentText: string | null = this.commentValue.value;
    this.isSent = true;
    if (commentText?.trim() === '') {
      this.commentValue.setErrors({ other: 'Comment has no value' });
      return;
    }
    this.postService.commentPost(this.postId, this.userInfo.id, commentText! || '.').subscribe({
      next: value => {
        this.commentValue.setValue('');
        this.currentPostService.updatePost(value);
        this.isSent = false;
        this.onRefreshPost.emit();
      },
      error: err => {
        this.errorHandler.handleError(err);
        this.isSent = false;
      }
    });
  }
}

export function commentValidator(field: AbstractControl): Validators | null {
  if (!field.value) return null;
  if (field.value.split(' ').length > 100) return { other: `The maximum length of your comment is 100 words. Please try again.` };
  return null;
}
