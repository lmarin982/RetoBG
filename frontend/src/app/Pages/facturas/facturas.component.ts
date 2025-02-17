import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FilterPipe } from '../../pipes/filter.pipe';
import { FacturaModel } from '../../interfaces/Factura';

@Component({
  selector: 'app-facturas',
  templateUrl: './facturas.component.html',
  styleUrls: ['./facturas.component.scss'],
  standalone: true,
  imports: [CommonModule, FormsModule, FilterPipe],
})
export class FacturasComponent implements OnInit {
  public filtroFactura: string = '';
  private api_url: string = '';

  constructor() { }
  facturas: FacturaModel[] = [/* 
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
   */];
  ngOnInit() { }

  ObtenerFacturas() {
    fetch(`${this.api_url}`).then(res => {
      if (!res.ok) throw new Error('Error en la peticion');
      return res.json();
    }).then(data => {
      this.facturas = data
    }).catch(err => {
      console.error('Error al obtener usuarios', err);
    })
  }

  editarFactura(venta: any) {
    fetch(`${this.api_url}`, { method: 'PUT', headers: { 'Content-Type': 'application/json', body: JSON.stringify(venta) } }).then(res => {
      if (!res.ok) throw new Error('Error en la peticion');
      return res.json();
    }).then(data => {
      alert(data);
    }).catch(err => {
      console.error('Error al obtener usuarios', err);
    })
    /* console.log('Editando venta:', venta); */
  }

  eliminarFactura(venta: any) {
    fetch(`${this.api_url}/${venta.id}`, { method: 'DELETE' }).then(res => {
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
