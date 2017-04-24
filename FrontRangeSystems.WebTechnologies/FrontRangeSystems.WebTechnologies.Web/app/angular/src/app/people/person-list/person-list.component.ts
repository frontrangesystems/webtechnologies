import { Component, OnInit } from '@angular/core';
import { PersonService } from "app/services/person.service";
import { Person } from 'app/models/person.model';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})

export class PersonListComponent implements OnInit {

  constructor(private personService: PersonService) { }

  public data: Person[];
  public showModel: boolean;

  ngOnInit() {
    this.personService.getAll().then(response => this.data = response);
  }

  toggleShowModel() {
    this.showModel = !this.showModel;
  }

  delete(item: Person) {
    if (confirm(`Are you sure you want to delte the person '${item.firstName} ${item.lastName}'?`)) {
      this.personService.delete(item.personId)
        .then(() => this.removeFromList(item))
    }
  }

  removeFromList(item: Person) {
    var index = this.data.indexOf(item);
    if (index >= 0) {
      this.data.splice(index, 1);
    }
  }
}
