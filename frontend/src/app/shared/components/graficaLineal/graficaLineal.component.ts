import { Component, Input, OnInit } from '@angular/core';
import { Chart } from 'chart.js/auto';

export interface DatosGrafica {
  mes: string[];
  valores: number[];
}

@Component({
  selector: 'app-graficaLineal',
  templateUrl: './graficaLineal.component.html',
  styleUrls: ['./graficaLineal.component.scss'],
})
export class GraficaLinealComponent implements OnInit {
  @Input() datos: DatosGrafica = {} as DatosGrafica;
  public chart: Chart | undefined;
  public delayed: any;
  constructor() {}

  ngOnInit() {
    this.chart = new Chart('chart', {
      type: 'line',
      data: {
        labels: this.datos.mes,
        datasets: [
          {
            label: 'Ventas 2024',
            data: this.datos.valores,
            borderColor: 'rgba(0,128,0,0.3)',
            backgroundColor: 'rgba(0,128,0,0.3)',
            fill: false,
            tension: 0.2,
          },
        ],
      },
      //agregar delay a la animacion
      options: {
        responsive: true,
        maintainAspectRatio: false,
        animation: {
          onComplete: () => {
            if (this.delayed) {
              clearTimeout(this.delayed);
            }
            this.delayed = setTimeout(() => {
              this.delayed = null;
              this.chart?.update();
            }, 2000);
          },
        },
      },

      //aqui acaba el componente
    });
  }
}
