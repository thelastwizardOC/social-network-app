import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import * as _ from 'lodash';
import { IPost, LikeStatus } from 'src/app/interface/post';
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
    this.handleUpdatePostLike = _.debounce(this.handleUpdatePostLike, 500);
  }

  handlePostSucceeded() {
    this.posts = [];
    this.offset = 0;
    this.fetchPosts();
  }
  fetchPosts(): void {
    this.isLoading = true;
    this.postService.getNewsfeedPost(this.userId, this.offset, this.limit).subscribe({
      next: value => {
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

  handleToggleLikePost(postId: number) {
    let status: LikeStatus;
    const foundPost = { ...(this.posts.find(p => p.id === postId) as IPost) };
    const checkPostLiked = foundPost.postLikes.find(p => p.userId === this.userId);

    if (checkPostLiked) {
      status = LikeStatus.UNLIKE;
      foundPost.numberOfLikes--;
      foundPost.postLikes = foundPost.postLikes.filter(p => p.userId !== this.userId);
    } else {
      status = LikeStatus.LIKE;
      foundPost.numberOfLikes++;
      foundPost.postLikes = [...foundPost.postLikes, { postId: foundPost.id, userId: this.userId }];
    }

    this.posts = this.posts.map(post => {
      if (post.id === postId) {
        return foundPost!;
      }
      return post;
    });

    this.handleUpdatePostLike(postId, status);
  }
  handleUpdatePostLike(postId: number, status: LikeStatus): void {
    this.postService.likePost(postId, this.userId, status).subscribe({
      next: value => {
        console.log({ value });
      },
      error: err => {
        console.log({ err });
      }
    });
  }
}
