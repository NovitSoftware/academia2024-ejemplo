import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteComponent } from './cliente.component';
import {  ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from '../auth/pages/login/login.component';

@NgModule({
  declarations: [
    ClienteComponent,
  ],
  imports: [
    CommonModule,
  ]
})
export class ClienteModule { }
