export const api_url: ApiConfig = {
    cliente: 'http://localhost:3001/api/Cliente',
    factura: 'http://localhost:3001/api/Factura',
    Producto: 'http://localhost:3001/api/Producto',
    usuario: 'http://localhost:3001/api/Usuario'
}

interface ApiConfig {
    cliente: string;
    usuario: string;
    factura: string;
    Producto: string;
}