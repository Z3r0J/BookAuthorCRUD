import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { CreateGenreComponent } from '../create-genre/create-genre.component';
import { IGenreResponse } from 'src/app/interfaces/Genre/IGenreResponse';
import { GenreService } from 'src/app/services/genre.service';
import Swal from 'sweetalert2';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css'],
})
export class GenreComponent implements OnInit {
  constructor(public dialog: MatDialog, private genreService: GenreService) {}

  genres: IGenreResponse[] = [];
  timeout: any;
  searchForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
  });

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

  getGenres = () =>
    this.genreService.getAll().then((data) => (this.genres = data));

  openDeleteDialog = (id: string) =>
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this genre!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it',
    }).then((result) => {
      if (result.isConfirmed) {
        this.genreService.delete(id).then(() => {
          this.getGenres();
          Swal.fire({
            title: 'Deleted!',
            text: 'Genre was deleted successfully.',
            icon: 'success',
            timer: 1500,
            timerProgressBar: true,
            showConfirmButton: false,
          });
        });
      }
    });

  searchGenre = (value: string) => {
    clearTimeout(this.timeout);

    this.timeout = setTimeout(() => {
      this.genreService.getAll(value).then((data) => (this.genres = data));
    }, 3000);
  };

  ngOnInit(): void {
    window.document.title = 'Genre - Book App';

    this.searchForm.valueChanges.subscribe((values: any) => {
      this.searchGenre(values.name);
    });

    this.getGenres();

    this.dialog.afterAllClosed.subscribe(() => {
      this.getGenres();
    });
  }
}
