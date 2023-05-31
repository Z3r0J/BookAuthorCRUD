import { IAuthorResponse } from './../../interfaces/Author/IAuthorResponse';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateAuthorComponent } from '../create-author/create-author.component';
import Swal from 'sweetalert2';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css'],
})
export class AuthorComponent implements OnInit {
  constructor(
    private dialog: MatDialog,
    private authorService: AuthorService
  ) {}

  authors: IAuthorResponse[] = [];

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

  openDeleteDialog = (id: string) =>
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this author!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it',
    }).then((result) => {
      if (result.isConfirmed) {
        this.authorService
          .delete(id)
          .then(() => {
            Swal.fire(
              'Deleted!',
              'The author was deleted successfully.',
              'success'
            );
            this.getData();
          })
          .catch(() => {
            Swal.fire('Error!', 'The author could not be deleted.', 'error');
          });
      }
    });

  getData = () =>
    this.authorService.getAll().then(
      (data) =>
        (this.authors = data.map((x) => {
          x.birthDate = new Date(x.birthDate);
          return x;
        }))
    );

  ngOnInit(): void {
    this.getData();
    this.dialog.afterAllClosed.subscribe(() => {
      this.getData();
    });
  }
}
