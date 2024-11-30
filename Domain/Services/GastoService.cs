using CashFlow_API.DAL;
using CashFlow_API.DAL.Entities;
using CashFlow_API.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CashFlow_API.Domain.Services
{
    public class GastoService : IGastoService
    {
        private readonly DataBaseContext _context;
        public GastoService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Gasto>> GetGastoAsync()
        {
            try
            {
                var gastos = await _context.Gastos.ToListAsync();
                return gastos;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<Gasto> GetGastoByIdAsync(Guid id)
        {
            try
            {
                var gasto = await _context.Gastos.FirstOrDefaultAsync(g => g.Id == id);
                return gasto;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<Gasto> GetGastoByReferenceAsync(string referencia)
        {
            try
            {
                var gasto = await _context.Gastos.FirstOrDefaultAsync(g => g.Referencia == referencia);
                return gasto;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<Gasto> CreateGastoAsync(Gasto gasto)
        {
            try
            {
                gasto.Id = Guid.NewGuid();
                gasto.CreatedDate = DateTime.Now;
                _context.Gastos.Add(gasto);
                await _context.SaveChangesAsync();
                return gasto;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<Gasto> UpdateGastoAsync(Gasto gasto)
        {
            try
            {
                gasto.ModifiedDate = DateTime.Now;
                _context.Gastos.Update(gasto);
                await _context.SaveChangesAsync();
                return gasto;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<Gasto> DeleteGastoByIdAsync(Guid id)
        {
            try
            {
                var gasto = await GetGastoByIdAsync(id);
                if (gasto == null)
                {
                    return null;
                }
                _context.Gastos.Remove(gasto);
                await _context.SaveChangesAsync();
                return gasto;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
        public async Task<Gasto> DeleteGastoByReferenceAsync(string referencia)
        {
            try
            {
                var gasto = await GetGastoByReferenceAsync(referencia);
                if (gasto == null)
                {
                    return null;
                }
                _context.Gastos.Remove(gasto);
                await _context.SaveChangesAsync();
                return gasto;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }        
    }
}
