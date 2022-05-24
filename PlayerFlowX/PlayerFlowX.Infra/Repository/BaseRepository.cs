using Microsoft.EntityFrameworkCore;
using PlayerFlowX.Business.Interfaces.RepositoryContract;
using PlayerFlowX.Infra.EFCore.Context;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlayerFlowX.Infra.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseCommandsRepository<TEntity, TKey> 
        where TEntity : class


    {
        private ApplicationDbContext _dbContext;
        protected DbSet<TEntity> Dbset => this._dbContext.Set<TEntity>();

        public BaseRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public bool HaveObjectInDb(Expression<Func<TEntity, bool>> where) => this.Dbset.AsNoTracking().Any(where);


        protected async Task<bool> SaveDbAsync()
        {
            return (await this._dbContext.SaveChangesAsync()) > 0;
        }

        public async Task<bool> SaveAsync(TEntity entity)
        {
            this.Dbset.Add(entity);
            this._dbContext.Entry(entity).State = EntityState.Added;
            return await SaveDbAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            if (this._dbContext.Entry(entity).State == EntityState.Detached)
                this.Dbset.Attach(entity);


            this._dbContext.Entry(entity).State = EntityState.Modified;
            return await SaveDbAsync();
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var entity = await this.Dbset.FindAsync(id);

            if (this._dbContext.Entry(entity).State == EntityState.Detached)
            {
                this.Dbset.Attach(entity);
            }

            this.Dbset.Remove(entity);
            return await SaveDbAsync();
        }

        public void Dispose() => this._dbContext.Dispose();

        
    }
}
