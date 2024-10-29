using BusinessObjects.Models;


namespace Repositories.Interfaces
{
    public interface IUserRepository
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
