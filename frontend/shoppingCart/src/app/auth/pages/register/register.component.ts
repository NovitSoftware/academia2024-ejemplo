import { Component, effect, inject, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../auth.service';
import { UserRegister } from '../../interface';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  private authService = inject(AuthService);

  selectedValue!: string;
  selectedCar!: string;
  roles: string[] = ['administrador', 'comerciante', 'cliente', 'vendedor'];

  registerForm!: FormGroup;
  usuarioCreado!: UserRegister;

  constructor(private fb: FormBuilder) {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      role: ['', Validators.required],
    });
  }

  register() {
    const { username, password, role } = this.registerForm.value;

    // const user = this.registerForm.value as UserRegister

    const newUser: UserRegister = {
      username: username,
      password: password,
      role: role,
    };

    this.authService.register(newUser).subscribe({
      next: (userCreado) => {
        this.usuarioCreado = userCreado;
        this.registerForm.reset();
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
