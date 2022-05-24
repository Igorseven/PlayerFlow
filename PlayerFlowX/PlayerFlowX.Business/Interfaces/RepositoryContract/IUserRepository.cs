using PlayerFlowX.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlayerFlowX.Business.Interfaces.RepositoryContract
{
    public interface IUserRepository : IDisposable
    {
        Task<bool> SaveAsync(User entity);
        Task<bool> UpdateAsync(User entity);
        Task<bool> DeleteAsync(Guid id);
        bool HaveObjectInDb(Expression<Func<User, bool>> where);

        Task<IEnumerable<User>> FindUsersAsync();
        Task<User> FindByAsync(Guid id);
        Task<User> FindByUserNameAsync(string name);

    }
}
