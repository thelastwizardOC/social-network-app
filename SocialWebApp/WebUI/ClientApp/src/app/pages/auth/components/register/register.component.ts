import {ChangeDetectionStrategy, Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {TuiCountryIsoCode} from '@taiga-ui/i18n';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegisterComponent implements OnInit {
  gender = [{name: `Male`}, {name: `Female`}];

  readonly registerForm = new FormGroup({
    firstNameValue: new FormControl(``, [Validators.required, Validators.minLength(2), Validators.pattern('[a-zA-Z ]')]),
    lastNameValue: new FormControl(``, Validators.required),
    userNameValue: new FormControl(``, Validators.required),
    passwordValue: new FormControl(``, Validators.required),
    emailValue: new FormControl(``, Validators.email),
    phoneValue: new FormControl(``, Validators.minLength(12)),
    genderValue: new FormControl(this.gender[0]),
    conditionValue: new FormControl(false)
  });
  countries: TuiCountryIsoCode[] = Object.values(TuiCountryIsoCode);

  countryIsoCode = TuiCountryIsoCode.VN;

  constructor() {
  }

  ngOnInit(): void {
  }
}
