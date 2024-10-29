using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;
using BusinessObjects.Models;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService()
        {
            this.userRepository = new UserRepository();
        }

        public void AddUser(User user) => userRepository.AddUser(user);
        public void DeleteUser(int userId) => userRepository.DeleteUser(userId);
        public List<User> GetAllUsers() => userRepository.GetAllUsers();
        public List<User> GetUsersByRole(int roleId) => userRepository.GetUsersByRole(roleId);
        public User GetUserById(int userId) => userRepository.GetUserById(userId);
        public User GetUserByUserName(string userName) => userRepository.GetUserByUserName(userName);
        public void UpdateUser(User user) => userRepository.UpdateUser(user);

    }
}
