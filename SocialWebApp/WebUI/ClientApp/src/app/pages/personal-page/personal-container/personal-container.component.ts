import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IPersonalPost } from 'src/app/interface/personal-post';
import { IUser } from 'src/app/interface/user';
import { PersonalPostService } from 'src/app/services/personal-post.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-personal-container',
  templateUrl: './personal-container.component.html',
  styleUrls: ['./personal-container.component.scss'],
})
export class PersonalContainerComponent implements OnInit {
  userNotFound: boolean = false;
  userId: number = 0;
  personalPosts: IPersonalPost[] = [];
  userInfo: IUser | undefined;
  hasNextPage: boolean = false;
  activeItemIndex = 0;
  limit: number = 1;
  offset: number = 0;
  isLoading: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private personalPostService: PersonalPostService,
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
    this.personalPostService
      .getPersonalPost(this.userId, this.offset, this.limit)
      .subscribe({
        next: (value) => {
          this.personalPosts = [...this.personalPosts, ...value.items];
          console.log(this.personalPosts);

          this.hasNextPage = value.hasNextPage;
          this.isLoading = false;
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
        if (err.status == 404) {
          this.userNotFound = true;
        }
      },
    });
  }

  handleOnScroll() {
    if (this.hasNextPage) {
      this.offset += this.limit;
      this.fetchPosts();
    }
  }
}
