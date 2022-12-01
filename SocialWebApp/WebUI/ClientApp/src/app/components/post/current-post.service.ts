import { Injectable } from '@angular/core';
import { IPost } from '../../interface/post';

@Injectable({
  providedIn: 'root'
})
export class CurrentPostService {
  post!: IPost;

  constructor() {}

  updatePost(updatedPost: IPost) {
    this.post = updatedPost;
  }

  getCurrentPost() {
    return this.post;
  }
}
