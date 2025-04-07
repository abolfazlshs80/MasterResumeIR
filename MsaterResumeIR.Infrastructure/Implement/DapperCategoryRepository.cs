using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaterResumeIR.Infrastructure.Implement
{
    using Dapper;
    using MsaterResumeIR.Domain.Entities;
    using MsaterResumeIR.Domain.Interface;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public class DapperCategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public DapperCategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var sql = "SELECT * FROM Category WHERE CategoryId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var sql = "SELECT * FROM Category";
            return await _dbConnection.QueryAsync<Category>(sql);
        }

        public async Task AddAsync(Category entity, CancellationToken cancellationToken = default)
        {
            var sql = "INSERT INTO Category (Name) VALUES (@Name)";
            await _dbConnection.ExecuteAsync(sql, entity);
        }

        public async Task UpdateAsync(Category entity, CancellationToken cancellationToken = default)
        {
            var sql = "UPDATE Category SET Name = @Name WHERE CategoryId = @CategoryId";
            await _dbConnection.ExecuteAsync(sql, entity );
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var sql = "DELETE FROM Category WHERE CategoryId = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Category>> GetCategoryReportsAsync(CancellationToken cancellationToken = default)
        {
            var sql = @"
            SELECT c.CategoryId, c.Name, COUNT(p.ProductId) AS ProductCount
            FROM Category c
            LEFT JOIN Products p ON c.CategoryId = p.CategoryId
            GROUP BY c.CategoryId, c.Name";

            return await _dbConnection.QueryAsync<Category>(sql );
        }
    }
}
