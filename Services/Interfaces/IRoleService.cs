
using BusinessObjects.Models;

namespace Services.Interfaces
{
    public interface IRoleService
    {
        List<Role> GetAllRoles();
        Role GetRoleById(int roleId);
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int roleId);
    }
}
