import { Inject, Injectable } from '@angular/core';
import { TuiAlertService, TuiNotification } from '@taiga-ui/core';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(
    @Inject(TuiAlertService) private readonly alert: TuiAlertService
  ) {}

  showSuccess(message: string): void {
    this.alert
      .open(message, {
        label: 'Success',
        status: TuiNotification.Success,
        autoClose: true,
      })
      .subscribe();
  }

  showError(message: string): void {
    this.alert
      .open(message, {
        label: 'Error',
        status: TuiNotification.Error,
        autoClose: false,
      })
      .subscribe();
  }

  showWarning(message: string): void {
    this.alert
      .open(message, {
        label: 'Warning',
        status: TuiNotification.Warning,
        autoClose: true,
      })
      .subscribe();
  }
}
