import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';

import { Organization } from "app/models/organization.model";
import { OrganizationService } from "app/services/organization.service";

@Component({
    selector: 'app-organization',
    templateUrl: './organization.component.html',
    styleUrls: ['./organization.component.css']
})
export class OrganizationComponent implements OnInit {

    constructor(private route: ActivatedRoute,
        private router: Router,
        private builder: FormBuilder,
        private organizationService: OrganizationService) {
    }

    private organization: Organization;
    private organizationForm: FormGroup;
    private id: number;
    private showModel: boolean;

    ngOnInit() {
        this.route.params
            .map(params => params['id'])
            .do(id => this.id = +id)
            .subscribe(id => this.getOrganization());
    }

    getOrganization() {
        const id = this.id;

        if (id <= 0) {
            return;
        }

        if (isNaN(id)) {
            this.organization = <Organization>{ name: '' };
            this.buildForm(this.organization);
        }
        else {
            this.organizationService.get(id).then(o => this.buildForm(o));
        }
    }

    buildForm(data: Organization): void {
        this.organization = data;
        this.organizationForm = this.builder.group({
            name: [this.organization.name, [
                Validators.required,
                Validators.minLength(2),
                Validators.maxLength(50)]
            ]
        });

        this.organizationForm.valueChanges.subscribe(data => this.onValueChanged(data));

        // reset form validation error messages
        this.onValueChanged();
    }

    onValueChanged(data?: any) {
        if (!this.organizationForm) {
            return;
        }

        const form = this.organizationForm;
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
        this.organization = this.organizationForm.value;
        if (isNaN(this.id)) {
            this.organizationService.create(this.organization)
                .then(() => this.goBack());
        }
        else {
            this.organization.organizationId = this.id;
            this.organizationService.update(this.organization)
                .then(() => this.goBack());
        }
    }

    private goBack() {
        this.router.navigate(['organizations']);
    }

    toggleShowModel() {
        this.showModel = !this.showModel;
    }

    formErrors = {
        name: '',
        power: ''
    };

    validationMessages = {
        name: {
            required: 'Name is required.',
            minlength: 'Name must be at least 2 characters long',
            maxlength: 'Name cannot be more than 50 characters long.',
        }
    };
}
