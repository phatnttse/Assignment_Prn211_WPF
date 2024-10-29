using BusinessObjects.Models;
using DAO;
using Repositories.Interfaces;


namespace Repositories
{
    public class UserClassRepository : IUserClassRepository
    {
        public List<UserClass> GetAllUserClasses() => UserClassDAO.Instance.GetAllUserClasses();
        public UserClass GetUserClassById(int userClassId) => UserClassDAO.Instance.GetUserClassById(userClassId);
        public UserClass GetUserClassByUserIdAndClassId(int userId, int classId) => UserClassDAO.Instance.GetUserClassByUserIdAndClassId(userId, classId);
        public void AddUserClass(UserClass userClass) => UserClassDAO.Instance.AddUserClass(userClass);
        public void UpdateUserClass(UserClass userClass) => UserClassDAO.Instance.UpdateUserClass(userClass);
        public void DeleteUserClass(int userClassId) => UserClassDAO.Instance.DeleteUserClass(userClassId);

    }
}
