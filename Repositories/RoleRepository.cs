using BusinessObjects.Models;
using DAO;
using Repositories.Interfaces;


namespace Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public List<Role> GetAllRoles() => RoleDAO.Instance.GetAllRoles();
        public Role GetRoleById(int roleId) => RoleDAO.Instance.GetRoleById(roleId);
        public void AddRole(Role role) => RoleDAO.Instance.AddRole(role);
        public void UpdateRole(Role role) => RoleDAO.Instance.UpdateRole(role);
        public void DeleteRole(int roleId) => RoleDAO.Instance.DeleteRole(roleId);

    }
}
