using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Create(UserViewModel entity);
        Task<User> Update(User entity);
        Task<User> Delete(User entity);

        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int id);

        Task<User> Login(UserViewModel entity);


    }
}
