using poryecto_finanzas.DTOs;

namespace poryecto_finanzas.Repositories
{
    public interface IUserRepositorie
    {
        Task<List<UserDTO>> GetUsers();

        Task<UserDTO> GetUserByEmail(string email);
    }
}
