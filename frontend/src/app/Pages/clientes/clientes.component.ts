import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FilterPipe } from '../../pipes/filter.pipe';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss'],
  imports: [CommonModule, FormsModule, FilterPipe],
})
export class ClientesComponent implements OnInit {
  public filtroCliente: string = '';
  constructor() {}
  clientes = [
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
  ];
  ngOnInit() {}

  editarCliente(venta: any) {
    console.log('Editando venta:', venta);
  }

  eliminarCliente(venta: any) {
    console.log('Eliminando venta:', venta);
  }
}
