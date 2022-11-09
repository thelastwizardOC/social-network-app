import {ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {TuiCountryIsoCode} from '@taiga-ui/i18n';
import {
  emailValidator,
  nameValidator,
  passwordValidator,
  phoneValidator,
  userNameValidator
} from "../../validators/register-validator";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  encapsulation:ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class RegisterComponent implements OnInit {
  gender = [{name: `Male`}, {name: `Female`}];
  countries: TuiCountryIsoCode[] = Object.values(TuiCountryIsoCode);
  countryIsoCode = TuiCountryIsoCode.VN;
  readonly emailValidator = Validators.email;
  sendingState:boolean = false;


  readonly registerForm = new FormGroup({
    firstNameValue: new FormControl(``, nameValidator("First name")),
    lastNameValue: new FormControl(``, nameValidator("Last name")),
    userNameValue: new FormControl(``, userNameValidator),
    passwordValue: new FormControl(``, passwordValidator),
    emailValue: new FormControl(``, emailValidator),
    phoneValue: new FormControl(``, phoneValidator),
    genderValue: new FormControl(this.gender[0]),
    conditionValue: new FormControl(true, Validators.requiredTrue)
  });

  constructor() {
  }

 ngOnInit() {
 }

  onRegisterFormSubmitted(){
    this.sendingState = true;
    console.log(this.registerForm.value);
  }
}
