using CashFlow_API.DAL.Entities;
using System.Diagnostics.Metrics;

namespace CashFlow_API.Domain.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<Persona>> GetPersonasAsync();
        Task<Persona> CreatePersonaAsync(Persona persona);
        Task<Persona> GetPersonaByIdAsync(long Cedula);
        Task<Persona> UpdatePersonaAsync(Persona persona);
        Task<Persona> DeletePersonaAsync(long Cedula);
    }
}
