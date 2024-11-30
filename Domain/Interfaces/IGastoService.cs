using CashFlow_API.DAL.Entities;

namespace CashFlow_API.Domain.Interfaces
{
    public interface IGastoService
    {
        Task<IEnumerable<Gasto>> GetGastoAsync();
        Task<Gasto> GetGastoByIdAsync(Guid id);
        Task<Gasto> GetGastoByReferenceAsync(string referencia);
        Task<Gasto> CreateGastoAsync(Gasto gasto);
        Task<Gasto> UpdateGastoAsync(Gasto gasto);
        Task<Gasto> DeleteGastoByIdAsync(Guid id);
        Task<Gasto> DeleteGastoByReferenceAsync(string referencia);
    }
}
