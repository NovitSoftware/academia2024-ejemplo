import { AfterContentChecked, AfterContentInit, AfterViewChecked, AfterViewInit, Component, DoCheck, OnChanges, OnDestroy, OnInit, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrl: './cliente.component.css'
})
export class ClienteComponent {

  title:string = 'Cliente Component'

  myForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.myForm = this.formBuilder.group({
      username: [''],
      password: ['']
    });
  }


  onSubmit():void{
    console.log(this.myForm.value);
  }

}
