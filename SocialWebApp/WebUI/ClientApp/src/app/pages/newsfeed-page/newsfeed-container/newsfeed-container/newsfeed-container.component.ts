import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IPost } from 'src/app/interface/personal-post';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-newsfeed-container',
  templateUrl: './newsfeed-container.component.html',
  styleUrls: ['./newsfeed-container.component.scss'],
})
export class NewsfeedContainerComponent implements OnInit {
  posts: IPost[] = [];
  isLoading: boolean = false;
  hasNextPage: boolean = false;
  userId: number = 0;
  limit: number = 3;
  offset: number = 0;
  constructor(
    private postService: PostService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe({
      next: ({ id }) => {
        this.userId = id;
        this.fetchPosts();
      },
    });
  }

  fetchPosts(): void {
    this.isLoading = true;
    this.postService
      .getNewsfeedPost(this.userId, this.offset, this.limit)
      .subscribe({
        next: (value) => {
          this.posts = [...this.posts, ...value.items];
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

  handleOnScroll() {
    if (this.hasNextPage) {
      this.fetchPosts();
    }
  }
}
