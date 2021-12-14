using Localiza.Frotas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.Frotas.Infra.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly LocalizaDbContext _context;
        public VeiculoRepository(LocalizaDbContext context)
        {
            _context = context;
        }
        public async Task Add(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Veiculo veiculo)
        {
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Veiculo>> GetAll(int pagina, int quantidade)
        {
            return await _context.Veiculos.OrderBy(v => v.Id).ToListAsync();
        }

        public async Task<Veiculo> GetbyId(Guid id)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == id);
            
        }

        public async Task Update(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
