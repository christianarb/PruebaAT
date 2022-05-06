import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { TreeTableModule } from 'primeng/treetable';
import { TableModule } from 'primeng/table';
import { SplitterModule } from 'primeng/splitter';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { ToastModule } from 'primeng/toast';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import {MessageService} from 'primeng/api';


import { QuestionRoutingModule } from './question-routing.module';
import { QuestionComponent } from './question.component';
import { QuestionOneComponent } from './pages/question-one/question-one.component';
import { QuestionTwoComponent } from './pages/question-two/question-two.component';
import { QuestionService } from './services/question.service';

@NgModule({
  declarations: [QuestionComponent, QuestionOneComponent, QuestionTwoComponent],
  imports: [
    CommonModule,
    QuestionRoutingModule,
    CardModule,
    ButtonModule,
    TreeTableModule,
    TableModule,
    SplitterModule,
    InputTextModule,
    DropdownModule,
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    MessagesModule,
    MessageModule,
  ],
  providers: [QuestionService, MessageService],
})
export class QuestionModule {}
