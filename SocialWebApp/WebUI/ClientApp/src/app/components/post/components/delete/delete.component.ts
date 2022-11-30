import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { TuiDialogService } from '@taiga-ui/core';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.scss']
})
export class DeleteComponent {
  dropdownOpen = false;
  @Output() handlePostDeleted = new EventEmitter();

  constructor(@Inject(TuiDialogService) private readonly dialogService: TuiDialogService) {}

  deletePost(): void {
    this.dialogService
      .open(`Are you sure you want to delete this post?`, {
        dismissible: true,
        label: 'Delete the post'
      })
      .subscribe({
        complete: () => {
          this.handlePostDeleted.emit();
          this.dropdownOpen = false;
        }
      });
  }
}
