import { MatIconModule } from '@angular/material/icon';
import { NgModule } from '@angular/core';
import { AuthorComponent } from 'src/app/components/author/author.component';
import { AppRoutingModule } from '../app-routing/app-routing.module';

@NgModule({
  declarations: [AuthorComponent],
  imports: [AppRoutingModule, MatIconModule],
  exports: [AuthorComponent],
})
export class AuthorModule {}
