import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IPost } from 'src/app/interface/post';
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
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe({
      next: ({ id }) => {
        this.userId = +id;
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
          this.offset += this.limit;
        },
        error: (error) => {
          console.log({ error });
        },
        complete: () => {
          this.isLoading = false;
        },
      });
  }

  handleOnScroll() {
    if (this.hasNextPage) {
      this.fetchPosts();
    }
  }

  handleLikePost(postId: number) {
    this.postService.likePost(postId, this.userId).subscribe({
      next: (value) => {
        this.posts = this.posts.map((post) => {
          if (post.id === value.id) {
            return value;
          }
          return post;
        });
      },
      error: (err) => {
        console.log({ err });
        this.router.navigate(['/error']);
      },
    });
  }
}
