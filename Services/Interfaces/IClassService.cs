
using BusinessObjects.Models;

namespace Services.Interfaces
{
    public interface IClassService
    {
        List<Class> GetAllClasses();
        Class GetClassById(int classId);
        void AddClass(Class cls);
        void UpdateClass(Class cls);
        void DeleteClass(int classId);
    }
}
