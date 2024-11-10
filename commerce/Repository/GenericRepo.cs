using commerce.DTOs;
using commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace commerce.Repository
{
    public class GenericRepo<T> where T: class
    {
        private readonly CommerceDbContext _context;
        public GenericRepo(CommerceDbContext context)
        {
            _context = context;
        }
        public async Task<T> GetById(int id)
        {
               return await _context.Set<T>().FindAsync(id);

        }
        public async Task<List<T>> GetAll()
        {
            
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T Tmodel)
        {
            await _context.Set<T>().AddAsync(Tmodel);

            return Tmodel;
        }
    }
}
