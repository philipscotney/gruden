import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { PersonService } from "../person.service";
import { Person } from '../models/person';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  form: FormGroup = new FormGroup({
    name: new FormControl(''),

  });
  submitted = false;

  constructor(private formBuilder: FormBuilder,
    private personService: PersonService) { }

  person = new Person();
  namePattern = '^[a-zA-Z ]+$';
  message = false;
  nameResponse = "";
  ngOnInit(): void {
   

    this.form = this.formBuilder.group(
      {
        name: [
          '',
          [
            Validators.required            
          ]
        ]
      }
    );

    this.f['name'].valueChanges.subscribe(selectedValue => {
      this.message = false;

      if (this.person.id != 0) {
        this.person.id = 0
      }
    })
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }
   

  onSubmit(): void {
    this.person.name = this.f['name'].value;
    this.submitted = true;
    
    if (this.form.invalid) {
      return;
    }

    this.personService.sendName(this.person)
      .subscribe(data => {
        this.person = data
        this.message = true;
        this.nameResponse = this.person.name;
        
      })      
  }
}
