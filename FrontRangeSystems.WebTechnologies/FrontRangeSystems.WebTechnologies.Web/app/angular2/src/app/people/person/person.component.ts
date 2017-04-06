import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';

import { PersonService } from "app/services/person.service";
import { OrganizationService } from "app/services/organization.service";
import { Person } from 'app/models/person.model';
import { Organization } from 'app/models/organization.model';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private router: Router,
    private builder: FormBuilder,
    private personService: PersonService,
    private organizationService: OrganizationService) {
  }

  private person: Person;
  private personForm: FormGroup;
  private id: number;
  private showModel: boolean;
  private organizations: Organization[];
  private selectedOrganization: Organization;

  ngOnInit() {
    this.route.params
      .map(params => params['id'])
      .do(id => this.id = +id)
      .subscribe(id => this.getPerson());

    this.organizationService.getAll().then(orgs => this.organizations = orgs);
  }
  getPerson() {
    const id = this.id;

    if (id <= 0) {
      return;
    }

    if (isNaN(id)) {
      this.person = <Person>{ firstName: '', lastName: '' };
      this.buildForm(this.person);
    }
    else {
      this.personService.get(id).then(item => this.buildForm(item));
    }
  }

  buildForm(data: Person): void {
    this.person = data;
    this.personForm = this.builder.group({
      firstName: [this.person.firstName, [
        Validators.required,
        Validators.minLength(this.validationData.firstName.min),
        Validators.maxLength(this.validationData.firstName.max)]
      ],
      lastName: [this.person.lastName, [
        Validators.required,
        Validators.minLength(this.validationData.lastName.min),
        Validators.maxLength(this.validationData.lastName.max)]
      ],
      organizationId:[this.person.organizationId]
    });

    this.personForm.valueChanges.subscribe(data => this.onValueChanged(data));

    // reset form validation error messages
    this.onValueChanged();
  }

  onValueChanged(data?: Person): void {
    if (!this.personForm) {
      return;
    }

    const form = this.personForm;
    for (const field in this.formErrors) {
      // clear previous error message (if any)
      this.formErrors[field] = '';
      const control = form.get(field);

      if (control && control.dirty && !control.valid) {
        const messages = this.validationMessages[field];
        for (const key in control.errors) {
          this.formErrors[field] += messages[key] + ' ';
        }
      }
    }
  }
  onSubmit() {
    this.person = this.personForm.value;
    if (isNaN(this.id)) {
      this.personService.create(this.person)
        .then(() => this.goBack());
    }
    else {
      this.person.personId = this.id;
      this.personService.update(this.person)
        .then(() => this.goBack());
    }
  }

  private goBack() {
    this.router.navigate(['people']);
  }

  toggleShowModel() {
    this.showModel = !this.showModel;
  }

  formErrors = {
    name: '',
    power: ''
  };

  validationData = {
    firstName: {
      display: 'First Name',
      min: 2,
      max: 25
    },
    lastName: {
      display: 'Last Name',
      min: 2,
      max: 50
    }
  };

  validationMessages = {
    firstName: {
      required: `${this.validationData.firstName.display} is required.`,
      minlength: `${this.validationData.firstName.display} must be at least ${this.validationData.firstName.min} characters long`,
      maxlength: `${this.validationData.firstName.display} cannot be more than ${this.validationData.firstName.max} characters long.`,
    },
    lastName: {
      required: `${this.validationData.lastName.display} is required.`,
      minlength: `${this.validationData.lastName.display} must be at least ${this.validationData.lastName.min} characters long`,
      maxlength: `${this.validationData.lastName.display} cannot be more than ${this.validationData.lastName.max} characters long.`,
    }
  };
}
