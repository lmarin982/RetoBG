import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FilterPipe } from '../../pipes/filter.pipe';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss'],
  standalone: true,
  imports: [CommonModule, FormsModule, FilterPipe],
})
export class UsuarioComponent implements OnInit {
  public filtroUsuario: string = '';
  constructor() {}

  usuarios = [
    {
      id: 1,
      username: 'user1',
      password: 'pass1',
      rol: 'admin',
    },
    {
      id: 2,
      username: 'user2',
      password: 'pass2',
      rol: 'user',
    },
    {
      id: 3,
      username: 'user3',
      password: null,
      rol: 'guest',
    },
  ];

  ngOnInit() {}

  editarUsuario(usuario: any) {
    console.log('Editando usuario:', usuario);
  }

  eliminarUsuario(usuario: any) {
    console.log('Eliminando usuario:', usuario);
  }
}
