using BusinessObjects.Models;


namespace Repositories.Interfaces
{
    public interface IClassRepository
    {
        List<Class> GetAllClasses();
        Class GetClassById(int classId);
        void AddClass(Class cls);
        void UpdateClass(Class cls);
        void DeleteClass(int classId);
    }
}
