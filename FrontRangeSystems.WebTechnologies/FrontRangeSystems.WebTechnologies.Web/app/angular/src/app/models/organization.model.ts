import {Person} from "app/models/person.model"

export class Organization {
    organizationId: number;
    name: string;
    members: Person[];
}
