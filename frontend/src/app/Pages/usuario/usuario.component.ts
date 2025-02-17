import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FilterPipe } from '../../pipes/filter.pipe';
import { UsuarioModel } from '../../interfaces/usuario';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss'],
  standalone: true,
  imports: [CommonModule, FormsModule, FilterPipe],
})
export class UsuarioComponent implements OnInit {
  public filtroUsuario: string = '';
  private api_url: string = '';
  usuarios: UsuarioModel[] = [/* 
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
   */];

  constructor() { }

  ngOnInit() {
    this.obtenerUsuarios();
  }

  obtenerUsuarios() {
    fetch(`${this.api_url}`).then(res => {
      if (!res.ok) throw new Error('Error en la peticion');
      return res.json();
    }).then(data => {
      this.usuarios = data
    }).catch(err => {
      console.error('Error al obtener usuarios', err);
    })
  }

  editarUsuario(usuario: UsuarioModel) {
    fetch(`${this.api_url}`, { method: 'PUT', headers: { 'Content-Type': 'application/json', body: JSON.stringify(usuario) } }).then(res => {
      if (!res.ok) throw new Error('Error en la peticion');
      return res.json();
    }).then(data => {
      alert(data);
    }).catch(err => {
      console.error('Error al obtener usuarios', err);
    })
    /* console.log('Editando usuario:', usuario); */
  }

  eliminarUsuario(usuario: UsuarioModel) {
    fetch(`${this.api_url}/${usuario.id}`, { method: 'DELETE' }).then(res => {
      if (!res.ok) throw new Error('Error en la peticion');
      return res.json();
    }).then(data => {
      alert(data);
    }).catch(err => {
      console.error('Error al obtener usuarios', err);
    })
    /* console.log('Eliminando usuario:', usuario); */
  }
}
