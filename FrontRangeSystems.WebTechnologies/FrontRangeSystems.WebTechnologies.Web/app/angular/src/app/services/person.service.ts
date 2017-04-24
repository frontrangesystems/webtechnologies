import { Injectable } from '@angular/core';
import { Headers, Http } from "@angular/http"
import { Person } from "app/models/person.model";

import 'rxjs/add/operator/toPromise';

@Injectable()
export class PersonService {

  constructor(private http: Http) { }

  private url = 'api/person';

      public getAll(): Promise<Person[]> {

        return this.http.get(this.url)
            .toPromise()
            .then(response => response.json() as Person[])
            .catch(this.handleError);
    }

    public get(id: number): Promise<Person> {
        return this.http.get(`${this.url}/${id}`)
            .toPromise()
            .then(response => response.json() as Person)
            .catch(this.handleError);
    }

    public create(model: Person): Promise<Person> {
        return this.http.post(this.url, model)
            .toPromise()
            .then(response => response.json() as Person)
            .catch(this.handleError);
    }

    public update(model: Person): Promise<Person> {
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
