import { NgModule } from "@angular/core";
import { PreloadAllModules, Routes, RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { PageNotFoundComponent } from "./page-not-found/page-not-found.component";
import { OrganizationComponent } from "./organizations/organization/organization.component";
import { OrganizationListComponent } from "./organizations/organization-list/organization-list.component";
import { PersonComponent } from "./people/person/person.component";
import { PersonListComponent } from "./people/person-list/person-list.component";

const routes: Routes = [
    { path: "", pathMatch: "full", redirectTo: "dashboard" },
    { path: "dashboard", pathMatch: "full", component: DashboardComponent },
    { path: "person-list", pathMatch: "full", component: PersonListComponent },
    { path: "person/:id", pathMatch: "full", component: PersonComponent },
    { path: "organization-list", pathMatch: "full", component: OrganizationListComponent },
    { path: "organization/:id", pathMatch: "full", component: OrganizationComponent },
    { path: "**", pathMatch: "full", component: PageNotFoundComponent },
];

@NgModule({
    imports: [
        CommonModule, RouterModule.forRoot(routes)
    ],
    exports: [RouterModule],
    declarations: [],
    providers: []
})
export class AppRoutingModule {
}

export const routableComponents = [
    DashboardComponent,
    PageNotFoundComponent,
    OrganizationComponent,
    OrganizationListComponent,
    PersonComponent,
    PersonListComponent
];