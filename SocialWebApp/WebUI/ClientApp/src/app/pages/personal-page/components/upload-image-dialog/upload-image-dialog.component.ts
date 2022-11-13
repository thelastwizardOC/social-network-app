import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TuiFileLike } from '@taiga-ui/kit';
import { finalize, map, Observable, of, Subject, switchMap, timer } from 'rxjs';

@Component({
  selector: 'app-upload-image-dialog',
  templateUrl: './upload-image-dialog.component.html',
  styleUrls: ['./upload-image-dialog.component.scss'],
})
export class UploadImageDialogComponent implements OnInit {
  @Input() observer: any;

  constructor() {}

  ngOnInit(): void {}

  imageURL: string = '';

  processFile(event: any) {
    const file: File = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.imageURL = reader.result as string;
    };
  }

  handleCloseDialog(observer: any) {
    observer.complete();
  }
}
