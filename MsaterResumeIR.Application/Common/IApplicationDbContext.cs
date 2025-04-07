using Microsoft.EntityFrameworkCore;
using MsaterResumeIR.Domain.Entities;

namespace MsaterResumeIR.Application.Common;

public interface IApplicationDbContext
{
    DbSet<Category> Category { get; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
