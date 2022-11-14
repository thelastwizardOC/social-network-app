import {
  Component,
  ElementRef,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { IPost } from 'src/app/interface/personal-post';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnChanges {
  @ViewChild('postStatus')
  postStatus!: ElementRef;
  @Input()
  post!: IPost;

  mockImg: string = environment.mockImg;
  hasSeeMore: boolean = false;

  onSeeMore(): void {
    this.hasSeeMore = false;
    this.postStatus.nativeElement.style.setProperty('--line-to-show', 0);
    console.log(this.hasSeeMore);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.hasOwnProperty('post')) {
      if (changes['post'].firstChange) {
        this.hasSeeMore = this.post.status.length > 250;
        console.log(this.hasSeeMore);
      }
    }
  }
  constructor() {}
}
