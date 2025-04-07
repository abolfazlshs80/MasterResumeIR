using Microsoft.EntityFrameworkCore;
using MsaterResumeIR.Application.Common;
using MsaterResumeIR.Domain.Entities;

namespace MsaterResumeIR.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<Category> Category { get; set; }
}
