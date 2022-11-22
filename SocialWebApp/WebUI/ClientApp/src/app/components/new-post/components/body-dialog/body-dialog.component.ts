import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-body-dialog',
  templateUrl: './body-dialog.component.html',
  styleUrls: ['./body-dialog.component.scss'],
  encapsulation:ViewEncapsulation.None
})
export class BodyDialogComponent implements OnInit {
  value=""
  postForm = new FormGroup({
    postStatusValue:new FormControl(``,Validators.required )
  })
  constructor() { }

  ngOnInit(): void {
  }

  onPostSummited(){
    console.log(this.postForm.value)
  }

}
