import {
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnChanges,
  Output,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { IPost } from 'src/app/interface/post';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnChanges {
  @ViewChild('postStatusRef')
  postStatusRef!: ElementRef;
  @Input()
  userId!: number;
  @Input()
  post!: IPost;
  @Output() onLike = new EventEmitter<number>();
  mockImg: string = environment.mockImg;
  hasSeeMore: boolean = false;
  isLiked: boolean = false;
  onSeeMore(): void {
    this.hasSeeMore = false;
    this.postStatusRef.nativeElement.style.setProperty('--line-to-show', 0);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.hasOwnProperty('post')) {
      if (changes['post'].firstChange) {
        this.hasSeeMore = this.post.status.length > 250;
        this.isLiked = this.post.postLikes.some(
          (p) => this.userId === p.userId
        );
      }
    }
  }
  constructor() {}
}
