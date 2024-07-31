using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces
{
    public interface IRoleService
    {
        Task<Role> Create(Role entity);
        Task<Role> Update(Role entity);
        Task<Role> Delete(int id);

        Task<Role> Read(int id);

        Task<IEnumerable<Role>> GetAll();
    }
}
