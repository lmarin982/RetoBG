import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FilterPipe } from '../../pipes/filter.pipe';
import { Cliente } from '../../interfaces/cliente';
import { api_url } from '../../Configs/ApiUrl';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss'],
  imports: [CommonModule, FormsModule, FilterPipe],
})
export class ClientesComponent implements OnInit {
  public filtroCliente: string = '';

  constructor() { }
  clientes: Cliente[] = [/* 
    {
      id: 1,
      nombre: 'Juan',
      apellido: 'Pérez',
      correo: 'juan.perez@example.com',
      cedula: '1234567890',
    },
    {
      id: 2,
      nombre: 'María',
      apellido: 'Gómez',
      correo: 'maria.gomez@example.com',
      cedula: '0987654321',
    },
    {
      id: 3,
      nombre: 'Carlos',
      apellido: 'López',
      correo: 'carlos.lopez@example.com',
      cedula: '1122334455',
    },
   */];
  ngOnInit() {
    this.ObtenerClientes();
  }

  ObtenerClientes() {
    fetch(`${api_url.cliente}`).then(res => {
      if (!res.ok) throw new Error('Error en la peticion');
      return res.json();
    }).then(data => {
      this.clientes = data
    }).catch(err => {
      console.error('Error al obtener usuarios', err);
    })
  }

  editarCliente(cliente: any) {
    fetch(`${api_url.cliente}`, { method: 'PUT', headers: { 'Content-Type': 'application/json', body: JSON.stringify(cliente) } }).then(res => {
      if (!res.ok) throw new Error('Error en la peticion');
      return res.json();
    }).then(data => {
      alert(data);
    }).catch(err => {
      console.error('Error al obtener usuarios', err);
    })
    /* console.log('Editando venta:', venta); */
  }

  eliminarCliente(cliente: any) {
    fetch(`${api_url.cliente}/${cliente.id}`, { method: 'DELETE' }).then(res => {
      if (!res.ok) throw new Error('Error en la peticion');
      return res.json();
    }).then(data => {
      alert(data);
    }).catch(err => {
      console.error('Error al obtener usuarios', err);
    })
    /* console.log('Eliminando venta:', venta); */
  }
}
