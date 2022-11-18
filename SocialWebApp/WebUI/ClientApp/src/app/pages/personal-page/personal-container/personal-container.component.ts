import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TuiDialogContext, TuiDialogService } from '@taiga-ui/core';
import { PolymorpheusContent } from '@tinkoff/ng-polymorpheus';
import { IPost } from 'src/app/interface/post';
import { IUser } from 'src/app/interface/user';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/user.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-personal-container',
  templateUrl: './personal-container.component.html',
  styleUrls: ['./personal-container.component.scss']
})
export class PersonalContainerComponent implements OnInit {
  userNotFound: boolean = false;
  hasNextPage: boolean = false;
  isLoading: boolean = false;
  userId!: number;
  limit: number = 1;
  offset: number = 0;
  file!: File;
  avatar: any;

  personalPosts: IPost[] = [];
  userInfo: IUser | undefined;
  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private postService: PostService,
    private dialogService: TuiDialogService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe({
      next: ({ id }) => {
        this.userId = +id;
        this.fetchPosts();
        this.fetchUserInfo();
        this.handleLikePost = _.debounce(this.handleLikePost, 1000);
      }
    });
  }

  fetchPosts(): void {
    this.isLoading = true;

    this.postService.getPersonalPost(this.userId, this.offset, this.limit).subscribe({
      next: value => {
        this.personalPosts = [...this.personalPosts, ...value.items];
        this.hasNextPage = value.hasNextPage;
        this.offset += this.limit;
      },
      error: error => {
        console.log({ error });
      },
      complete: () => {
        this.isLoading = false;
      }
    });
  }

  fetchUserInfo(): void {
    this.userService.getUserInfo(this.userId).subscribe({
      next: value => {
        this.userInfo = value;
      },
      error: (err: HttpErrorResponse) => {
        this.userNotFound = true;
      }
    });
  }

  handleOnScroll() {
    if (this.hasNextPage) {
      this.fetchPosts();
    }
  }

  showDialog(content: PolymorpheusContent<TuiDialogContext>): void {
    this.dialogService.open(content).subscribe();
  }

  handlePhotoUploaded(event: any) {
    if (this.userInfo !== undefined) {
      if (event.uploadType === 'avatar') this.userInfo.avatar = event.$event.res;
      if (event.uploadType === 'cover') this.userInfo.cover = event.$event.res;
    }
  }
  handleLikePost(postId: number) {
    this.postService.likePost(postId, this.userId).subscribe({
      next: value => {
        this.personalPosts = this.personalPosts.map(post => {
          if (post.id === postId) {
            return value;
          }
          return post;
        });
      },
      error: err => {
        console.log({ err });
        // this.router.navigate(['/error']);
      }
    });
  }
}
