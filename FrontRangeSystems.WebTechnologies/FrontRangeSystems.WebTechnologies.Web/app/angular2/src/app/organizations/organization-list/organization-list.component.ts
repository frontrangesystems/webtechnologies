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

    ngOnInit() {
        this.organizationService.getAll().then(o => this.organizations = o);
    }

}
