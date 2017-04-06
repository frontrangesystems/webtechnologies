import { Component, OnInit } from '@angular/core';
import { OrganizationService } from "app/services/organization.service";
import { Organization } from "app/models/organization.model";

@Component({
    selector: 'app-organization-list',
    templateUrl: './organization-list.component.html',
    styleUrls: ['./organization-list.component.css']
})

export class OrganizationListComponent implements OnInit {
    organizations: Organization[];

    constructor(private organizationService: OrganizationService) { }

    public showModel: boolean = false;

    ngOnInit() {
        this.organizationService.getAll().then(o => this.organizations = o);
    }

    delete(org: Organization) {
        if (confirm(`Are you sure you want to delte the organization '${org.name}'?`)) {
            this.organizationService.delete(org.organizationId)
                .then(() => this.removeFromList(org))
        }
    }

    toggleShowModel() {
        this.showModel = !this.showModel;
    }

    removeFromList(org: Organization) {
        var index = this.organizations.indexOf(org);
        if (index >= 0) {
            this.organizations.splice(index, 1);
        }
    }
}
