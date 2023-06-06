import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { CreateAuthorComponent } from 'src/app/components/create-author/create-author.component';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [CreateAuthorComponent],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatIconModule,
  ],
  exports: [CreateAuthorComponent],
})
export class CreateAuthorModule {}
