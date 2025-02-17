import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FilterPipe } from '../../pipes/filter.pipe';
import {
  DatosGrafica,
  GraficaLinealComponent,
} from '../../shared/components/graficaLineal/graficaLineal.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  standalone: true,
  imports: [CommonModule, FormsModule, FilterPipe, GraficaLinealComponent],
})
export class HomeComponent implements OnInit {
  public filtroCliente: string = '';
  constructor() {}

  datosGrafica: DatosGrafica = {
    mes: [
      'Enero',
      'Febrero',
      'Marzo',
      'Abril',
      'Mayo',
      'Junio',
      'Julio',
      'Agosto',
      'Septiembre',
      'Octubre',
      'Noviembre',
      'Diciembre',
    ],
    valores: [
      8000, 10000, 15000, 5000, 5000, 8000, 6000, 15000, 7000, 11000, 20000,
      25000,
    ],
  };

  ventas = [
    {
      fecha: '2023-01-01',
      cliente: 'Cliente 1',
      vendedor: 'Vendedor 1',
      estado: 'Completado',
      total: 100,
    },
    {
      fecha: '2023-01-02',
      cliente: 'Cliente 2',
      vendedor: 'Vendedor 2',
      estado: 'Pendiente',
      total: 200,
    },
    {
      fecha: '2023-01-03',
      cliente: 'Cliente 3',
      vendedor: 'Vendedor 3',
      estado: 'Cancelado',
      total: 300,
    },
  ];
  ngOnInit() {}
  get filteredVentas() {
    return this.ventas.filter((venta) =>
      venta.cliente.toLowerCase().includes(this.filtroCliente.toLowerCase())
    );
  }
  editarVenta(venta: any) {
    console.log('Editando venta:', venta);
  }

  eliminarVenta(venta: any) {
    console.log('Eliminando venta:', venta);
  }
}
