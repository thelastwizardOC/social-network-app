import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TuiValidatorModule } from '@taiga-ui/cdk';
import {
  TuiButtonModule,
  TuiErrorModule,
  TuiGroupModule,
  TuiHintModule,
  TuiLabelModule,
  TuiLinkModule,
  TuiPrimitiveTextfieldModule,
  TuiTextfieldControllerModule
} from '@taiga-ui/core';
import {
  TuiCheckboxLabeledModule,
  TuiDataListWrapperModule,
  TuiFieldErrorPipeModule,
  TuiInputDateModule,
  TuiInputModule,
  TuiInputPasswordModule,
  TuiInputPhoneInternationalModule,
  TuiInputPhoneModule,
  TuiIslandModule,
  TuiRadioBlockModule,
  TuiRadioLabeledModule,
  TuiSelectModule
} from '@taiga-ui/kit';
import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { BrandLogoComponent } from './components/brand-logo/brand-logo.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

@NgModule({
  declarations: [AuthComponent, LoginComponent, BrandLogoComponent, RegisterComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    TuiIslandModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TuiButtonModule,
    TuiIslandModule,
    TuiInputModule,
    TuiErrorModule,
    TuiInputDateModule,
    TuiInputPasswordModule,
    TuiFieldErrorPipeModule,
    TuiSelectModule,
    TuiDataListWrapperModule,
    TuiInputPhoneModule,
    TuiGroupModule,
    TuiRadioBlockModule,
    TuiCheckboxLabeledModule,
    TuiLabelModule,
    TuiTextfieldControllerModule,
    TuiInputPhoneInternationalModule,
    TuiRadioLabeledModule,
    TuiLinkModule,
    TuiValidatorModule,
    TuiHintModule,
    TuiPrimitiveTextfieldModule
  ]
})
export class AuthModule {}
