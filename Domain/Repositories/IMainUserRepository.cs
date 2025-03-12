using Domain.Entities.User;

namespace Domain.Repositories
{
    public interface IMainUserRepository
    {
        Task<MainUser?> GetUserByIdAsync(string id);
    }
}
