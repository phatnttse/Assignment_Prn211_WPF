using BusinessObjects.Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        List<User> GetUsersByRole(int roleId);
        User GetUserById(int userId);
        User GetUserByUserName(string userName);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}
