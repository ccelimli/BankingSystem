using Domain.Entities;

namespace Application.Services.UserService;

public interface IUserService
{
    Task CheckUserExistById(int userId);
    Task<User> GetById(int id);
}
