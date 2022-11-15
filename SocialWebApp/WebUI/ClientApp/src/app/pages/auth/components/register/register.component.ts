import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TuiCountryIsoCode } from '@taiga-ui/i18n';
import { tuiInputPasswordOptionsProvider } from '@taiga-ui/kit';
import { emailValidator, nameValidator, passwordValidator, phoneValidator, userNameValidator } from '../../validators/register-validator';
import { AuthService } from '../../../../services/auth.service';
import { Router } from '@angular/router';
import { IRegisterUser } from '../../../../interface/registerd-user';
import { Gender, IUser } from '../../../../interface/user';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../../../../services/notification.service';
import { GlobalErrorHandler } from '../../../../services/error-handler.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    tuiInputPasswordOptionsProvider({
      icons: {
        hide: `tuiIconEyeOpen`,
        show: `tuiIconEyeClosed`
      }
    })
  ]
})
export class RegisterComponent implements OnInit {
  gender = [{ name: Gender.male }, { name: Gender.female }, { name: Gender.other }];
  countries: TuiCountryIsoCode[] = Object.values(TuiCountryIsoCode);
  countryIsoCode = TuiCountryIsoCode.VN;
  isSendingData: boolean = false;

  readonly registerForm = new FormGroup({
    firstNameValue: new FormControl(``, nameValidator('First name')),
    lastNameValue: new FormControl(``, nameValidator('Last name')),
    userNameValue: new FormControl(``, userNameValidator),
    passwordValue: new FormControl(``, passwordValidator),
    emailValue: new FormControl(``, emailValidator),
    phoneValue: new FormControl(``, phoneValidator),
    genderValue: new FormControl(this.gender[0]),
    conditionValue: new FormControl(true, Validators.requiredTrue)
  });

  constructor(
    private authService: AuthService,
    private route: Router,
    private notification: NotificationService,
    private errorHandler: GlobalErrorHandler
  ) {}

  ngOnInit() {}

  onRegisterFormSubmitted() {
    this.isSendingData = true;
    this.authService.register(this.handleParsingData()).subscribe({
      next: (response: IUser) => {
        const token = response.token;
        if (typeof token === 'string') {
          localStorage.setItem('jwt', token);
        }
        this.notification.showSuccess('Register successfully');
        this.route.navigate(['auth/login']);
      },
      error: (err: HttpErrorResponse) => {
        this.isSendingData = false;
        this.errorHandler.handleError(err);
      }
    });
  }

  handleParsingData(): IRegisterUser {
    const genderRecord = this.registerForm.value.genderValue?.name;
    let gender = genderRecord === Gender.male ? 0 : genderRecord === Gender.female ? 1 : 2;

    return {
      firstName: this.registerForm.value.firstNameValue as string,
      lastName: this.registerForm.value.lastNameValue as string,
      userName: this.registerForm.value.userNameValue as string,
      password: this.registerForm.value.passwordValue as string,
      dob: new Date().toISOString(),
      email: this.registerForm.value.emailValue + '@gmail.com',
      phoneNo: this.registerForm.value.phoneValue as string,
      createdAt: new Date().toISOString(),
      gender
    };
  }
}
