import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-upload-image-dialog',
  templateUrl: './upload-image-dialog.component.html',
  styleUrls: ['./upload-image-dialog.component.scss'],
})
export class UploadImageDialogComponent implements OnInit {
  @Input() observer: any;

  constructor(private userService: UserService) {}

  ngOnInit(): void {}

  file: any;
  imageURL: string = '';

  processFile(event: any) {
    this.file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(this.file);
    reader.onload = () => {
      this.imageURL = reader.result as string;
      console.log(this.imageURL);
    };
  }

  handleCloseDialog(observer: any) {
    observer.complete();
  }

  onSubmit() {
    this.userService.uploadAvatar(this.imageURL, 1).subscribe({});
  }
}
