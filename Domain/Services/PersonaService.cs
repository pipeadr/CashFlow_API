using CashFlow_API.DAL;
using CashFlow_API.DAL.Entities;
using CashFlow_API.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CashFlow_API.Domain.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly DataBaseContext _context;
        public PersonaService(DataBaseContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Persona>> GetPersonasAsync()
        {
            return await _context.Personas.ToListAsync();
        }
        public async Task<Persona> GetPersonaByIdAsync(long Cedula)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.Cedula == Cedula);
            return persona;
        }
        public async Task<Persona> CreatePersonaAsync(Persona persona)
        {
            try
            {
                persona.Id = Guid.NewGuid();
                persona.CreatedDate = DateTime.Now;
                _context.Personas.Add(persona);
                await _context.SaveChangesAsync();
                return persona;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
        public async Task<Persona> UpdatePersonaAsync(Persona persona)
        {
            try
            {

                persona.ModifiedDate = DateTime.Now;
                _context.Personas.Update(persona);
                await _context.SaveChangesAsync();
                return persona;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
        public async Task<Persona> DeletePersonaAsync(long Cedula)
        {
            try
            {
                var persona = await GetPersonaByIdAsync(Cedula);
                if (persona == null)
                {
                    return null;
                }
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
                return persona;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
      
    }
}
