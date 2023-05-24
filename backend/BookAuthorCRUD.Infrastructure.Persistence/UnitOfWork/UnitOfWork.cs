using BookAuthorCRUD.Domain.Common;
using BookAuthorCRUD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorCRUD.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context) { 
        
            _context = context;

        }

        public Task SaveChangesAsync(CancellationToken cancellationToken= default)
        {
            UpdateAuditableEntities();
            return _context.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditableEntities()
        {
            foreach (var entry in _context.ChangeTracker.Entries<AuditableBaseEntity>())
            {
                _ = entry.State switch
                {
                    EntityState.Modified => () => entry.Entity.UpdatedAt = DateTime.UtcNow,
                    EntityState.Added => () => entry.Entity.CreatedAt = DateTime.UtcNow,

                    _ => new Action(() => { })
                };
            }
        }
    }
}
