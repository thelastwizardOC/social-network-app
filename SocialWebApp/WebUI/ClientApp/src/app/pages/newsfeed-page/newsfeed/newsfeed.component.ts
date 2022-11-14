import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TuiEditorTool } from '@taiga-ui/addon-editor';
import { IPost } from 'src/app/interface/personal-post';

@Component({
  selector: 'app-newsfeed',
  templateUrl: './newsfeed.component.html',
  styleUrls: ['./newsfeed.component.scss'],
})
export class NewsfeedComponent implements OnInit {
  @Input() posts: IPost[] = [];
  @Input() isLoading: boolean = false;
  @Output() onScroll = new EventEmitter();
  constructor() {}

  ngOnInit(): void {}
}
