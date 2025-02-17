import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FilterPipe } from '../../pipes/filter.pipe';

@Component({
  selector: 'app-facturas',
  templateUrl: './facturas.component.html',
  styleUrls: ['./facturas.component.scss'],
  standalone: true,
  imports: [CommonModule, FormsModule, FilterPipe],
})
export class FacturasComponent implements OnInit {
  public filtroFactura: string = '';
  constructor() {}
  facturas = [
    {
      id: 1,
      idCliente: 1,
      idUsuario: 1,
      fecha: '2023-01-01',
      formaDePago: 'Tarjeta de Crédito',
    },
    {
      id: 2,
      idCliente: 2,
      idUsuario: 1,
      fecha: '2023-02-01',
      formaDePago: 'Efectivo',
    },
    {
      id: 3,
      idCliente: 3,
      idUsuario: 2,
      fecha: '2023-03-01',
      formaDePago: null,
    },
  ];
  ngOnInit() {}

  editarFactura(venta: any) {
    console.log('Editando venta:', venta);
  }

  eliminarFactura(venta: any) {
    console.log('Eliminando venta:', venta);
  }
}
