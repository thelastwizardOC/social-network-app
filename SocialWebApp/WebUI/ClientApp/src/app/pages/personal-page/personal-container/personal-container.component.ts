import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IPost } from 'src/app/interface/personal-post';
import { IUser } from 'src/app/interface/user';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-personal-container',
  templateUrl: './personal-container.component.html',
  styleUrls: ['./personal-container.component.scss'],
})
export class PersonalContainerComponent implements OnInit {
  userNotFound: boolean = false;
  hasNextPage: boolean = false;
  isLoading: boolean = false;
  activeItemIndex: number = 0;
  userId: number = 0;
  limit: number = 1;
  offset: number = 0;

  personalPosts: IPost[] = [];
  userInfo: IUser | undefined;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private postService: PostService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe({
      next: ({ id }) => {
        this.userId = id;
        this.fetchPosts();
        this.fetchUserInfo();
      },
    });
  }

  fetchPosts(): void {
    this.isLoading = true;
    this.postService
      .getPersonalPost(this.userId, this.offset, this.limit)
      .subscribe({
        next: (value) => {
          this.personalPosts = [...this.personalPosts, ...value.items];
          this.hasNextPage = value.hasNextPage;
          this.isLoading = false;
          this.offset += this.limit;
        },
        error: (error) => {
          console.log({ error });
          this.isLoading = false;
        },
      });
  }
  fetchUserInfo(): void {
    this.userService.getUserInfo(this.userId).subscribe({
      next: (value) => {
        this.userInfo = value;
      },
      error: (err: HttpErrorResponse) => {
        this.userNotFound = true;
        this.router.navigate(['/error']);
      },
    });
  }

  handleOnScroll() {
    if (this.hasNextPage) {
      this.fetchPosts();
    }
  }
}
