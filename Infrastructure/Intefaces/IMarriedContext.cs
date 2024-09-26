using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Intefaces;

public interface IMarriedContext
{
    public DbSet<Person> Person { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}