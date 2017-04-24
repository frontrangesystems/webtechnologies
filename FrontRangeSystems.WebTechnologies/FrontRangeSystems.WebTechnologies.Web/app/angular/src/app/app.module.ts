import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { NavComponent } from './nav/nav.component';
import { DashboardComponent } from './dashboard/dashboard.component';

import { PersonListComponent } from './people/person-list/person-list.component';
import { PersonComponent } from './people/person/person.component';
import { OrganizationComponent } from './organizations/organization/organization.component';
import { OrganizationListComponent } from './organizations/organization-list/organization-list.component';

import { OrganizationService } from "app/services/organization.service"
import { PersonService } from "app/services/person.service"

@NgModule({
    declarations: [
        AppComponent,
        PersonListComponent,
        PersonComponent,
        DashboardComponent,
        OrganizationComponent,
        OrganizationListComponent,
        PageNotFoundComponent,
        NavComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        AppRoutingModule
    ],
    providers: [
        OrganizationService,
        PersonService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
