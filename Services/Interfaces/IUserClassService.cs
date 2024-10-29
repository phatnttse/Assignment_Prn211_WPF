
using BusinessObjects.Models;

namespace Services.Interfaces
{
    public interface IUserClassService
    {
        List<UserClass> GetAllUserClasses();
        UserClass GetUserClassById(int userClassId);
        UserClass GetUserClassByUserIdAndClassId(int userId, int classId);
        void AddUserClass(UserClass userClass);
        void UpdateUserClass(UserClass userClass);
        void DeleteUserClass(int userClassId);
    }
}
