using Core.Models;
using Infrastructure.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataBase;

public class MarriedContext : DbContext, IMarriedContext
{
    public MarriedContext(DbContextOptions<MarriedContext> options) : base(options)
    {
    }

    public DbSet<Person> Person { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
