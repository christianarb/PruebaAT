import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuestionOneComponent } from './pages/question-one/question-one.component';
import { QuestionTwoComponent } from './pages/question-two/question-two.component';
import { QuestionComponent } from './question.component';

const routes: Routes = [
  {
    path: '',
    component: QuestionComponent,
    children: [
      {
        path: 'question-one',
        component: QuestionOneComponent,
      },
      {
        path: 'question-two',
        component: QuestionTwoComponent,
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuestionRoutingModule { }
