using DAO;
using Repositories.Interfaces;
using BusinessObjects.Models;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAllUsers() => UserDAO.Instance.GetAllUsers();
        public List<User> GetUsersByRole(int roleId) => UserDAO.Instance.GetUsersByRole(roleId);
        public User GetUserById(int userId) => UserDAO.Instance.GetUserById(userId);
        public User GetUserByUserName(string userName) => UserDAO.Instance.GetUserByUsername(userName);
        public void AddUser(User user) => UserDAO.Instance.AddUser(user);
        public void UpdateUser(User user) => UserDAO.Instance.UpdateUser(user);
        public void DeleteUser(int userId) => UserDAO.Instance.DeleteUser(userId);

    }
}
