﻿using Core.Entities;
using Core.Interfaces;
using Core.Spacefications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpacefication<T> spec)
        {
            return await ApplySpacification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpacefication<T> spec)
        {
            return await ApplySpacification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpacefication<T> spec)
        {
            return await ApplySpacification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpacification(ISpacefication<T> spec)
        {
            return SpacificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
