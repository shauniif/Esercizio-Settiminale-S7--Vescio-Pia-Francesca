using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Create(UserViewModel entity);
        Task<User> Update(User entity);
        Task<User> Delete(int id);

        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int id);

        Task<User> Login(UserViewModel entity);

        Task<User> AddRoleToUser(int userId, string roleName);
        Task<User> RemoveRoleToUser(int userId, string roleName);


    }
}
