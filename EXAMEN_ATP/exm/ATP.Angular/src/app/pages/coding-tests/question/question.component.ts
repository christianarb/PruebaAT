import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-question',
  template: `<router-outlet></router-outlet>`,
})
export class QuestionComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
