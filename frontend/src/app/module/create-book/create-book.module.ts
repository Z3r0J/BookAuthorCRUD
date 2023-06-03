import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { CreateBookComponent } from 'src/app/components/create-book/create-book.component';

@NgModule({
  declarations: [CreateBookComponent],
  imports: [BrowserModule, MatDialogModule],
  exports: [CreateBookComponent],
})
export class CreateBookModule {}
