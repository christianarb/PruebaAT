import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {ButtonModule} from 'primeng/button';
import {MenubarModule} from 'primeng/menubar';
import {InputTextModule} from 'primeng/inputtext';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { LayoutComponent } from './layout/layout.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    LayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ButtonModule,
    MenubarModule,
    InputTextModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
