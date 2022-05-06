import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-layout',
  template: `<div class="wrapper">
    <app-header></app-header>
    <app-sidebar></app-sidebar>
    <div class="container-fluid">
      <router-outlet></router-outlet>
    </div>
    <app-footer></app-footer>
  </div>`,
})
export class LayoutComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
