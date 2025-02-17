export interface FacturaModel {
  id: number;
  idCliente: number;
  idUsuario: number;
  fecha: string;
  formaDePago: string | null;
}
