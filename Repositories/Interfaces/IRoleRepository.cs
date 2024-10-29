

using BusinessObjects.Models;

namespace Repositories.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> GetAllRoles();
        Role GetRoleById(int roleId);
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int roleId);
    }
}
