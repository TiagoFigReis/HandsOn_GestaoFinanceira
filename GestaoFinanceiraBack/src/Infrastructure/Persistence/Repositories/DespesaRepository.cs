using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Core.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly UsersDbContext _context;

        public DespesaRepository(UsersDbContext context){
            _context = context;
        }

        public async Task<Despesas?> GetByIdAsync(Guid Id, Guid UserId){
            return await _context.Despesas.FirstOrDefaultAsync(r => r.UserId == UserId && r.Id == Id);
        }

        public async Task<IEnumerable<Despesas>?> GetAllAsync(Guid UserId){
            return await _context.Despesas.Where(r => r.UserId == UserId).ToListAsync();
        }

        public async Task<Despesas> Add(Despesas despesa){
            var result = await _context.Despesas.AddAsync(despesa);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Despesas> Update(Despesas despesa){
            var result = _context.Despesas.Update(despesa);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Despesas> Delete(Despesas despesa){
            var result = _context.Despesas.Remove(despesa);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}