using BusinessObjects.Models;
using DAO;
using Repositories.Interfaces;


namespace Repositories
{
    public class ClassRepository : IClassRepository
    {
        public List<Class> GetAllClasses() => ClassDAO.Instance.GetAllClasses();
        public Class GetClassById(int classId) => ClassDAO.Instance.GetClassById(classId);
        public void AddClass(Class cls) => ClassDAO.Instance.AddClass(cls);
        public void UpdateClass(Class cls) => ClassDAO.Instance.UpdateClass(cls);
        public void DeleteClass(int classId) => ClassDAO.Instance.DeleteClass(classId);
    }
}
