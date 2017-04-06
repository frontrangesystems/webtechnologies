import { Component, OnInit } from '@angular/core';
import { PersonService } from "app/services/person.service";

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
