import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TuiFileLike } from '@taiga-ui/kit';
import { finalize, map, Observable, of, Subject, switchMap, timer } from 'rxjs';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-upload-image-dialog',
  templateUrl: './upload-image-dialog.component.html',
  styleUrls: ['./upload-image-dialog.component.scss'],
})
export class UploadImageDialogComponent implements OnInit {
  @Input() observer: any;
  @Input() type!: 'avatar' | 'cover';
  @Output() onUploadAvatarSuccess = new EventEmitter();
  @Output() onUploadCoverSuccess = new EventEmitter();

  constructor(private userService: UserService) {}

  ngOnInit(): void {}

  imageURL: string | null = null;

  handleCloseDialog(observer: any) {
    observer.complete();
  }

  onSubmit(observer: any) {
    this.userService
      .uploadPhoto(this.imageURL as string, 2, this.type)
      .subscribe({
        next: (res) => {
          observer.complete();
          this.type === 'avatar' && this.onUploadAvatarSuccess.emit(res);
          this.type === 'cover' && this.onUploadCoverSuccess.emit(res);
        },
        error: (err) => {
          console.log(err);
        },
      });
  }

  control = new FormControl();
  rejectedFiles$ = new Subject<TuiFileLike | null>();
  loadingFiles$ = new Subject<TuiFileLike | null>();
  rejectedState: Boolean = false;
  loadedFiles$ = this.control.valueChanges.pipe(
    switchMap((file) => {
      return file ? this.makeRequest(file) : of(null);
    })
  );

  onReject(file: TuiFileLike | readonly TuiFileLike[]): void {
    this.rejectedState = true;
    this.rejectedFiles$.next(file as TuiFileLike);
  }

  removeFile(): void {
    this.rejectedState = false;
    this.imageURL = null;
    this.control.setValue(null);
  }

  clearRejected(): void {
    this.removeFile();
    this.rejectedFiles$.next(null);
  }

  makeRequest(file: TuiFileLike): Observable<TuiFileLike | null> {
    this.loadingFiles$.next(file);
    return timer(1000).pipe(
      map(() => {
        const reader = new FileReader();
        reader.readAsDataURL(file as File);
        reader.onload = () => {
          this.imageURL = reader.result as string;
        };
        return file;
      }),
      finalize(() => this.loadingFiles$.next(null))
    );
  }
}
