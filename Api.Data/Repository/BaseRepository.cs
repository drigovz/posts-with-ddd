using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"\nAn error ocurred when try to Get all entities: {ex.Message}\n");
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"\nAn error ocurred when try to Get entity by Id: {ex.Message}\n");
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"\nAn error ocurred when try to Add a new entity: {ex.Message}\n");
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await GetByIdAsync(entity.Id);
                if (result == null)
                    return null;

                entity.CreatedAt = result.CreatedAt;
                entity.UpdatedAt = DateTime.UtcNow;
                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"\nAn error ocurred when try to Update entity: {ex.Message}\n");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                if (result == null)
                    return false;

                _context.Set<T>().Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"\nAn error ocurred when try to Delete entity: {ex.Message}\n");
            }
        }
    }
}