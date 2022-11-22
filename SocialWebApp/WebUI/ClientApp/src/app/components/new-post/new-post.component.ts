import {ChangeDetectionStrategy, Component, Inject, OnInit, ViewEncapsulation} from '@angular/core';
import {TuiDialogService} from "@taiga-ui/core";

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.scss'],
  encapsulation:ViewEncapsulation.None,
  changeDetection:ChangeDetectionStrategy.OnPush
})
export class NewPostComponent implements OnInit {
  isDialogOpened: boolean = false;

  constructor(@Inject(TuiDialogService) private readonly dialogService: TuiDialogService) { }

  ngOnInit(): void {
  }

  showPostDialog(){
    this.isDialogOpened = true;
  }

}
