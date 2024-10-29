

using BusinessObjects.Models;

namespace Repositories.Interfaces
{
    public interface IUserClassRepository
    {
        List<UserClass> GetAllUserClasses();
        UserClass GetUserClassById(int userClassId);
        UserClass GetUserClassByUserIdAndClassId(int userId, int classId);
        void AddUserClass(UserClass userClass);
        void UpdateUserClass(UserClass userClass);
        void DeleteUserClass(int userClassId);
    }
}
