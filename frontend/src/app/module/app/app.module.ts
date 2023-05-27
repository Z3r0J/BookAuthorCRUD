import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from '../../components/app/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from '../app-routing/app-routing.module';
import { MenuModule } from '../menu/menu.module';
import { BookComponent } from '../../components/book/book.component';
@NgModule({
  declarations: [AppComponent, BookComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MenuModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
