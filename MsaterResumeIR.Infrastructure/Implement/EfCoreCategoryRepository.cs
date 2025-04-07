using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaterResumeIR.Infrastructure.Implement
{
    using Microsoft.EntityFrameworkCore;
    using MsaterResumeIR.Domain.Entities;
    using MsaterResumeIR.Domain.Interface;
    using MsaterResumeIR.Infrastructure.Context;

    public class EfCoreCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EfCoreCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Category.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Category.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Category entity, CancellationToken cancellationToken = default)
        {
            await _context.Category.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Category entity, CancellationToken cancellationToken = default)
        {
            _context.Category.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var category = await GetByIdAsync(id, cancellationToken);
            if (category != null)
            {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<Category>> GetCategoryReportsAsync(CancellationToken cancellationToken = default)
        {
            // این متد می‌تواند با Dapper پیاده‌سازی شود.
            throw new NotImplementedException("Use Dapper for complex queries.");
        }
    }
}
