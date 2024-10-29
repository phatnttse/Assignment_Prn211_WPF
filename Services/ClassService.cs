using Repositories.Interfaces;
using Repositories;
using Services.Interfaces;
using BusinessObjects.Models;

namespace Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository classRepository;

        public ClassService()
        {
            this.classRepository = new ClassRepository();
        }

        public void AddClass(Class cls) => classRepository.AddClass(cls);
        public void DeleteClass(int classId) => classRepository.DeleteClass(classId);
        public List<Class> GetAllClasses() => classRepository.GetAllClasses();
        public Class GetClassById(int classId) => classRepository.GetClassById(classId);
        public void UpdateClass(Class cls) => classRepository.UpdateClass(cls);

    }
}
