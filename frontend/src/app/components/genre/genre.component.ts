import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { CreateGenreComponent } from '../create-genre/create-genre.component';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css'],
})
export class GenreComponent implements OnInit {
  constructor(public dialog: MatDialog) {}

  openDialog = () =>
    this.dialog.open(CreateGenreComponent, {
      width: '500px',
      data: {
        isEdit: false,
        id: undefined,
      },
    });

  openEditDialog = (id: string) =>
    this.dialog.open(CreateGenreComponent, {
      width: '500px',
      data: {
        isEdit: true,
        id: id,
      },
    });

  ngOnInit(): void {}
}
