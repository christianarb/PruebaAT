import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  items: MenuItem[] = [];
  constructor() {}

  ngOnInit(): void {
    this.items = [
      {
        icon: 'pi pi-fw pi-question',
        label: 'Question',
        items:[
          {
            icon: 'pi pi-fw pi-code',
            label: 'Question One',
            routerLink: 'dev/coding-tests/question/question-one',
          },
          {
            icon: 'pi pi-fw pi-code',
            label: 'Question Two',
            routerLink: 'dev/coding-tests/question/question-two',
          },
        ]
      }
    ];
  }
}
