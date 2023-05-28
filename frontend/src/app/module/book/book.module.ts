import { NgModule } from '@angular/core';
import { AppRoutingModule } from '../app-routing/app-routing.module';
import { BookComponent } from '../../components/book/book.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [BookComponent],
  imports: [AppRoutingModule],
  exports: [BookComponent],
})
export class BookModule {}
