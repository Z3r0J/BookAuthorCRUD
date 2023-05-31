import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateAuthorComponent } from '../create-author/create-author.component';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css'],
})
export class AuthorComponent implements OnInit {
  constructor(private dialog: MatDialog) {}

  openDialog = () =>
    this.dialog.open(CreateAuthorComponent, {
      width: '500px',
      data: { id: '', isEdit: false },
    });

  openEditDialog = (id: string) =>
    this.dialog.open(CreateAuthorComponent, {
      width: '500px',
      data: { id: id, isEdit: true },
    });

  ngOnInit(): void {
    this.dialog.afterAllClosed.subscribe(() => {
      console.log('The dialog was closed');
    });
  }
}
