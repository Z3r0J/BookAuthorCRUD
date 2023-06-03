import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookComponent } from '../../components/book/book.component';
import { AuthorComponent } from 'src/app/components/author/author.component';
import { GenreComponent } from 'src/app/components/genre/genre.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  {
    path: 'home',
    component: BookComponent,
  },
  {
    path: 'author',
    component: AuthorComponent,
  },
  {
    path: 'genre',
    component: GenreComponent,
  },
  { path: '**', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
