using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.User
{
    public interface IUserRepository
    {

        Task<UserModel> CreateAsync(UserRequest userRequest);
    }
}
