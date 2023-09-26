using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_MVC___ProvaDjalma.Models;
using Projeto_MVC___ProvaDjalma.Models.Interface;

namespace Projeto_MVC___ProvaDjalma.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Cadastros> Cadastros { get; set; }

        

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            PreencheIStatusModificacao();
            return base.SaveChanges();
        }

        private void ModelStatusModificacao<TEntity>(EntityTypeBuilder<TEntity> entity) where TEntity : class,  IStatusModificacao
        {
            entity.HasQueryFilter(x => !x.Excluido);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            PreencheIStatusModificacao();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void PreencheIStatusModificacao()
        {

            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity != null
                        && typeof(IStatusModificacao).IsAssignableFrom(e.Entity.GetType())))
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Property("Excluido").CurrentValue = true;
                }
            }
        }
    }
}
