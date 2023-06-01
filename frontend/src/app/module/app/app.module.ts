import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from '../../components/app/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from '../app-routing/app-routing.module';
import { MenuModule } from '../menu/menu.module';
import { BookComponent } from '../../components/book/book.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateBookComponent } from 'src/app/components/create-book/create-book.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { AuthorComponent } from 'src/app/components/author/author.component';
import { CreateAuthorComponent } from 'src/app/components/create-author/create-author.component';
import { GenreComponent } from 'src/app/components/genre/genre.component';
import { CreateGenreComponent } from 'src/app/components/create-genre/create-genre.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    AuthorComponent,
    GenreComponent,
    CreateBookComponent,
    CreateAuthorComponent,
    CreateGenreComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MenuModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatProgressSpinnerModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
