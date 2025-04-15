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
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly UsersDbContext _context;

        public ReceitaRepository(UsersDbContext context){
            _context = context;
        }

        public async Task<Receitas?> GetByIdAsync(Guid Id, Guid UserId){
            return await _context.Receitas.FirstOrDefaultAsync(r => r.UserId == UserId && r.Id == Id);
        }

        public async Task<IEnumerable<Receitas>?> GetAllAsync(Guid UserId){
            return await _context.Receitas.Where(r => r.UserId == UserId).ToListAsync();
        }

        public async Task<Receitas> Add(Receitas receita){
            var result = await _context.Receitas.AddAsync(receita);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Receitas> Update(Receitas receita){
            var result = _context.Receitas.Update(receita);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Receitas> Delete(Receitas receita){
            var result = _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}