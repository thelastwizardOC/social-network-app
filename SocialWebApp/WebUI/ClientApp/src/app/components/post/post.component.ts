import { Component, ElementRef, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { IPost, IPostResponse } from 'src/app/interface/post';
import { environment } from 'src/environments/environment';
import { PostService } from '../../services/post.service';
import { NotificationService } from '../../services/notification.service';
import { GlobalErrorHandler } from '../../services/error-handler.service';
import { HttpErrorResponse } from '@angular/common/http';
import { CurrentPostService } from './current-post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnChanges, OnInit {
  @ViewChild('postStatusRef')
  postStatusRef!: ElementRef;
  @Input() userId!: number;
  @Input() post!: IPost;
  @Output() onLike = new EventEmitter<number>();
  @Output() onDeletePost = new EventEmitter();
  mockImg: string = environment.mockImg;
  hasSeeMore: boolean = false;
  isLiked: boolean = false;
  postImages: string[] = [];
  expanded = false;

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.hasOwnProperty('post')) {
      if (changes['post'].firstChange) {
        this.hasSeeMore = this.post.status?.length! > 250;
        this.isLiked = this.post.postLikes.some(p => this.userId === p.userId);
      }
    }
  }
  constructor(
    private postService: PostService,
    private notification: NotificationService,
    private errorHandler: GlobalErrorHandler,
    private currentPostService: CurrentPostService
  ) {}

  ngOnInit(): void {
    if (this.post.photos) {
      this.post.photos.forEach(p => {
        this.postImages.push(p.photo);
      });
    }
  }

  onSeeMore(): void {
    this.hasSeeMore = false;
    this.postStatusRef.nativeElement.style.setProperty('--line-to-show', 0);
  }

  handlePostDeleted() {
    this.postService.deletePost(this.post.id, this.userId).subscribe({
      next: value => {
        this.notification.showSuccess('Delete post successfully');
        this.onDeletePost.emit();
      },
      error: (error: HttpErrorResponse) => {
        this.errorHandler.handleError(error);
      }
    });
  }

  toggleCommentExpand(): void {
    this.expanded = !this.expanded;
  }

  onRefreshPost() {
    this.post = this.currentPostService.getCurrentPost();
  }
}
