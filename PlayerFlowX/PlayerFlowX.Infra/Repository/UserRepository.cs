using Microsoft.EntityFrameworkCore;
using PlayerFlowX.Business.Interfaces.RepositoryContract;
using PlayerFlowX.Domain.Identity;
using PlayerFlowX.Infra.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlayerFlowX.Infra.Repository
{
    public class UserRepository :  IUserRepository
    {
        private ApplicationDbContext _context;
        private DbSet<User> Dbset => this._context.Set<User>();

        public UserRepository(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }

        private async Task<bool> SaveDbAsync() => (await this._context.SaveChangesAsync()) > 0;

        public async Task<User> FindByAsync(Guid id) => await this.Dbset.FindAsync(id);

        public async Task<IEnumerable<User>> FindUsersAsync() => await this.Dbset.ToListAsync();

        public async Task<User> FindByUserNameAsync(string name) => await this.Dbset
            .SingleOrDefaultAsync(u => u.UserName == name.ToLower());

        public void Dispose() => this._context.Dispose();

        public bool HaveObjectInDb(Expression<Func<User, bool>> where) => this.Dbset.AsNoTracking().Any(where);

        public async Task<bool> SaveAsync(User entity)
        {
            this.Dbset.Add(entity);
            this._context.Entry(entity).State = EntityState.Added;
            return await SaveDbAsync();
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            return await SaveDbAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await this._context.FindAsync<User>(id);
            if (this._context.Entry(user).State == EntityState.Detached)
                this.Dbset.Attach(user);

            this.Dbset.Remove(user);
            return await SaveDbAsync();
        }
    }
}
