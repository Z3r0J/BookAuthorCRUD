import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MenuComponent } from '../../components/menu/menu.component';
import { AppRoutingModule } from '../app-routing/app-routing.module';

@NgModule({
  declarations: [MenuComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    AppRoutingModule,
    MatIconModule,
  ],
  bootstrap: [MenuComponent],
  exports: [MenuComponent],
})
export class MenuModule {}
