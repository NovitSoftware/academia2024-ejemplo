import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserLogin } from './interface/user-login.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  private fb = inject(FormBuilder)
  private router = inject(Router);
  myForm!: FormGroup




  // constructor(private fb: FormBuilder) {

  //   this.myForm = new FormGroup({
  //     username: new FormControl('', []),
  //     password: new FormControl('', [])
  //   })
  // }
  ngOnInit(): void {
    this.myForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    })
  }


  login(){
    console.log(this.myForm.value);

    const newUsuario = this.myForm.value as UserLogin

    // result ok:
    this.router.navigateByUrl('productos')
    // this.router.navigate(['detalle', 1])

  }


}
