import { MatToolbar } from '@angular/material/toolbar';
import { Component } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
})
export class MenuComponent {
  title: string = 'Book App';
  menuList = [
    { name: 'Book', path: '/home', iconName: 'books' },
    { name: 'Author', path: '/author', iconName: 'supervisor_account' },
    { name: 'Genre', path: '/genre', iconName: 'list' },
  ];
}
