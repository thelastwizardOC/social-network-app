import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { IPost } from 'src/app/interface/post';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-newsfeed-container',
  templateUrl: './newsfeed-container.component.html',
  styleUrls: ['./newsfeed-container.component.scss']
})
export class NewsfeedContainerComponent implements OnInit {
  posts: IPost[] = [];
  isLoading: boolean = false;
  hasNextPage: boolean = false;
  userId: number = 0;
  limit: number = 7;
  offset: number = 0;

  constructor(private postService: PostService, private jwtHelper: JwtHelperService) {}

  ngOnInit(): void {
    this.userId = +this.jwtHelper.decodeToken(localStorage.getItem('jwt') as string).sub;
    this.fetchPosts();
  }

  handleReloadPage() {
    this.posts = [];
    this.offset = 0;
    this.fetchPosts();
  }
  fetchPosts(): void {
    this.isLoading = true;
    this.postService.getNewsfeedPost(this.userId, this.offset, this.limit).subscribe({
      next: value => {
        console.log(value);
        this.posts = [...this.posts, ...value.items];
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

  handleOnScroll() {
    if (this.hasNextPage) {
      this.fetchPosts();
    }
  }
}
