import { Component, OnInit } from '@angular/core';
import { PersonService } from "app/services/person.service";

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
