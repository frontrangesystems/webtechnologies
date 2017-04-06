import { Injectable } from '@angular/core';
import { Headers, Http } from "@angular/http"
import { Organization } from "app/models/organization.model";

import 'rxjs/add/operator/toPromise';

@Injectable()
export class OrganizationService {

    constructor(private http: Http) { }

    private url = "api/organization";

    public getAll(): Promise<Organization[]> {

        return this.http.get(this.url)
            .toPromise()
            .then(response => response.json() as Organization[])
            .catch(this.handleError);
    }

    public get(id: number): Promise<Organization> {
        return this.http.get(`${this.url}/${id}`)
            .toPromise()
            .then(response => response.json() as Organization)
            .catch(this.handleError);
    }

    public create(model: Organization): Promise<Organization> {
        return this.http.post(this.url, model)
            .toPromise()
            .then(response => response.json() as Organization)
            .catch(this.handleError);
    }

    public update(model: Organization): Promise<Organization> {
        return this.http.put(this.url, model)
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    }

    public delete(id: number): Promise<void> {
        return this.http.delete(`${this.url}/${id}`)
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

}
