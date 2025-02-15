using System;
using reto_bg.Domain.Types;

namespace reto_bg.Application.Contracts;

public interface IProductoRepository
{
    public Task<ProductoType> GetProductoAsync(int id);
    public Task<ICollection<ProductoType>> GetProductosAsync();
    public Task<bool> AddProductoAsync(ProductoType producto);
    public Task<bool> UpdateProductoAsync(ProductoType producto);
    public Task<bool> DeleteProductoAsync(int id);
}
