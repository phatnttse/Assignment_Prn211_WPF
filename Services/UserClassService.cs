using Repositories.Interfaces;
using Repositories;
using Services.Interfaces;
using BusinessObjects.Models;

namespace Services
{
    public class UserClassService : IUserClassService
    {
        private readonly IUserClassRepository userClassRepository;

        public UserClassService()
        {
            this.userClassRepository = new UserClassRepository();
        }

        public void AddUserClass(UserClass userClass) => userClassRepository.AddUserClass(userClass);
        public void DeleteUserClass(int userClassId) => userClassRepository.DeleteUserClass(userClassId);
        public List<UserClass> GetAllUserClasses() => userClassRepository.GetAllUserClasses();
        public UserClass GetUserClassById(int userClassId) => userClassRepository.GetUserClassById(userClassId);
        public UserClass GetUserClassByUserIdAndClassId(int userId, int classId) => userClassRepository.GetUserClassByUserIdAndClassId(userId, classId);
        public void UpdateUserClass(UserClass userClass) => userClassRepository.UpdateUserClass(userClass);
    }
}