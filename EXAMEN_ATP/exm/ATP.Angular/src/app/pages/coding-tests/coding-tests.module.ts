import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CodingTestsRoutingModule } from './coding-tests-routing.module';
import { CodingTestsComponent } from './coding-tests.component';


@NgModule({
  declarations: [
    CodingTestsComponent
  ],
  imports: [
    CommonModule,
    CodingTestsRoutingModule
  ]
})
export class CodingTestsModule { }
